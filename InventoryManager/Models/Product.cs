// Unused auto-generated using statements removed:
// using InventoryManager.Models; // no need as the file is already inside the "Models" folder
// using Microsoft.AspNetCore.Http.HttpResults; // is not used anywhere in our code

/*
 * This class is called a Model:
 * *****************************
 * In the MVC (Model-View-Controller) pattern:
 * - Model: Represents the application's data and the objects that the application works with
 * - View: Displays the user interface (HTML pages)
 * - Controller: Handles incoming HTTP requests and coordinates the interaction between Models and Views
 *
 * In this project, the "Product" class is our "Model"
 * because it represents the data for a single inventory item.
 */
namespace InventoryManager.Models
{

    /*
     * Product.cs:
     * ***********
     * - This class represents a product in our inventory application
     * - In ASP.NET Core MVC, classes like this are called "Models"
     * - A Model represents the application's data and business objects
     *
     * Entity Framework Core will use this class
     * to create a corresponding table in the SQL Server database.
     * 
     * This Model class "Product" will be mapped by Entity Framework Core 
     * to a database table that stores product records.
     * 
     * By convention, EF Core can create a table based on this entity.
     * The exact table name depends on EF Core conventions and configuration.
     */
    public class Product
    {
        // NOTE: Each property represents data that will later be stored as a column in the database table.
        /*
         * Product Identifier (ID):
         * ***********************
         * Every product needs a unique identifier (ID).
         *
         * By convention, Entity Framework Core recognizes a property named "Id" 
         * as the primary key for the entity.
         *
         * When we create our SQL Server database,
         * this property will become the table's Primary Key.
         * 
         * In many ASP.NET Core applications using EF Core,
         * an integer primary key "int" is a common and standard choice.
         * 
         * Link: https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations
         */
        public int Id { get; set; }

        /*
         * Product Name:
         * *************
         * Stores the name of the product.
         *
         * Examples:
         *  - Laptop
         *  - Keyboard
         *  - Wireless Mouse
         *
         * Notice that we initialized the property with "string.Empty" 
         * because "nullable reference" types are enabled in this project
         * 
         * NOTE:
         * *****
         * Skipping the string.Empty, C# Compiler will give us this warning "CS8618"
         * Because in .NET 8, "nullable" reference types are enabled by default,
         * so a property with a "string" data type should always contain a value.
         * 
         * In C#, we have 3 options to handle this issue:
         * - Declare it as "nullable":
         *      > public string? Name
         * - Make it "required" Property:
         *      > public required string Name 
         * - Initializing it with "string.Empty":
         *      > public string Name { get; set; } = string.Empty;
         *      
         * Notice that VS will show different fix options:
         * - Declare it as nullable => public string? Name
         * - Required Property => public required string Name 
         * 
         * For this educational project, we use "string.Empty"
         * because it keeps the property non-null
         * and avoids nullable reference warnings when objects are created before a value is assigned.
         * which means: "Initialize this property with an empty string instead of null."
         * 
         * Notice that other applications may choose different approaches depending on their design requirements.
         * 
         * Later, ASP.NET Core MVC validation will handle whether the user entered a meaningful product name.
         * 
         * Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
         * Link: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/null-safety/nullable-reference-types
         */
        public string Name { get; set; } = string.Empty;

        /*
         * Product Price:
         * **************
         * Stores the product's selling price.
         * 
         * Floating-point types represent real numbers that contain fractional parts and decimals.
         * - float with the suffix "F" or "f"
         * - double  no-suffix
         * - decimal with the suffix "M" or "m"
         *
         * We use the decimal data type because it provides
         * better precision for financial and monetary values.
         *
         * Examples:
         *  - 28.99
         *  - 257.50
         *  - 990.00
         *
         * Using decimal helps avoid the rounding errors 
         * that can occur with floating-point data types such as "float" and "double".
         * 
         * In other words, we use "decimal" because it is the recommended type for financial and monetary values.
         * It's also Microsoft's recommendation for currency values.
         * 
         * Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
         */
        public decimal Price { get; set; }

        /*
         * Product Description:
         * ********************
         * Stores optional additional information about the product.
         *
         * Because a description is not required,
         * we use nullable reference type syntax:
         *      
         *      > string?
         *
         * This allows the property to contain a null value when no description is provided.
         */
        public string? Description { get; set; }

        /*
         * Product Quantity:
         * *****************
         * Stores the number of units currently available in inventory.
         *
         * Examples:
         *  - 5
         *  - 15
         *  - 20
         *
         * We use the "int" data type because quantity is represented as a whole number.
         */
        public int Quantity { get; set; }

        /*
         * C# Auto-implemented Properties Concept Review:
         * **********************************************
         * Properties provide a controlled way to access and modify class data.
         * 
         * In C#, an auto-implemented property:
         * 
         *      > public string Name { get; set; }
         *      
         * automatically creates the hidden backing field needed to store the value:
         *  - The "get" accessor reads the value
         *  - The "set" accessor assigns a new value.
         *
         * Example:
         *     product.Name = "Laptop";  // set
         *     Console.WriteLine(product.Name); // get
         *
         * Auto-properties reduce unnecessary code and are commonly used in C# model classes.
         * 
         * Without using the "Auto-implemented" property:
         * First: Declare the private field:
         *      > private string _name;
         * Second: Declare its property:
         * 
         * public string Name
         * {
         *      get
         *         {
         *              return _name;
         *         }
         *      set
         *         {
         *              _name = value;
         *         }
         * }
         * 
         * 
         * Our Java Programming Lectures:
         * ******************************
         * In traditional Java programming, we usually write explicit getter and setter methods:
         * 
         * private String name;
         * 
         * public String getName()
         * {
         *     return name;
         * }
         * 
         * public void setName(String name)
         * {
         *     this.name = name;
         * }
         * 
         * Then we can access them:
         *  product.setName("Laptop");
         *  product.getName();
         *  
         * For more details about C# Essentials, review my repo:
         * https://github.com/anmarjarjees/csharp-essentials/tree/main/Topic5OOP
         * 
         * For more details about Java Programming, review my repo:
         * https://github.com/anmarjarjees/java1-code/tree/main/week12
         */

        /*
         * Entity Framework Core Note:
         * ****************************
         * This class currently only defines the structure of a Product.
         * It does not connect to the database yet.
         *
         * Later in this project:
         * - EF Core will use this class as an Entity.
         * - DbContext will manage database communication.
         * - Migrations will create/update the database schema.
         */
    } // class
} // namespace
