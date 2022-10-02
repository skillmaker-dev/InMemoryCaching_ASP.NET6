

## Using in memory caching in ASP.NET6 and demonstrating it using a Blazor webserver application.

## We have 3 methods to load Employees:
- GetEmployees() : Load data synchronously
- GetEmployeesAsync() : Load asynchronously
- GetEmployeesCached() : Load asynchronously and cached when available

In ```FetchData.razor``` change the method in ```OnInitializedAsync()``` to compare between different data loading ways.
<br/><br/>
You can see that the first time we load data it will take 3 seconds to be available, Then on the second try, We will get data instantly, This is because we are loading the data from the database in the first time and then saving it to the cache, In the next times we are getting data directly from the memory cache.

#### Note: If your data is changing overtime then don't cache it for too long.
