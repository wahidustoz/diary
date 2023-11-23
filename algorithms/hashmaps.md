# Hash Maps :hash: - intervyu kaliti :key:

**HashMap Data Structure** tech intervyularda eng ko'p so'raladigan agoritmlardan biri.

Lekin ajoyib hushxabar bor :star_struck:

**HashMap**ni eng ko'p uchraydigan 2ta holatda ishlatishni o'rganib olsangiz yetarli! 

Ushbu post davomida ikkala holatni ham misollar yordami o'rganib olasiz.


## 1. Element mavjudligini aniqlash.

`Array` ichida element bor/yo'qligini tekshirish **linear** $O(N)$ vaqt talab etadi. Ya'ni array ichidagi $N$ta elementlarni tekshirib chiqish kerak.

`HashMap` esa shu operatsiyani **constant** $O(1)$ vaqt ichida bajaradi.

Tasavvur qiling sizda shu tekshirish operatsiyasini $M$ marta takrorlashingiz kerak. Array ustida bu $O(NM)$ vaqt talab qilsa, `HashMap` ustida $O(M)$ vaqt oladi.

Bu nazariyani quyidagi LeetCode misollari orqali isbotlaymiz.

<br/>

#### Two Sum
`int array` **nums** va `int` **target** berilgan bo'lsa, `array` ichidan yig'indisi **target**ga teng 2ta elementlar *index*larini qaytarish kerak.

:point_right: [ Masalaga havola](https://leetcode.com/problems/two-sum/solutions/3511887/best-solution-in-c/)

```csharp
public class Solution 
{
    public int[] TwoSum(int[] nums, int target)
    {
        var juftlar = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
            if(juftlar.ContainsKey(target - nums[i]))
                return new int[] { i, juftlar[target - nums[i]]};
            else
                juftlar.TryAdd(nums[i], i);

        return new int[] { };
    }
}
```

> [!TIP]
> Yuqoridagi yechimda `HashMap`ga asoslangan `Dictionary` ishlatilgan. 
> 
> - Qisqacha, `array`dagi har bir elementni juftini `Dictionary`dan qidiramiz. 
> - Agar jufti yo'q bo'lsa, shu elementni `Dictionary`ga qo'shamiz. 
> 
> `Dictionary`dan qidirish $O(1)$ vaqt talab qiladi. Bu amal `for loop` ichida $N$ marta takrorlangani uchun yechim umumiy $O(N)$ vaqt talab qiladi.

<br/>

#### Counting Elements
Berilgan `array` ichida `x + 1` jufti mavjud bo'lgan `x` qiymatli elementlar sonini qaytarish kerak. Agar shunday sonlar bir nechta bo'lsa, hammasi alohida sanalsin.

:point_right: [Masalaga havola](https://leetcode.ca/all/1426.html)

```csharp
public class Solution
{
    public int CountElements(int[] nums)
    {
        var frequency = new Dictionary<int, int>();
        foreach(var num in nums)
        {
            frequency.TryGetValue(num, out var value);
            frequency[num] = value + 1;
        }

        var count = 0;
        foreach(var num in nums)
            if(frequency.ContainsKey(num + 1))
                count++;
            
        return count;
    }
}
```

> [!TIP]
> Bu yechimda ham `HashMap` sifatida **C#**ning `Dictionary` `class`i ishlatilgan. 
> 
> - `Array` elementlari necha marta takrorlanishini `Dictionary`ga saqlab olamiz. 
> - Keyingi **loop**da shu *map* ichidan $x+1$ qiymatli elementlarni qidiramiz.
> 
> Ikkala loop ham $O(N)$ vaqt sarflagani uchun umumiy algoritm $O(N)$ vaqt oladi.

<br/>

#### First Letter to Appear Twice
Kichik lotin harflaridan iborat `string` berilganda ikki marta takrorlanuvchi birinchi harfni qaytaring.

:point_right: [Masalaga havola](https://leetcode.com/problems/first-letter-to-appear-twice/)

> [!WARNING]
> 
> **Ushbu yechimni mashq sifatida o'zingiz bajarib ko'ring.**
> 
> Savollar va mulohazalaringizni o'zingizga o'xshagan qiziquvchan dasturchilar bilan [**Telegram Kanalimiz**](https://t.me/wahidustoz)da ulashing :writing_hand:.

---
<br/>

## 2. Takrorlanishlar sonini sanash

`HashMap` yordamida istalgan elementni to'plamdagi [**chastota**](../glossary.md#frequency)sini aniqlash juda ham oson. 

Masalan, `string` ichidagi belgilar chastotasi bir xil yoki yo'qligini aniqlash.

`HashMap` yordami berilgan tekst ichidagi har bir belgi chastotasi bir xil yo'qlini bitta `loop` orqali $O(N)$ **linear** vaqt ichida aniqlasa bo'ladi.

Keling yana misollar yordamida isbotlaymiz.

<br/>

#### Subarray Sum Equals K
`int array` **nums** va `int` **k** berilgan bo'lsa, yig'indisi **k** ga teng bo'lgan **subarray**lar sonini qaytaring.

**Subarray** - ketma-ket joylashgan elementlardan tashkil topgan kichi array.

:point_right: [Masalaga havola](https://leetcode.com/problems/subarray-sum-equals-k/)

```csharp
public class Solution 
{
    public int SubarraySum(int[] nums, int k) 
    {
        var sumsMap = new Dictionary<long, int>();
        var count = 0;
        long sum = 0;

        foreach(var num in nums)
        {
            sum += num;

            if(sum == k)
                count++;
            
            if(sumsMap.TryGetValue(sum - k, out var frequency))
                count += frequency;
            
            sumsMap.TryGetValue(sum, out var x);
            sumsMap[sum] = x + 1;
        }

        return count;
    } 
}
```

> [!TIP]
> Yuqoridagi yechimda barcha `subarray`lar yig'indisini hisoblab ketish bilan bir vaqtda, shu yig'indini `HashMap`ga joylab, agar mavjud bo'lsa **chastota**sini oshirib ketamiz.
> - Har bir `loop iteration`da yig'indi $K$ ga teng bo'lsa sanoqni birga oshiramiz
> - Agar `HashMap` ichida joriy yig'indini jufti $sum - k$ mavjud bo'lsa, o'sha kalitli elementni chastotasini sanoqqa qo'shamiz.
> 
> `HashMap`dan qidirish $O(1)$ vaqt olgani va bu operatsiya $N$ marta takrorlangani uchun umumiy algoritm $O(N)$ vaqt oladi.

<br/>

#### Maximum Number of Balloons
**text** deb nomlangan `string` berilgan bo'lsa, undagi **`balloon`** takrorlanishlar sonini qaytaring.

:point_right: [Masalaga havola](https://leetcode.com/problems/maximum-number-of-balloons)

```csharp
public class Solution 
{
    public int MaxNumberOfBalloons(string text) 
    {
        var map = new Dictionary<char, int>
        {
            { 'b', 0 },
            { 'a', 0 },
            { 'l', 0 },
            { 'o', 0 },
            { 'n', 0 },
        };

        foreach(var c in text)
            if(map.TryGetValue(c, out var frequency))
                map[c] = ++frequency;
        
        // l va o ikki martadan keladi
        map['l'] /= 2;
        map['o'] /= 2;

        var min = int.MaxValue;
        foreach(var value in map.Values)
            min = Math.Min(min, value);
        
        return min;
    }
}
```

> [!TIP]
> Yechimda yana `HashMap` yordamida harflar chastotasi saqlangan. Keyin esa bu **map**dan eng kichik chastota tanlab olingan. Chunki shu eng kam marta takrorlangan harf **balloon** so'zini ko'pi bilan necha marta hosil qila olishimizni belgilaydi.
>
> - Kod juda ham oddiy, tushinish muammo bo'lmasa kerak. 
> - Etiborga loyiq jihati 2ta `loop` ishlatilgan bo'lsa ham algoritm umumiy murakkabligi $O(N)$ligicha qoladi.
> - **balloon** so'zida `'o'` va `'l'` harflari 2 martadan takrorlangani uchun, ularni chastotatsini 2ga bo'lib qoyganmiz
> 

---
<br/>

### :wave: Hulosa
`HashMap` yoki `HashTable` **Data Structure** dasturlashdagi eng muhim va juda ko'p uchraydigan algoritmlar. Ularni o'rganish va mashq qilish orqali nafaqat intervyu savollarida balki injinerlik faoliyatingizda ham sezilarli samara bo'ladi.

<br/>

> [!Hint]
> Keyingi maqolada [**Binary Heap**](./binaryheap.md) *Data Structure*ni **C#**ni eng zamonaviy *feature*larini qo'llagan holda implementatsiya qilamiz.
> 
> Shu kabi sifatli o'zbek tilidagi kontentni qo'llab quvvatlash uchun bizni [**Telegram Kanalimiz**](https://t.me/wahidustoz)ga obuna bo'ling.