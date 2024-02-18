using BlazorView.Pages;
using BlazorView.Services;
using BusinessLayer;
using BussinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using MudBlazor.Services;
using ServiceLayer;

namespace BlazorView
{
    public class Startup
    {
        //DbContextOptionsBuilder.EnableSensitiveDataLogging
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();

            services.AddScoped<ErrorModel, ErrorModel>();

            services.AddScoped<StateContainer<Video>, StateContainer<Video>>();

            services.AddScoped<VideoManager, VideoManager>();
            services.AddScoped<VideoContext, VideoContext>();

            services.AddScoped<GenreManager, GenreManager>();
            services.AddScoped<GenreContext, GenreContext>();

            services.AddScoped<AuthorManager, AuthorManager>();
            services.AddScoped<AuthorContext, AuthorContext>();

            services.AddScoped<TagManager, TagManager>();
            services.AddScoped<TagContext, TagContext>();

            services.AddScoped<FormatManager, FormatManager>();
            services.AddScoped<FormatContext, FormatContext>();

            services.AddScoped<IdentityManager, IdentityManager>();
            services.AddScoped<IdentityContext, IdentityContext>();

            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                // Log in required.
                options.SignIn.RequireConfirmedAccount = false; // default
                options.SignIn.RequireConfirmedEmail = false; // default
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
