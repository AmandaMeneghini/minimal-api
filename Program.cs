using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTO;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options =>{
    var builderConfiguration = builder.Configuration.GetConnectionString("mysql");

    options.UseMySql(builderConfiguration, ServerVersion.AutoDetect(builderConfiguration));
} );

var app = builder.Build();

app.MapPost("/login", (LoginDTO loginDTO) => {
    if(loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456"){
        return Results.Ok("Login com sucesso");
    }else{
        return Results.Unauthorized();
    }
});


app.Run();



