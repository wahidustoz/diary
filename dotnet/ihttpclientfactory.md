# IHttpClientFactory in .NET

Bugungi maqolada `IHttpClientFactory` interface’i bilan qanday qilib `HttpClient` ochishni ko’rib chiqamiz. Buni amalga oshirishda bizga `Dependency Injection (DI)` yordamga keladi. Aslida `IHttpClientFactory` .NET Core 2.1 (**May 30, 2018)** da chiqqan. Biz bu interface bilan HttpClient yaratsak nima afzalliklari bo’ladi degan savol tug’ilishi tabiiy albatta. Agarda `IHttpClientFactory` bilan `HttpClient` ochadigan bo’lsak biz unga o’zimiz hohlagancha `configuration`  bersak bo’ladi. *Давайте gapni cho’zmasdan* bu interface haqida batafsil gaplashishni boshlaymiz, kettik 🚀.

---

## `IHttpClientFactory` o’zi nima?

Yuqorida ta’kidlaganimdek, IHttpClientFactory bilan biz `HttpClient` ochsak bo’ladi. Xo’sh buning nima afzalliklari bor, oddiy ochib ishlatib ketursam bo’lmaydimi degan savol tug’ilishi mumkin. Quyida qachonki biz `AddHttpClient` qilib servisni registratsiyadan o’tkazsak, biz quyidagi afzalliklarga ega bo’lamiz:

- `HttpClient` ni DI (Dependency Injection)’ga tayyor qo’shib qo’yadi.
- Turli-xil API’lar uchun `HttpClient`larni nomlab qo’ysak bo’ladi.
- `HttpClient`ning umrini (lifetime) boshqarishga yo’l ochiladi.
- Log qo’shish imkonini beradi.

---

## `IHttpClientFactory` ishlatilishi

Bizda bir-nechta *вариант’lar* bor:

- [Oddiy ishlatilinishi (Basic usage)](https://www.notion.so/IHttpClientFactory-in-NET-16b7df59bb4d803889adcd88bd086017?pvs=21)
- [Nomlash orqali ishlatish (Named clients)](https://www.notion.so/IHttpClientFactory-in-NET-16b7df59bb4d803889adcd88bd086017?pvs=21)
- [Turlash orqali ishlatish (Typed Clients)](https://www.notion.so/IHttpClientFactory-in-NET-16b7df59bb4d803889adcd88bd086017?pvs=21)

Bular orasidan eng zo’ri esa dastur nimani talab qilayotganidan kelib chiqilgan holda aniqlanadi.

Bularni esa birma-bir ko’rib chiqamiz, ketti: 🚀

### Oddiy ishlatilinishi (Basic usage)

`IHttpClientFactory`ni servis ichiga qo’shish uchun `AddHttpClient`ni chaqiramiz:

```csharp
using httpclient;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddTransient<TodoService>();

using IHost host = builder.Build();
```

Va uni qanday qilib `TodoService.cs` da chaqirishni ko’ramiz:

```csharp
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace httpclient;

public sealed class TodoService(
    IHttpClientFactory httpClientFactory, // Bu yerda IHttpClientFactoryni inject qilamiz
    ILogger<TodoService> logger)
{
    public async Task<Todo[]> GetUserTodosAsync(int userId)
    {
        using HttpClient client = httpClientFactory.CreateClient(); // Client ochamiz

        try
        {
            Todo[]? todos = await client.GetFromJsonAsync<Todo[]>(
                $"https://jsonplaceholder.typicode.com/todos?userId={userId}",
                new JsonSerializerOptions(JsonSerializerDefaults.Web)); // Va uni ishlatamiz

            return todos ?? [];
        }
        catch (Exception ex)
        {
            logger.LogError("Error getting something fun to say: {Error}", ex);
        }

        return [];
    }
}
```

Shu qadar, tamom. Mana shunday qilib oddiygina `HttpClient` ochib uni ishlataveramiz, hech kim hech qanday mo’nelik bildirmaydi.

---

### Nomlash orqali (Named Clients)

`HttpClient`ni nomlash orqali ishlatish bizga bir xolatda kerak bo’ladi:

- Bir-nechta `HttpClient`lar bir necha xil `configuration` bilan kerak bo’lib qolganda.

Hop, lekin qanday qilib `HttpClient`ga `configuration` qo’shish mumkin? Uni servislarga registratsiya qilayotganda (asosan Program.cs’da) qo’shib ketamiz:

```csharp
builder.Services.AddHttpClient("Private", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddHttpClient("Public", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
```

Ushbu misolda biz `HttpClient`ni nomini Private va Public qilyapmiz va qachonki biz `HttpClient` Public nomi bilan chaqirganimizda bizga aynan shu `configuration` bilan `HttpClient` ochiladi, tamom. 

```csharp
public class SomeService(
    HttpClient client,
    IHttpClientFactory clientFactory,
    JsonSerializerOptions jsonOptions) : ISomeService
{
	public async Task<Something?> GetByNumberAsync(
	        string number, 
	        bool usePrivateClient = false,
	        CancellationToken cancellationToken = default)
	    {  
	        var httpClient = client;
	
	        if (usePrivateClient is false)
	            httpClient = clientFactory.CreateClient("Public");
	
	        var item = await httpClient.GetFromJsonAsync<Something>(
	            $"api/certificates/{number}",
	            jsonOptions,
	            cancellationToken);
	        return item;
	    }
}
```

Va ushbu misolda `Something` degan nimadurni `id`si orqali olishi kerak ekan va qachonki biz oddiy `HttpClient` chaqirsak u bizga doim `Private` bo’lib keladi, lekin biz aynan shu `method` ni ichida `Public` qilinganini chaqirmoqchimiz, shunchaki tekshirib agarda Private bo’lsa Public bo’lganini olyabmiz, tamom. Shunda `Public` qilib nomlangan `Configuration` li `HttpClient`imiz ishlaydi.

---

### Turlash orqali (Typed client)

- Nomlash turi (named client) bilan deyarli bir-xil imkoniyatlar beradi.
- [IntelliSense](https://learn.microsoft.com/en-us/visualstudio/ide/using-intellisense)’ni bilan ta’minlaydi.
- Servisga registratsiya qilingan `HttpClient` faqatgina bir joyda ishlatilinadi va usha servisga registratsiya paytida `Configure` qilsak bo’ladi. Demak u nomidan kelib chiqadigan bo’lsakham turlangan `client` ekan:
    - Demak bir dona `backend endpoint` uchun ishlaydi.
- Servisga registratsiya qilindimi demak `DI` sharofati bilan dasturimizning istalgan joyida `inject` qilib ishlatib keta olamiz.

Shunchaki buni `Program.cs`da servisga registratsiya qilayotganimizda aynan qaysi servis uchun bu `client` ishlashini berib ketishimiz kerak shunda u `Typed Client` bo’ladi:

```csharp
builder.Services.AddHttpClient<TodoService>(
    client =>
    {
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
			  client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    });
```

Bu yerda e’tibor bersangis `AddHttpClient`ni ichiga `TodoService` ni berib yuboryapmiz. Va `client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");` bu qism esa `header`ga “dotnet-docs” yozuvini qo’shib qo’yadi.

`Turlash (typed client)`lar `Transient` sifatida `DI (dependency injection)` ga qo’yiladi.

---

## POST, PUT va DELETE uchun request

Yuqoridagi misollarda faqatgina `GET` uchun misol keltirilgan, ammo `HttpClient` boshqa turdagi HTTP amallariniham bajara oladi:

- `POST`
- `PUT`
- `DELETE`
- `PATCH`
- Va boshqalar