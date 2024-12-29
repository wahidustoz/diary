# SSH kalitini Github.com'ga qo'shish

Ushbu maqolada SSH kaliti yo'q bo'lsa yangisini ochish va bor bo'lsa Github.com profilimizga qo'shishni ko'rib chiqamiz.

## [](https://dev.to/muhammad_khodjaev/ssh-kalitini-githubcomga-qoshish-heh#1bosqich-kompyuterda-ssh-bormi-yoki-yoqmi-tekshirish)1-bosqich  _Kompyuterda SSH bormi yoki yo'qmi tekshirish_

1.  Kompyuterimizda  **Git Bash**'ni ochamiz.
2.  `ls -al ~/.ssh`  mana shu komandani kiritamiz.
3.  Agarda sizning kompyuteringizda allaqachon SSH key bo'lsa quyidagi fayllardan biri bo'ladi:  `id_rsa.pub`  `id_ecsda.pub`  `id_ed25519.pub`

> Agarda sizda ushbu fayllardan biri bo'lsa, 4-bosqichga o'tib ketavering! Agarda bo'lmasa, hozir 2 va 3 chi bosqichlarda yangisini ochishni o'rganamiz.

## [](https://dev.to/muhammad_khodjaev/ssh-kalitini-githubcomga-qoshish-heh#2bosqich-kompyuterda-yangi-ssh-ochish)2-bosqich  _Kompyuterda yangi SSH ochish_

1.  Git Bash'ni ochamiz
2.  `ssh-keygen -t ed25519 -C "your_email@example.com"`  mana shu komandani kiritamiz. > Qo'shtirnoq ichiga Github profilingiz ulangan pochta manzilini kiritasiz. (qo'shtirnoq olib tashlanmaydi)
3.  SSH'ni saqlash uchun fayl so'raydi. Default holatda berilgan faylga saqlash uchun shunchaki enter'ni bosishingiz kifoya.
4.  Ana endi "Enter passphrase" so'raydi ya'ni kod. Esingizda qoladigan kodni kiritasiz
5.  Va kiritgan kodingizni yana bir bor kiritasiz.

## [](https://dev.to/muhammad_khodjaev/ssh-kalitini-githubcomga-qoshish-heh#3bosqich-sshni-sshagentga-qoshish)3-bosqich  _SSH'ni ssh-agent'ga qo'shish_

1.  PowerShell'ni ochamiz.
2.  ssh-add c:/Users/YOU/.ssh/id_ed25519 mana shu komandani kiritamiz

> Users va YOU degan joyga o'zingizning kompyuteringizdagi fayl nomlarini kiritishingiz esingizdan chiqmasin!

## [](https://dev.to/muhammad_khodjaev/ssh-kalitini-githubcomga-qoshish-heh#4bosqich-githubcomga-kirib-ssh-ni-qoshish)4-bosqich  _Github.com'ga kirib SSH ni qo'shish_

1.  PowerShell'ni ochamiz
2.  cd .ssh qilib SSH joylashgan faylga kiramiz
3.  code . qilib VS Code'da ochib olamiz
4.  Kirib .pub bilan tugagan faylga kiramiz va nima bor bo'lsa ushani ko'chirib olamiz (oxirida sizning Github'ga ulangan pochta manzilingiz bo'lishi kerak)
5.  Github.com'ga kiramiz va settings qismiga o'tib SSH and GPG keys bo'limiga kiramiz
6.  NEW SSH key'ni bosamiz
7.  Title degan joyga SSH uchun nom beramiz, masalan Muhammad's SSH Key
8.  Key degan joyga .pub bilan tugagan fayldan olgan uzuuun yozuvimizni paste qilamiz
9.  Add SSH key'ni bosamiz
10.  Sizdan github profilingizning parolini so'rashi mumkin, uni kiritamiz

----------

Tabriklayman, siz SSH'ni muvaffaqiyatli qo'shdingiz!