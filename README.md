# ASP .NET Core API to Azure Function

This project migrates an existing ASP.NET Core API project to Azure Function.

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
