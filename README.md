# 🌍 Traversal Core – ASP.NET Core MVC Seyahat Yönetim Sistemi

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-purple.svg)
![.NET](https://img.shields.io/badge/.NET-6%2F7%2F8-blueviolet.svg)
![Entity Framework](https://img.shields.io/badge/EF%20Core-Code%20First-orange.svg)
![SignalR](https://img.shields.io/badge/SignalR-Real--Time-green.svg)
![Status](https://img.shields.io/badge/Status-Completed-success.svg)

**Traversal Core**; kullanıcıların yurt içi ve yurt dışı tur paketlerini inceleyip rezervasyon yapabildiği, rehberlerin turlarını yönettiği ve yöneticilerin tüm sistemi kontrol ettiği; **N-Katmanlı Mimari**, **SignalR** ve **REST API** entegrasyonuyla geliştirilmiş modern bir seyahat yönetim sistemidir.

---

## 🚀 Öne Çıkan Özellikler

- **🗺️ Tur Yönetimi:** Yurt içi ve yurt dışı tur paketlerinin tam CRUD yönetimi.
- **⚡ Gerçek Zamanlı Bildirimler:** SignalR ile anlık mesaj ve istatistik güncellemeleri.
- **🔐 Kimlik & Yetkilendirme:** ASP.NET Core Identity ile rol tabanlı erişim kontrolü (Admin, Rehber, Kullanıcı).
- **📊 Admin Dashboard:** Sistem genelindeki tur, kullanıcı ve rezervasyon verilerini özetleyen istatistik paneli.
- **📬 İletişim Modülü:** Kullanıcıların mesaj gönderebildiği ve Admin'in cevaplayabildiği dahili mesajlaşma sistemi.
- **🌐 REST API Entegrasyonu:** Ayrı bir API katmanı üzerinden veri tüketimi (SignalRApi, SignalRApiForSql).
- **🗂️ DTO Katmanı:** View ve API arasında temiz veri transferi için ayrı DTO (Data Transfer Object) yapısı.
- **📧 E-posta Desteği:** Rezervasyon ve bildirim e-postalarının gönderimi.

---

## 👥 Panel Yapısı ve Özellikler

### 🛡️ Admin Paneli
- **Dashboard:** Toplam tur, kullanıcı, rezervasyon ve gelir verilerini özetleyen istatistik kartları.
- **Tur Yönetimi:** Tur oluşturma, düzenleme, silme ve listeleme (tam CRUD).
- **Kullanıcı & Rol Yönetimi:** ASP.NET Core Identity üzerinden kullanıcı rolleri ve yetki atamaları.
- **Rezervasyon Yönetimi:** Tüm rezervasyonları görüntüleme, durum güncelleme.
- **Mesaj Yönetimi:** Gelen kullanıcı mesajlarını okuma ve yanıtlama.
- **Duyuru Yönetimi:** Sisteme duyuru ekleme ve yayınlama.

### 🧭 Rehber / Kullanıcı Paneli
- **Rezervasyon Takibi:** Alınan rezervasyonları listeleme ve durumlarını takip etme.
- **Profil Yönetimi:** Kişisel bilgileri güncelleme ve şifre değiştirme.
- **Mesajlaşma:** Admin ile dahili mesajlaşma modülü.

### 🌐 Genel Web Sitesi
- **Tur Listesi:** Tüm aktif tur paketlerini dinamik olarak listeleme ve detay görüntüleme.
- **Rezervasyon Formu:** Tur seçimi ve rezervasyon oluşturma akışı.
- **İletişim Sayfası:** Kullanıcıların mesaj gönderebildiği form.

---

## 🛠️ Teknik Mimari ve Kullanılan Teknolojiler

| Alan | Teknoloji / Araç |
| :--- | :--- |
| **Framework** | ASP.NET Core MVC |
| **Veritabanı & ORM** | MS SQL Server, Entity Framework Core (Code First) |
| **Gerçek Zamanlı İletişim** | SignalR |
| **Kimlik Doğrulama** | ASP.NET Core Identity |
| **API Katmanı** | ASP.NET Core Web API (SignalRApi, SignalRApiForSql) |
| **Mimari Desen** | N-Katmanlı Mimari (N-Layer Architecture) |
| **Veri Transferi** | DTO (Data Transfer Object) Pattern |
| **UI & Frontend** | Bootstrap, jQuery, HTML/CSS/JS |
| **Mapping** | AutoMapper |

---

## 🗂️ Proje Mimarisi

```
TraversalCoreProje/
│
├── BusinessLayer/              # İş kuralları ve servis sınıfları
│   ├── Abstract/               # Servis arayüzleri (IService)
│   └── Concrete/               # Servis implementasyonları
│
├── DataAccessLayer/            # Veritabanı erişim katmanı
│   ├── Abstract/               # Repository arayüzleri (IRepository)
│   ├── Concrete/               # EF Core DbContext & Implementasyonlar
│   └── Migrations/             # Code-First migration dosyaları
│
├── DTOLayer/                   # Data Transfer Object sınıfları
│   └── DTOs/                   # View ve API için DTO modelleri
│
├── EntityLayer/                # Varlık (entity) sınıfları
│   └── Concrete/               # Tour, Reservation, AppUser vb.
│
├── SignalRApi/                 # Gerçek zamanlı veri için Web API
│   └── Controllers/
│
├── SignalRApiForSql/           # SQL veritabanına bağlı SignalR API
│   └── Controllers/
│
├── SignalRConsume/             # SignalR API tüketimi (istemci tarafı)
│
└── TraversalCoreProje/         # Ana MVC Web Uygulaması
    ├── Areas/
    │   └── Admin/
    │       ├── Controllers/    # Admin CRUD controller'ları
    │       └── Views/
    ├── Controllers/            # Genel web sitesi controller'ları
    ├── Models/                 # View model sınıfları
    ├── Views/                  # Razor View (.cshtml) dosyaları
    │   ├── Default/            # Ana sayfa görünümleri
    │   └── Shared/             # Layout ve partial view'lar
    └── wwwroot/                # Statik dosyalar (CSS, JS, görseller)
```

---

## 🔐 Kullanıcı Rolleri ve Yetkilendirme

Giriş yapıldığında kullanıcının rolüne göre otomatik yönlendirme yapılır:

| Rol | Yönlendirme | Erişim |
| :--- | :--- | :--- |
| **Admin** | `/Admin/Dashboard` | Tüm paneller, CRUD işlemleri ve kullanıcı yönetimi |
| **Rehber / Kullanıcı** | `/Default/Index` | Profil, rezervasyon takibi ve mesajlaşma |
| **Yetkisiz** | `/Account/Login` | Yalnızca genel web sitesi sayfaları |

---

## ⚡ SignalR Gerçek Zamanlı Özellikler

```
1. SignalRApi veya SignalRApiForSql → Veritabanından anlık veri çeker
        ↓
2. SignalRConsume → API'den veriyi tüketir
        ↓
3. Admin Dashboard veya ilgili sayfa → Gerçek zamanlı olarak güncellenir
        ↓
4. Kullanıcıya anlık istatistik, bildirim veya mesaj gösterilir
```

---

