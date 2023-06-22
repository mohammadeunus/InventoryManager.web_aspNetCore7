## Model 
 
- Model is a normal c# class that contains business logic
	- This logic is used to handle the data passed between the database and the user interface (UI).
- For each table in database there will be a model
	- And the properties inside those class will represent columns in the database.#### Model 

### Data Annotation
data annotation is a feature that allows you to apply validation rules to model properties. 
- `using System.ComponentModel.DataAnnotations;` is added in the file to be able to use the functionality of the data annotation.
- we have applied different data annotations to the properties:

    - `[Required]` ensures that the FirstName and LastName properties are not empty.
    - `[EmailAddress]` validates that the Email property is a valid email address.
    - `[Range(18, 100)]` specifies that the Age property must be between 18 and 100.
