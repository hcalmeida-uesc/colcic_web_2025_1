using System;

namespace ddd_project.Domain;

public class Atividade
{
   public Guid Id { get; set; }
   public string Titulo { get; set; }
   public int Ch { get; set; }
   public string Descricao { get; set; }
   public string Periodo { get; set; }
   public List<Aluno> Alunos { get; } =[];
   public List<AlunoAtividade> AlunoAtividades { get; } =[];

}

