using System;
using ddd_project.Domain;

namespace ddd_project.Domain;

public class AlunoAtividade
{
   public Aluno Aluno { get; set; }
   public Guid AlunoId { get; set; }
   public Atividade Atividade { get; set; }
   public Guid AtividadeId { get; set; }
   public int Ch { get; set; }

   // public AlunoAtividade(Aluno aluno, Atividade atividade)
   // {
   //    Aluno = aluno ?? throw new ArgumentNullException(nameof(aluno), "Aluno não pode ser nulo.");
   //    Atividade = atividade ?? throw new ArgumentNullException(nameof(atividade), "Atividade não pode ser nula.");
   //    Ch = atividade.Ch;
   // }

   // public AlunoAtividade(Aluno aluno, Atividade atividade, int ch)
   // {
   //    Aluno = aluno ?? throw new ArgumentNullException(nameof(aluno), "Aluno não pode ser nulo.");
   //    Atividade = atividade ?? throw new ArgumentNullException(nameof(atividade), "Atividade não pode ser nula.");
   //    Ch = ch;
   // }
}
