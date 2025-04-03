using System;

namespace ddd_project.Domain.Entities;

public class Aluno
{
   public Guid Id { get; set; }
   public string Nome { get; private set; }
   public string Matricula { get; private set; }
   private List<Atividade> Atividades { get; } = [];
   private List<AlunoAtividade> AlunosAtividades { get; } = [];

   protected Aluno() { } // EF Core requires a parameterless constructor
   public Aluno(string nome, string matricula)
   {
      Id = Guid.NewGuid();
      Nome = nome ?? throw new ArgumentNullException(nameof(nome), "Nome não pode ser nulo.");
      Matricula = matricula ?? throw new ArgumentNullException(nameof(matricula), "Matrícula não pode ser nula.");
   }

   public void AssociarAtividade(Atividade atividade, int? ch)
   {
      AlunoAtividade alunoAtividade = new AlunoAtividade(this, atividade, ch ?? atividade.Ch);
      AlunosAtividades.Add(alunoAtividade);
      Atividades.Add(atividade);

   }
   
}
