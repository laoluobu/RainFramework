## Swagger

```C#

  var builder = WebApplication.CreateBuilder(args);
  builder.Services.AddControllers();
  builder.Services.AddSwagger();
  var app = builder.Build();
  app.UseSwaggerPkg();
  app.Run();


```

## Serilog

```C#

 var builder = WebApplication.CreateBuilder(args);
 builder.Host.UseSerilogger();

```


## Json

```C#

builder.Services.AddControllers()
                .AddNewtonsoftJsonConfig();

```

## HttpResposeFilter

```
builder.Services.AddControllers(options => options.AddHttpResponseFilter());

```