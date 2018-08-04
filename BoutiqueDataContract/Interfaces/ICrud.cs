using System;
using System.Collections.Generic;
using System.Text;

namespace BoutiqueDataContract.Interfaces
{
    /// <summary>
    /// Interface para manipulação dos dados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrud<T>
    {
        /// <summary>
        /// Retorna uma Lista
        /// </summary>
        /// <returns></returns>
        List<T> GetLista();

        /// <summary>
        /// Recupera uma instancia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(long id);

        /// <summary>
        /// Adciona uma Instancia
        /// </summary>
        /// <param name="pessoa"></param>
        int Add(T pessoa);

        /// <summary>
        /// Elimina uma entrada no banco de dados
        /// </summary>
        /// <param name="id"></param>
        void Del(long id);

        /// <summary>
        /// Retorna o numero de pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        int Count();


    }
}
