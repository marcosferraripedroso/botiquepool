using BoutiqueDataContract.DataDefinition.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoutiquePool.DataDefinition
{
    /// <summary>
    /// Classe que abriga a definição de uma Pessoa(POCO)
    /// </summary>
    public class Pessoa
    {
        /// <summary>
        /// Idenficador da pessoa no sistema
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Nome da pessoa no sistema
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Email da pessoa no sistema
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Idade da pessoa no sistema
        /// </summary>
        public int Idade { get; set; }

        /// <summary>
        /// Profissao da Pessoa
        /// </summary>
        public enProfissao Profissao { get; set; }

        /// <summary>
        /// Sattus atual da pessoa
        /// </summary>
        public enStatus Status { get; set; }

    }

   
}
