	�ndirilecek Programlar(Geli�tirme s�resince kullan�lacaklar)
		1.a postgresql.org - dbeaver.io

1- Yeni bir emty solution "Blank Solution" olu�turuldu.

2- Solution i�erisine Common, Library ve Presentation ad�nda 3 adet solution folder eklendi

3- Common klas�r�ne sa� t�k "New Project" , New .Net Core Class Library projesini se�ip, ad�n� MKaymaz_ECommerce.Common olarak belirleyip, Yine Common klas�r ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Common ad�nda fiziksel bir klas�r olu�turup projesinin i�erisine eklendi.

4- Library klas�r�ne sa� t�k "New Project" , New .Net Core Class Library projesini se�ip, ad�n� MKaymaz_ECommerce.Core olarak belirleyip, Yine Library klas�r ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Library ad�nda fiziksel bir klas�r olu�turup projesinin i�erisine eklendi.

5- Library klas�r�ne sa� t�k "New Project" , New .Net Core Class Library projesini se�ip, ad�n� MKaymaz_ECommerce.Model olarak belirleyip, Yine Library klas�r ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Library ad�nda fiziksel bir klas�r olu�turup projesinin i�erisine eklendi.

6- Library klas�r�ne sa� t�k "New Project" , New .Net Core Class Library projesini se�ip, ad�n� MKaymaz_ECommerce.Service olarak belirleyip, Yine Library klas�r ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Library ad�nda fiziksel bir klas�r olu�turup projesinin i�erisine eklendi.

7- Presentation klas�r�ne sa� t�k "New Project" , New "ASP .Net Core Empty" projesini se�ip, ad�n� MKaymaz_ECommerce.API olarak belirleyip, Yine Presentation klas�r ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Presentation ad�nda fiziksel bir klas�r olu�turup projesinin i�erisine eklendi. (Configure for Https kald�r�lacak)

8- Presentation klas�r�ne sa� t�k "New Project" , New "ASP .Net Core Empty" projesini se�ip, ad�n� MKaymaz_ECommerce.Web.UI olarak belirleyip, Yine Presentation klas�r ismini otomatik olarak gelen dosya yolunun sonuna ekleyerek Presentation ad�nda fiziksel bir klas�r olu�turup projesinin i�erisine eklendi. (Configure for Https kald�r�lacak)

Referanslar (Referanslar eklendi�inde katmanlar�n alt�ndaki Dependencies'e sa� t�klan�p referans eklenecek.!!!)
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



Yeni bir tablo olu�turma s�reci
1-) Entity Olu�tur => MKaymaz_ECommerce.Model.Entities
2-) EntityMap Olu�tur => MKaymaz_ECommerce.Model.Maps+
3-) Migration Olu�tur
	3.1-) Api pprojesini set startup Project olarak ayarla
	3.2-) Package Manager Console �zerinde Default proje olarak BilgeAdamBlog.Model katman�n� set et
	3.3-) Add Migration <MigrationAd�>
	3.4-) Updata Database
4-) Repository Olu�tur => MKaymaz_ECommerce.Service
5-) Repository'leri MKaymaz_ECommerce.API projesi i�indeki Startup i�inde DependencyInjection Container'�na ekle 
6-) Dto'lar� olu�tur => MKaymaz_ECommerce.Common.Dtos
7-) AutoMapper Mapping => MKaymaz_ECommerce.API.Infrastructor.Mapper
8-) Controller Olu�turuyoruz...