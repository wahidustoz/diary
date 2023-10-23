# Task yoki ValueTask?

`Task` va uning jenerik sherigi `Task<TResult>` klasi ancha vaqtlardan beri bor va har bir .NETchi asinxron dasturlash uchun uni ishlatib ko’rgan. **.NET Core 2.0**dan boshlab yangi klas `ValueTask` va `ValueTask<TResult>` olib kirildi. Ho’sh siz ulardan qaysi birini ishlatishingiz kerak?

Qisqa qilib aytganda, agarda siz kutubxona yozayotgan bo’lsangiz va shu kutubxona xotirani va resurslarni  judayam kam sarflashi zarur bo’lgan joylarda ishlatilsa, siz `ValueTask` haqida bosh qotirsangiz arziydi. Lekin `ValueTask` ishlatishda judayam extiyotkor bo’lish kerak. Odatiy kunlik ishlarda esa **Senior** darajada bo’lmagan dasturchilar `Task` klasi ishlatgani ma’qul.

Ushbu postni oxirigacha o’qib tushinib olganingizdan keyin darajangizdan qatiy nazar `ValueTask` va `Task`ni qayerda va qanday ishlatishni tushinib olasiz.

## `Task`/`Task<TResult>`

`Task` klasining vaziflari ko’p. Qisqa qilib aytganda u uzoq vaqt davom etadigan ish qaytaradigan ma’lumotni o’rash uchun **wrapper** sifatida ishlatiladi va **promise** ya’ni *va’da* deyiladi. Qaytarilgan `Task` *obyekt*ini hohlagan vaqtda `await` qilib kutib turgan holda natijasini olsa bo’ladi. Bundan tashqari shu *obyekt*ni hohlagancha qayta-qayta yoki parallel bir nechta **thread**da `await` qilsa ham bir xil natija qaytaradi. Bu judaham kuchli yechim!

```csharp
async Task<int> GetNaturalGasPriceInUsdAsync()
{
    await Task.Delay(1000);

    return 9; 
}

var uzbekNaturalGasPrice = GetNaturalGasPriceInUsdAsync();
var price = await uzbekNaturalGasPrice;
var price2 = await uzbekNaturalGasPrice;
```

Yuqoridagi kodda ko’rinib turibdiki bitta `Task` obyektini bir necha marta `await` qilish mumkin va u bir xil natija qaytaradi.

## Muammo

Unda muammo nimada? Gap shundaki, `Task` va `Task<TResult>` klas tiplar bo’lib har safar asinxron funksiya chaqirilganda `Task` yoki `Task<TResult>` **allocate** (*xotirani o’zlashtirish*) qilib qaytarishga to’g’ri keladi. Hullas, har safar funksiya chaqirilganda yangi instance yaratib qaytarish dastur tezligi va xotira samaradorligiga sezilarli ta’sir qiladi. 

## `Runtime`dagi yechimlar

Ko’p hollarda asinxron funksiyalar sodda bo’ladi va ularni bir marta await orqali chaqirish kifoya bo’ladi.

```csharp
...
await SendEmailAsync(email, cancellationToken);
...
```

Bundan tashqari, ko’p hollarda asinxron funksiya ham ishini sinxron tugatadi ya’ni quyidagi misoldagidek ma’lum shartlar bajarilsagina asinxron ish bajariladi yo’qsa funksiya ishini sinxron tugatib Task qaytaradi. 

```csharp
public async Task SendEmailAsync(Email email, CancellationToken cancellationToken = default)
{
		if(email is not null)
				await client.SendEmailAsync(email, cancellationToken);

		logger.LogInformation("Email not sent!");
}
```

Ushbu koddan tushinish mumkinki ba’zi hollarda funksiya hech qanday asinxron ish bajarilmaydi. 

Bunday holatlar juda ham ko’p takrorlangani uchun **.NET Runtime** o’zi `Task`ning hech qanday asinxron ish bajarilmaganda qaytariladigan nusxasini **Cache** qilib oladi va qayta-qayta ishlataveradi. Bu o’sha biz bilgan `Task.CompletedTask` **obyekti**. Yuqoridagi kodda agar **email** `null` bo’lsa **Runtime** o’zi `Task.CompletedTask`ni **cache**dan olib qaytaradi. Agar asinxron ish bajarilsa, yangi `Task` **obyekti allocate** qilib qaytariladi.

Yana bir misolga qarang. Bir `Task<bool>` qaytaradigan funksiya bor. Bu funksiyada 3 xil holat bor:

- darxol sinxron `true` qaytaradi
- darxol sinxron `false` qaytaradi
- asinxron ravishda uzoq vaqtda true yoki false qaytaradi.

Dastlabki ikki holatda `Task<bool>`dan yangi obyekt allocate qilib qaytarish shart emas. 2 ta dona qiymat bo’lgani uchun Runtime ularni allaqachon Cache saqlab qo’ygan bo’ladi va o’shalarni qaytaradi. Ya’ni yangi xotira allocate qilinmaydi.  Agar funksiya asinxron ish bajarsa, majburan `Task<bool>` obyekti allocate qilinadi. Quyidagi **snippet** shuni ko’rsatadi.

```csharp
public async Task<bool> ShouldSendEmailAsync(User user, CancellationToken cancellationToken = default)
{
    if(user is null)
            return false;

    if(user.IsNew())
            return true;

    return await IsNotAdminAsync()
}
```

Lekin hamma narsani ham **Cache** qilish practical yechim emas. Masalan, `Task<int>` qaytaradigan funksiyani hamma bo’lishi mumkin bo’lgan natijalarni **Cache**da saqlash Gigabaytlab xotira talab qiladi.

Ko’plab kutibxonalar shunday **Cache** texnikasidan foydalanib yangi obyektlar yaratilishini oldini olishadi. Masalan, `MemoryStream.ReadAsync` funksiyadi `Task<int>` obyekti orqali nechta bayt o’qilganini qaytaradi. Bu funksiya ko’pincha bir xil son qaytargani uchuni ichkarida birinchi qaytarilgan `Task<int>` obyekti **Cache** qilinadi. Keyingi safar chaqirilganda, agar yana o’shancha bayt o’qigan bo’lsa eski **Cache** qilingan obyekt qaytariladi. Yo’qsa `Task.FromResult` ishlatib yangi obyekt yaratiladi.

> *Bu funksiya .NET yangi versiyalarida `ValueTask<int>` qaytaradigan qilib update qilingan.*
> 

## `ValueTask<TResult>`

Yuqoridagi yechimni yanada takomillashtirish uchun **.NET Core 2.0**dan boshlab `ValueTask<TResult>`  **struct** tanishtirildi. U asinxon funksiyalardan qaytariladi va `TResult` yoki `Task<TResult>` uchun **wrapper** vazifasini bajaradi. Agar asinxron funksiya muvaffaqiyatli **sinxron** yakunlansa, `ValueTask<TResult>` **struct**i `TResult` ga *initialize* qilib qaytarialdi. Hech qanday *allocation* bo’lmaydi. Agar asinxron yakunlansa yoki qandaydir exception sodir bo’lsa, yangi `Task<TResult>` obyekti **allocate** qilib `ValueTask<TResult>`ga o’rab qaytariladi.

Buning yordamida yuqorida keltirilgan `MemoryStream.ReadBytes` funksiyasi quyidagicha takomillashtirildi. Endi hech qanday **Cache** ishlatilmaydi.

```csharp
public override ValueTask<int> ReadAsync(byte[] buffer, int offset, int count)
{
    try
    {
        int bytesRead = Read(buffer, offset, count);
        return new ValueTask<int>(bytesRead);
    }
    catch (Exception e)
    {
        return new ValueTask<int>(Task.FromException<int>(e));
    }
}
```

## Muhim narsa qolib ketyapti

`await` dasturlash yo’lining eng muhim xususiyatlaridan biri bu asinxron operatsiya yakunlanganda chaqirish imkonini beruvchi **callback** method bilan ta’minlash. Ya’ni `Task`/`Task<TResult>` qaytaradigan asinxron funksiyalarga ish tugatilganda chaqiriladigan **callback** method bersangiz bo’ladi.

```csharp
async Task<ZipArchive> CreateZipArchiveFromCloudFiles()
{
    var files await DownloadAllFilesToTempFolderAsync();
    return await CreateZipAsync(files);  
}

var zipArchive = await CreateZipArchiveFromCloudFiles()
	.ContinueWith(async (task) =>
	{
			await CleanupTempFolderAsync();
	});
```

Buni amalga oshirish uchun xotirada shu operatsiyani aks ettiruvchi obyekt saqlanishi kerak va u orqali *callback method* chaqirilishi kerak. Shu hususiyatni ta’minlash uchun **.NET Core 2.1**dan boshlab `IValueTaskSource<TResult>` interface tanishtirildi. Bu interface asinxron operatsiya holati haqida ma’lumot saqlaydi va **OnCompleted** methodi orqali unga yuqoridagidan *callback method* bersa bo’aldi. 

> `*IValueTaskSource<TResult>` haqida keyingi postlarda.*
> 

Endi `ValueTask<TResult>` va `ValueTask` **struct**lari birgalikda asinxron funsiyalarni har qanday holatda ham hech qanday hotira **allocate** qilmasdan natija qaytarish imkonini beradi. 

## ValueTask ishlatishdagi havf

`ValueTask` va `ValueTask<TResult>` qisqa qilib aytganda oddiy holatlarda bir marta await qilib ishlatiladigan **Task**lar uchun chiqarilgan. Quyidagi holatlarda hech qachon `ValueTask` / `ValueTask<TResult>` ishlatmaslik kerak.

- **`ValueTask` / `ValueTask<TResult>`** ni bir martadan ortiq `await` qilish. `ValueTask<TResult>` ichidagi `TResult` **obyekti** GC tomonidan **recycle** qilib yuborilgan bo’lishi yoki boshqa operatsiya tomonidan ishlatilayotgan bo’lishi mumkin
- **`ValueTask` / `ValueTask<TResult>`**ni bir vaqta bir nechta **thread**dan`await` qilish. Yuqoridagiday `TResult` obyekti bitta thread ishini tugatgach recycle qilib yuborilgan bo’lishi mumkin.
- Operatsiya yakunlanmasidan avval `.GetAwaiter().GetResult()` funksiyasi orqali blok qilib natijani kutish. `IValueTaskSource` va `IValueTaskSource<TResult>` interfacelari blok qilish imkoniyatini bermaydi.

Agar sizga yuqoridagi imkoniyatlar chindan ham zarur bo’lsa, `.AsTask()` methodi orqali `ValueTask`/`ValueTask<TResult>` larni **Task**ga aylantirib olsangiz bo’ladi.

> **Ushbu maqolada qandaydir xatolik topsangiz habar bering.**
>