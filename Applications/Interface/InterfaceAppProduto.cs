using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Interface
{
    public interface InterfaceAppProduto : InterfaceGenericaApp<Produto>
    {
        void Add(Produto Produto);
        void Update(Produto Produto);
        void Delete(Produto Produto);
        Produto GetEntity(int Id);
        List<Produto> List();


        Produto AdicionarVerificarExisteNome(Produto produto);

    }
}
