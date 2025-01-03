# C#'da Remove()
**C# tilida Array'ni ochganimizdan so'ng uni o'zgartira olmaymiz, chunki Array'lar C#'da immutable ya'ni o'zgarmas.**

**Lekin qonun-qoidalarni aylanib o'tishimiz mumkin. Ya'ni Array'ni List ga o'zgartirib, kerakli ishlarni bajarib (masalan undan biror-bir element'ni olib tashlash  `listName.Remove()`) so'ng yana Listni Array'ga aylantirib qo'ya olamiz.**

**Lekin List tipida usha  `listName.Remove()`  qanday ishlaydi? Hozir birma-bir ko'rib chiqamiz.**

----------

### [](https://dev.to/muhammad_khodjaev/cda-remove-20pm#1-arrayni-list-tipiga-otkazib-olish)1. Array'ni List tipiga o'tkazib olish

```
int[] array = { 1, 2, 3, 4, 5 };
List<int> list = new List<int>(array); // List<T>'ga aylantirish
```

### [](https://dev.to/muhammad_khodjaev/cda-remove-20pm#2-listdan-elementni-ochirib-tashlash)2. List'dan elementni o'chirib tashlash

```
list.Remove(3); // 3 raqamini o'chiradi
array = list.ToArray(); // Qaytadan Array'ga aylantirish
// Array'ning qiymati {1, 2, 4, 5}
```

----------

> **Array'imiz o'zgardi. Lekin bizga yordam bergan Remove()'ni ishlatganimizda (kapot ostida) xotirada nimalar sodir bo'ldi, endi hozir buni ko'rib chiqamiz.**

----------

### [](https://dev.to/muhammad_khodjaev/cda-remove-20pm#1-dinamik-hajm-ozgarishi)1. Dinamik hajm o'zgarishi

-   `Capacity`  va  `Count`.  `List<T>`ning ikki muhim xususiyati bor -> Count (List'dagi mavjud bo'lgan elementlar soni) va Capacity (List o'zining hajmini o'zgartirmasdan umumiy nechta element saqlay olishi soni (qisqacha hajmi)).  `List<T>`  ochganimizda uning  `Capacity`si 0 ga teng bo'ladi. List'ga element qo'shganimiz sari agarda  `Count`ning soni  `Capacity`ning soniga teng bo'lib qolsa  `List<T>`  resize bo'ladi ya'ni hajmi o'zgaradi va  `Capacity`imiz avtomatik ravishda 4 taga oshadi.

### [](https://dev.to/muhammad_khodjaev/cda-remove-20pm#2-elementi-ochirib-tashlash)2. Elementi o'chirib tashlash

Qachonki biz  `Remove()`  chaqirganimizda quyidagi ishlar sodir bo'ladi:

-   `Remove()`  metodini chaqirganimizda, Listimiz birinchi bo'lib biz o'chirmoqchi bo'lgan element'ni qidiradi. Bu bolsa  _**itaration**_  ya'ni uni aylanib chiqishiga olib keladi.
    
-   Element'ni topib uni o'chirib tashlagandan so'ng, o'chirib tashlangan element'dan keyingi (ya'ni o'ng taraf) elementlar o'chirib tashlanganning o'rnini bosish uchun chapga shift qilinadi ya'ni suriladi. (Agarda o'chirib tashlangan element so'ngi element bo'lsa unda shift qilinmaydi.)  
    Masalan sizda quyidagi list bor:  
    

```
Index:   0   1   2   3   4
Values: [10, 20, 30, 40, 50]
```

Agarda siz  `30`ni o'chirib tashlasangiz list quyidagi ko'rinishga keladi:  

```
Index:   0   1   2   3
Values: [10, 20, 40, 50]
```

### [](https://dev.to/muhammad_khodjaev/cda-remove-20pm#3-countning-kamayishi)3. Count'ning kamayishi

-   Bitta element o'chib ketganidan so'ng Count'imiz bittaga kamayadi.

### [](https://dev.to/muhammad_khodjaev/cda-remove-20pm#4-xotiradagi-ishlar)4. Xotiradagi ishlar

-   `List`ning  `Capacity`si element'ni o'chirib tashlaganimizdan so'ng bittaga kamaymayib qolmaydi.  `List`ning tagida yotgan  `Array`ning hajmi usha-usha turaveradi va oldin qancha joy egallab turgan bo'lsa ushancha egallab turaveradi. Ammo biz  `Remove()`  qilishda to'xtamay davom etaversak bu  `Count`ning  `Capacity`dan o'ta sezilarli ravishda kichik bo'lishiga olib keladi. Bundan so'ng qachonki siz  `List<T>`ga element  **qo'shganingizda**,  `Capacity`  ko'payish o'rniga kamayishi mumkin. Bu ish esa  `List<T>`ning tagida yotgan Array'ning o'rniga yangi  `Array`  ochiladi va barcha element'lar u yerga ko'chirib o'tkaziladi.

----------

### [](https://dev.to/muhammad_khodjaev/cda-remove-20pm#xulosa)Xulosa

> _Xulosa qilib aytadigan bo'lsak,  `Remove()`  ishlatganimizda -> element qidiriladi, o'chirib tashlangandan so'ng qolgan elementlar chapga suriladi,  `Count`  kamayadi._

---

[!INCLUDE [<author>](../authors/muhammad_khodjaev.html)]
