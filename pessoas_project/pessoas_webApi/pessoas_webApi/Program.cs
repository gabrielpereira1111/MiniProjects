using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()

                .AddNewtonsoftJson(option =>
                {
                    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
builder.Services.AddAuthentication(options =>
                                    {
                                        options.DefaultAuthenticateScheme = "JwtBearer";
                                        options.DefaultChallengeScheme = "JwtBearer";
                                    }
                                  )

                .AddJwtBearer("JwtBearer" ,options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = "pessoas_webApi",
                        ValidAudience = "pessoas_webApi",
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-secreta-pessoas")),
                        ClockSkew = TimeSpan.FromMinutes(30)
                    };
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
