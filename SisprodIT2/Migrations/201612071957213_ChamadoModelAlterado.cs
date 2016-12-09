namespace SisprodIT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChamadoModelAlterado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chamado", "Finalizacao_FinalizacaoModelId", "dbo.Finalizacao");
            DropIndex("dbo.Chamado", new[] { "Finalizacao_FinalizacaoModelId" });
            RenameColumn(table: "dbo.Chamado", name: "FuncionarioResponsavel_FuncionarioModelId", newName: "FuncionarioResponsavelId");
            AddColumn("dbo.Chamado", "FinalizacaoModelId", c => c.Int());
            AddForeignKey("dbo.Chamado", "FinalizacaoModelId", "dbo.Finalizacao", "FinalizacaoModelId");
            CreateIndex("dbo.Chamado", "FinalizacaoModelId");
            DropColumn("dbo.Chamado", "Finalizacao_FinalizacaoModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chamado", "Finalizacao_FinalizacaoModelId", c => c.Int());
            DropIndex("dbo.Chamado", new[] { "FinalizacaoModelId" });
            DropForeignKey("dbo.Chamado", "FinalizacaoModelId", "dbo.Finalizacao");
            DropColumn("dbo.Chamado", "FinalizacaoModelId");
            RenameColumn(table: "dbo.Chamado", name: "FuncionarioResponsavelId", newName: "FuncionarioResponsavel_FuncionarioModelId");
            CreateIndex("dbo.Chamado", "Finalizacao_FinalizacaoModelId");
            AddForeignKey("dbo.Chamado", "Finalizacao_FinalizacaoModelId", "dbo.Finalizacao", "FinalizacaoModelId");
        }
    }
}
