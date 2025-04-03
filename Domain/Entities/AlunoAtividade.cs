using System;
using ddd_project.Domain;

namespace ddd_project.Domain.Entities;


public class AlunoAtividade
{
   public Guid AlunoId { get; set; }
   public Guid AtividadeId { get; set; }
   public Aluno Aluno { get; set; }
   public Atividade Atividade { get; set; }
   public int Ch { get; set; }

   public AlunoAtividade(Aluno aluno, Atividade atividade)
   {
      Aluno = aluno ?? throw new ArgumentNullException(nameof(aluno), "Aluno não pode ser nulo.");
      Atividade = atividade ?? throw new ArgumentNullException(nameof(atividade), "Atividade não pode ser nula.");
      Ch = atividade.Ch;
   }

   public AlunoAtividade(Aluno aluno, Atividade atividade, int ch):this(aluno, atividade)
   {
      Ch = ch;
   }

   public void AssociarAtividade(Aluno aluno, Atividade atividade, int? ch)
   {
      aluno.AssociarAtividade(atividade, ch);
   }
}
