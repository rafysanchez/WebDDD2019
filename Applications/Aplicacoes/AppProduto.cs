using Applications.Interface;
using Domain.Entidades;
using Domain.Interfaces.InterfaceServico;
using Domain.Interfaces.Produtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Aplicacoes
{
    public class AppProduto : InterfaceAppProduto
    {

        InterfaceProduto _InterfaceProduto;

        IProdutoServico _IProdutoServico;

        public AppProduto(InterfaceProduto InterfaceProduto, IProdutoServico IProdutoServico)
        {
            _InterfaceProduto = InterfaceProduto;
            _IProdutoServico = IProdutoServico;
        }


        public Produto AdicionarVerificarExisteNome(Produto produto)
        {
            return _IProdutoServico.AdicionarVerificarExisteNome(produto);
        }


        #region Metodos CORE
        public void Adcionar(Produto Objeto)
        {
            _InterfaceProduto.Adcionar(Objeto);
        }



        public void Atualizar(Produto Objeto)
        {
            _InterfaceProduto.Atualizar(Objeto);
        }


        public void Excluir(Produto Objeto)
        {
            _InterfaceProduto.Excluir(Objeto);
        }



        public IList<Produto> Listar()
        {
            return _InterfaceProduto.Listar();
        }

        public Produto ObterPorId(int Id)
        {
            return _InterfaceProduto.ObterPorId(Id);
        }


        #endregion


        public void Add(Produto Produto)
        {
            _InterfaceProduto.Add(Produto);
        }

        public void Delete(Produto Produto)
        {
            _InterfaceProduto.Delete(Produto);
        }

        public Produto GetEntity(int Id)
        {
            return _InterfaceProduto.GetEntity(Id);
        }

        public List<Produto> List()
        {
            return _InterfaceProduto.List();
        }

        public void Update(Produto Produto)
        {
            _InterfaceProduto.Update(Produto);
        }


    }
}
