# ASP .NET Core API to Azure Function

This project migrates an existing ASP.NET Core API project to Azure Function.

## Technical Requirements

- The .NET Core backend should be recreated using Azure functions
- The Azure functions will be hosted in the Consumption plan (pay per request)
- The sqlite database will be replaced with Azure MySQL
- The Angular application will be deployed to Azure as a SPA

## Stretch Goals

- Add CI/CD pipeline - build, test and deploy the application to Azure using Github Action
- The Azure functions will be deployed from an ARM (Azure Functions resources) template
- Secure user login using Auth0

## Get Started

You can run this project in Visual Studio (which provides Intellisense). If you decide to run this project in Visual Studio Code, download the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code and follow the instructions below:

### Start the Angular App Server

```bash
cd ClientApp

# Install Angular app dependencies
npm install

# Start the Angular app locally
npm start
```

### Start the .Net Core Application

```bash
# Use NuGet to restore dependencies and project-specific tools
# specified in the `.csproj` file
dotnet restore
dotnet build
dotnet watch run
```
