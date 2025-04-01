using System;

namespace ddd_project.Domain;

public class Aluno
{
   public string Nome { get; set; }
   public string Matricula { get; set; }
   public List<Atividade> Atividades { get; } = [];
   public List<AlunoAtividade> AlunosAtividades { get; } = [];

   public void AssociarAtividade(Atividade atividade, int? ch)
   {
      AlunoAtividade alunoAtividade = new AlunoAtividade(this, atividade, ch ?? atividade.Ch);
      AlunosAtividades.Add(alunoAtividade);
      Atividades.Add(atividade);

   }
   
}
