using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Notificacoes
{
    public class Notifica
    {

        public Notifica()
        {
            notificacoes = new List<Notifica>();
        }


        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string mensagem { get; set; }

        [NotMapped]
        public List<Notifica> notificacoes;
    }
}
