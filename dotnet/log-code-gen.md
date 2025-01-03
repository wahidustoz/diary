# Improve logging performance with code generation

[Avvalgi postda](log-levels.md) **logging levels** __(logging darajalari)__ni tushintirib bergan edim. Bugun logging tezligini oshirish uchun taklif etilayotgan yangi feature **Logging Code Generation** haqida gaplashamiz.

Code generation bu yangilik emas. Avvaldan Blazor, Razor va shunga o'xshash engine'lar compile vaqtida kod generate qiladi. **`.NET 6`** versiyasida olib kirilgan yangi attribute `LoggingMessageAttribute` bo'lsa aynan Logging samaradorligini oshirish uchun compile vaqtida reusable logging funksiyalari yaratish uchun ishlatiladi.
Ushbu qo'shimcha haqida batafsil [bu yerda](https://learn.microsoft.com/en-us/dotnet/core/extensions/logger-message-generator) o'qishingiz mumkin.

Logging Code generation ishlatish uchun `static partial` klas yaratib uni ichida `partial` kalit so'zi orqali methodlar elon qilishingiz kerak. Bu methodlarni tanasi compile vaqtida .NET tomonidan yaratiladi va qayta ishlatiladi.
[!code-csharp[](snippets/log-code-gen-1.cs)]
> E'lon qilingan funksiyani tanasi compile vaqtida .NET tomonidan yaratiladi.

Keyin ushbu logging methodni quyidagicha ishlatsa bo'ladi.
[!code-csharp[](snippets/log-code-gen-2.cs?highlight=11)]


> [!NOTE]
> Yuqorida elon qilingan `LogValidationStarted` funksiyasi `ILogger` interface ustiga qurilgani uchun, bu methodni istalgan `ILogger` interface obyektida ishlatsa bo'ladi. 
> Agar sizga maxsus bitta generic `ILogger<T>` ustida ishlaydigan mehod kerak bo'lsa, `this ILogger<T>` shaklida elon qilishingiz kerak. Misol uchun quyidagi kodga qarang :eyes:


[!code-csharp[](snippets/log-code-gen-3.cs?highlight=8)]

--- 

[!INCLUDE [<author>](../authors/wahid_abduhakimov.html)]
