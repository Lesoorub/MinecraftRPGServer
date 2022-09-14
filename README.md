# MMORPG Minecraft server 1.18.2

![](https://img.shields.io/badge/environment-server-orangered?style=flat-square) ![](https://img.shields.io/github/commit-activity/m/Lesoorub/MinecraftRPGServer) ![](https://img.shields.io/github/last-commit/Lesoorub/MinecraftRPGServer)

![Переделай меня](https://github.com/Lesoorub/MinecraftRPGServer/blob/main/images/favicon.png)

# О проекте
- Это кастомная реализация майнкрафт сервера с нуля на языке C#, используя лишь документацию протокола Minecraft (https://wiki.vg)
- Проект еще далеко не закончен и может иметь значительные баги.
- На данный момент в планах очень много всякого разного.

# Установка для Windows
1. Склонируйте репозиторий `git clone https://github.com/Lesoorub/MinecraftRPGServer`
2. Создайте папку для сервера, например `mkdir server`
3. Скопируйте все файлы из папки MinecraftRPGServer/bin/Debug/MinecraftRPGServer.exe в вашу папку, например `copy MinecraftRPGServer/bin/Debug server`

# Запуск
Просто запустите файл MinecraftRPGServer.exe любым удобным для вас способом, например: `start MinecraftRPGServer.exe`

# Настройка
Все настройки сервера распологаются в файле `cfg.json` <br>
Там вы можете указать путь до мира, motd сервера и прочие.

# О плагинах
+ По умолчанию сервер копирует все плагины расположенные в корневой папке plugins к себе
+ Вы можете удалять любые плагины из папки сервера
+ Плагином считается файл с разрешением `.cs` , например WorldGuard.cs или ExamplePlugin.cs
+ У плагина может иметься файл конфигураций с разрешением `.conf`

# Планы
✏️ - В процессе
✔️ - Реализовано
❌ - Не реализовано
⚠️ - Найден баг

+ ✔️ Мир
  + ✔️ Загрузка
  + ✔️ Изменение и синхронизация между пользователями
  + ✏️ Сохранение
+ ✔️ Инвентари
  + ✔️ Инвентарь игрока 
    + ✔️ Перемещение предметов
    + ✏️ Сундук
    + ⚠️ Сумка
+ ✔️ Система существ
  + ⚠️ Синхронизация существ между пользователями
+ ✔️ Здоровье
  + ✔️ Респавн
  + ❌ Влияние чего-нибудь на статистики
+ ❌ Лошади
+ ✔️ Мобы
  + ❌ ИИ
  + ❌ Спавнпоинты
  + ⚠️ Поиск пути
+ ✏️ Система плагинов

# Плагины
+ ❌ WorldEdit
+ ✏️ WorldGuard

# Поддержка проекта
Поддержите проект добрым словом или советом, для этого можете связаться со мной через discord Lesoorub#8255.
Так же любая помощь по коду или ресурсам (иконки, текстур-пак и т.д) приветствуется
