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

   public Aluno AssociarAtividade(Aluno aluno, Atividade atividade, int? ch)
   {
      if (aluno == null)
         throw new ArgumentNullException(nameof(aluno), "Aluno não pode ser nulo.");
      if (atividade == null)
         throw new ArgumentNullException(nameof(atividade), "Atividade não pode ser nula.");
      
      if (aluno.Atividades == null)
         throw new ArgumentNullException(nameof(aluno.Atividades), "Atividades não podem ser nulas.");

      aluno.Atividades.Add(atividade);

      return aluno;
   }

   public ICollection<Aluno> GetAllAlunos()
   {
      return _alunos;
   }

   public ICollection<Atividade> GetAtividadesByAluno()
   {
      // LINQ query to get all activities from all students
       return _alunos.SelectMany(a => a.Atividades).ToList();
   }
}
