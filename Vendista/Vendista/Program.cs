var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IVendistaService, VendistaService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://178.57.218.210:198") });

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStatusCodePagesWithRedirects("~/home/error/{0}");
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
