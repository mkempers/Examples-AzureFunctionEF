# Example of an Azure Function using Entity Framework

I had some trouble finding an example of how to use an Azure function which used entity framework, thus I created it. The example is a Http triggered Azure function which returns all customers from the AdventureWorks database.

## Get started
1. Create the AdventureWorks database. You have two options. Create a new database with the AdventureWorks demo data straight from the Azure Portal. Or deploy the SQL project in this solution (do not forget to create dummy data).
2. Copy the ADO.NET (SQL authentication) connection string from the connectionstring settings of your Azure SQL database.
3. Rename 'local - Copy.settings.json' to 'local.settings.json' and paste in your connectionstring at the placeholder.
4. Set AzureFunctionEF.Function as startup project and run the function in Visual Studio.

## Take note!
* Project AzureFunctionEF.Data is the EF project. I generated the EF model. After generation I extended the generated dbcontext class 'AzureFunctionEF.Function' in file 'AdventureWorksEntitiesExt.cs'. It provides an extra constructor which let you pass in the ADO.net connectionstring.
* Also in this file the metadata constant is set. You can find the right value for this constant in the connectionstring in the app.config of your EF project. It is usually the first part of the connectionstring. Do not forget to omit 'metadata='!
* For deployement to Azure you also have to add your connectionstring to the Azure function appsettings!
