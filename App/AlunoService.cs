using System;
using ddd_project.Domain;

namespace ddd_project.App.Services;

public class AlunoService : IAlunoService
{
   private readonly List<Aluno> _alunos;

   public AlunoService()
   {
      _alunos = new List<Aluno>
      {
         new Aluno { Nome = "João Silva", Matricula = "20251001" },
         new Aluno { Nome = "Maria Oliveira", Matricula = "20251002" },
         new Aluno { Nome = "Carlos Santos", Matricula = "20251003" },
         new Aluno { Nome = "Ana Costa", Matricula = "20251004" },

      };
   }

   public ICollection<Aluno> GetAllAlunos()
   {
      return _alunos;
   }

}
