using System;
using ddd_project.Domain;

namespace ddd_project.App.Services;

public interface IAtividadeService
{
   Atividade GetAtividade();

   Atividade AssociarAtividade(Aluno aluno, Atividade atividade, int? ch);
}
