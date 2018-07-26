# Dynamic Search Service

This is a .Net WebApi (.NET Framework 4.6.1) that uses the Lambda ExpressionBuilder NuGet package to consume a JSON payload that contains search criteria.

The payload must be in the shape of the following JSON object:

`{
    "SearchCriteria": [
        {
            "FieldName": "DeliveryPostalCode",
            "OperationName": "EqualTo",
            "FieldValue": ["90061"],
            "Type": "String",
            "Connector": "Or"
        },        
        {
            "FieldName": "CustomerName",
            "OperationName": "Contains",
            "FieldValue": ["Head Office"],
            "Type": "String",
            "Connector": "Or"
        }
    ]
}`

There is a companion Angular 5+ application that has a Dynamic Search Form component that builds the request to the service in the shape needed by this service.

[Angular 5 - Dynamic Search Form](https://github.com/kahanu/DynamicSearchForm)

![alt text](https://github.com/kahanu/FullTextSearchWebApi/blob/master/angular-form.jpg "Angular Dynamic Search Form")

# Wide World Importers Database

This WebApi service also makes use of Full Text indexing by using the Wide World Importers database which is freely downloadable. [Download Wide World Importers Database here.](https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0) - download the WideWorldImporters-Full.bak file.

Install this database locally, and change the connection string in the WebApi project, and you should be good to go.