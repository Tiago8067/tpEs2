using System.Security.Cryptography;
using BusinessLogic.Context;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UtililizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly TarefasDbContext _contexta;

    public UtilizadorService(TarefasDbContext contexta)
    {
        _contexta = contexta;
    }
    
    public async Task<List<Usermodel>> GetAllUtilizadores()
    {
        return await _contexta.Usermodels.ToListAsync();
    }

    public async Task<Usermodel?> GetUtilizadorById(Guid id)
    {
        var utilizador = await _contexta.Usermodels.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        return utilizador;
    }

    /*public async Task<List<Usermodel>> AddUtilizador(Usermodel utilizador)
    {
        _contexta.Usermodels.Add(utilizador);
        await _contexta.SaveChangesAsync();
        return await _contexta.Usermodels.ToListAsync();
    }*/
    
    public async Task<ServiceResponse<Guid>> AddUtilizador(Usermodel user, string pass)
    {
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<Guid>
            {
                Success = false,
                Message = "Este Utilizador já existe."
            };
        }
        
        CreatePassHash(pass, out byte[] passHash, out byte[] passSalt);

        user.Passhash = passHash;
        user.Passsalt = passSalt;

        _contexta.Usermodels.Add(user);
        await _contexta.SaveChangesAsync();

        return new ServiceResponse<Guid>
        {
            Data = user.Id,
            Message = "Registo realizado com Sucesso!" 
        };
    }
    
    public async Task<bool> UserExists(string email)
    {
        if (await _contexta.Usermodels.AnyAsync(usermodel => usermodel.Email.ToLower().Equals(email.ToLower())))
        {
            return true;
        }

        return false;
    }
    
    private void CreatePassHash(string pass, out byte[] passHash, out byte[] passSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passSalt = hmac.Key;
            passHash = hmac
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
        }
    }

    public async Task<List<Usermodel>?> UpdateUtilizador(Guid id, Usermodel request)
    {
        var utilizador = await _contexta.Usermodels.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        
        utilizador.Nome = request.Nome;
        utilizador.Horasdiarias = request.Horasdiarias;
        utilizador.Role = request.Role;

        await _contexta.SaveChangesAsync();
        
        return await _contexta.Usermodels.ToListAsync();
    }

    public async Task<List<Usermodel>?> DeleteUtilizador(Guid id)
    {
        var utilizador = await _contexta.Usermodels.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        _contexta.Usermodels.Remove(utilizador);
        await _contexta.SaveChangesAsync();
        return await _contexta.Usermodels.ToListAsync();
    }
}