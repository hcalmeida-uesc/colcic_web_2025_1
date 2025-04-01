using System;
using ddd_project.Domain;

namespace ddd_project.App.Services;

public interface IAlunoService: ICRUD<Aluno>, IAlunoAtividadeService
{
   ICollection<Atividade> GetAtividades();
}
