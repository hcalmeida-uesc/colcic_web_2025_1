using System;
using ddd_project.Domain;

namespace ddd_project.App.Services;

public interface IAlunoAtividadeService
{
   void AssociarAlunoAtividade(Aluno aluno, Atividade atividade, int? ch);
   void AssociarAlunoAtividade(String matricula, Atividade atividade, int? ch);
}
