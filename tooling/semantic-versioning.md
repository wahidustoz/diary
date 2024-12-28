# Semantic Versioning (SemVer)

---

## Umumiy tushuncha

Semantic versioning yoxud SemVer dastur yangilanishdagi o’zgarishlar haqidagi ma’lumotni o’zida mujassam etuvchi 3 ta qismga bo’lingan raqamlar kombinatsiyasidan tashkil topgan versiyalash sxemasidir.

> *(Play market/app store lada ko’pchiligimizni ko’zimiz tushgan 2.1.4 | 1.0.0 | 1.0.1 raqamlarga)*
> 

---

## SemVer ning yozilish formati

Versiyalash formati (raqamlar qaysi tartibga ko’ra yozilishi) quyidagidan iborat = **‘MAJOR.MINOR.PATCH’.** 

> *(Major = asosiy/katta, Minor = mayda/kichik, Patch = huddiki kiyimga yamoq qilgandek)*
> 

Ularning ma’nosi quyidagicha:

- **MAJOR** versiya (**’X.y.z’**): Qachonki dasturga oldingi versiyasi bilan umuman bir xil holatdan uzoqlashgan yangilik kiritganingizda ushbu raqam bittaga oshadi. Masalan: “lyuboy” kod, skript o’chirib tashlanishi, yoki umuman dastur oldingi holatidan yangi ko’rinishga kelgan bo’lsa.
- 1.0.0 dan 2.0.0 ga o’zgaradi

```python
def calculate_sum(a, b):
    return a + b
```

```python
# calculate_sum function is removed
```

---

```python
def calculate_sum(a, b):
    return a + b
```

```python
def calculate_sum(a, b, c):
    return a + b + c
```

---

- **MINOR** versiya (**’x.Y.z’**): Qachonki dasturga yangi biror-bir narsalar qo’shilganda (masalan yangi endpoint lar, yangi funksiyalar, metodlar, class lar va hokazo) ushbu raqam bittaga oshadi. Va bu yangilanishlar ishlab turgan kod, funkiyalarga o’zgartirish kiritilmasdan qo’shilishi kerak.
- 1.2.3 dan 1.3.0 ga o’zgaradi

```python
def calculate_sum(a, b):
    return a + b
```

```python
def calculate_sum(a, b):
    return a + b

def calculate_product(a, b):
    return a * b
```

---

```python
def greet_user(name):
    return f"Hello, {name}!"
```

```python
def greet_user(name, greeting="Hello"):
    return f"{greeting}, {name}!"
```

---

- **PATCH** versiya (**’x.y.Z’**): Qachonki siz xatoliklarni bartaraf etganingizda yoki juda kichik o’zgartirish kiritganingizda ushbu raqam bittada oshadi. Ushbu o’zgartirishlar dasturga yangi imkoniyat/funksiyalar qo’shish yoki ularni o’zgartirish degani emas, balki bu mavjud bo’lgan muammoni bartaraf etish yoki kodning asl mohiyatini buzmasdan uni yaxshilash/tezlashtirishni bildiradi.
- 1.0.0 dan 1.0.1 ga o’zgaradi

```python
def calculate_sum(a, b):
    return a - b  # Noto'g'ri ish harakati
    # Bu yerda yeg'indini qaytarishi kerak
```

```python
def calculate_sum(a, b):
    return a + b  # Bu yerda esa yeg'indi
```

---

```python
def get_items():
    items = []
    for i in range(1000):
        items.append(i)
    return items
```

```python
def get_items():
    return list(range(1000))  # Kod yaxshilashdi
```

---

## Pre-release versiyalar (Umumiy tushuncha)

Pre-release ya’ni dastur ommaga to’liq taqdim etilishidan oldin dasturni ishga tushirish. Ushbu versiyalar dastur hali stabil holatda ishlamayotgani va haliham dastur ishlab chiqilayotgani <under development> yoki haliham test qilinayotganini anglatadi. Pre-release versiyalar dasturchilarga yoki testerlarga juda foydali. Ular dasturni asosiy (ya’ni ommaga allaqachon taqdim qilingan) versiyaga ta’sir o’tgazmasdan ishlatib ko’ra olishadi va feedback ya’ni o’z fikrlarini qoldirishlari mumkin. (Pre-release dastur umuman ommaga taqdim qilinishida oldinham chiqishi mumkin albatta)

---

## Pre-release ning yozilish formati

Huddi MAJON.MINOR.PATCH ni saqlab qolamiz va oldiga shunchaki ***alpha, beta*** yoki ***rc.X** l*arni qo’yamiz:

1. **alpha:** Bu odatda test qilishning eng birinchi fazasini bildiradi. Odata bu stabil bo’lmagan yoki haliham eksperement qilinayotgan yangiliklarni o’z ichiga oladi
- **‘1.0.0-alpha’**
1. **beta:** Bu alpha ga qaraganda stabilroq versiya hisoblanadi. Ammo haliham xatoliklar bo’lishi mumkun va albatta ommaga to’liq taqdim etiladigan produkt hisoblanmaydi. (Qisqa qilib aytganda alpha dan keyingi bosqich).
- **‘1.0.0-beta’**
1. **rc (release candidate):** Bu esa beta ga qaraganda stabilroq versiya hisoblanar ekan. Bu odatda mahsulot (dastur)ni testlashning final bosqichini bildiradi. (Qisqaroq esa beta dan keyingi bosqich).
- **‘1.0.0-rc.1’**

---

## Pre-release versiyalarning oshib borishi

- **1.0.0-alpha** dan **1.0.0-alpha.1** ga
- **1.0.0-beta** dan **1.0.0-beta.1** ga
- **1.0.0-rc.1** dan **1.0.0-rc.2** ga

---

### Pre-release lar dasturning birinchi ommaga taqdim qilinishidan oldin ham qo’llanilishi mumkin

Eng birinchi test uchun taqdim etiladigan versiya quyidagicha yoziladi: 

- **0.1.0-alpha**
- **0.1.0-beta**
- **0.1.0-rc.1**

va bulardan so’ng eng birinchi stabil versiya ommaga taqdim etiladi:

- **1.0.0**

---

## Dokumentatsiya

Yangi versiya chiqqanida faqatgina ushbu raqamlardan foylanibgina qolmasdan foydalanuvchilar uchun albatta nima yangiliklar qilingani haqida ma’lumot beruvchi dokumentatsiya yozish esdan chiqmasin.

---

## Xulosa

*SemVer dan foydalanib siz nafaqat dasturni versiyalaysiz balki foydalanuvchilar bilan ishonchli aloqa o’rnata olasiz. Foydalanuvchilar yanglilanish tugmasini bosishdan oldin nima yangilanishlar qo’shilganini bilib olishligi mumkin. Kichik bir kutubxona qilyapsizmi yoki biror bir katta dastur tuzyapsizmi farqi yo’q, SemVer bilan dasturingizni ma’noliroq, chunarliroq versiyalaysiz.*

---

Xurmat bilan,
Muhammad Khodjaev