using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Vendas.Application.Mapping;
using Vendas.Application.Services;
using Vendas.Infrastructure.Data;
using Vendas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

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
        ValidIssuer = jwtSettings["Issuer"],

        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

builder.Services.AddScoped<ClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<VendaRepository, VendaRepository>();
builder.Services.AddScoped<VendaService>();

builder.Services.AddScoped<ReceitaRepository, ReceitaRepository>();
builder.Services.AddScoped<ReceitaService>();

builder.Services.AddScoped<MovimentacaoEstoqueRepository, MovimentacaoEstoqueRepository>();
builder.Services.AddScoped<MovimentacaoEstoqueService>();

builder.Services.AddScoped<AtendimentoRepository, AtendimentoRepository>();
builder.Services.AddScoped<AtendimentoService>();

builder.Services.AddAutoMapper(typeof(ClienteProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);
builder.Services.AddAutoMapper(typeof(VendaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ReceitaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(MovimentacaoEstoqueProfile).Assembly);
builder.Services.AddAutoMapper(typeof(SaldoProfile).Assembly);
builder.Services.AddAutoMapper(typeof(AtendimentoProfile).Assembly);

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
