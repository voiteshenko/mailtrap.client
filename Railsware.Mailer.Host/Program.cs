using Railsware.Mailer.Mailtrap.Client.AspNet.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var mailtrapUrl = builder.Configuration["Mailtrap:Url"];
var mailtrapApiToken = builder.Configuration["Mailtrap:ApiToken"];

builder.Services.AddMailtrapClient(mailtrapUrl, mailtrapApiToken);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
