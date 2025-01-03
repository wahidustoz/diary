## C# 12 :astonished:

Ushbu qismda qismda **C# 12**dagi eng :cool: *feature*larni ko'rib chiqamiz.

<br/>

## :star: Primary Constructor
`class` va `struct` tiplarini elon qilishda bira to'la endi *asosiy konstruktor* berib ketsa bo'ladi. Primary Constructor orqali yuborilgan obyektlar klass hududi bo'ylab ko'rinadi. 

> [!TIP]
> Primary constructor orqali yuborilgan obyektlar `class` **member**i emas aksincha parametr ekanini yoddan chiqarmaslik kerak. Ularni `this` kalit so'zi orqali chaqirib bo'lmaydi.

`struct` misolida.
[!code-csharp[](snippets/primary-constructor.cs#L2-L6)]

ota `class`ga ma'lumot uzatish.
[!code-csharp[](snippets/primary-constructor.cs#L8-L12)]

Va eng keraklisi *dependency injection*.
[!code-csharp[](snippets/primary-constructor.cs#L14-L26)]


<br/>

## :bulb: Collection Expressions
Endi to'plamlarni e'lon qilishda `new` kalit so'zini ishlatishni hojati yo'q :astonished:.

```csharp
int[] sonlar = [1, 2, 3, 4, 5];
List<string> ismlar = ["Ali", "Vali", "Hasan"];

double[] qator1 = [1, 2, 3];
double[] qator2 = [4, 5, 6];

// ko'p o'lchamli array yasash
double[][] jadval = [qator1, qator2, [7, 8, 9]];
```
<br/>

## :bomb: Spead Operator
Agar yuqoridagilari hali *miyyangizni portlatmagan* bo'lsa unda bunisiga qarang. 
Spread Operator `..` yordami mavjud to'plamlarni yangi to'plamga osonlik bilan qo'shing!

```csharp
string[] qizlar = ["Madina", "Hadicha", "Aisha"];
string[] yigitlar = ["Umar", "Ali", "Abubakr"];

string[] hamma = ["Wahid", ..yigitlar, ..qizlar];
// hamma = ["Wahid", "Umar", "Ali", "Abubakr", "Madina", "Hadicha", "Aisha"]
```

<br/>

## :stars: Default Lambda parameters
*lambda expression* elon qilishda endi uning parametrlariga **default** qiymatlarni berib ketsa bo'ladi.
```csharp
var yuza = (int a, int? b = null) => a * (b  ?? a);

Console.WriteLine(yuza(5));     // 25
Console.WriteLine(yuza(5, 6));  // 30
```

Bu yangi *feature* eng ko'p ishlatilishi kutilyapkan yana bir misol.
```csharp
app.MapGet("/users", async (IUserService service, int? page = 1, int? pageSize = 50) => { });
```

> [!TIP]
> Yuqorida *lambda expression* yangi imkoniyatidan foydalanib Pagination uchun default qiymatlar berib ketilgan.

---

[!INCLUDE [<author>](../authors/wahid_abduhakimov.html)]