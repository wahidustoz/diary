# Logging Levels

**Logging** dasturni eng muhim qismlaridan biri hisoblanadi. Ko’pchilik unga katta e’tibor bermasa ham **Logging** to’g’ri qilinmasa juda katta mablag’ va vaqt yo’qotilishiga olib kelishi mumkin.

> *Odam yozgan lyuboy sistemada Bug 🪲 bo’ladi.*


Dastur ishga tushgandan keyin kelib chiqqan xatoliklarni dasturda yozib borilayotgan Loglarsiz qidirib topishni imkoni yo’q. 

Bugungi postda **Log Levels** ya’ni log xabarlarni muhimlik darajalariga qarab qanday ishlatishni o’rganamiz.

## 1. `Trace — logger.LogTrace()`

Bu turdagi loglar dastur davomidagi har bir qadamni batafsil yozib ketish uchun ishlatiladi. Yangi jarayon, funksiya, loop yoki oqim boshlanishi va tugaganidan keyin iz qoldirish uchun Trace log yozib ketiladi.

```csharp
public async Task ProcessOrder(CustomerOrder order)
{
    logger.LogTrace("Starting order processing for OrderId: {OrderId}", order.OrderId);

    // Validate the order
    if (IsOrderValid(order))
    {
        logger.LogTrace("Order validation successful for OrderId: {OrderId}", order.OrderId);

        // Perform necessary actions such as updating inventory, sending notifications, etc.
        logger.LogTrace("Persisting order with OrderId: {OrderId}", order.OrderId);
        await storage.PersistOrderAsync(order);

        logger.LogTrace("Publishing OrderCreated message with OrderId: {OrderId}", order.OrderId);
        await messaging.PublishOrderCreated(order);
    }
}
```

---

## 2. `Debug — logger.LogDebug()`

Bu turdagi log Tracega juda ham yaqin, lekin yagona farqi Debug log ichida o’zgaruvchilar qiymatlari batafsilroq yoritiladi. Shu sababli bu turdagi log ichida maxfiy ma’lumotlar bo’lishi mumkin. Debug va Trace log miqdori juda katta bo’lgani uchun odatda Production muhitda o’chirib qo’yish tavsiya qilinadi. 

> *Shaxsiy fikrimcha **Debug** yoki **Trace** darajasidan kamida bittasi **Production** muhitda ham ko’rinishi kerak.*
> 

```csharp
public async Task ProcessOrder(CustomerOrder order)
{
    logger.LogTrace("Starting order processing for OrderId: {OrderId}", order.OrderId);
    logger.LogDebug("Processing order: {Order}", order);

    // Validate the order
    if (IsOrderValid(order))
    {
        logger.LogTrace("Order validation successful for OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Order validation successful for: {Order}", order);

        // Perform necessary actions such as updating inventory, sending notifications, etc.
        logger.LogTrace("Persisting order with OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Persisting order: {order}", order);
        await storage.PersistOrderAsync(order);

        logger.LogTrace("Publishing OrderCreated message with OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Publishing OrderCreated for order: {order}", order);
        await messaging.PublishOrderCreated(order);
    }
}
```

---

## Summary

Yuqorida keltirilgan LogTrace va LogDebug odatda dasturchilar uchun yo’naltirilgan bo’ladi. Ya’ni bu turdagi loglarni odatda developerlar BUG🪲ni qidirib topish uchun ishlatishadi.

## 3. `Information — logger.LogInformation()`

Bu turdagi log odatda biror katta jarayon boshlanishi va muvaffaqiyatli tugaganini ko’rsatish uchun ketiladi. Trace va Debugdan farqli o’laroq, Information turidagi xabarlar miqdori juda kam bo’ladi. Bunday log ichida iloji boricha maxfiy ma’lumotlar ko’rsatilmasligi kerak.

```csharp
public async Task ProcessOrder(CustomerOrder order)
{
    logger.LogTrace("Starting order processing for OrderId: {OrderId}", order.OrderId);
    logger.LogDebug("Processing order: {Order}", order);

    // Validate the order
    if (IsOrderValid(order))
    {
        logger.LogTrace("Order validation successful for OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Order validation successful for: {Order}", order);

        // Perform necessary actions such as updating inventory, sending notifications, etc.
        logger.LogTrace("Persisting order with OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Persisting order: {order}", order);
        await storage.PersistOrderAsync(order);

        logger.LogTrace("Publishing OrderCreated message with OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Publishing OrderCreated for order: {order}", order);
        await messaging.PublishOrderCreated(order);

        logger.LogInformation("Order with orderId {OrderId} successfully processed.", order.Id);
    }
}
```

## 4. `Warning — logger.LogWarning()`

Warning xabarlar dasturda kutilmagan holat yoki noto’g’ri ma’lumot paydo bo’lganda qoldiriladi. Bunday holat yuz berganda dasturchi, sistema admini yoki dasturni o’zi ham hech qanday amal bajarish orqali xatoni tuzatishga urinishi shart emas. 
Bu xabarni muhim tarafi, sistemadagi bu kutilmagan holat keyinchalik e’tibor talab etuvchi jiddiy xatolikka olib borishi mumkin.

```csharp
public async Task ProcessOrder(CustomerOrder order)
{
    logger.LogTrace("Starting order processing for OrderId: {OrderId}", order.OrderId);
    logger.LogDebug("Processing order: {Order}", order);

    // Validate the order
    if (IsOrderValid(order))
    {
        logger.LogTrace("Order validation successful for OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Order validation successful for: {Order}", order);

        // Perform necessary actions such as updating inventory, sending notifications, etc.
        logger.LogTrace("Persisting order with OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Persisting order: {order}", order);
        await storage.PersistOrderAsync(order);

        logger.LogTrace("Publishing OrderCreated message with OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Publishing OrderCreated for order: {order}", order);
        await messaging.PublishOrderCreated(order);

        logger.LogInformation("Order with orderId {OrderId} successfully processed.", order.Id);
    }
    else
    {
        logger.LogDebug("Validation failed for order {order}", order);    // batafsil ma'lumot qoldirish uchun
        logger.LogWarning("Validation failed for order with id: {OrderId}", order.Id);

        logger.LogDebug("Publishing OrderFailed for order: {order}", order);
        await messaging.PublishOrderFailed(order);
    }
}
```

---

## 5. `Error — logger.LogError()`

Error xabarlar biror katta yumush bajarish jarayonida xatolik yuz berib shu funksiya oxiriga yeta olmasa qoldiriladi. Error xabar qoldirilish shu jarayon oxiriga yetmay qolganini lekin sistemaning boshqa qismlariga ta’sir qilmasligini anglatadi. Odatda Error xabarlarni sistemani o’zinig Error Handling, Retry mexanizmlari bartafar qiladi. Ayrim hollarda operatorlar ma’lumot xolatini o’zgartirish orqali ham bu Error holatdan chiqib ketishlari mumkin.

Error xabar yuz berganda Operatorlar yoki dasturchilar uyqularidan turib bo’lsa ham shu xatolikni bartaraf etishlari kerak. Shuning uchun bu turdagi xatoliklarni log qilishda shoshilmaslik kerak. *Operator va dasturchini uyqusini buzishga arziydimi* degan savolni berish kerak.

![https://media4.giphy.com/media/jG5uIKBfJyouY/giphy.gif?cid=7941fdc6loeg1acst9hzogxw3f6v9r4lf2w9bwq1fm4xh9o9&ep=v1_gifs_search&rid=giphy.gif&ct=g](https://media4.giphy.com/media/jG5uIKBfJyouY/giphy.gif?cid=7941fdc6loeg1acst9hzogxw3f6v9r4lf2w9bwq1fm4xh9o9&ep=v1_gifs_search&rid=giphy.gif&ct=g)

```csharp
public async Task ProcessOrder(CustomerOrder order)
{
    logger.LogTrace("Starting order processing for OrderId: {OrderId}", order.OrderId);
    logger.LogDebug("Processing order: {Order}", order);

    // Validate the order
    if (IsOrderValid(order))
    {
        logger.LogTrace("Order validation successful for OrderId: {OrderId}", order.OrderId);
        logger.LogDebug("Order validation successful for: {Order}", order);

        try
        {
            // Perform necessary actions such as updating inventory, sending notifications, etc.
            logger.LogTrace("Persisting order with OrderId: {OrderId}", order.OrderId);
            logger.LogDebug("Persisting order: {order}", order);
            await storage.PersistOrderAsync(order);

            logger.LogTrace("Publishing OrderCreated message with OrderId: {OrderId}", order.OrderId);
            logger.LogDebug("Publishing OrderCreated for order: {order}", order);
            await messaging.PublishOrderCreated(order);
        }
        catch(DbException ex)
        {
            logger.LogError("Order processing failed for order with id: {OrderId}", order.Id);
            throw new OrderProcessingFailedException(order, ex);
        }

        logger.LogInformation("Order with orderId {OrderId} successfully processed.", order.Id);
    }
    else
    {
        logger.LogDebug("Validation failed for order {order}", order);    // batafsil ma'lumot qoldirish uchun
        logger.LogWarning("Validation failed for order with id: {OrderId}", order.Id);

        logger.LogDebug("Publishing OrderFailed for order: {order}", order);
        await messaging.PublishOrderFailed(order);
    }
}
```

---

## 6. `Critical — logger.LogCritical()`

Bunday Log sistemani barcha qismlarini ishdan chiqaruvchi xatolikni yozish uchun ishlatiladi. Masalan, RAM yoki SSD xotira tugab qolishi, butun dastur bo’ylab Database’ga bog’lana olmaslik yoki shunga o’xshash dastur ishlashi uchun so’zsiz kerak resursni yo’qligi.

Bunday xatoliklar dastur davomida bir marta yuz beradi. Ya’ni Critical error yuz bergandan keyin dastur o’chib qolishi va Sistem adminstrator tomonidan qayta yoqilishi zarur. Critical error xabar yuz berganda Sistem Adminstrator uyqusidan turib bo’lsa ham xatolikni bartaraf etishi kerak.

![https://media0.giphy.com/media/8p9O3TyoTaNlXDwmSj/giphy.gif?cid=7941fdc64lordhji9bsz6autt6r8xixu8q2yt1gvha6iz4vu&ep=v1_gifs_search&rid=giphy.gif&ct=g](https://media0.giphy.com/media/8p9O3TyoTaNlXDwmSj/giphy.gif?cid=7941fdc64lordhji9bsz6autt6r8xixu8q2yt1gvha6iz4vu&ep=v1_gifs_search&rid=giphy.gif&ct=g)

```csharp

builder.Services.AddDbContext<AppDbContext>((provider, options) =>
{
    var logger = provider.Services.GetRequiredService<ILogger<Program>>();
    var connectionString = builder.Configuration.GetConnectionString("Postgres");
    if(string.IsNullOrWhiteSpwace(connectionString))
    {
        logger.LogCritical("Postgres connection string not configured.");
        Environment.Exit(-1);
    }

    options.UseNqgsql(connectionString);
});
```

---

Yuqoridagi misollardan ko’rinib turibdi agar dastur davomida yetarlicha log xabarlar qoldirmoqchi bo’lsangiz kodda judaham noise *(shovqin — chalg’ituvchi qismlar)* juda ko’payib ketadi. Buni oldini olish uchun Logging Abstraction qo’llash kerak.
Bu haqida batafsil keyingi postda.