namespace SisprodIT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setor",
                c => new
                    {
                        SetorModelId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sigla = c.String(nullable: false),
                        Descricao = c.String(),
                        Telefone = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SetorModelId);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        FuncionarioModelId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(),
                        RG = c.String(),
                        Nascimento = c.DateTime(),
                        Altura = c.Single(),
                        Usuario = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        PerfilModelId = c.Int(nullable: false),
                        SetorModelId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FuncionarioModelId)
                .ForeignKey("dbo.Setor", t => t.SetorModelId)
                .ForeignKey("dbo.Perfil", t => t.PerfilModelId)
                .Index(t => t.SetorModelId)
                .Index(t => t.PerfilModelId);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        PerfilModelId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilModelId);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        EmailModelId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FuncionarioModelId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmailModelId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioModelId)
                .Index(t => t.FuncionarioModelId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoModelId = c.Int(nullable: false, identity: true),
                        Pais = c.String(),
                        UF = c.String(),
                        Municipio = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        Complemento = c.String(),
                        Numero = c.Int(),
                        Referencia = c.String(),
                        CEP = c.String(),
                        FuncionarioModelId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoModelId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioModelId)
                .Index(t => t.FuncionarioModelId);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        TelefoneModelId = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        Telefone = c.Int(nullable: false),
                        FuncionarioModelId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TelefoneModelId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioModelId)
                .Index(t => t.FuncionarioModelId);
            
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
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        FuncionarioAtualizadorId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        FuncionarioResponsavel_FuncionarioModelId = c.Int(),
                        Finalizacao_FinalizacaoModelId = c.Int(),
                    })
                .PrimaryKey(t => t.ChamadoModelId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioCriadorId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioResponsavel_FuncionarioModelId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaModelId)
                .ForeignKey("dbo.Finalizacao", t => t.Finalizacao_FinalizacaoModelId)
                .Index(t => t.FuncionarioCriadorId)
                .Index(t => t.FuncionarioResponsavel_FuncionarioModelId)
                .Index(t => t.CategoriaModelId)
                .Index(t => t.Finalizacao_FinalizacaoModelId);
            
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
            DropIndex("dbo.Chamado", new[] { "Finalizacao_FinalizacaoModelId" });
            DropIndex("dbo.Chamado", new[] { "CategoriaModelId" });
            DropIndex("dbo.Chamado", new[] { "FuncionarioResponsavel_FuncionarioModelId" });
            DropIndex("dbo.Chamado", new[] { "FuncionarioCriadorId" });
            DropIndex("dbo.Telefone", new[] { "FuncionarioModelId" });
            DropIndex("dbo.Endereco", new[] { "FuncionarioModelId" });
            DropIndex("dbo.Email", new[] { "FuncionarioModelId" });
            DropIndex("dbo.Funcionario", new[] { "PerfilModelId" });
            DropIndex("dbo.Funcionario", new[] { "SetorModelId" });
            DropForeignKey("dbo.Comentario", "ChamadoModelId", "dbo.Chamado");
            DropForeignKey("dbo.Chamado", "Finalizacao_FinalizacaoModelId", "dbo.Finalizacao");
            DropForeignKey("dbo.Chamado", "CategoriaModelId", "dbo.Categoria");
            DropForeignKey("dbo.Chamado", "FuncionarioResponsavel_FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Chamado", "FuncionarioCriadorId", "dbo.Funcionario");
            DropForeignKey("dbo.Telefone", "FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Endereco", "FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Email", "FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "PerfilModelId", "dbo.Perfil");
            DropForeignKey("dbo.Funcionario", "SetorModelId", "dbo.Setor");
            DropTable("dbo.Comentario");
            DropTable("dbo.Finalizacao");
            DropTable("dbo.Categoria");
            DropTable("dbo.Chamado");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Email");
            DropTable("dbo.Perfil");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Setor");
        }
    }
}
