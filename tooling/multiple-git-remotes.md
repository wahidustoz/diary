# 🖇️ Bir loyihani bir vaqtda **GitHub** va **GitLab**da boshqarish

Git'da bir nechta **remote**larni sozlashni bilasizmi? 🤔 Marhamat, quyidagi super-yengil qadamlar orqali GitHub va GitLab uchun alohida **SSH Key**lar yaratib, ulardan qanday foydalanishni o'rganib oling! 🎉

---

## 🔑 **SSH Key**larni yaratish

#### 1. Terminalda `~/.ssh` papkasiga o'tamiz:
> agar unday papka mavjud bo'lmasa, yaratishni unutmang 😉
```sh
cd ~/.ssh
```

#### 2. **SSH kalitlar**lar yaratamiz. GitHub va GitLab email manzillarini to'ldirishni unutmang (email bir xil bo'lsa ham muammo yo'q 😉):
   ```sh
   ssh-keygen -t rsa -C "your@github.email"
   ssh-keygen -t rsa -C "your@gitLAB.email"
   ```
#### 3. Yaratilgan keylar `~/.ssh` papkasida saqlanadi. Endi terminalda quyidagini yozib, `~/.ssh` papkasida **config** fayl yaratamiz:
   ```sh
   code config
   ```
#### 4. **config** faylga quyidagi kodlarni yozamiz va saqlaymiz:
```plaintext
Host github.com
    Hostname github.com
    User git
    IdentityFile ~/.ssh/github

Host gitlab.com
    Hostname gitlab.com
    User git
    IdentityFile ~/.ssh/gitlab
```

---

## 🔗 SSH Key'larni GitHub va GitLab'ga ulash

### 🐙 **GitHub** uchun:
1. GitHub'da **Settings > SSH and GPG keys** bo'limiga o'ting.
2. **New SSH key** tugmasini bosing. 
3. **~/.ssh/github.pub** faylini ochib, ichidagi hamma tekstni nusxa oling.
4. **Title** maydoniga kalit uchun nom kiriting va nusxa olingan tekstni quyi maydonga joylashtiring.
5. **Add SSH Key** tugmasini bosing. ✅

### 🦊 **GitLab** uchun:
1. GitLab'da **Preferences > SSH Keys** sahifasiga o'ting.
2. **~/.ssh/gitlab.pub** faylini ochib, ichidagi hamma tekstni nusxa oling.
3. **Key** maydoniga nusxa olingan tekstni joylashtiring.
4. **Title** maydoniga kalit uchun nom kiriting va **Expiration Date**ga 1 yillik amal qilish muddatini belgilang (tavsiya qilinadi 📅).
5. **Add Key** tugmasini bosing. ✅

---

## 🔄 **Git Remote**larni sozlash
Endi kodlaringizni yuklashda **HTTPS** linklar o'rniga **SSH** linklardan foydalanishingiz kerak! 👌 Misol uchun: 

```sh
git remote add github "github repo ssh link"
git remote add gitlab "gitlab repo ssh link"
```

Shundan keyin, bir vaqtning o'zida kodlaringizni ikkala platformaga yuklashingiz mumkin:
```sh
git push github main
git push gitlab main
```

---

## 🎉 You've made it!
Hammasi tayyor! Endi siz **GitHub** va **GitLab**'ni bir vaqtda boshqarishingiz mumkin. 👏🚀