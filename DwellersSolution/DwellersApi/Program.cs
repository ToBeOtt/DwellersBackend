using Dwellers.Authentication;
using Dwellers.Calendar;
using Dwellers.Chat;
using Dwellers.Chat.Application.Hubs;
using Dwellers.Common.Data;
using Dwellers.Common.Persistance;
using Dwellers.Household.Application;
using Dwellers.Notes;
using Dwellers.Offerings;
using DwellersApi;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.OpenApi.Models;
using SharedKernel.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Other services
builder.Services.AddCoreServices();

// Persistence and DA
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

// Auth
builder.Services.AddAuthenticationServices(builder.Configuration);

// Modules
builder.Services.AddHouseholdModuleServices(builder.Configuration);
builder.Services.AddOfferingsModuleServices(builder.Configuration);
builder.Services.AddChatModuleServices(builder.Configuration);
builder.Services.AddNotesModuleServices(builder.Configuration);
builder.Services.AddCalendarModuleServices(builder.Configuration);



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
    endpoints.MapHub<HouseholdHub>("/householdHub", options =>
    {
        options.TransportMaxBufferSize = 1024;
        options.LongPolling.PollTimeout = TimeSpan.FromSeconds(30);
        options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
    });
});

app.MapControllers();


app.Run();
