Features

	-Supports .Net Core
	-Supports XML and JSON deserialization

Examples

IRestClient client = new RestClient("http://user.com");

IRestRequest request = new RestRequest("/user");

request.AddContentType("application/json");
request.AddDataFormat(DataFormat.Json);
request.AddMethod(Method.Post);
if (data != null)
 request.AddBody(data);
 
IRestResponse response = client.ExecuteAsync(request);
var content = response.Content 
 
IRestResponse<User> response = client.ExecuteAsync<User>(request);
var data = response.Data
