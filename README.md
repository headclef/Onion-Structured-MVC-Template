<!DOCTYPE html>
<html lang="tr">
<head>
<meta charset="UTF-8">
</head>

<body>
<!-- Proje Başlığı -->
<div style="text-align:center; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h1 style="font-size:3rem;">
Soğan Mimarisi ile Yapılandırılmış Proje Taslağı
</h1>
</div>
</div>

<!-- Proje Açıklaması -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Proje Açıklaması
</h2>
<p style="font-size:1.75rem;">
.NET 9.0 teknolojisi ile geliştirilmiş, sıfırdan proje geliştirme işlemlerinin önüne geçmek için 
toplamda beş katmandan tasarlanmış, olabildiğince basitleştirilmiş bir proje taslağıdır.
</p>
</div>
</div>

<!-- Proje Durumu -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Proje Durumu
</h2>
<p style="font-size:1.75rem;">
Proje taslağı geliştirme aşamasındadır.
</p>
</div>
</div>

<!-- Kurulum Talimatları -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Kurulum Talimatları
</h2>
<p style="font-size:1.75rem;">
GitHub 'dan projeyi kurmak için aşağıdaki adımları izleyin:
</p>
<ol style="font-size:1.75rem; margin:0px; padding:0px;">
<li>Terminal veya Komut İstemcisi'ni açın.</li>
<li>Aşağıdaki komutu kullanarak projeyi klonlayın:
<pre style="margin-top:5px; margin-bottom:5px;"><code>git clone https://github.com/headclef/Onion-Structured-MVC-Template.git</code></pre>
</li>
<li>Proje dizinine gidin:
<pre style="margin-top:5px; margin-bottom:5px;"><code>cd Onion-Structured-MVC-Template</code></pre>
</li>
<li>Gerekli bağımlılıkları yüklemek için aşağıdaki komutu çalıştırın:
<pre style="margin-top:5px; margin-bottom:5px;"><code>dotnet restore</code></pre>
</li>
<li>Projeyi çalıştırmak için:
<pre style="margin-top:5px; margin-bottom:5px;"><code>dotnet run</code></pre>
</li>
</ol>
</div>
</div>

<!-- Kullanım Kılavuzu -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Kullanım Kılavuzu
</h2>
<p style="font-size:1.75rem;">
Geliştirecek olduğunuz projenin ön yüzünü ve arka yüzünü tanımlayabileceğiniz yapıyı elde etmiş olursunuz.
Bu yapıyı kullanarak projenizi geliştirebilir ve yönetebilirsiniz. Dilerseniz proje yapısını değiştirebilir
ve kendi projenize uygun hale getirebilirsiniz.
</p>
</div>
</div>

<!-- Özellikler -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Özellikler
</h2>
<p style="font-size:1.75rem;">
Proje taslağı, aşağıdaki özelliklere sahiptir:
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li>Soğan Mimarisi</li>
<li>Entity Framework Core</li>
<li>Bağımlılık Enjeksiyonu</li>
<li>Repository Pattern</li>
<li>Unit of Work Pattern</li>
<li>AutoMapper</li>
<li>Logging</li>
<li>Global Exception Handling</li>
<li>Global Response Wrapper</li>
<li>Unit Test</li>
</ul>
</div>
</div>

<!-- Katmanlar -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Katmanlar
</h2>
<p style="font-size:1.75rem;">
Proje soğan mimarisini temel almıştır. Bu yüzden katmanları aşağıdaki gibi olup, asla içeriden dışarıya
doğru bağımlılık olmamalıdır.
<div style="text-align:center;">
<img src="images/SoganMimarisi.png" style="max-width: 100%; height:auto;" />
</div>
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li>Core</li>
<ul>
<li>
<p>
Domain:
<br />
Bu katman, projenin temel yapı taşlarını içerir ve projenin diğer katmanlarına 
bağımlı olmamalıdır.
<pre style="margin-top:5px; margin-bottom:5px;"><code>public class BaseEntity
{
	[Key]
	public int Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}
</code></pre>
</p>
</li>
<li>
<p>
Application:
<br />
Bu katman, projenin iş mantığını içerecek elemanların imzalarını taşır ve projenin 
diğer katmanlarına bağımlı olmamalıdır.
<pre style="margin-top:5px; margin-bottom:5px;"><code>public interface IBaseRepository&lt;T&gt; where T : BaseEntity
{
	Task&lt;ModelResponse&lt;T&gt;&gt; AddAsync(T entity);
	Task&lt;ModelResponse&lt;T&gt;&gt; UpdateAsync(T entity);
	Task&lt;ModelResponse&lt;T&gt;&gt; DeleteAsync(int id);
	Task&lt;ModelResponse&lt;T&gt;&gt; GetByIdAsync(int id);
	Task&lt;IEnumerable&lt;T&gt;&gt; GetAllAsync();
}
</code></pre>
</p>
</li>
</ul>
<li>Infrastructure
</li>
<ul>
<li>
<p>
Infrastructure
<br />
Bu katman, projenin dış dünyayla iletişimini sağlayacak elemanları içerir ve projenin
alt katmanlarına bağımlı olabilir ancak üst katmanlara bağımlı olmamalıdır.
<pre style="margin-top:5px; margin-bottom:5px;"><code>public interface IBaseService
{
	Task&lt;ModelResponse&lt;T&gt;&gt; AddAsync(T entity);
	Task&lt;ModelResponse&lt;T&gt;&gt; UpdateAsync(T entity);
	Task&lt;ModelResponse&lt;T&gt;&gt; DeleteAsync(int id);
	Task&lt;ModelResponse&lt;T&gt;&gt; GetByIdAsync(int id);
	Task&lt;IEnumerable&lt;T&gt;&gt; GetAllAsync();
}
</code></pre>
<pre style="margin-top:5px; margin-bottom:5px;"><code>public class BaseService : IBaseService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogService _logService;
	public BaseService(IUnitOfWork unitOfWork, IMapper mapper, ILogService logService)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logService = logService;
	}
	// Diğer metotlar
}</code></pre>
</p>
</li>
<li>
<p>
Persistence
<br />
Bu katman, projenin veritabanı işlemlerini gerçekleştirecek elemanları içerir ve projenin
alt katmanlarına bağımlı olabilir ancak üst katmanlara bağımlı olmamalıdır.
<pre style="margin-top:5px; margin-bottom:5px;"><code>public class BaseDbContext : DbContext
{
	// Entity 'lerin DbSet 'leri
	public BaseDbContext(DbContextOptions&lt;BaseDbContext&gt; options) : base(options) { }
}
</code></pre>
<pre style="margin-top:5px; margin-bottom:5px;"><code>public class UnitOfWork : IUnitOfWork
{
	private readonly BaseDbContext _context;
	public UnitOfWork(BaseDbContext context)
	{
		_context = context;
	}
	// Diğer metotlar
}
</code></pre>
<pre style="margin-top:5px; margin-bottom:5px;"><code>public class BaseRepository&lt;T&gt; : IBaseRepository&lt;T&gt; where T : BaseEntity
{
	private readonly BaseDbContext _context;
	private readonly IMapper _mapper;
	public BaseRepository(BaseDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	// Diğer metotlar
}
</code></pre>
Bu katmanda elde edilen hatalar, Infrastructure katmanına gönderilerek yönetilir. Bu işlem için
ise;
<pre style="margin-top:5px; margin-bottom:5px;"><code>try
{
	// İşlemler
}
catch (Exception exception)
{
	return new Exception(exception.Message);
}
</code></pre>
Yapısı kullanılır.
</p>
</li>
</ul>
<li>Presentation</li>
<ul>
<li>
<p>
MVC
<br />
Bu katman, projenin kullanıcı arayüzünü oluşturacak elemanları içerir ve projenin
alt katmanlarına bağımlı olabilir ancak üst katmanlara bağımlı olmamalıdır. İyi bir
izolasyon sağlanabilirse bu katmanın, projenin diğer katmanlarına bağımlı olmaması
gerekmektedir.
</p>
</li>
</ul>
<li>Test</li>
<ul>
<li>
<p>
Unit Test
<br />
Bu katman, projenin testlerini içerir ve projenin diğer katmanlarına bağımlı olmamalıdır.
Test için temel sınıf yapısı aşağıdaki gibidir:
<pre style="margin-top:5px; margin-bottom:5px;"><code>using AutoMapper;
using Moq;
using Your.Service.Interface.Location;
public class TestBase
{
	protected readonly Mock&lt;ILogService&gt; _logService = new();
	protected readonly Mock&lt;IMapper&gt; _mapper = new();
	protected readonly Mock&lt;IUnitOfWork&gt; _unitOfWork = new();
	protected readonly &lt;IMailService&gt; _mailService = new();
}
</code></pre>
Ardından, örneğin User nesnesi için oluşturulan bir servis için test sınıfı aşağıdaki gibi olabilir:
<pre style="margin-top:5px; margin-bottom:5px;"><code>using Your.Service.Location;
public class UserTestBase : TestBase
{
	protected UserService CreateUserService()
	{
		return new UserService(
			_unitOfWork.Object, 
			_mapper.Object, 
			_logService.Object, 
			_mailService.Object
		);
	}
}
</code></pre>
Bu yapı sayesinde InsertTests, UpdateTests, DeleteTests, GetByEmailTests, GetByIdTests gibi birden fazla
kontrol yapısını tek çatı altında toplayabilirsiniz. Bu sayede, projenizin testlerini daha kolay bir şekilde
yönetebilirsiniz ve kod tekrarından da kaçınmış olursunuz.
</p>
</li>
</ul>
</ul>
</div>
</div>

<!-- Loglama -->
<div style="text-align:justify;
margin:0px;
padding:0px;
display:flex;
flex-direction:column;
align-items:center;
align-content:center;
font-size:1.75rem;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Loglama
</h2>
<p>
Proje içerisinde loglama işlemleri, Infrastructure katmanında gerçekleştirilir. Bu işlem için
ILogService arayüzü oluşturulur ve bu arayüzü implemente eden LogService sınıfı oluşturulur.
<pre style="margin-top:5px; margin-bottom:5px;"><code>void WriteLog(LogLevel logLevel, string message);</code></pre>
Bu yapı sayesinde hem merkezi ve loglama türüne göre kolay yönetilir bir sisteme sahip olur hem de
loglanan dosyaların boyutuna ve tarihine göre dört adımdan oluşan bir kontrol sistemi ile loglanan
dosyaların yönetimi sağlanır.
<pre style="margin-top:5px; margin-bottom:5px;"><code>private void PrepareLogEnvironment(string logType)
{
    EnsureLogPathExists();           // 1️⃣
    EnsureLogFileExists(logType);    // 2️⃣
    RotateLogFile(logType);          // 3️⃣
    ArchiveOldLogsToZip();           // 4️⃣
}
</code></pre>
</p>
</div>
</div>

<!-- Katkıda Bulunanlar -->
<div style="text-align:justify;
margin:0px;
padding:0px;
display:flex;
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Katkıda Bulunanlar
</h2>
<p style="font-size:1.75rem;">
Bu projeye katkıda bulunanlar:
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li><a href="https://github.com/headclef">headclef</a></li>
</ul>
</div>
</div>
</body>

</html>
