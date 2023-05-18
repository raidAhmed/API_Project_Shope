
using Agricultural.Application.Extensions;
using Agricultural.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;




var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddApplication();

var configuration = new ConfigurationBuilder()
     //Read from your appsettings.json.
    .AddJsonFile("appsettings.json")
     //Read from your secrets.
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables()
    .Build();

//Add controllers
builder.Services.AddControllers();
builder.Services.AddMvc();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();





builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

   // the following is only needed for swagger to enable basic authenication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",

                            }
                        },
                        Array.Empty<string>()
                    }
                });

});





builder.Services.AddPresistenceAPI(builder.Configuration);//, builder.Environment);

//this is needed for Serilog.AspNetCore, Serilog.Settings.Configuration, Serilog.Sinks.File, Serilog.Sinks.Console, Serilog.Expressions
//installed in application project,
//this project has reference to application project
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(configuration)
//    .CreateLogger();
//builder.Host.UseSerilog();
//this is need for basic authentication
//builder.Services.Configure<BasicAuthentication>(configuration.GetSection("BasicAuthentication"));

//this is need for exception handling
//builder.Services.AddTransient<ExceptionHandlingMiddleware>();

 //Register CurrentUserService
//builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddAuthorization();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "API v1");
    });
}

//added to handle basic authentication     
//app.UseBasicAuthMiddleware();

//added to handle exceptions
//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
//app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();

//app.UseMvc(routes =>
//    routes.MapRoute(
//        name: "defaultArea",
//        template: "{area : exists}/{controller = Activity}/{action =Index}/{index?}",
//        defaults: new { area = "defaultArea" }
//        )
//);

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller = Activity}/{action =Index}/{index?}"
//    );
app.MapControllers();
app.MapRazorPages();


app.Run();
