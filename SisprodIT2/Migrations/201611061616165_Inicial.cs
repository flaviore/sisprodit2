namespace SisprodIT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Telefone", new[] { "FuncionarioModelId" });
            DropIndex("dbo.Endereco", new[] { "FuncionarioModelId" });
            DropIndex("dbo.Email", new[] { "FuncionarioModelId" });
            DropIndex("dbo.Funcionario", new[] { "PerfilModelId" });
            DropIndex("dbo.Funcionario", new[] { "SetorModelId" });
            DropForeignKey("dbo.Telefone", "FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Endereco", "FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Email", "FuncionarioModelId", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "PerfilModelId", "dbo.Perfil");
            DropForeignKey("dbo.Funcionario", "SetorModelId", "dbo.Setor");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Email");
            DropTable("dbo.Perfil");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Setor");
        }
    }
}
