namespace SisprodIT2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SisprodIT2.Areas.Funcionario.Models;
    using SisprodIT2.Areas.Setor.Models;
    using SisprodIT2.Areas.Perfil.Models;
    using SisprodIT2.Areas.Categoria.Models;
    using SisprodIT2.Areas.Finalizacao.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SisprodIT2.Map.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SisprodIT2.Map.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Funcionarios.AddOrUpdate(p => p.FuncionarioModelId,
                new FuncionarioModel()
                {
                    FuncionarioModelId = 1,
                    Nome = "Flavio Alencar",
                    RG = "1231231",
                    CPF = "22333212312",
                    Altura = 1.75f,
                    Usuario = "flavio",
                    Senha = "1234",
                    Nascimento = DateTime.Now,
                    SetorModelId = 1,
                    PerfilModelId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true,
                    FuncionarioAtualizadorId = 1,
                    Setor = new SetorModel()
                    {
                        Nome = "CPD",
                        Descricao = "Centro de Processamento de Dados",
                        Sigla = "CPD",
                        FuncionarioAtualizadorId = 1,
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Telefone = "81-34128208",
                        Ativo = true
                    },

                    Perfil = new PerfilModel()
                    {
                        Descricao = "Administrador",
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Ativo = true,
                        FuncionarioAtualizadorId = 1
                    }

                },
                new FuncionarioModel()
                {
                    FuncionarioModelId = 2,
                    Nome = "Michel Temer",
                    RG = "1234567",
                    CPF = "12345678911",
                    Altura = 1.65f,
                    Usuario = "michel",
                    Senha = "1234",
                    Nascimento = DateTime.Now,
                    SetorModelId = 1,
                    PerfilModelId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true,
                    FuncionarioAtualizadorId = 1,
                    Setor = new SetorModel()
                    {
                        Nome = "Gerencia",
                        Descricao = "Setor da Gerência",
                        Sigla = "GER",
                        FuncionarioAtualizadorId = 1,
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Telefone = "81-34121234",
                        Ativo = true
                    },

                    Perfil = new PerfilModel()
                    {
                        Descricao = "Gerente",
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Ativo = true,
                        FuncionarioAtualizadorId = 1
                    }
                },

                new FuncionarioModel()
                {
                    FuncionarioModelId = 3,
                    Nome = "Fernando Henrique Cardoso",
                    RG = "7654321",
                    CPF = "98778978901",
                    Altura = 1.85f,
                    Usuario = "fernando",
                    Senha = "1234",
                    Nascimento = DateTime.Now,
                    SetorModelId = 1,
                    PerfilModelId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true,
                    FuncionarioAtualizadorId = 1,
                    Setor = new SetorModel()
                    {
                        Nome = "Financeiro",
                        Descricao = "Setor Financeiro",
                        Sigla = "FIN",
                        FuncionarioAtualizadorId = 1,
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Telefone = "81-34122222",
                        Ativo = true
                    },

                    Perfil = new PerfilModel()
                    {
                        Descricao = "Agente",
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Ativo = true,
                        FuncionarioAtualizadorId = 1
                    }
                },

                new FuncionarioModel()
                {
                    FuncionarioModelId = 4,
                    Nome = "Dilma Rousseff",
                    RG = "1134567",
                    CPF = "11122233345",
                    Altura = 1.55f,
                    Usuario = "dilma",
                    Senha = "1234",
                    Nascimento = DateTime.Now,
                    SetorModelId = 1,
                    PerfilModelId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true,
                    FuncionarioAtualizadorId = 1,
                    Setor = new SetorModel()
                    {
                        Nome = "Recursos Humanos",
                        Descricao = "Setor de Recursos Humanos",
                        Sigla = "REC",
                        FuncionarioAtualizadorId = 1,
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Telefone = "81-34121111",
                        Ativo = true
                    },

                    Perfil = new PerfilModel()
                    {
                        Descricao = "Cliente",
                        DataCadastro = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Ativo = true,
                        FuncionarioAtualizadorId = 1
                    }
                }

                );

            context.Categorias.AddOrUpdate(x => x.CategoriaModelId,
                new CategoriaModel()
                {
                    CategoriaModelId = 1,
                    Descricao = "Hardware",

                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new CategoriaModel()
                {
                    CategoriaModelId = 2,
                    Descricao = "Rede",

                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },

                new CategoriaModel()
                {
                    CategoriaModelId = 3,
                    Descricao = "Software",

                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new CategoriaModel()
                {
                    CategoriaModelId = 4,
                    Descricao = "Internet",

                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new CategoriaModel()
                {
                    CategoriaModelId = 5,
                    Descricao = "Telefonia",

                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new CategoriaModel()
                {
                    CategoriaModelId = 6,
                    Descricao = "Radio",

                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                }
                );

            context.Finalizacoes.AddOrUpdate(x => x.FinalizacaoModelId,
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 1,
                    Descricao = "Problemas com a internet",


                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 2,
                    Descricao = "Problemas com Hardware",


                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 3,
                    Descricao = "Problemas com Office",


                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 4,
                    Descricao = "Problemas com outros Softwares",


                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 5,
                    Descricao = "Cabo de rede desconectado",


                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 6,
                    Descricao = "Cabo de força folgado",


                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 7,
                    Descricao = "Problemas com Telefonia",

                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                },
                
                new FinalizacaoModel()
                {
                    FinalizacaoModelId = 8,
                    Descricao = "Problemas com Radio",


                    FuncionarioAtualizadorId = 1,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                }

                );

            base.Seed(context);
        }
    }
}
