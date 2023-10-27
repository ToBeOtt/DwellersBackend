using Dwellers.Household.Application;
using Dwellers.Household.Application.Features.Household.Chat.Hubs;
using DwellersApi;
using Microsoft.OpenApi.Models;
using SharedKernel.Exceptions;

var builder = WebApplication.CreateBuilder(args);


// Other services
builder.Services.AddCoreServices();
builder.Services.AddHouseholdModuleServices(builder.Configuration);

// DEVELOPMENT -- for authentication testing 
builder.Services.AddSwaggerGen(c => {
c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
{
    Name = "Bearer",
    BearerFormat = "JWT",
    Scheme = "bearer",
    Description = "Specify the authorization token.",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
});
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();
app.UseRouting();

app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<HouseholdHub>("/householdHub");
});
app.MapControllers();


app.Run();
