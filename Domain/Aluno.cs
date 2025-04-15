using System;

namespace ddd_project.Domain;

public class Aluno
{
   public Guid Id { get; set; }
   public string Nome { get; set; }
   public string Matricula { get; set; }
   public List<Atividade> Atividades { get; } = [];
   public List<AlunoAtividade> AlunoAtividades { get; } = [];
   
}
