# MiniRest

Fast Lightweight Http Api Client

### Features
* Supports .NET 4.6.1 , .NET Standard 1.6 and .NET Standard 2.0
* Supports .Net Core and Net Framework
* Supports XML and JSON deserialization
* Supports Basic Authentication
* Supports WebHeaderCollection extra parameter

### Installing MiniRest

You should install [MiniRest with NuGet](https://www.nuget.org/packages/MiniRest):

    Install-Package MiniRest
    
Or via the .NET Core command line interface:

    dotnet add package MiniRest

### Preview

```csharp
//Http Get
IRestRequest request = new RestRequest("http://localhost:15670");
request.AddPath("/api/test");
request.AddContentType("application/json");
request.AddDataFormat(DataFormat.Json);
request.AddMethod(Method.Get);
IRestClient client = new RestClient(request);
var response = client.Execute<object>();

IRestRequest request = new RestRequest("http://localhost:3508");
request.AddPath("/api/test");
request.AddContentType("application/json");
request.AddDataFormat(DataFormat.Json);
request.AddMethod(Method.Post);
request.AddBody("Request Post body data");
IRestClient client = new RestClient(request);
var response = client.Execute<object>();
//var response = await client.ExecuteAsync<object>();
var data = response.Data
```
