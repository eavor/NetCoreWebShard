using Autofac;
using Autofac.Extensions.DependencyInjection;
using LHJ.Repository;
using LHJ.WebHost;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region JWT����
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"])),
        ClockSkew = TimeSpan.Zero  // Ĭ�ϵ� 5 ����ƫ��ʱ��
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var token = context.Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");
            if (!string.IsNullOrEmpty(token))
            {
                context.Token = token;
            }
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            // ������ڣ��ѹ�����Ϣ��ӵ�ͷ��
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Append("Token-Expired", "true");
            }

            return Task.CompletedTask;
        }
    };
});

#endregion

#region Autofac����
// ʹ�� Autofac ��Ϊ��������
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// ���� Autofac ����
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // ע�����
    containerBuilder.RegisterModule(new AutofacModuleRegister());
});
#endregion
// Add services to the container.

builder.Services.AddOpenApi();

builder.Services.AddControllers();

BaseDBConfig.ConnectionString = builder.Configuration.GetSection("AppSetting:ConnectionStringSqlServer").Value;

#region swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.UseSwagger();
//    //app.UseSwaggerUI();
//}
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(); // scalar/v1
    app.MapOpenApi();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
