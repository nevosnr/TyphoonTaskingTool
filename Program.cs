using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MudBlazor.Services;
using TyphoonTaskingTool.Components;
using TyphoonTaskingTool.Components.Account;
using TyphoonTaskingTool.Data;
using TyphoonTaskingTool.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();

/*
Two DbContexts are used in this application: ApplicationDbContext for Identity and TmscDbContext for Tasking databases respectivly.
Whilst it may not be the most performant, it provides clear seperation between Identity Core and the Tasking database, 
allowing them both to be manipulated independently. 
*/

var connectionString = builder.Configuration.GetConnectionString("TMSCTasking") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
    .EnableDetailedErrors()
    .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)));

var tmscConnString = builder.Configuration.GetConnectionString("TMSCTasking") ?? throw new InvalidOperationException("Connection string 'TMSCTasking' not found.");
builder.Services.AddDbContextFactory<TmscDbContext>(options =>
    options.UseSqlServer(tmscConnString)
    .EnableDetailedErrors()
    .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)))
    //Added configureWarnings to ignore exception warnings thrown when seeding 'dynamic data'
    ;

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<ILookupRankService, LookupRankService>();
builder.Services.AddScoped<ILookupUnitService, LookupUnitService>();
builder.Services.AddScoped<ILookupTeamService, LookupTeamService>();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
