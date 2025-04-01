using System;

namespace ddd_project.Domain;

public class Aluno
{
   public string Nome { get; set; }
   public string Matricula { get; set; }
   public List<Atividade> Atividades { get; } = [];
   public List<AlunoAtividade> AlunoAtividade { get; } = [];

   public Aluno AssociarAtividade(Atividade atividade, int? ch)
   {
      if (atividade == null)
         throw new ArgumentNullException(nameof(atividade), "Atividade não pode ser nula.");

      Atividades.Add(atividade);

      return this;
   }
   
}
