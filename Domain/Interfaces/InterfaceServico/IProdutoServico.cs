using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceServico
{
    public interface IProdutoServico
    {
        Produto AdicionarVerificarExisteNome(Produto produto);


        // Somente criado para Serviço
        string TransformaTextoParaMaiusculo(string nome);

    }
}
