namespace SisprodIT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracoesComentarios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comentario", "DataAtualizacao", c => c.DateTime());
            AlterColumn("dbo.Comentario", "FuncionarioAtualizadorId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Comentario", "FuncionarioAtualizadorId", "dbo.Funcionario", "FuncionarioModelId");
            CreateIndex("dbo.Comentario", "FuncionarioAtualizadorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comentario", new[] { "FuncionarioAtualizadorId" });
            DropForeignKey("dbo.Comentario", "FuncionarioAtualizadorId", "dbo.Funcionario");
            AlterColumn("dbo.Comentario", "FuncionarioAtualizadorId", c => c.Int());
            AlterColumn("dbo.Comentario", "DataAtualizacao", c => c.DateTime(nullable: false));
        }
    }
}
