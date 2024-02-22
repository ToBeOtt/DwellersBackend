using Dwellers.Authentication;
using Dwellers.Common.Application;
using Dwellers.Common.Application.Commands.Chats.Hubs;
using Dwellers.Common.Infrastructure;
using DwellersApi;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.OpenApi.Models;
using SharedKernel;
using SharedKernel.Exceptions;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;

var builder = WebApplication.CreateBuilder(args);

// Other services
builder.Services.AddCoreServices();

// Persistence and DA
builder.Services.AddInfrastructureServices(builder.Configuration);

// Auth
builder.Services.AddAuthenticationServices(builder.Configuration);

// Shared kernel
builder.Services.AddSharedKernelServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);


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
    endpoints.MapHub<DwellersHub>("/dwellersHub", options =>
    {
        options.TransportMaxBufferSize = 1024;
        options.LongPolling.PollTimeout = TimeSpan.FromSeconds(30);
        options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
    });
});

app.MapControllers();

app.Run();
