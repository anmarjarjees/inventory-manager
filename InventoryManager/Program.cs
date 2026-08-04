namespace InventoryManager
{
    /*
     * The main entry point of our ASP.NET Core application.
     * This file is responsible for configuring:
     * - Dependency Injection (registering application services)
     * - Middleware pipeline
     * - Routing
     * - MVC services
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * Creates the application builder:
             * ********************************
             * The builder prepares:
             *  > application configuration
             *  > logging system
             *  > dependency injection container
             *  > hosting environment.
             */
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container:
            /*
             * Registers MVC services into the Dependency Injection container.
             * This enables:
             *  > Controllers
             *  > Razor Views
             *  > Model Binding
             *  > Validation
             *  > MVC-related framework features
             */
            builder.Services.AddControllersWithViews();

            /*
             * Builds the WebApplication object:
             * *********************************
             * After this point, we configure the HTTP request pipeline
             * using middleware components.
             */
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                /*
                 * Enables a friendly error page:
                 * ******************************
                 * instead of exposing technical exception details in production
                 *
                 * Detailed errors are only enabled during development:
                 */
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        } // Main()
    } // class
} // namespace
