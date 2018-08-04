using BoutiqueDataContract.Interfaces;
using BoutiquePool.DataDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoutiquePool.Business
{
    /// <summary>
    /// DEclaração da classe de Business Layer
    /// </summary>
    public class blPessoas
    {
        /// <summary>
        /// Interface que aponta para uma instancia do Data Layer
        /// </summary>
        private ICrud<Pessoa> DataLayer;

        /// <summary>
        /// Contrutor da Classe do Business Layer
        /// </summary>
        public blPessoas()
        {
            DataLayer = new DataLayer.DataAccess();
        }

        /// <summary>
        /// Retorna uma lista de pessoas salvas no banco de dados
        /// </summary>
        /// <returns></returns>
        public IList<Pessoa> GetListas()
        {
            return DataLayer.GetLista();
        }

        /// <summary>
        /// Conta o Numero de pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return DataLayer.Count();

        }

        /// <summary>
        /// Adiciona uma pessoa ao banco de dados
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public int Save( Pessoa pessoa)
        {
            if (!pessoa.Id.HasValue || DataLayer.Get(pessoa.Id.Value)==null)
                pessoa.Id = DataLayer.Add(pessoa);

            return 0;
        }

    }
}
