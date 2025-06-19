# Справочник погрузчиков.
## 🛠️ Технологический стек
- **Backend**: ASP.NET Core 8 (REST API)
- **Frontend**: Vue 3
- **Database**: PostgreSQL
- **Дополнительно**: Swagger, Entity Framework Core

## 🚀 Быстрый старт


### 1. Запуск backend
```bash 
cd ForkliftDirectory.API
dotnet run
```
API будет доступно на:
- Swagger UI: ```https://localhost:5001/swagger```
- Основной endpoint: ```https://localhost:5001/api/forklifts```

## 2. Запуск Frontend
```bash
cd forklift-frontend
npm install
npm run serve
```
Приложение будет доступно по адресу: ```http://localhost:3000/forklifts```


## 3. Импорт базы данных
#### Вариант 1: через pgAdmin 4
- Открыть pgAdmin и создать базу данных с именем ForkliftDirectoryDb.
- Открыть базу, затем Query Tool.
- Загрузить файл ForkliftDirectoryDb.sql и выполнить его.

#### Вариант 2: через терминал
```bash
createdb -U postgres ForkliftDirectoryDb
psql -U postgres -d ForkliftDirectoryDb -f ForkliftDirectoryDb.sql
```
