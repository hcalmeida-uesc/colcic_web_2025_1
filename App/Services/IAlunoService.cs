using System;
using ddd_project.Domain;
using ddd_project.Domain.Entities;

namespace ddd_project.App.Services;

public interface IAlunoService: IAlunoAtividadeService
{
   ICollection<Atividade> GetAtividades();
}
