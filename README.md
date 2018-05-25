# APICore-Boilerplate
An ASP.NET core API boilerplate which is based on key design principles such as:

* Domain Driven Design
* SOLID principles
* Repository Pattern
* UnitOfWork Pattern

# What's in the box?

* ASP.NET Core 2  
* Swashbuckle for swagger support
* FluentValidate for validation
* Nunit for testing
* Cake for the build scripting

# Build Steps
Cake build configuration has been added to execute the following:

* Clean bin/obj dir 
* Build Solution
* Restore nuget packages
* Run Unit Tests
* Run Integration Tests
* Publish to API/bin/Release

To execute the cake build script execute the following:

* Navigate to root directory
* Open powershell or use VS Code's powershell extension
* execute ./build.ps

# To install CLI template
The solution supports .NET Core CLI template, to install:

*open cmd 
*to install run 
```
dotnet new --install "[customDirectory]\APICore-BoilerPlate"
```
*To start a new project with this template
```
dotnet new boilerplate --name [your solution name]
```

To uninstall the template simply execute 
```
dotnet new --uninstall "[customDirectory]\APICore-BoilerPlate"
```


