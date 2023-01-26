using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(builderContext =>
    {
        if (builderContext.Route.Metadata is not null && builderContext.Route.Metadata.ContainsKey("Blazor"))
        {
            builderContext.AddRequestTransform(async transformContext =>
            {

                string blazorUrl = builder.Configuration["ReverseProxy:Clusters:BlazorApp:Destinations:Server1:Address"]!;
                if (transformContext.Path.ToString().Contains("/_framework"))
                {
                    string path = transformContext.Path.ToString().Split("/_framework")[1];

                    transformContext.ProxyRequest.RequestUri = new Uri(blazorUrl + "/_framework" + path);

                }

                if (transformContext.Path.ToString().Contains("/_blazor"))
                {
                    string path = transformContext.Path.ToString().Split("/_blazor")[1];

                    transformContext.ProxyRequest.RequestUri = new Uri(blazorUrl + "/_blazor" + path);
                }


                if (transformContext.Path.ToString().Contains("/_content"))
                {
                    string path = transformContext.Path.ToString().Split("/_content")[1];

                    transformContext.ProxyRequest.RequestUri = new Uri(blazorUrl + "/_content" + path);
                }

                if (transformContext.Query.QueryString.ToString().Contains("/_content"))
                {
                    string path = transformContext.Query.QueryString.ToString().Split("/_content")[1];

                    transformContext.ProxyRequest.RequestUri = new Uri(blazorUrl + "/_content" + path);
                }

            });
        }
    });


var app = builder.Build();


app.MapReverseProxy();

app.Run();
