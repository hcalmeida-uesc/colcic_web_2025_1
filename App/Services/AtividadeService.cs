using System;
using ddd_project.App.Services;
using ddd_project.Domain;

namespace App.Services;

public class AtividadeService : IAtividadeService
{
   private readonly IAlunoService _alunoService;
   private List<Atividade> _atividades;
   public AtividadeService(IAlunoService alunoService)
   {
      _alunoService = alunoService;
      _atividades = new (){
         new Atividade { Id = 1, Titulo = "Atividade 1", Descricao = "Descrição da Atividade 1", Ch = 60, Periodo = "2023.1" },
         new Atividade { Id = 2, Titulo = "Atividade 2", Descricao = "Descrição da Atividade 2", Ch = 45, Periodo = "2023.1" },
         new Atividade { Id = 3, Titulo = "Atividade 3", Descricao = "Descrição da Atividade 3", Ch = 30, Periodo = "2023.1" }
      };
   }


   public void AssociarAlunoAtividade(Aluno aluno, Atividade atividade, int? ch)
   {
      _alunoService.AssociarAlunoAtividade(aluno, atividade, ch);
   }

   public void AssociarAlunoAtividade(string matricula, Atividade atividade, int? ch)
   {
      _alunoService.AssociarAlunoAtividade(matricula, atividade, ch);
   }

   public ICollection<Atividade> GetAll()
   {
      throw new NotImplementedException();
   }
}
