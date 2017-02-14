# MiniRest - .NET Core REST Client

### Features

* Supports .Net Core
* Supports XML and JSON deserialization
* Supports Basic Authentication
* Supports WebHeaderCollection extra parameter

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
