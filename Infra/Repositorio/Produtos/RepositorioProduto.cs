using Domain.Entidades;
using Domain.Interfaces.Produtos;
using Infra.Configuracao;
using Infra.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infra.Repositorio.Produtos
{
    public class RepositorioProduto : RepositorioGenerico<Produto>, InterfaceProduto
    {

        private readonly DbContextOptionsBuilder<Contexto> _OptionsBuilder;

        public RepositorioProduto()
        {
            _OptionsBuilder = new DbContextOptionsBuilder<Contexto>();
        }


        public bool VerificaSeprodutoExistePorNome(Produto produto)
        {
            using (var banco = new Contexto(_OptionsBuilder.Options))
            {
                return banco.Produto.Where(p => p.Nome.ToUpper() == produto.Nome.ToUpper())
                     .Select(p => p.Nome).Any();
            }
        }



        public void Add(Produto Produto)
        {
            using (var banco = new Contexto(_OptionsBuilder.Options))
            {
                var param = new SqlParameter("@NomeProduto", Produto.Nome);
                var param2 = new SqlParameter("@Preco", Produto.Preco);
                banco.Database.ExecuteSqlCommand("SalvarProduto @NomeProduto , @Preco", param, param2);
                banco.SaveChanges();
            }
        }



        public void Delete(Produto Produto)
        {
            using (var banco = new Contexto(_OptionsBuilder.Options))
            {
                var param = new SqlParameter("@Id", Produto.Id);
                banco.Database.ExecuteSqlCommand("ExcluirProduto @Id", param);
                banco.SaveChanges();
            }
        }

        public Produto GetEntity(int Id)
        {
            using (var banco = new Contexto(_OptionsBuilder.Options))
            {
                var param = new SqlParameter("@Id", Id);
                return banco.Produto.FromSql("ObterPorId @Id", param).FirstOrDefault();
            }
        }

        public List<Produto> List()
        {
            using (var banco = new Contexto(_OptionsBuilder.Options))
            {
                return banco.Produto.FromSql("ListarTodos").ToList();
            }
        }

        public void Update(Produto Produto)
        {
            using (var banco = new Contexto(_OptionsBuilder.Options))
            {
                var param = new SqlParameter("@NomeProduto", Produto.Nome);
                var param2 = new SqlParameter("@Preco", Produto.Preco);
                var param3 = new SqlParameter("@Id", Produto.Id);

                banco.Database.ExecuteSqlCommand("AtualizarProduto @NomeProduto,@Preco, @Id", param, param2, param3);
                banco.SaveChanges();
            }
        }


    }
}
