using System;

namespace ddd_project.Domain;

public class Atividade
{
   public int Id { get; set; }
   public string Titulo { get; set; }
   public int Ch { get; set; }
   public string Descricao { get; set; }
   public string Periodo { get; set; }
   public List<Aluno> Alunos { get; } =[];
   public List<AlunoAtividade> AlunosAtividades { get; } =[];

   public void AssociarAluno(Aluno aluno, int? ch)
   {
      AlunosAtividades.Add(new AlunoAtividade(aluno, this, ch ?? Ch));
      Alunos.Add(aluno);
         
   }

}

