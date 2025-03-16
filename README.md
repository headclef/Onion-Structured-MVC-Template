<!DOCTYPE html>
<html lang="tr">

<!-- Proje Ba�l��� -->
<div style="text-align:center; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h1 style="font-size:3rem;">
So�an Mimarisi ile Yap�land�r�lm�� Proje Tasla��
</h1>
</div>
</div>

<!-- Proje A��klamas� -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Proje A��klamas�
</h2>
<p style="font-size:1.75rem;">
.NET 9.0 teknolojisi ile geli�tirilmi�, s�f�rdan proje geli�tirme i�lemlerinin �n�ne ge�mek i�in 
toplamda be� katmandan tasarlanm��, olabildi�ince basitle�tirilmi� bir proje tasla��d�r.
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
Proje tasla�� geli�tirme a�amas�ndad�r.
</p>
</div>
</div>

<!-- Kurulum Talimatlar� -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Kurulum Talimatlar�
</h2>
<p style="font-size:1.75rem;">
GitHub 'dan projeyi kurmak i�in a�a��daki ad�mlar� izleyin:
</p>
<ol style="font-size:1.75rem; margin:0px; padding:0px;">
<li>Terminal veya Komut �stemcisi'ni a��n.</li>
<li>A�a��daki komutu kullanarak projeyi klonlay�n:
<pre><code>git clone https://github.com/headclef/Onion-Structured-MVC-Template.git</code></pre>
</li>
<li>Proje dizinine gidin:
<pre><code>cd Onion-Structured-MVC-Template</code></pre>
</li>
<li>Gerekli ba��ml�l�klar� y�klemek i�in a�a��daki komutu �al��t�r�n:
<pre><code>dotnet restore</code></pre>
</li>
<li>Projeyi �al��t�rmak i�in:
<pre><code>dotnet run</code></pre>
</li>
</ol>
</div>
</div>

<!-- Kullan�m K�lavuzu -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Kullan�m K�lavuzu
</h2>
<p style="font-size:1.75rem;">
Geli�tirecek oldu�unuz projenin �n y�z�n� ve arka y�z�n� tan�mlayabilece�iniz yap�y� elde etmi� olursunuz.
Bu yap�y� kullanarak projenizi geli�tirebilir ve y�netebilirsiniz. Dilerseniz proje yap�s�n� de�i�tirebilir
ve kendi projenize uygun hale getirebilirsiniz.
</p>
</div>
</div>

<!-- �zellikler -->
<div style="text-align:justify; 
margin:0px; 
padding:0px; 
display:flex; 
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
�zellikler
</h2>
<p style="font-size:1.75rem;">
Proje tasla��, a�a��daki �zelliklere sahiptir:
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li>So�an Mimarisi</li>
<li>Entity Framework Core</li>
<li>Ba��ml�l�k Enjeksiyonu</li>
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
Proje so�an mimarisini temel alm��t�r. Bu y�zden katmanlar� a�a��daki gibi olup, asla i�eriden d��ar�ya
do�ru ba��ml�l�k olmamal�d�r.
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
Bu katman, projenin temel yap� ta�lar�n� i�erir ve projenin di�er katmanlar�na 
ba��ml� olmamal�d�r.
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
Bu katman, projenin i� mant���n� i�erecek elemanlar�n imzalar�n� ta��r ve projenin 
di�er katmanlar�na ba��ml� olmamal�d�r.
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
Bu katman, projenin d�� d�nyayla ileti�imini sa�layacak elemanlar� i�erir ve projenin
alt katmanlar�na ba��ml� olabilir ancak �st katmanlara ba��ml� olmamal�d�r.
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
	// Di�er metotlar
}</code></pre>
</p>
</li>
<li>
<p>
Persistence
<br />
Bu katman, projenin veritaban� i�lemlerini ger�ekle�tirecek elemanlar� i�erir ve projenin
alt katmanlar�na ba��ml� olabilir ancak �st katmanlara ba��ml� olmamal�d�r.
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
	// Di�er metotlar
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
	// Di�er metotlar
}
</code></pre>
Bu katmanda elde edilen hatalar, Infrastructure katman�na g�nderilerek y�netilir. Bu i�lem i�in
ise;
<pre><code>try
{
	// ��lemler
}
catch (Exception exception)
{
	return new Exception(exception.Message);
}
</code></pre>
Yap�s� kullan�l�r.
</p>
</li>
</ul>
<li>Presentation</li>
<ul>
<li>
<p>
MVC
<br />
Bu katman, projenin kullan�c� aray�z�n� olu�turacak elemanlar� i�erir ve projenin
alt katmanlar�na ba��ml� olabilir ancak �st katmanlara ba��ml� olmamal�d�r. �yi bir
izolasyon sa�lanabilirse bu katman�n, projenin di�er katmanlar�na ba��ml� olmamas�
gerekmektedir.
</p>
</li>
</ul>
</ul>
</div>
</div>

<!-- Katk�da Bulunanlar -->
<div style="text-align:justify;
margin:0px;
padding:0px;
display:flex;
flex-direction:column;
align-items:center;
align-content:center;">
<div style="width:90%;">
<h2 style="font-size:2.25rem; text-align:center;">
Katk�da Bulunanlar
</h2>
<p style="font-size:1.75rem;">
Bu projeye katk�da bulunanlar:
</p>
<ul style="font-size:1.75rem; margin:0px; padding:0px;">
<li><a href="https://github.com/headclef">headclef</a></li>
</ul>
</div>
</div>

</html>