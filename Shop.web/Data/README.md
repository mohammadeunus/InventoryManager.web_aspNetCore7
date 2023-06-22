### Data/DbContext
DbContext is the bridge between **Entity FrameWork** and **Database**.
> Whatever we are doing in Entity Framework (get data, save data, fetch data or any other opration) is done via **DbContext**.
- **Step01**: Create a class with a meaningful name, indicating it is a DbContext, inside the "Data" folder.
- **Step02(DbContext General Setup)**: By accepting the `DbContextOptions<ApplicationDbContext>` parameter and passing it to the base class constructor, the ApplicationDbContext class can receive the necessary configuration options for connecting to the database. 
    - This allows the DbContext to establish the connection and perform operations on the database using Entity Framework Core.

- **Step03(Create table for the model you want)**: To create tables in the database for your models using Entity Framework Core, you need to define a **DbSet** within the `ApplicationDbContext` class. 
    - Each model in your application should have a corresponding DbSet to map it to a table in the database.  
    - `DbSet<UserModel> Users { get; set; }` // this creates a Users table in the database based on the properties of the UserModel class. 
        - It also ensures that any **DATA ANNOTATION** associated with the properties of the UserModel class are included.
- **FinalStep(Setup Program.cs to use DbContext)**: step involves configuring the Program.cs file to ensure that your application is aware of the connection string from appsettings.json and can utilize the DbContext to interact with the SQL Server. 
    - By adding the necessary configuration to the services section in Program.cs, you enable your application to establish the required connection with the database and utilize the DbContext for performing operations using Entity Framework Core.
  