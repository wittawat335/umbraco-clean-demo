using umbraco_clean_demo.Application;
using umbraco_clean_demo.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
	.Build();

builder.Services.InjectServices().InjectInfra();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

app.MapControllerRoute(
    name: "MigrateRoute",
    pattern: "migrate/{action=Index}",
    defaults: new { controller = "Migrate" });

await app.RunAsync();
