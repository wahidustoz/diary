# Ko'p ishlatiladigan terminlar izohi

#### bug
`Bug` bu dasturdagi kutilmagan xatolik. 

#### debug (debugging)
Dasturni xatolarini aniqlash uchun kod bloklarini qadamma qadam ishga tushirib tekshirish. `Debugging` jarayoni dasturdagi taxmin qilib topib bolmaydigan `bug`larni va ularni sababini qidirib topishga yordam beradi.

#### pointer
**Pointer** bu asosiy ma'lumot saqlanadigan xotira manzilini saqlovchi o'zgaruvchi. U ko'rsatuvchi xotira manzilini to'liq boshqarish imkonini beradi. Odatda C/C++ kabi low-level tillarda ishlatiladi. C#/Java kabi high-level tillarda to'g'ridan to'g'ri **pointer**lar ishlatish tavsiya etilmaydi. 

#### reference
C#/Java kabi high-level tillarda **heap** xotira manzilidagi asosiy ma'lumotni ko'rsatuvchi o'zgaruvchi. U xotira manzilini to'g'ridan-to'g'ri manipulatsiya qilish imkonini bermaydi.  **Reference** texnik jihatdan [*pointer*](./glossary.md#pointer)ga o'xshab ketadi. 

.NET muhitida **reference**lar xotiraga qanday bog'lanishi va ular bog'langa xotira manzillarini boshqarishni [**`CLR`**](./glossary.md#clr) bajaradi. 

#### frequency
Chastota - biror hodisa yoki elementning takrorlanish tezligi.

---
#### data structure
Ma'lumotlarni saqlash, o'qish va o'zgartirish qulay va tez bo'lishi uchun ularni sistematik tartibga solish usuli. Data structures - katta ma'lumotlar to'plamidan maxsuslarini qidirish, tartiblash va joylashtirishni osonlashtiradi.
Quyidagilar **data structure**ga misollar: 
- `array`
- `linked list`
- `stack`
- `queue`
- `tree`

#### traverse
[**Data structure**](./glossary.md#data-structure)lar kontekstida shu strukturani har bir elementiga birma-bir murojat qilib qandaydir operatsiya bajarishni anglatadi. Masalan, **loop** orqali `array`ni har bir elementiga murojat qilish *array traversing* deb ataladi.

#### node
Node - **linked list**, **stack**, **queue**, **tree** kabi [data structure](./glossary.md#data-structure)larni asosi hisoblanadi. Har bir `node` asosiy ma'lumotdan tashqari strukturadagi boshqa `node`larga [reference](./glossary.md#reference) yoki *link*ni o'z ichiga oladi.

#### root
**Tree** *(daraxtsimon)* data strukturalarida eng yuqoridagi [**node**](./glossary.md#node). **Tree** data strukturani [**traverse**](./glossary.md#traverse) qilish  **root** **node**dan boshlanadi.

#### parent
**Tree** *(daraxtsimon)* data strukturalarda o'zidan pastda bir yoki undan ortiq [**child**](./glossary.md#child)**-node**ga ega bo'lgan **node** `parent node` deb ataladi.

#### child
**Tree** *(daraxtsimon)* data strukturalarda [**parent**](./glossary.md#parent)**-node**ga ega bo'lgan **node** `child node` deb ataladi. *Ma'lumot o'rnida, `root node` hech qachon **child** ro'lida bo'la olmaydi. Sababi unda **parent-node** yo'q.*

#### leaf
**Tree** *(daraxtsimon)* data strukturalarda birorta ham [**child**](./glossary.md#child)**-node**ga ega **node** `leaf node` deb ataladi. Boshqacha qilib aytganda **leaf** shu branch/*(shox)*ni yakuni bo'ladi.

#### subtree
**Tree** *(daraxtsimon)* data strukturalarida bitta **node** va uni barcha [**child**](./glossary.md#child)laridan tashkil topgan mini-tree `subtree` deb ataladi.

#### sibling
**Tree** *(daraxtsimon)* data strukturalarida umumiy [**parent**](./glossary.md#parent)**-node**ga ega bo'lgan barcha bitta **node**lar `sibling`s deb ataladi.

#### binary tree
**Tree** *(daraxtsimon)* data strukturalarida har bir **node**i ko'pi bilan 2ta [**child**](./glossary.md#child)**ga ega bo'lgan strukturalar **binary tree** deb ataladi. **Child node**lar **`right node`** va **`left node`** deb ataladi.

#### balanced tree
**Tree** *(daraxtsimon)* data strukturalarida istalgan **node**ni olganda uni *o'ng* va *chap*idagi [**subtree**](./glossary.md#subtree)** balandligi uzog'i bilan bitta **node**ga farq qilsa, bunday **tree** **`balanced tree`** deb ataladi.

#### complete tree
Har bir qavati *(oxirgi qavatdan tashqari)* to'liq to'ldirilgan **tree** **`complete tree`** deb ataladi. Oxirgi qatorda yangi **node**lar chapdan o'ngga qarab qo'shib boriladi.

| Namuna 1                  | Namuna 2                  | 
| -------------------------- | -------------------------- |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1<br/>&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;\\<br/>&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;3 | &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1<br/>&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;\\<br/>&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;3<br/>&nbsp;/&nbsp;\\<br/>4&nbsp;&nbsp;&nbsp;5 |

#### heap property
**Binary Heap** data strukturasi kontekstida har bir node tegishli joyda bo'lishini ta'minlovchi shartlarga **heap property** deb ataladi.

| **`Min-heap`** | **`Max-heap`** |
| ------------- | ------------- |
| har bir **node** uchun [**parent**](./glossary.md#parent)**-node** qiymati [**child**](./glossary.md#child)**-node**lar qiymatidan KICHIK yoki teng bo'lishi shart. | har bir **node** uchun [**parent**](./glossary.md#parent)**-node** qiymati [**child**](./glossary.md#child)**-node**lar qiymatidan KATTA yoki teng bo'lishi shart. | 
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2<br/>&nbsp;&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;\\<br/>&nbsp;&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5<br/>&nbsp;/&nbsp;&nbsp;&nbsp;\\&nbsp;<br/>10&nbsp;&nbsp;&nbsp;&nbsp;8 | &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;15<br/>&nbsp;&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;\\<br/>&nbsp;&nbsp;10&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3<br/>&nbsp;/&nbsp;&nbsp;&nbsp;\\&nbsp;<br/>5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;7 |

---

#### recursion
Dasturda funksiya o'z tanasida o'zini chaqirishiga **recursion** deb ataladi. *Loop* ishlatmasdan o'zini-o'zi chaqirish *recursive* funksiyalar muammoni kichik muammochalarga bo'lib tashlab, bir xil logikani qayta-qayta ishlatib hal qiladi.
```csharp
public int Sum(int n)
{
    if (n == 0)
        return 0;

    return n + Sum(n - 1);
}
```


#### CLR
TODO
