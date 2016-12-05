namespace SisprodIT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasChamados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chamado",
                c => new
                    {
                        ChamadoModelId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Revisao = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                        Descricao = c.String(),
                        CategoriaModelId = c.Int(nullable: false),
                        FuncionarioCriadorId = c.Int(nullable: false),
                        FuncionarioResponsavelId = c.Int(nullable: false),
                        FinalizacaoModelId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        FuncionarioResponsavel_FuncionarioModelId = c.Int(),
                    })
                .PrimaryKey(t => t.ChamadoModelId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioResponsavelId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioResponsavel_FuncionarioModelId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaModelId)
                .ForeignKey("dbo.Finalizacao", t => t.FinalizacaoModelId)
                .Index(t => t.FuncionarioResponsavelId)
                .Index(t => t.FuncionarioResponsavel_FuncionarioModelId)
                .Index(t => t.CategoriaModelId)
                .Index(t => t.FinalizacaoModelId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaModelId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaModelId);
            
            CreateTable(
                "dbo.Finalizacao",
                c => new
                    {
                        FinalizacaoModelId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FinalizacaoModelId);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        ComentarioModelId = c.Int(nullable: false, identity: true),
                        Comentario = c.String(nullable: false),
                        Ordem = c.Int(nullable: false),
                        ChamadoModelId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComentarioModelId)
                .ForeignKey("dbo.Chamado", t => t.ChamadoModelId)
                .Index(t => t.ChamadoModelId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comentario", new[] { "ChamadoModelId" });
            DropIndex("dbo.Chamado", new[] { "FinalizacaoModelId" });
            DropIndex("dbo.Chamado", new[] { "CategoriaModelId" });
            DropIndex("dbo.Chamado", new[] { "FuncionarioResponsavel_FuncionarioModelId" });
            DropIndex("dbo.Chamado", new[] { "FuncionarioResponsavelId" });
            DropForeignKey("dbo.Comentario", "ChamadoModelId", "dbo.Chamado");
            DropForeignKey("dbo.Chamado", "FinalizacaoModelId", "dbo.Finalizacao");
            DropForeignKey("dbo.Chamado", "CategoriaModelId", "dbo.Categoria");
            DropForeignKey("dbo.Chamado", "FuncionarioResponsavel_FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Chamado", "FuncionarioResponsavelId", "dbo.Funcionario");
            DropTable("dbo.Comentario");
            DropTable("dbo.Finalizacao");
            DropTable("dbo.Categoria");
            DropTable("dbo.Chamado");
        }
    }
}
