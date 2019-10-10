using Domain.Entidades;
using Domain.Interfaces.Genericos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Produtos
{
    public interface InterfaceProduto : InterfaceGenerica<Produto>
    {
        void Add(Produto Produto);
        void Update(Produto Produto);
        void Delete(Produto Produto);
        Produto GetEntity(int Id);
        List<Produto> List();


        // customizados 
        bool VerificaSeprodutoExistePorNome(Produto produto);


    }
}
