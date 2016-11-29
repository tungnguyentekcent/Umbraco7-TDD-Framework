# Umbraco7-TDD-Framework
### A Sample Framework for Umbraco which supports:
- DI (Dependency Injection)
- TDD (Test-Driven Development)
- ORM (Object-Relational Mapping)

### Main technologies:
- .Net Framework version 4.5.2
- Umbraco CMS version 7.5.4
- Ditto version 0.10.0: the friendly view-model mapper for Umbraco https://github.com/leekelleher/umbraco-ditto
- Castle Windsor version 3.3.0: Inversion of Control (Ioc) container
- AutoMapper version 3.3.1: a convention-based object-object mapper in .NET
- NUnit version 2.6.2: unit testing framework

### Setup:  
* Attach the **Databases/UmbracoTDDFramework.mdf** database to MSSQL server  
* Modify connection string in the **Web.config**  
```xml
<connectionStrings>
  <add name="umbracoDbDSN" connectionString="server=localhost;database=UmbracoTDDFramework;user id=sa;password='sa'" providerName="System.Data.SqlClient" />
</connectionStrings>
```
* Build the solution on Visual Studio  
* Launch the demo website via Visual Studio (press F5) or setup your own site on IIS (point to *Umbraco7-TDD-Framework/src/SampleFramework.Web* folder) to view the sample Home page  

### Login info: http://YourLocalSite/umbraco
- Username: Admin
- Password: Admin1234!
