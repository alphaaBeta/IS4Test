## Identity Server 4 authenticating the client App against AD

There are alredy built executables for windows in appropriate zip files.

Inside each you will find an .exe file and a config file (for example, in case of the server it will be `IdentityServer4withRSA.exe` and `IdentityServer4withRSA.dll.config`)

Information about config values:

	* AD.Domain - name or address of your AD domain
	
	* Api.Identifier - unique identifier of your endpoint to authenticate against, in this case, Active Directory. Server needs to have it set during configuration, client just needs to make a request of it.
	
	* Api.Secret - key for connecting with API. In this case, not really used.
	
	* Client.Identifier - unique identifier of your client (for example, an app). Must be set to the same value in both client and server config.
	
	* Client.Secret - key for connecting client with identity server. Must be set to the same value in both client and server config.
	
	* IS.Ip - IP under which the server will be listening for connections. If you're hosting both client and server on local machine, use `localhost`
	
	* IS.Port - Port under which the server will be listening for connections. Usually `5001`.


Implementing the client in your app is simple. All you need to do is to save discovery data somewhere (as taken from Client's Program.cs):  
`
	var disco = await DiscoveryClient.GetAsync($"http://{Config.ISAddress}:{Config.ISPort}");  
	if (disco.IsError)  
	{  
	Console.WriteLine(disco.Error);  
	}
`  
and then use them by requesting a token:  
`
	var tokenClient = new TokenClient(disco.TokenEndpoint, Config.ClientId, Config.ClientSecret);  
	var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(username, password, Config.ApiId);  
`  

Then you can check the tokenResponse if the authentication was successful
