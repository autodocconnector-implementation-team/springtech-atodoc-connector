using AutodocConnector.Application;
using AutodocConnector.Application.Interfaces.ForPresentation;
using AutodocConnector.Persistence.Extensions.Public;
using AutodocConnector.WebApi.Filters;
using AutodocConnector.WebApi.Middlewares;
using AutodocConnector.WebApi.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    x.OperationFilter<AutodocLoginHeadersFilter>();
});

// Register core layers
builder.Services.AddApplicationLayer();

// Register infrastructure layers
builder.Services.AddPersistenceLayer(builder.Configuration);

// Register presentation layer services
builder.Services.AddTransient<AutodocAuthenticationMiddleware>();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddScoped<IAuthenticatedAutodocUser>(provider =>
{
    return new AuthenticatedAutodocUser(provider.GetService<IHttpContextAccessor>()!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<AutodocAuthenticationMiddleware>();
app.UseExceptionHandler(x => {});

await app.RunAsync();
