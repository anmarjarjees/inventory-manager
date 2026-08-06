/*
 * We need to add the necessary using statements.
 * Based on what we have in the default Controller file "HomeController":
 * 
 * - using Microsoft.AspNetCore.Mvc;
 * The controller base class "Controller" is provided by ASP.NET Core MVC,
 * without this namespace, C# does not know what "Controller" means
 */
using Microsoft.AspNetCore.Mvc;

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
    } // class
} // namespace
