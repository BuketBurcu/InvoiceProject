# Invoice API

Bu proje, fatura verilerini yöneten bir .NET Core Web API uygulamasıdır. 
.NET 8 ile geliştirilmiştir.

## 🛠️ Kurulum ve Çalıştırma

### 1. Repoyu klonlayınız:
```bash
git clone https://github.com/kullaniciadi/InvoiceApi.git
cd InvoiceApi
```

### 2. Paketlerin Yüklenmesi
```bash
dotnet restore
```

### 3. SqLite Database İşlemleri:
- Konfigürasyon Ayarları
appsettings.json dosyasında DefaultConnection ayarını kontrol ediniz:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Data Source=invoice.db"
}
```
- Database Migration işlemleri
Package Manager Consol üzerinden;
```bash
Add-Migration class ismi
Update-database
```
- Sqlite/Sql Server Compact Toolbox extensionu Visual Strudio'da indirerek database'i görüntüleyebilirsiniz.

### 4. SMTP Bilgilerini:
appsettings.json içerisinde bulunan MailSettings alanından bilgileri giriniz:
```bash
"MailSettings": {
  "SmtpServer": "smtp.gmail.com",
  "SmtpPort": 587,
  "SmtpUser": "ornekmail@gmail.com",
  "SmtpPass": "uygulama-sifresi",
  "From": "ornekmail@gmail.com"
}
```

### 5. MailJob:
Projeye entegre edilen MailJob, BackgroundService üzerinden çalışır.
Program.cs dosyasında şu satır ile servis uygulamaya eklenmiştir:

```bash
builder.Services.AddHostedService<MailJob>();
```

Bu nedenle, servis uygulama başlatıldığında otomatik olarak devreye girer.
Manuel bir çağrı yapmaya gerek yoktur.

### 6. Projeyi Çalıştırma:
```bash
dotnet run 
or
Debug > Start Debugging
```
