using System;
using ddd_project.App.Services;
using ddd_project.Domain;

namespace App.Services;

public class AtividadeService : IAtividadeService
{
   private readonly IAlunoService _alunoService;
   public AtividadeService(IAlunoService alunoService)
   {
      _alunoService = alunoService;
   }
   public Atividade AssociarAtividade(Aluno aluno, Atividade atividade, int? ch)
   {
      _alunoService.AssociarAtividade(aluno, atividade, ch);

      return atividade;
   }

   public Atividade GetAtividade()
   {
      Atividade atividade = new Atividade(){
         Titulo = "Atividade 1",
         Descricao = "Descrição da Atividade 1",
         Ch = 60,
         Periodo = "2023.1"
      };

      return atividade;
   }
}
