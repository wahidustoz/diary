## Linux Swap nima va uni qanday yaratish mumkin?

[!INCLUDE [<author>](../authors/wahid_abduhakimov.html)]

---

<br><br>

#### Swap nima va uning ahamiyati?

> Tasavvur qiling, sizning xonangiz bor va u kitoblar bilan to‘lib ketgan. Agar yangi kitob qo‘shmoqchi bo‘lsangiz, lekin joy qolmagan bo‘lsa, vaqtincha ba'zi eski kitoblarni javondan olib, boshqa joyga qo‘yishingiz kerak. Keyinchalik kerak bo‘lganda ularni qaytarib olishingiz mumkin. _Swap huddi shu jarayon kabi ishlaydi._

Linux tizimida **operativ xotira (RAM)** to‘lib ketganida, tizim ishlamay qolmasligi uchun kam ishlatiladigan ma’lumotlarni **swap hududiga** (diskda ajratilgan maxsus joy) vaqtincha ko‘chiradi. Shu tariqa, tizim barqaror ishlashda davom etadi.

<br><br>

#### Swap bo‘lmasa nima bo‘ladi?

Agar swap bo‘lmasa va operativ xotira to‘lib ketsa, tizim dasturlarni majburan yopishga yoki hatto osilib qolishga majbur bo‘ladi. Tizimda yetarli RAM bo‘lmasa, operatsion tizim muhim bo‘lmagan jarayonlarni yopadi yoki tizim sekinlashib, hatto ishlamay qolishi mumkin. Ayniqsa, **kam RAM** (masalan, 2GB yoki 4GB) bo'lgan tizimlarda swap juda muhim.

---

<br><br>

#### Linux tizimida swap yaratish

Agar tizimingizda swap yo‘q bo‘lsa yoki mavjud swap hajmini oshirmoqchi bo'lsangiz, quyidagi bosqichlarni bajaring:

<br><br>

##### 1. Swap mavjudligini tekshirish

Birinchi navbatda, swap yo‘qligini tekshirib olamiz:

```bash
swapon --show
```

Agar hech narsa ko‘rinmasa, swap yo‘q degani.

---

<br><br>

##### 2. Swap fayl yaratish

2GB swap fayl yaratish uchun:

```bash
sudo fallocate -l 2G /swapfile
```

Agar `fallocate` ishlamasa, quyidagi usuldan foydalaning:

```bash
sudo dd if=/dev/zero of=/swapfile bs=1M count=2048
```

`fallocate` swap faylni tez yaratadi, lekin ba'zi eski tizimlarda ishlamasligi mumkin. `dd` usuli esa sekinroq, lekin hamma tizimlarda ishlaydi.

---

<br><br>

##### 3. Swap fayl uchun ruxsatlarni sozlash

Xavfsizlik uchun faqat tizim swap faylga murojaat qila olishi kerak:

```bash
sudo chmod 600 /swapfile
```

---

<br><br>

##### 4. Swap faylni formatlash

Swap sifatida sozlash:

```bash
sudo mkswap /swapfile
```

---

<br><br>

##### 5. Swap-ni faollashtirish

Endi swap-ni yoqamiz:

```bash
sudo swapon /swapfile
```

Ishlayotganligini tekshiramiz:

```bash
free -h
swapon --show
```

Agar swap ro‘yxatda ko‘rinsa, demak, hammasi to‘g‘ri ishlamoqda.

---

<br><br>

##### 6. Swap-ni doimiy qilish

Tizimni qayta yuklagandan keyin swap avtomatik ravishda yoqilishi uchun `/etc/fstab` fayliga quyidagi qatorni qo‘shamiz:

```bash
echo '/swapfile none swap sw 0 0' | sudo tee -a /etc/fstab
```

Bu qator tizim yuklanganda swap faylni avtomatik ravishda ulaydi.

---

<br><br>

##### 7. Swapni ishlatish darajasini sozlash (ixtiyoriy)

**Swappiness** - bu tizim qanchalik tez-tez swap-dan foydalanishini belgilaydi.

Joriy sozlamani tekshirish:

```bash
cat /proc/sys/vm/swappiness
```

Odatiy qiymat **60** bo‘ladi. Agar swap kamroq ishlatilishini xohlasangiz, **10 yoki 20** qilib qo‘ying:

```bash
echo 'vm.swappiness=10' | sudo tee -a /etc/sysctl.conf
sudo sysctl -p
```

Agar tizimingizda yetarli RAM bo‘lsa va swap kamroq ishlatilishini istasangiz, bu qiymatni pasaytirish mumkin.

---

<br><br>

#### Xulosa

Swap - Linux tizimining barqaror ishlashida muhim rol o‘ynaydi. Ayniqsa, kam RAM-ga ega kompyuterlar uchun swap hajmini to‘g‘ri sozlash tizim ish faoliyatini sezilarli darajada yaxshilashi mumkin.

Tizimingizdagi RAM miqdoriga qarab swap hajmini belgilash tavsiya etiladi:

- **4GB RAM** uchun **2GB swap**
- **8GB RAM** uchun **4GB swap**
- **16GB RAM** va undan ko‘p bo‘lsa, swap **minimal (1GB-2GB)** bo‘lishi mumkin.

Endi siz swap faylni qanday yaratishni va uni qanday sozlashni bilasiz! 🚀 Agar savollaringiz bo‘lsa, bemalol so‘rang. 😊

<br><br>
