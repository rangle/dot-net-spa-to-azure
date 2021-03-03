# Angular SPA

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.0.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Deployment

1. Run the following commands in Azure CLI to create an Azure Blob Storage Account to host the Angular SPA

```bash
# Login
az login
az account set --subscription <YOUR_SUBSCRIPTION_ID>

# Create a Resource Group
az group create --name <RESOURCE_GROUP_NAME> --l <LOCATION>

# Create a Storage Account to store the Angular SPA
az storage account create --name <STORAGE_ACCOUNT_NAME> -g <RESOURCE_GROUP_NAME> --sku Standard_RAGRS

# Enable static site hosting for this Storage Account
# For SPA all the URLs pointing to non-existing resources should be routed to the `index.html` page
az storage blob service-properties update --account-name <STORAGE_ACCOUNT_NAME> --static-website --index-document index.html --404-document index.html
```

If static site hosting is enabled successfully, your storage account will have a blob container named $web that you can access via this URL:
`https://<STORAGE_ACCOUNT_NAME>.z13.web.core.windows.net/`

2. Run `yarn build && yarn deploy` to deploy the Angular SPA to Azure Blob Storage
