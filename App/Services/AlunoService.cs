using System;
using ddd_project.Domain;
using ddd_project.Domain.Entities;

namespace ddd_project.App.Services;

public class AlunoService : IAlunoService
{
   public void AssociarAlunoAtividade(Aluno aluno, Atividade atividade, int? ch)
   {
      throw new NotImplementedException();
   }

   public void AssociarAlunoAtividade(string matricula, Atividade atividade, int? ch)
   {
      throw new NotImplementedException();
   }

   public ICollection<Atividade> GetAtividades()
   {
      throw new NotImplementedException();
   }
}
