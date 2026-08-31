/*
 * We need to add the necessary using statements.
 * Based on what we have in the default Controller file "HomeController":
 * 
 * - using Microsoft.AspNetCore.Mvc;
 * The controller base class "Controller" is provided by ASP.NET Core MVC,
 * without this namespace, C# does not know what "Controller" means
 * 
 * -using InventoryManager.Models;
 * We need to access the "Product" model when we submit the data to our database,
 * so we need to use the "Model" folder that contains the "Product.cs"
 */
using Microsoft.AspNetCore.Mvc;
using InventoryManager.Models;

namespace InventoryManager.Controllers
{
    /*
     * ProductsController:
     * *******************
     * This controller manages product-related HTTP requests.
     *
     * In ASP.NET Core MVC:
     * - Controllers receive HTTP requests.
     * - They coordinate application logic.
     * - They return Views or other HTTP responses.
     *
     * This controller is responsible for Product-related operations.
     */

    /*
     * Also as shown in the "HomeController",
     * Our custom controller class "ProductsController" must inherit from the "Controller" base class
     * 
     * Remember what we have learned before about using OOP terminologies in different programming languages, for example:
     * - In PHP: Child class inherits from Parent class
     *      > We use the keyword/function: parent()
     * - In Java: Subclass inherits from Superclass
     *      > We use the keyword/function: super()
     * - In C#: Derived class inherits from Base class
     *      > We use the keyword/function: base()
     *      
     * Below we have:
     *      > ProductsController == inherits ==> Microsoft.AspNetCore.Mvc.Controller
     * 
     * By inheriting from Controller, this class receives MVC helper methods such as:
     * - View()
     * - Redirect()
     * - NotFound()
     * - BadRequest()
     * 
     * These methods allow action methods to return different HTTP responses.
     */
    public class ProductsController : Controller
    {
        /*
         * As we have in the "HomeController",
         * we need to add our first Action method "Index()",
         * so I copied the method from the "HomeController":
         * 
         * Index action:
         * *************
         * The default action method for this controller.
         * By convention, this action is executed when users navigate to /Products.
         * 
         * By MVC convention:
         * ******************
         * - URL:
         *      > /Products
         * - Maps to:
         *      > ProductsController => Index()
         *
         * So this Index() method:
         * - In "HomeController" => Displays the application's home page
         * - In our current "ProductsController" => Displays the products page
         * 
         * Later this action will display the list of products retrieved from the database.
         */
        // Displays the products page:
        public IActionResult Index()
        {
            return View();
        } // Index()


        /*
         * HTTP GET: [HttpGet]
         * URL: /Products/Details/{id}
         *
         *      > Displays information about a single product.
         *      > The product ID is supplied through the URL.
         *
         * Example:
         *      /Products/Details/5
         *
         * This action will retrieve the product
         * from the SQL Server database using Entity Framework Core.
         * 
         * Notice the use of the ASP.NET annotation [HttpGet]
         * [HttpGet] => used for GET request => Display/View/Read Data only
         */
        [HttpGet]
        public IActionResult Details(int? id)
        {
            /*
             * Defensive Programming:
             * **********************
             * The ID value comes from the URL.
             *
             * A user could manually navigate to:
             *
             *      /Products/Details
             *
             * In this case:
             *      id = null
             *
             * We check this situation before continuing.
             *
             * Link: https://en.wikipedia.org/wiki/Defensive_programming
             * Link: https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/404
             */
            // If no ID was attached to the URL => return HTTP 404 (Not Found)
            if (id == null)
            {
                return NotFound();
                /*
                 * Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound
                 * Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound?view=aspnetcore-10.0#microsoft-aspnetcore-mvc-controllerbase-notfound
                 * */
            }

            /*
             * Database retrieval will be added later:
             *
             * Example:
             *      > var product = _context.Products.Find(id);
             *
             * Then we will pass the Product object to the View:
             *      > return View(product);
             */
            return View();
        } // Details (GET)

        /*
         * HTTP GET: [HttpGet]
         * URL: /Products/Create
         *
         * Displays the empty form used to create a new Product.
         *
         * This method is responsible for:
         * - displaying the form.
         * - No Product has been created yet.
         * - No data is being saved to the database.
         * - The POST action will process the submitted form later
         */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /*
         * HTTP POST: [HttpPost]
         * URL: /Products/Create
         * 
         * This action handles the submitted Create Product form.
         * 
         * The Product object is populated automatically by ASP.NET Core MVC through Model Binding.
         * 
         * At this stage, we are only demonstrating form submission.
         * Database saving will be added later when we introduce Entity Framework Core.
         * 
         * Notice the use of the ASP.NET annotation [HttpPost]
         * [HttpPost] => Specifies that this action handles "HTTP POST" requests.
         * 
         * POST requests are commonly used for operations that submit data
         * or cause a state change, such as Create, Edit, Update, or Delete.
         * 
         * -----------------------------------------------------------
         * 
         * CRUCIAL SECURITY NOTE: "Anti-Forgery" Protection:
         * **************************************************
         * The [ValidateAntiForgeryToken] attribute:
         *  > Helps protect against CSRF (Cross-Site Request Forgery) attacks
         *  > Validates that the request contains a valid antiforgery token generated for this application
         * 
         * NOTE:
         * *****
         * When using the ASP.NET Core Form Tag Helper with:
         * 
         *      > <form asp-action="Create" method="post">
         * 
         * ASP.NET Core automatically generates the antiforgery token for the form.
         * 
         * Therefore, we do not need to manually add:
         * 
         *      > @Html.AntiForgeryToken()
         *      
         * in this particular Razor form.
         * 
         * However, @Html.AntiForgeryToken() can be used 
         * when an antiforgery token must be generated manually.
         * 
         * 
         * How to code it:
         * ***************
         * We need to add/use [ValidateAntiForgeryToken] on all "POST" actions 
         * that perform "State-Changing" operations:
         * 
         * - Create:
         * 
         *      [HttpPost]
         *      [ValidateAntiForgeryToken]
         *      public IActionResult Create(Product product)
         *      
         * 
         * - Edit:
         * 
         *      [HttpPost]
         *      [ValidateAntiForgeryToken]
         *      public IActionResult Edit(Product product)
         *      
         * 
         * - Delete:
         * 
         *      [HttpPost]
         *      [ValidateAntiForgeryToken]
         *      public IActionResult DeleteConfirmed(int id)
         *      
         * And also inside the <form> (Refer to the view pages):
         *      
         *      > @Html.AntiForgeryToken()
         * 
         * To summarize:
         * *************
         *  > [ValidateAntiForgeryToken] = Validates the antiforgery token on the server => in controller
         *  > ASP.NET Core Form Tag Helper => Automatically generates an antiforgery token for POST form
         *      >> NO NEED FOR: @Html.AntiForgeryToken() = client-side token => in form
         *  > Used for POST actions that perform state-changing operations (Create, Edit, Update, Delete)
         *  > Helps protect against CSRF attacks
         * 
         * To learn more about CSRF:
         * Link: https://cybersecuritynews.com/cross-site-request-forgery/
         * Link: https://owasp.org/www-community/attacks/csrf
         * Link: https://developer.mozilla.org/en-US/docs/Web/Security/Attacks/CSRF
         * Link: https://en.wikipedia.org/wiki/Cross-site_request_forgery
         * Link: https://www.cloudflare.com/learning/security/threats/cross-site-request-forgery/
         * 
         * Microsoft CSRF:
         * Link: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.validateantiforgerytokenattribute?view=aspnetcore-10.0
         * Link: https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-10.0
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            // Database code will be added later.

            return View(product);
        }

        /*
         * HTTP GET: [HttpGet]
         * URL: /Products/Edit/{id}
         * 
         *      > Displays the Edit form for an existing Product
         *      > The product ID is supplied through the URL
         *
         * Example:
         *      /Products/Edit/7
         * 
         * Provides:
         *      id = 7
         *
         * At this stage, Entity Framework Core has not been implemented yet,
         * so this action does not retrieve the Product from SQL Server yet.
         *
         * Later, Entity Framework Core will be used to:
         * - find the Product by its ID
         * - pass the existing Product to the Edit.cshtml view
         *
         * The Edit.cshtml view is strongly typed to:
         *
         *     > @model InventoryManager.Models.Product
         *
         * so it can display the Product's existing property values in the form controls.
         */
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // Defensive programming:
            // If no ID was attached to the URL => return HTTP 404 (Not Found)

            if (id == null)
            {
                return NotFound();
            }

            // Database retrieval will be added later using Entity Framework Core.

            return View();
        }
    } // class
} // namespace
