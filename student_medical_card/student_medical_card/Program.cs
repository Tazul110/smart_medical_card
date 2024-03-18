using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using student_medical_card.Repository.LoginRepo.Implementations;
using student_medical_card.Repository.LoginRepo.Interfaces;
using student_medical_card.Repository.MedicineRepo.Implements;
using student_medical_card.Repository.MedicineRepo.Interfaces;
using student_medical_card.Repository.PrescriptionRepo.Implementations;
using student_medical_card.Repository.PrescriptionRepo.Interfaces;
using student_medical_card.Repository.StudentRepo.Implements;
using student_medical_card.Repository.StudentRepo.Interfaces;
using student_medical_card.Repository.TestRepo.Implements;
using student_medical_card.Repository.TestRepo.Interfaces;
using student_medical_card.Service.LoginServ.Implementations;
using student_medical_card.Service.LoginServ.Interfaces;
using student_medical_card.Service.MedicineServ.Implementations;
using student_medical_card.Service.MedicineServ.Interfaces;
using student_medical_card.Service.PrescriptionRepo.interfaces;
using student_medical_card.Service.PrescriptionServ.implementation;
using student_medical_card.Service.StudentServ.Implementations;
using student_medical_card.Service.StudentServ.Interfaces;
using student_medical_card.Service.TestServ.Implements;
using student_medical_card.Service.TestServ.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

    });




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAddRepo, AddRepo>();
builder.Services.AddScoped<t_IAddServ, t_AddServ>();

builder.Services.AddScoped<IGetUserByEmail, GetUserByEmail>();
builder.Services.AddScoped<IGetUserByEmailServ, GetUserByEmailServ>();

builder.Services.AddScoped<L_IAddUserRepo, L_AddUserRepo>();
builder.Services.AddScoped<L_IAddUserServ, L_AddUserServ>();

builder.Services.AddScoped<s_IGetAllStudentRepo, s_GetAllStudentRepo>();
builder.Services.AddScoped<s_IGetAllStudentServ, s_GetAllStudentServ>();

builder.Services.AddScoped<m_IAddRepo, m_AddRepo>();
builder.Services.AddScoped<m_IAddServ, m_AddServ>();

builder.Services.AddScoped<s_IGetRepo, s_GetRepo>();
builder.Services.AddScoped<s_IGetServ, s_GetServ>();

builder.Services.AddScoped<p_IAddRepo, p_AddRepo>();
builder.Services.AddScoped<p_IAddServ, p_AddServ>();

builder.Services.AddScoped<s_IAddRepo, s_AddRepo>();
builder.Services.AddScoped<s_IAddServ, s_AddServ>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseCors(policy=> policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
