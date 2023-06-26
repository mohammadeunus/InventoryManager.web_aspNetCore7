# BuyingHouseApplication
## Description 

DreamHomeFinder is a web application designed to help users find their dream homes and facilitate the process of buying a house. It provides a user-friendly interface and powerful search functionality to simplify the house hunting experience.


## Project creation

### step1: 
- Serilog: the first configuration you typically set up is the logger configuration, such as Serilog. 
    - add the following configuration in `appsettings.json`
    ```
    "serilog":{
        "writeTo": [
            {
                "Name": "File",
                "Args": {
                    "path": "Logs/web-log-.log",
                    "rollingInterval": "Day"
                }
            }
        ]
    }
    ```
    - add following code in `program.cs` aboce `var app = builder.Build()`
    ```
    builder.Host.UserSerilog((ctx,lc)=>lc)
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(builder.Configuration));
    ```
    - also modify `app.Run()`
    to following
    ```
    try{
        Log.Information("Application Starting Up");
        app.Run();
    }
    catch(Exception ex){
        Log.Fatal(ex, "Application start-up failed");
    }
    finally{
        Log.CloseAndFlush();
    }
    ```
- Autofac: After that, you can proceed with configuring the dependency injection container, such as Autofac.

## Usage

Explain how to use the project, including any important features or functionalities. Provide code examples if necessary.

## Project Structure 

1. Models:
   - PropertyListing: Represents the structure and properties of a property listing, such as address, price, bedrooms, bathrooms, and other relevant details.
   - User: Represents the structure and properties of a user account, including name, email, password, and any additional profile information.

2. Controllers:
   - HomeController: Handles the homepage and basic navigation.
   - PropertyController: Manages property-related actions, such as listing creation, updating, deletion, and displaying property details.
   - UserController: Handles user-related actions, such as registration, login, and managing the user's profile.

3. Views:
   - Home: Contains views related to the homepage and basic navigation elements.
   - Property: Contains views for creating, updating, and deleting property listings, as well as displaying property details.
   - User: Contains views for user registration, login, and managing the user's profile.

4. Services:
   - PropertyService: Contains methods for interacting with the property-related data, such as retrieving property listings, creating new listings, updating existing ones, and deleting listings. This service communicates with the database or data access layer.
   - UserService: Contains methods for user-related operations, including user registration, authentication, and profile management.

5. Data Access Layer:
   - DatabaseContext: Represents the database context and contains DbSet properties for property listings, user accounts, and any other relevant entities. It uses Entity Framework or another ORM to interact with the database.

6. Utilities:
   - AuthenticationManager: Provides methods for user authentication, authorization, and managing user sessions.
   - MappingUtils: Contains helper methods for mapping data models to view models or vice versa.

7. Views and Templates:
   - Shared: Contains shared layout files, partial views, and reusable components.
   - Layout: Defines the overall structure and design of the application's layout, including header, navigation, and footer.

8. Configurations:
   - Startup: Configures the application's services, middleware, and routing.
   - Database: Contains database connection string and configuration settings.

9. Static Assets:
   - CSS: Contains custom stylesheets for the application.
   - Scripts: Contains JavaScript files for client-side functionality.



## Code Explanation
![FolderStructure](/img/FolderStructure.png)

### Program.cs
The Program.cs file in an ASP.NET Core application can be divided into two sections: one for configuring services and another for configuring the HTTP request pipeline.

1.**Services**: services section in the Program.cs file is where you configure and register various services that your application requires. The services section is responsible for setting up the application's dependency injection (DI) container.

- Between `WebApplication.CreateBuilder(args)` and `app.builder.build()`: When we want to register dependencies with the dependency injection container, we will be doing that here.
  - Dependencies: These are external services that the application relies on to function properly, such as databases, email services, external APIs, logging frameworks, and authentication systems.
  - Dependency Injection Container: It manages the creation and resolution of dependencies in an application. The container registers and resolves dependencies, automatically injecting them into classes or components. Autofac is one popular DI container in ASP.NET.
  - `Services.AddControllersWithViews`: This sets up the required services for MVC in an ASP.NET application, enabling the use of controllers and views to handle HTTP requests and generate responses.

2. **Configuring HTTP request pipeline**: 
- A pipeline is a series of stages or middlewares that a web request goes through to be processed and responded to by an application. Each middleware performs a specific task or modification on the request before passing it to the next middleware. The order of the middlewares in the pipeline is important and determines how the request is processed. The last middleware generates the response and returns it to the server.
  >note that most of the middleware will start with `app`, because `app` is instance of `IApplicationBuilder` which is responsible of Configuring the request pipeline.	
  - `app.UseHttpsRedirection()`: This middleware automatically redirects HTTP requests to HTTPS for secure communication. It ensures that all requests are served over a secure connection.
  - `app.UseRouting()`: This middleware handles URL routing and directs requests to the appropriate controller and action in the MVC framework. It determines which code should be executed based on the requested URL pattern.
  - `app.UseAuthorization()`: This middleware is responsible for verifying whether the user is authorized to access the requested resource. It checks the user's credentials, permissions, or roles to determine if they have the necessary privileges.
  - MVC middleware.

### MVC architecture 
![MVCframework](/img/MVCframework.gif)

#### Model 

>Model is a POCO(Plain Old CLR Object) class, Which are not depended on any framework-specific base class.
- Model is normal c# class that contains business logic
	- This logic is used to handle the data passed between the database and the user interface (UI).
- For each table in database there will be a model
	- And the properties inside those class will represent columns in the database.

#### View 
View represents the user interface. It consists of HTML and CSS code
- `_ViewStart.cshtml`
includes common settings for views in an MVC application. It is typically used to specify the layout that should be applied to multiple views, avoiding the need to repeat the same code in each individual view.

##### View/Shared
- `_Layout.cshtml`
Consists of default master page of our apllication
    - Master pages are used to create consistency from page to page in a document.
- `_validationscriptspartial`
    - This contains client-side form validation scripts. By including this partial view in your views, you can reuse the validation scripts and ensure consistent validation behavior across multiple views. It automatically adds the necessary script tags for client-side form validation to the HTML, saving you from writing repetitive code.
        - Client-side form validation refers to the process of validating form input data on the client-side, typically using JavaScript, before the form is submitted to the server. It allows for immediate feedback to the user regarding any errors or invalid data entered into the form fields, without the need to make a round trip to the server.




#### Controller
- The controller acts as an intermediary between the model and view.
    -  When a user interacts with the application, the controller receives the request, processes it, and coordinates the flow of data between the model and view.
- It processes data using the `model` and interacts with the `view` to render the final output. 
- When a user performs an action, such as clicking a button, 
    - the controller receives the request and directs it to an appropriate `action method` from the `controller`. 
    - The controller retrieves the required data from the model, renders the view, and passes the response back to the user.

#### Route 
![MVCrouting](/img/MVCrouting.png)
Routing and controllers in ASP.NET MVC work together to handle incoming requests. 
- Routing determines how URLs are mapped to specific controller actions, 
    - while controllers contain methods (controller actions) that process the requests and generate responses. 
- The routing configuration defines the URL patterns and associates them with the appropriate controller actions. 
- ***!*** </span> If there is no ***controller*** and ***action*** in URL then the default route is set in `program.cs` file as shown below
    ```
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    ```
    

### Data/DbContext
DbContext is the bridge between **Entity FrameWork** and **Database**.
> Whatever we are doing in Entity Framework (get data, save data, fetch data or any other opration) is done via **DbContext**.

  
### appsettings.json
- This is a configuration file that allows you to store application settings in a structured JSON format. 
    - It is commonly used to store configuration settings such as database 
        - connection strings, 
        - API keys, 
        - logging settings, 
        - and other application-specific configurations.
- **ConnectionString**:  There are two types of connection string blocks: default and user-defined.
    - The user-defined block in the connection string helps organize and manage multiple connection strings for different databases or environments. 
        - This is achieved by using multiple appsettings files, 
            - each corresponding to a specific environment e.g. 
                - `appsettings.development.json`,
                - `appsettings.staging.json`,
                - `appsettings.production.json`). 
            - These appsettings files contain the necessary configuration settings, including connection strings, specific to each environment

## License
MIT License: This is a permissive license that allows others to use, modify, and distribute your project, both commercially and non-commercially, as long as they include the original license and copyright notice. It imposes minimal restrictions on users.

## Acknowledgments

Give credit to any individuals or resources that have been instrumental in the development of the project. 