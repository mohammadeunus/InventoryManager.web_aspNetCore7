### Controller
- The controller acts as an intermediary between the model and view.
    -  When a user interacts with the application, the controller receives the request, processes it, and coordinates the flow of data between the model and view.

#### ActionResult vs IActionResult
- ActionResult is a result of action methods/pages or return types of action methods/page handlers.
- ActionResult is a parent class of many of the derived classes that have associated helpers.
- The IActionResult return type is appropriate when the mthod returns multiple ActionResults return type are possible in an action. Example
    - the type of the action method is `RedirectToAction`, which means the method is expected to return a RedirectToActionResult object. 
        - However, when the condition is not true, the method is attempting to return a `ViewResult` object by invoking `return View("Index")`. This causes a compile-time error because the declared return type is incompatible with the actual return type.
            - **incompatible** means: means that two entities (such as types, variables, or methods) cannot work together or be used interchangeably due to differences or conflicts between them.

        ```
        public RedirectToAction Index()
        {
            if (true)
            {
                return RedirectToAction("Error");
            }
            return View("Index");//error
        }
        ```
    - but using `IActionResult` as the type of the action method allows for flexible selection of different types of action results based on the condition or logic in the action method.
        ```
        public IActionResult Index()
        {
            if (true)
            {
                return RedirectToAction("Error");
            }
            return View("Index");//error
        }
        ```
### IEnumerable vs List
```
IEnumerable<User> objUserList = _context.Users; // can use any of them
            //var objUserList = _context.Users.ToList();
```
here IEnumerable is preferable because u can perform additional operations or apply filtering on the user data, using IEnumerable<User> 
here is some example
```
IEnumerable<User> usersList = _context.Users;

// Apply filtering
usersList = usersList.Where(u => u.IsActive);

// Apply sorting
usersList = usersList.OrderBy(u => u.LastName);

// Retrieve the data
var userList = usersList.ToList();

return View(userList);
```
