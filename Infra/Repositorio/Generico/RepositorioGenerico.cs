using Domain.Interfaces.Genericos;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositorio.Generico
{
    public class RepositorioGenerico<T> : InterfaceGenerica<T>, IDisposable where T : class
    {

        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioGenerico()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }


        public void Adcionar(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Add(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public void Atualizar(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Update(Objeto);
                banco.SaveChangesAsync();
            }
        }



        public void Excluir(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Remove(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public IList<T> Listar()
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return banco.Set<T>().AsNoTracking().ToList();

            }
        }

        public T ObterPorId(int Id)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return banco.Set<T>().Find(Id);
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
