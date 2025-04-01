using System;
using ddd_project.Domain;

namespace ddd_project.App.Services;

public interface IAtividadeService: ICRUD<Atividade>,IAlunoAtividadeService
{}
