	Ýndirilecek Programlar(Geliþtirme süresince kullanýlacaklar)
		1.a postgresql.org - dbeaver.io

1- Yeni bir emty solution "Blank Solution" oluþturuldu.

2- Solution içerisine Common, Library ve Presentation adýnda 3 adet solution folder eklendi

3- Common klasörüne sað týk "New Project" , New .Net Core Class Library projesini seçip, adýný MKaymaz_ECommerce.Common olarak belirleyip, Yine Common klasör ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Common adýnda fiziksel bir klasör oluþturup projesinin içerisine eklendi.

4- Library klasörüne sað týk "New Project" , New .Net Core Class Library projesini seçip, adýný MKaymaz_ECommerce.Core olarak belirleyip, Yine Library klasör ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Library adýnda fiziksel bir klasör oluþturup projesinin içerisine eklendi.

5- Library klasörüne sað týk "New Project" , New .Net Core Class Library projesini seçip, adýný MKaymaz_ECommerce.Model olarak belirleyip, Yine Library klasör ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Library adýnda fiziksel bir klasör oluþturup projesinin içerisine eklendi.

6- Library klasörüne sað týk "New Project" , New .Net Core Class Library projesini seçip, adýný MKaymaz_ECommerce.Service olarak belirleyip, Yine Library klasör ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Library adýnda fiziksel bir klasör oluþturup projesinin içerisine eklendi.

7- Presentation klasörüne sað týk "New Project" , New "ASP .Net Core Empty" projesini seçip, adýný MKaymaz_ECommerce.API olarak belirleyip, Yine Presentation klasör ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Presentation adýnda fiziksel bir klasör oluþturup projesinin içerisine eklendi. (Configure for Https kaldýrýlacak)

8- Presentation klasörüne sað týk "New Project" , New "ASP .Net Core Empty" projesini seçip, adýný MKaymaz_ECommerce.Web.UI olarak belirleyip, Yine Presentation klasör ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Presentation adýnda fiziksel bir klasör oluþturup projesinin içerisine eklendi. (Configure for Https kaldýrýlacak)

Referanslar (Referanslar eklendiðinde katmanlarýn altýndaki Dependencies'e sað týklanýp referans eklenecek.!!!)
Common		=> ---
Core		=> References(Common)
Models		=> References(Core)
Service		=> References(Core,Common,Model)
API			=> References(Common, Model, Services)
Web.UI		=> References(Common) 


Manage Packages For Solkution eklenecekler

1.  AutoMapper.Extensions.Microsoft.DependencyInjection (7.0.0) => Common,API,WebUI
2.  Microsoft.EntityFrameworkCore 3.1.29 => Model, API,Core
3.  Microsoft.EntityFrameworkCore.Relational 3.1.29 => Model
4.  Microsoft.EntityFrameworkCore.Design 3.1.29 => Model 
5.  Microsoft.EntityFrameworkCore.Tools 3.1.29 => API
6.  Npgsql.EntityFrameworkCore.PostgreSQL 3.1.18 => Model, API
7.  Microsoft.AspNetCore.Http =2.2.2 => Model
8.  Microsoft.Extensions.Configuration.Json 3.1.29 => Model
9.  Microsoft.Extensions.Configuration.EnvironmentVariables 3.1.29 => Model
10. Microsoft.AspNetCore.Authentication.JwtBearer 3.1.29 => API
11. Swashbuckle.AspNetCore.Swagger 6.4.0 => API
12. Swashbuckle.AspNetCore.SwaggerGen 6.4.0 => API
13. Swashbuckle.AspNetCore.SwaggerUI 6.4.0 => API
14. Microsoft.AspNetCore.Mvc.NewtonsoftJson 3.1.29 => API, Web.UI
15. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 3.1.29 => Web.UI
16. Microsoft.VisualStudio.Web.CodeGeneration.Design 3.1.5 => Web.UI
17. Microsoft.Extensions.Http.Polly 3.1.29 => Web.UI
18. Refit.HttpClientFactory 6.3.2 => Web.UI



Yeni bir tablo oluþturma süreci
1-) Entity Oluþtur => MKaymaz_ECommerce.Model.Entities
2-) EntityMap Oluþtur => MKaymaz_ECommerce.Model.Maps+
3-) Migration Oluþtur
	3.1-) Api pprojesini set startup Project olarak ayarla
	3.2-) Package Manager Console üzerinde Default proje olarak BilgeAdamBlog.Model katmanýný set et
	3.3-) Add Migration <MigrationAdý>
	3.4-) Updata Database
4-) Repository Oluþtur => MKaymaz_ECommerce.Service
5-) Repository'leri MKaymaz_ECommerce.API projesi içindeki Startup içinde DependencyInjection Container'ýna ekle 
6-) Dto'larý oluþtur => MKaymaz_ECommerce.Common.Dtos
7-) AutoMapper Mapping => MKaymaz_ECommerce.API.Infrastructor.Mapper
8-) Controller Oluþturuyoruz...