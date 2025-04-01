using System;
using ddd_project.Domain;

namespace ddd_project.App.Services;

public interface IAlunoService
{
   ICollection<Aluno> GetAllAlunos();
   Aluno AssociarAtividade(Aluno aluno, Atividade atividade, int? ch);
   ICollection<Atividade> GetAtividadesByAluno();
}
