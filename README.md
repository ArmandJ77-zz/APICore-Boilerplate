# APICore-Boilerplate
An ASP.NET core API boilerplate which is based on key design principles such as:

* Domain Driven Design
* SOLID principles
* Repository Pattern
* UnitOfWork Pattern

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


