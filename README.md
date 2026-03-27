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

## 📷 Ekran Görüntüleri

### 🌐 Genel Web Sitesi
<img width="1896" height="827" alt="Ekran görüntüsü 2026-03-27 052315" src="https://github.com/user-attachments/assets/701a948c-081e-4c6a-ab60-24316b3458d6" />
<img width="1900" height="830" alt="Ekran görüntüsü 2026-03-27 052335" src="https://github.com/user-attachments/assets/13be4d26-7332-4e8b-9ea2-b4b7256ffff9" />
<img width="1896" height="823" alt="Ekran görüntüsü 2026-03-27 052347" src="https://github.com/user-attachments/assets/fa83dae5-2b58-44e1-ab32-555888000c4f" />
<img width="1897" height="826" alt="Ekran görüntüsü 2026-03-27 052404" src="https://github.com/user-attachments/assets/44eb77e5-89f2-405e-acdc-924a8f567ef3" />
<img width="1895" height="823" alt="Ekran görüntüsü 2026-03-27 052416" src="https://github.com/user-attachments/assets/6bd88014-bf70-4448-976c-33a16e391e51" />
<img width="1892" height="835" alt="Ekran görüntüsü 2026-03-27 052445" src="https://github.com/user-attachments/assets/d631e0ef-c368-402d-8a5b-8bf84c5554ab" />
<img width="1896" height="828" alt="Ekran görüntüsü 2026-03-27 052519" src="https://github.com/user-attachments/assets/f8dedeb9-8264-4e26-bf48-5da3bf59148a" />
<img width="1894" height="821" alt="Ekran görüntüsü 2026-03-27 052530" src="https://github.com/user-attachments/assets/0ecb83f3-ed40-4d24-936a-0f0b053fc433" />
<img width="1895" height="835" alt="Ekran görüntüsü 2026-03-27 052543" src="https://github.com/user-attachments/assets/a477f16c-cabb-4b4c-b546-a3d2f89af486" />

### 🛡️ Admin Paneli
<img width="1919" height="822" alt="Ekran görüntüsü 2026-03-27 053438" src="https://github.com/user-attachments/assets/0796f609-93b9-4978-b346-57c06ff89d71" />
<img width="1919" height="827" alt="Ekran görüntüsü 2026-03-27 053456" src="https://github.com/user-attachments/assets/4b3b9d72-cf91-4c7f-8a2d-9a3acd274483" />
<img width="1919" height="824" alt="Ekran görüntüsü 2026-03-27 053509" src="https://github.com/user-attachments/assets/557ecadb-a08c-4d95-a2ea-af996c63984e" />
<img width="1919" height="821" alt="Ekran görüntüsü 2026-03-27 053523" src="https://github.com/user-attachments/assets/31558c77-0457-407a-8b9c-a8e06984dc15" />
<img width="1919" height="828" alt="Ekran görüntüsü 2026-03-27 053537" src="https://github.com/user-attachments/assets/be9c598f-3972-46c7-863f-771b3724650d" />
<img width="1919" height="823" alt="Ekran görüntüsü 2026-03-27 053558" src="https://github.com/user-attachments/assets/7473e7b0-8061-4624-906a-40fa2910e12e" />
<img width="1919" height="823" alt="Ekran görüntüsü 2026-03-27 053637" src="https://github.com/user-attachments/assets/bc429a67-11c3-49ac-a796-addceb5097b5" />
<img width="1919" height="829" alt="Ekran görüntüsü 2026-03-27 053742" src="https://github.com/user-attachments/assets/939436b7-134d-4bb8-a5eb-7bb40729f03d" />
<img width="1919" height="824" alt="Ekran görüntüsü 2026-03-27 053803" src="https://github.com/user-attachments/assets/2a0351d6-7e34-4211-b29b-458db228a1fd" />
<img width="1919" height="823" alt="Ekran görüntüsü 2026-03-27 053817" src="https://github.com/user-attachments/assets/67e6212a-f8cd-4db2-a4a7-5369874f65f3" />
<img width="1917" height="823" alt="Ekran görüntüsü 2026-03-27 053838" src="https://github.com/user-attachments/assets/f9a06f2b-cc59-45b0-a8fc-42e153fb7f18" />



### 🧭 Kullanıcı Paneli

<img width="1919" height="824" alt="Ekran görüntüsü 2026-03-27 054429" src="https://github.com/user-attachments/assets/fcf335e7-90ca-458b-be44-b5df853cf4c5" />
<img width="1919" height="820" alt="Ekran görüntüsü 2026-03-27 054439" src="https://github.com/user-attachments/assets/6c4781b3-8a4d-44fb-a2b5-e2017d1fcd91" />
<img width="1919" height="827" alt="Ekran görüntüsü 2026-03-27 054514" src="https://github.com/user-attachments/assets/02c3dcbc-ce26-4b90-bf60-ac1128b2074a" />
<img width="1919" height="822" alt="Ekran görüntüsü 2026-03-27 054521" src="https://github.com/user-attachments/assets/aa9f5bde-5a95-432a-9df6-85d8b509beac" />
<img width="1918" height="830" alt="Ekran görüntüsü 2026-03-27 054531" src="https://github.com/user-attachments/assets/72f5dc40-c293-465d-aecc-2a1cecb4b0eb" />
<img width="1919" height="824" alt="Ekran görüntüsü 2026-03-27 054537" src="https://github.com/user-attachments/assets/272323d2-896f-4239-9d67-4a2ea34a771d" />
<img width="1919" height="828" alt="Ekran görüntüsü 2026-03-27 054547" src="https://github.com/user-attachments/assets/632c0a3c-6d5f-4608-8e87-d4da9ca873d0" />
<img width="1919" height="824" alt="Ekran görüntüsü 2026-03-27 054556" src="https://github.com/user-attachments/assets/7103ca25-4dfa-4d49-8191-33b067a89424" />
<img width="1919" height="825" alt="Ekran görüntüsü 2026-03-27 054602" src="https://github.com/user-attachments/assets/71b16753-e3b6-4629-8fc6-829e04b8e2e4" />

### 🧭 Kullanıcı Paneli - Dil değişim
<img width="1918" height="821" alt="Ekran görüntüsü 2026-03-27 054610" src="https://github.com/user-attachments/assets/71773a46-81f1-447a-b13f-560cd50c4607" />
<img width="1919" height="822" alt="Ekran görüntüsü 2026-03-27 054623" src="https://github.com/user-attachments/assets/2f7cc425-55ea-4974-89d0-c4e79910f055" />
<img width="1919" height="827" alt="Ekran görüntüsü 2026-03-27 054630" src="https://github.com/user-attachments/assets/0cc8e613-8b03-4f06-a153-9bd1fe67d6c6" />



---

