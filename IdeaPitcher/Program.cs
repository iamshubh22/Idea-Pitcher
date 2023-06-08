using IdeaPitcher.DAL;
using IdeaPitcher.DAL.Implementation;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Service.Implementation;
using IdeaPitcher.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdeaPitcher.DAL.Data;
using IdeaPitcher.Permission;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdeaPitcherUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPostService, PostsService>();
builder.Services.AddTransient<IPublishService, PublishService>();
builder.Services.AddTransient<ITeamMappingService, TeamMappingService>();
builder.Services.AddTransient<IDraftService, DraftService>();
builder.Services.AddTransient<IChangeIdeaService,OwnerChange>();
builder.Services.AddTransient<IEnableDisableUserService, EnableDisable>();
builder.Services.AddTransient<IDraftRepository, DraftRepository>();
builder.Services.AddTransient<ITeamMappingRepository, TeamMappingRepository>();


builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IFactorAuthRepository, FactorAuthRepository>();
builder.Services.AddTransient<IChangeIdeaRepository, ChangeIdeaRepository>();
builder.Services.AddTransient<IEnableDisableUserRepository, EnableDisableUserRepository>();
builder.Services.AddTransient<ISuperAdminRepository,SuperAdminRepository>();
builder.Services.AddTransient<ISuperAdminService, SuperAdminService>();
builder.Services.AddTransient<IFactorAuthService, FactorAuthService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();



builder.Services.AddRazorPages();


builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;


    var userManager = services.GetRequiredService<UserManager<IdeaPitcherUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await IdeaPitcher.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
    await IdeaPitcher.Seeds.DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
    await IdeaPitcher.Seeds.DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
    await IdeaPitcher.Seeds.DefaultUsers.SeedLeaderAsync(userManager, roleManager);

}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();




app.Run();
