## DbContext

the deafault connection string is replaced using the servername of our local server which is : "DESKTOP-R0B9L4A\SQLEXPRESS"
- the previous connectionString was 
  ```
  {
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-Shop.web-b5167012-8302-40b5-9746-b6a85d65f556;Trusted_Connection=True;MultipleActiveResultSets=true"
  }"
   ```
- the new connectionString is 
  ```
  "DefaultConnection": "Server=DESKTOP-R0B9L4A\SQLEXPRESS;Database=aspnet-Shop.web-b5167012-8302-40b5-9746-b6a85d65f556;Trusted_Connection=True;MultipleActiveResultSets=true"
  ```
- also add "TrustServerCertificate=True" at the end of the string like the following
  ```
  "DefaultConnection": "Server=DESKTOP-R0B9L4A\SQLEXPRESS;Database=aspnet-Shop.web-b5167012-8302-40b5-9746-b6a85d65f556;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  ```

## Migration
create entity using the following migrations command in Package Manager Console, step2 is for uploading in database
- **step1**: `add-migration AddAdminToDataBase` 
    - Choose a descriptive and concise name for the migration that accurately represents the changes made. so that you and your team will have a clear understanding of the purpose and content of each migration.
- **step2**: check in the migration folder the rulling added with properties correct or not.
- **step3**: `update-database` 
    - to apply the migration in the database, run this command. 
    - make sure the `connectionString` is right.

### previous note
- **step1**:`dotnet ef migrations add createAdmin --project EntityFrameWorkExample --context ApplicationDBContext`
- **step2**:`dotnet ef database update --project EntityFrameWorkExample --context ApplicationDBContext` 
    - since i made a mistake while naming this entity name, i will run the step3 command in PMC. "CreateCourseTable" because thats where admin entity was created.
- **step3**: `dotnet ef database update CreateCourseTable --project EntityFrameWorkExample --context ApplicationDBContext`
    - console will say that reverting migration successuful. if admin table is showing in database, to delete it will enter the following command to delete the last migration
- **step4**: `dotnet ef migrations remove --project EntityFrameWorkExample --context ApplicationDBContext` 
    - to check if its deleted or not check the migrations folder in solutions explorer and search for the migration commit
- **step5**: use fluent API to change the name of the table in OnModelCreatting function
    - build the project, and run the following command
- **step6**:  `dotnet ef migrations add CreateAdmins --project EntityFrameWorkExample --context ApplicationDBContext` 
              `dotnet ef database update --project EntityFrameWorkExample --context ApplicationDBContext` 
    - this is a one to many relationship
        */