<!DOCTYPE html>
<html lang="tr">

<!-- Proje Baþlýðý -->
<div style="text-align:center; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h1 style="font-size:3rem;">
Soðan Mimarisi ile Yapýlandýrýlmýþ Proje Taslaðý
</h1>
</div>
</div>

<!-- Proje Açýklamasý -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Proje Açýklamasý
</h2>
<p style="font-size:1.75rem;">
.NET 9.0 teknolojisi ile geliþtirilmiþ, sýfýrdan proje geliþtirme iþlemlerinin önüne geçmek için 
toplamda beþ katmandan tasarlanmýþ, olabildiðince basitleþtirilmiþ bir proje taslaðýdýr.
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
Proje taslaðý geliþtirme aþamasýndadýr.
</p>
</div>
</div>

<!-- Kurulum Talimatlarý -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Kurulum Talimatlarý
</h2>
<p style="font-size:1.75rem;">
GitHub 'dan projeyi kurmak için aþaðýdaki adýmlarý izleyin:
</p>
<ol style="font-size:1.75rem; margin:0px; padding:0px;">
<li>Terminal veya Komut Ýstemcisi'ni açýn.</li>
<li>Aþaðýdaki komutu kullanarak projeyi klonlayýn:
<pre><code>git clone https://github.com/headclef/Onion-Structured-MVC-Template.git</code></pre>
</li>
<li>Proje dizinine gidin:
<pre><code>cd Onion-Structured-MVC-Template</code></pre>
</li>
<li>Gerekli baðýmlýlýklarý yüklemek için aþaðýdaki komutu çalýþtýrýn:
<pre><code>dotnet restore</code></pre>
</li>
<li>Projeyi çalýþtýrmak için:
<pre><code>dotnet run</code></pre>
</li>
</ol>
</div>
</div>

<!-- Kullaným Kýlavuzu -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Kullaným Kýlavuzu
</h2>
<p style="font-size:1.75rem;">
Geliþtirecek olduðunuz projenin ön yüzünü ve arka yüzünü tanýmlayabileceðiniz yapýyý elde etmiþ olursunuz.
Bu yapýyý kullanarak projenizi geliþtirebilir ve yönetebilirsiniz. Dilerseniz proje yapýsýný deðiþtirebilir
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
Proje taslaðý, aþaðýdaki özelliklere sahiptir:
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li>Soðan Mimarisi</li>
<li>Entity Framework Core</li>
<li>Baðýmlýlýk Enjeksiyonu</li>
<li>Repository Pattern</li>
<li>Unit of Work Pattern</li>
<li>AutoMapper</li>
<li>Logging</li>
<li>Global Exception Handling</li>
<li>Global Response Wrapper</li>
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
Proje soðan mimarisini temel almýþtýr. Bu yüzden katmanlarý aþaðýdaki gibi olup, asla içeriden dýþarýya
doðru baðýmlýlýk olmamalýdýr.
<div style="text-align:center;">
<img src="images/SoganMimarisiUpscaled.png" style="max-width: 100%; height:auto;" />
</div>
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li>Core</li>
<ul>
<li>
<p>
Domain:
<br />
Bu katman, projenin temel yapý taþlarýný içerir ve projenin diðer katmanlarýna 
baðýmlý olmamalýdýr.
<pre><code>public class BaseEntity
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
Bu katman, projenin iþ mantýðýný içerecek elemanlarýn imzalarýný taþýr ve projenin 
diðer katmanlarýna baðýmlý olmamalýdýr.
<pre><code>public interface IBaseRepository&lt;T&gt; where T : BaseEntity
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
Bu katman, projenin dýþ dünyayla iletiþimini saðlayacak elemanlarý içerir ve projenin
alt katmanlarýna baðýmlý olabilir ancak üst katmanlara baðýmlý olmamalýdýr.
<pre><code>public interface IBaseService
{
	Task&lt;ModelResponse&lt;T&gt;&gt; AddAsync(T entity);
	Task&lt;ModelResponse&lt;T&gt;&gt; UpdateAsync(T entity);
	Task&lt;ModelResponse&lt;T&gt;&gt; DeleteAsync(int id);
	Task&lt;ModelResponse&lt;T&gt;&gt; GetByIdAsync(int id);
	Task&lt;IEnumerable&lt;T&gt;&gt; GetAllAsync();
}
</code></pre>
<pre><code>public class BaseService : IBaseService
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
	// Diðer metotlar
}</code></pre>
</p>
</li>
<li>
<p>
Persistence
<br />
Bu katman, projenin veritabaný iþlemlerini gerçekleþtirecek elemanlarý içerir ve projenin
alt katmanlarýna baðýmlý olabilir ancak üst katmanlara baðýmlý olmamalýdýr.
<pre><code>public class BaseDbContext : DbContext
{
	// Entity 'lerin DbSet 'leri
	public BaseDbContext(DbContextOptions&lt;BaseDbContext&gt; options) : base(options) { }
}
</code></pre>
<pre><code>public class UnitOfWork : IUnitOfWork
{
	private readonly BaseDbContext _context;
	public UnitOfWork(BaseDbContext context)
	{
		_context = context;
	}
	// Diðer metotlar
}
</code></pre>
<pre><code>public class BaseRepository&lt;T&gt; : IBaseRepository&lt;T&gt; where T : BaseEntity
{
	private readonly BaseDbContext _context;
	private readonly IMapper _mapper;
	public BaseRepository(BaseDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	// Diðer metotlar
}
</code></pre>
Bu katmanda elde edilen hatalar, Infrastructure katmanýna gönderilerek yönetilir. Bu iþlem için
ise;
<pre><code>try
{
	// Ýþlemler
}
catch (Exception exception)
{
	return new Exception(exception.Message);
}
</code></pre>
Yapýsý kullanýlýr.
</p>
</li>
</ul>
<li>Presentation</li>
<ul>
<li>
<p>
MVC
<br />
Bu katman, projenin kullanýcý arayüzünü oluþturacak elemanlarý içerir ve projenin
alt katmanlarýna baðýmlý olabilir ancak üst katmanlara baðýmlý olmamalýdýr. Ýyi bir
izolasyon saðlanabilirse bu katmanýn, projenin diðer katmanlarýna baðýmlý olmamasý
gerekmektedir.
</p>
</li>
</ul>
</ul>
</div>
</div>

<!-- Katkýda Bulunanlar -->
<div style="text-align:justify;
margin:0px;
padding:0px;
display:flex;
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Katkýda Bulunanlar
</h2>
<p style="font-size:1.75rem;">
Bu projeye katkýda bulunanlar:
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li><a href="https://github.com/headclef">headclef</a></li>
</ul>
</div>
</div>

</html>