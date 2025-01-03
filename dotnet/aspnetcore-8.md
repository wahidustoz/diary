# ASP.NET Core 8.0

ASP.NET Core nima ekanini yoddan chiqarganlar uchun eslatib o'taman, bu .NET Frameworkni asosan web texnologiyalari uchun javobgar qismi. 
ASP.NET Core 8 web va server texnologiyalari samaradorligini oshiradigan *minglab* performance improvement va yangi *feature*lar taqdim etdi.


## Blazor :fire:
.NET 8 versiyasidan boshlab Blazor endi to'laqonli Web UI frameworkga aylandi. U orqali sayt kontentlarini page yoki component levelida qayta render qilsa bo'ladi.

Blazor avval 2 xil versiyaga ega edi.
- Server 
    - UI elementlari serverda render qilinib kerakli vaqtda SignalR orqali o'zgargan elementlargina klientga yuboriladi.
    - bu birinchi parta saytni tortishda juda tez lekin juda katta server resurslari talab qiladi
- WASM 
    - UI elementlari to'liqligicha klient brauzerida render bo'ladi.
    - birinchi marta saytni tortib olishga uzoq vaqt ketadi. 
    - serverdagi havfsizlik va boshqa server imkoniyatlari mavjud emas

Blazor app yasashdan avval 2ta tanlovdan birini tanlashga to'g'ri kelar edi va butun sayt bo'ylab yoki Server yoki WASM rejimda ishlar edi.

:loudspeaker: Endi Blazor render turini global sayt bo'yicha emas Page/Component levelida boshqarsa bo'ladi. 

Blazorni yangi Hybrid vesiyasida istalgan *Component* yoki *Page*ni server/wasm render bo'lishini boshqarsa bo'ladi. Bu orqali saytni birinchi marta tortib olish yorug'lik tezligida bo'ladi va unda keyin barcha renderin brauzerda WASM usulida amalga oshiriladi.

Bundan tashqari Blazorda yana yuzlab yangiliklar bor. Ularni [bu yerda](https://youtu.be/YwZdtLEtROA?si=EP-IJT32j9kvvDJo) o'qib oling.

:movie_camera: Batafsil [mana bu yerda](https://youtu.be/YwZdtLEtROA?si=EP-IJT32j9kvvDJo) 2X tezlikda ko'rib oling!

---
<br/>

## Minimal API :wink:
**.NET 8**dagi qo'shimchalarning ko'p qismi **Native AOT** va **Source Generator**lar bilan bog'liq. Ular compile time vaqtida kerakli kodlarni generate qiladi va bu orqali runtime performance sezilarli oshiriladi.

#### Form binding
Avvalgi versiyalarida `IFormFile` va `IFormCollection` orqali form elementlariga erishish imkoni bor edi. Lekin **MVC Controller**lar kabi `[FromForm]` attribute orqali form elementlarini Model objectga bog'lashni iloji yo'q edi. **.NET 8 Minimal API** endi bu ishni qila oladi.
```csharp
app.MapPost("/register", async([FromForm] RegisterModel model) =>
{
    // register logic
});
```

[Mana bu post](https://andrewlock.net/exploring-the-dotnet-8-preview-form-binding-in-minimal-apis/)da bu haqida batafsil!

### Native AOT Support
Native AOT orqali publish qilingan dasturlarni hajmi juda kichi bo'ladi, ular juda tez ishga tushadi va juda ham kam RAM talab qiladi.

[Bu yerda](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/native-aot?view=aspnetcore-8.0) batafsil o'qing!

--- 

[!INCLUDE [<author>](../authors/wahid_abduhakimov.html)]