using Domain.Entidades;
using Domain.Interfaces.InterfaceServico;
using Domain.Interfaces.Produtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class ProdutoServico : IProdutoServico
    {

        private readonly InterfaceProduto _InterfaceProduto;

        public ProdutoServico(InterfaceProduto InterfaceProduto)
        {
            _InterfaceProduto = InterfaceProduto;
        }

        public Produto AdicionarVerificarExisteNome(Produto produto)
        {
            var nomeExiste = _InterfaceProduto.VerificaSeprodutoExistePorNome(produto);

            // Trasforma para maiusculo
            produto.Nome = TransformaTextoParaMaiusculo(produto.Nome);

            if (!nomeExiste)
            {
                _InterfaceProduto.Add(produto);
            }
            else
            {
                produto.notificacoes.Add(new Notificacoes.Notifica
                {
                    NomePropriedade = "Nome",
                    mensagem = "Já Existe produto com este Nome"
                });
            }

            return produto;
        }

        public string TransformaTextoParaMaiusculo(string nome)
        {
            return nome.ToUpper();
        }
    }
}
