﻿using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Notes.Identity.Data;
using Notes.Identity.Models;

namespace Notes.Identity;

public class Startup
{
    public IConfiguration AppConfiguration { get; }

    public Startup(IConfiguration appConfiguration)
    {
        AppConfiguration = appConfiguration;
    }
    
    

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = AppConfiguration.GetValue<string>("DbConnection");

        services.AddDbContext<AuthDbContext>(options => options.UseSqlite(connectionString));
        services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = "Notes.Identity.Cookie";
            config.LoginPath = "/Auth/Login";
            config.LogoutPath = "/AuthLogout";
        });

        services.AddControllersWithViews();
        
        services.AddIdentityServer()
            .AddAspNetIdentity<AppUser>()
            .AddInMemoryApiResources(Configuration.ApiResources)
            .AddInMemoryIdentityResources(Configuration.IdentityResources)
            .AddInMemoryApiScopes(Configuration.ApiScopes)
            .AddInMemoryClients(Configuration.Clients)
            .AddDeveloperSigningCredential();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Styles")),
            RequestPath = "/styles"
        });
        app.UseRouting();
        app.UseIdentityServer();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}