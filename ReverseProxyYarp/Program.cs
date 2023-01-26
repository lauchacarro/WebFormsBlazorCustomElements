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
                if (transformContext.Path.ToString().Contains("/_framework"))
                {
                    string path = transformContext.Path.ToString().Split("/_framework")[1];

                    transformContext.Path = "/_framework" + path;
                }

                if (transformContext.Path.ToString().Contains("/_blazor"))
                {
                    string path = transformContext.Path.ToString().Split("/_blazor")[1];

                    transformContext.Path = "/_blazor" + path;
                }


                if (transformContext.Path.ToString().Contains("/_content"))
                {
                    string path = transformContext.Path.ToString().Split("/_content")[1];

                    transformContext.Path = "/_content" + path;
                }

            });
        }
    });


var app = builder.Build();


app.MapReverseProxy();

app.Run();
