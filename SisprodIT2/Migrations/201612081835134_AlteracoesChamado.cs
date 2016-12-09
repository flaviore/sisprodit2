namespace SisprodIT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracoesChamado : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Endereco", "FuncionarioAtualizadorId", c => c.Int());
            AlterColumn("dbo.Comentario", "FuncionarioAtualizadorId", c => c.Int());
            AddForeignKey("dbo.Chamado", "FuncionarioAtualizadorId", "dbo.Funcionario", "FuncionarioModelId");
            CreateIndex("dbo.Chamado", "FuncionarioAtualizadorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Chamado", new[] { "FuncionarioAtualizadorId" });
            DropForeignKey("dbo.Chamado", "FuncionarioAtualizadorId", "dbo.Funcionario");
            AlterColumn("dbo.Comentario", "FuncionarioAtualizadorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Endereco", "FuncionarioAtualizadorId", c => c.Int(nullable: false));
        }
    }
}
