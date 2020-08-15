## Environment:  
- .NET version: 3.0

## Read-Only Files:   
- ReportingService.Tests/IntegrationTests.cs

## Data:  
Example of a report data JSON object:
```
{
    id: 1,
    name: "Annual report",
    category: "Finance",
    rows: ["Header 1", "Header 2", "Header 3"]
}   
```

## Requirements:

A company is launching an API service that can manage reports. The service should be a web API layer using .NET Core 3.0. You already have a prepared infrastructure and need to implement a Web API Controller ReportsController. Also, you need to think about the localization for the reports' data in responses. The language to be used is retrieved from the request header's "Accept-Language" value.


The following API calls are already implemented:
1. Creating reports: a POST request to the endpoint api/reports adds a report to the database. The HTTP response code is 200.
2. Getting all reports: a GET request to the endpoint api/reports returns the entire list of reports. The HTTP response code is 200.



Change the `SetLanguageMiddleware.cs` and `CustomStringLocalizer.cs` files in the following way:
- Implement the localization mechanism for the report's data property rows by using the language set in the request header's "Accept-Language" value.
- The service should support 3 languages: "en"- English, "ru"- Russian, and "it"- Italian. Localized (translated) strings are given in the file `CustomStringLocalizer.cs`. Please use the .NET Core IStringLocalizer as a localizer to find the localized string.
- If nothing is set in the request header's "Accept-Language" value, then use the "en" language by default.
- Example: If the request header's "Accept-Language" value is "it" (Italian), then the response should return the report's data property rows with Italian translations.



Definition of Report model:
+ id - The ID of the report. [INTEGER]
+ name - The name of the report. [STRING]
+ category - The category of the report. [STRING]
+ rows - The report's data. [STRING[]]


## Example requests and responses with headers


**Request 1:**

GET request to api/reports/1 without an "Accept-Language" header.


The response code will be 200 with the report's details. The property rows is filled using the English language because there is no "Accept-Language" header and English is the default language.
```
{
    id: 1,
    name: "Annual report",
    category: "Finance",
    rows: ["Header 1", "Header 2", "Header 3"]
}   
```


**Request 2:**

GET request to api/reports/1 with the "Accept-Language" header set to "ru".


The response code will be 200 with the report's details. The property rows is filled using the Russian language because the "Accept-Language" header set to "ru".
```
{
    id: 1,
    name: "Annual report",
    category: "Finance",
    rows: ["Заголовок 1", "Заголовок 2", "Заголовок 3"]
}    
```

