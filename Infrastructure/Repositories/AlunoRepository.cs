using System;
using ddd_project.Domain.Contracts;
using ddd_project.Domain.Entities;
using ddd_projectq.Infrastructure.Repositories;

namespace ddd_project.Infrastructure.Repositories;

public class AlunoRepository:Repository<Aluno>, IAlunoRepository
{

}
