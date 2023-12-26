using BlazorView.Pages;
using BlazorView.Services;
using BussinessLayer;
using DataLayer;
using MudBlazor;
using MudBlazor.Services;
using ServiceLayer;

namespace BlazorView
{
    public class Startup
    {
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

            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();

            //services.AddScoped<AuthorManager, AuthorManager>();
            //services.AddScoped<IDb<Author, string>, AuthorContext>();
            //services.AddScoped<AuthorContext, AuthorContext>();

            //services.AddScoped<StateContainer<Book>, StateContainer<Book>>();
            //services.AddScoped<StateContainer<Author>, StateContainer<Author>>();
            //services.AddScoped<StateContainer<Genre>, StateContainer<Genre>>();

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
