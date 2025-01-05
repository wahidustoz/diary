# Sepolia orqali API integratsiya qilish

## Kirish

Sepolia Ethereum blockchain tarmog‘ining test tarmoqlaridan biri bo‘lib, dasturchilar yangi ilovalarni sinab ko‘rish va ularni ishlab chiqish jarayonida ishlatishlari uchun mo‘ljallangan. Ushbu maqolada, Sepolia orqali API integratsiyasini amalga oshirish bo‘yicha amaliy misol ko‘rib chiqamiz. Biz Nethereum kutubxonasidan foydalanamiz va ikkita endpoint yaratamiz:

1. Yangi EVM hisob yaratish.
2. Hisob balansini olish.

Demak, boshladik 🚀

## Infura platformasida akkaunt yaratish

1. infura.io saytiga kirib registratsiyadan o'tiladi
2. **API Keys** bo'limidagi "My First Key" nomi ostidagi kalitni ochamiz
3. "COPY" tugmasi yonida turgan kod bizni kalitimiz. Haliroq undan Sepolia Network'ga kirish uchun foydalanamiz.

## Kerakli kutubxonalar

Kodimizda **Nethereum** kutubxonasidan foydalanamiz. Ushbu kutubxona Ethereum bilan integratsiya qilish imkonini beradi, va uni quyidagicha proyektga qo'shish mumkin:

**Nethereum.Web3** kutubxonasini o‘rnatish:
```bash
dotnet add package Nethereum.Web3
```

## Kodning batafsil tahlili

### Yangi loyihani yaratish

ASP.NET Core loyihasini boshlash uchun quyidagilarni bajaring:
```bash
dotnet new webapi -n SepoliaIntegration
cd SepoliaIntegration
```

### Yangi EVM hisob yaratish

Birinchi endpointimiz `/evm/account` orqali yangi EVM hisob yaratamiz. Quyidagi kod misolida bu qanday ishlashini ko‘ramiz:

```csharp
app.MapGet("/evm/account", () =>
{
    var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
    var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
    var account = new Nethereum.Web3.Accounts.Account(privateKey);
    var publicKey = account.Address;

    return new {
        PrivateKey = privateKey,
        PublicKey = publicKey
    };
});
```

#### Explanation
1. **`GenerateKey`** funksiyasi orqali yangi xususiy kalit (private key) yaratiladi.
2. **`GetPrivateKeyAsBytes().ToHex()`** yordamida xususiy kalit 16-li (hex) formatga o‘tkaziladi.
3. **`Nethereum.Web3.Accounts.Account`** yordamida ochiq kalit (public key) va manzil (address) hosil qilinadi.
4. Natijada foydalanuvchiga xususiy va ochiq kalitni qaytaramiz.

### Balansni olish

Ikkinchi endpoint `/evm/balances/{publicKey}` orqali berilgan manzilning (address) Ethereum balansini olamiz.

```csharp
app.MapGet("/evm/balances/{publicKey}", async (string publicKey) =>
{
    var web3 = new Web3("https://sepolia.infura.io/v3/(bu yerda infura.io dan olgan kalitingizni joylashtirasiz)");
    var balance = await web3.Eth.GetBalance.SendRequestAsync($"{publicKey}");
    var etherAmount = Web3.Convert.FromWei(balance.Value);

    return new {
        Owner = publicKey,
        Eth = etherAmount
    };
});
```

#### Explanation
1. **`Web3` obyektini yaratish**: Infura xizmatidan foydalanib, Sepolia RPC orqali blockchainga ulanamiz.
2. **`GetBalance.SendRequestAsync`** funksiyasi yordamida berilgan manzilning balansini olamiz.
3. Balansni Ether formatiga o‘tkazish uchun **`Web3.Convert.FromWei`** funksiyasidan foydalanamiz.

### Kodni ishga tushirish

Loyihani ishga tushirish uchun quyidagi buyruqni bajaring:
```bash
dotnet run
```
Shundan so‘ng, API `/evm/account` va `/evm/balances/{publicKey}` endpointlarida ishlaydi.

[!INCLUDE [<author>](../authors/wahid_abduhakimov.html)]