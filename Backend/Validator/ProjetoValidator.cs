using BusinessLogic.Context;
using BusinessLogic.Entities;
using FluentValidation;

namespace Backend.Validator;

public class ProjetoValidator : AbstractValidator<Projeto>
{
    private readonly TarefasDbContexta _context;
    
    public ProjetoValidator(TarefasDbContexta context)
    {
        _context = context;
        
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Name is required.")
            .MustAsync(BeUniqueName).WithMessage("Name must be unique.");
    }
    
    private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        // Perform your uniqueness check logic here, e.g., query the database
        bool isUnique = await YourDatabaseCheckMethod(name);
        return isUnique;
    }
    
    private async Task<bool> YourDatabaseCheckMethod(string name)
    {
        // Perform your database check logic here
        // Return true if the name is unique, false 
        Boolean x = false;
        foreach (var Proj in _context.Projetos)
        {
            if (name.Equals(Proj.Nome))
            {
                x = true;
            }
        }

        return x;
    }
}