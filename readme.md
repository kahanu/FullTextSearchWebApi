# Dynamic Search Service

This is a .Net WebApi (.NET Framework 4.6.1) that uses the Lambda ExpressionBuilder NuGet package to consume a JSON payload that contains search criteria. [Lambda ExpressionBuilder](https://github.com/dbelmont/ExpressionBuilder)

The payload must be in the shape of the following JSON object:

```javascript
{
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
}
```

There is a separate Angular 5+ companion application that has a Dynamic Search Form component that builds the request to the service in the shape needed by this service.  You can check out the code at the following link.

[Angular 5 - Dynamic Search Form](https://github.com/kahanu/DynamicSearchForm)

![alt text](https://github.com/kahanu/FullTextSearchWebApi/blob/master/angular-form.jpg "Angular Dynamic Search Form")

# Wide World Importers Database

This WebApi service also makes use of Full Text indexing by using the Wide World Importers database which is freely downloadable. [Download Wide World Importers Database here.](https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0) - download the WideWorldImporters-Full.bak file.

Install this database locally, and change the connection string in the WebApi project, and you should be good to go.

## Postman

You can easily test this WebApi without using the Angular app.  Start the WebApi project, then open Postman and enter the following Url.

`http://localhost:59006/api/customers` 

Be sure to change the port if necessary.  Then POST a payload in the body like this:

```javascript
{
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
}
```

You should get a result similar to this:

```javascript
{
    "CustomerList": [
        {
            "CustomerId": 1,
            "CustomerName": "Tailspin Toys (Head Office)",
            "PhoneNumber": "(308) 555-0100",
            "DeliveryAddressLine1": "Shop 38",
            "DeliveryAddressLine2": "1877 Mittal Road",
            "DeliveryPostalCode": "90410",
            "PostalAddressLine1": "PO Box 8975",
            "PostalAddressLine2": "Ribeiroville"
        },
        {
            "CustomerId": 10,
            "CustomerName": "Tailspin Toys (Wimbledon, ND)",
            "PhoneNumber": "(701) 555-0100",
            "DeliveryAddressLine1": "Unit 67",
            "DeliveryAddressLine2": "372 Joo Lane",
            "DeliveryPostalCode": "90061",
            "PostalAddressLine1": "PO Box 8702",
            "PostalAddressLine2": "Rajuville"
        },
        {
            "CustomerId": 401,
            "CustomerName": "Wingtip Toys (Head Office)",
            "PhoneNumber": "(303) 555-0100",
            "DeliveryAddressLine1": "Shop 294",
            "DeliveryAddressLine2": "1263 Kwak Lane",
            "DeliveryPostalCode": "90625",
            "PostalAddressLine1": "PO Box 4823",
            "PostalAddressLine2": "Kopeckaville"
        }
    ],
    "Success": false,
    "Message": ""
}
```
