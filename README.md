# 📦 ECommerceWithCQRS

CQRS (Command-Query Responsibility Segregation) mimarisi kullanılarak oluşturulmuş modüler, katmanlı yapıya sahip örnek bir e-ticaret uygulamasıdır. Projede MediatR, FluentValidation, Entity Framework Core, Cache mekanizmaları ve SOLID prensipleri etkin şekilde uygulanmıştır.

## 🏗️ Proje Yapısı

```
ECommerceWithCQRS
├── src/
│   ├── core/
│   │   ├── Core.Application/          # Uygulama servisleri, pipeline davranışları
│   │   ├── Core.CrossCuttingConcerns/ # Hata yönetimi, cache vb.
│   ├── infrastructure/
│   │   ├── Persistence/               # EF Core, veritabanı context, migration
│   │   └── Security/                  # Token, hashing işlemleri
│   ├── webapi/
│   │   └── WebAPI/                    # API controller'ları ve startup konfigürasyonu
├── ProjectTemplateCqrs.sln           # Solution dosyası
```

## 🔧 Kullanılan Teknolojiler

- .NET 7+
- MediatR
- FluentValidation
- Entity Framework Core
- PostgreSQL
- Redis
- AutoMapper
- JWT Authentication
- CQRS + Pipeline Behaviors (Validation, Caching, Logging, Authorization)
- Onion Architecture

## 🚀 Kurulum & Çalıştırma

### 1. Bağımlılıkları yükleyin

```bash
dotnet restore
```

### 2. Veritabanını güncelleyin

Connection string'i `appsettings.json` içerisinde tanımladıktan sonra migration'ları uygulayın:

```bash
dotnet ef database update --project src/infrastructure/Persistence/
```

### 3. Uygulamayı başlatın

```bash
dotnet run --project src/webapi/WebAPI/
```

API Swagger UI ile test edilebilir:  
`https://localhost:5001/swagger`

## 📌 Öne Çıkan Özellikler

- **CQRS Pattern**: Okuma ve yazma işlemleri ayrılarak yönetilir.
- **Pipeline Behaviors**: Authorization, Caching, Logging, Validation, Performance gibi işlemler MediatR pipeline’da soyutlanmıştır.
- **Katmanlı Mimari**: Core, Application, Infrastructure ve Web API katmanları arasında gevşek bağlılık sağlanmıştır.
- **Exception Middleware**: Özel hata yönetimi pipeline üzerinde middleware olarak entegre edilmiştir.

## 📄 Katkı Sağlamak

Projeye katkıda bulunmak için:

1. Fork'layın
2. Yeni bir dal (branch) oluşturun
3. Geliştirme yapıp commit'leyin
4. Pull Request gönderin ✅

## 🧑‍💻 Geliştirici

**Esra Yılmaz**  
GitHub: [@esryllmz](https://github.com/esryllmz)
