using BoutiquePool.DataDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoutiqueDataContract.DataDefinition.Enuns;
using BoutiqueDataContract.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BoutiquePool.DataLayer
{

    /// <summary>
    /// Implementa a interface ICrud(Operações basicas no banco de dados) da classe Pessoa
    /// </summary>
    public class DataAccess : ICrud<Pessoa>
    {
        //Instancia de conexao com o banco de dados
        private System.Data.SqlClient.SqlConnection connection;

        ///Contem a instancia usada para recuperrar os dados de configuração do sistemas
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Contrutor da Classe
        /// </summary>
        public DataAccess()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            connection = new System.Data.SqlClient.SqlConnection(Configuration["DatabaseSettings"]);
            connection.Open();
        }

        /// <summary>
        /// Retorna uma lista de Pessoas 
        /// </summary>
        /// <returns></returns>
        public List<Pessoa> GetLista()
        {
            List<Pessoa> retLista = new List<Pessoa>();

            System.Data.SqlClient.SqlCommand coGetLista = new System.Data.SqlClient.SqlCommand("sp_GetLista", connection);
            System.Data.SqlClient.SqlDataAdapter daGetLista = new System.Data.SqlClient.SqlDataAdapter(coGetLista);
            System.Data.DataSet dsLista = new System.Data.DataSet();

            daGetLista.Fill(dsLista);

            if (dsLista.Tables.Count > 0 &&  dsLista.Tables[0].Rows.Count>0)
            {
                foreach (System.Data.DataRow listarow in dsLista.Tables[0].Rows)
                {
                    retLista.Add(toModel(listarow));
                }
            }

            return retLista;

        }

        /// <summary>
        /// Usado para tranaformar uma entrada no banco para uma instancia da classe Pessoa
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Pessoa toModel( System.Data.DataRow dr)
        {
            return new Pessoa { Id = (int)dr.ItemArray[0], Nome = (string)dr.ItemArray[1], Email = (string)dr.ItemArray[2], Idade = (byte)dr.ItemArray[3], Profissao = (enProfissao)Enum.ToObject(typeof(enProfissao), dr.ItemArray[4]) , Status = (enStatus)Enum.ToObject(typeof(enStatus),dr.ItemArray[5]) };
        }

        /// <summary>
        /// Recupera uma instancia do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa Get(long id)
        {
            System.Data.SqlClient.SqlCommand coGetLista = new System.Data.SqlClient.SqlCommand("sp_GetPessoa", connection);

            coGetLista.Parameters.AddWithValue("@PessoaId", id);

            System.Data.SqlClient.SqlDataAdapter daGetLista = new System.Data.SqlClient.SqlDataAdapter(coGetLista);
            System.Data.DataSet dsLista = new System.Data.DataSet();

            daGetLista.Fill(dsLista);
            if (dsLista.Tables.Count > 0 && dsLista.Tables[0].Rows.Count > 0)
                return toModel(dsLista.Tables[0].Rows[0]);

            return null;
        }

        /// <summary>
        /// Adciona uma instancia da classe Pessoa ao Banco de Dados
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public int Add(Pessoa pessoa)
        {
            
            System.Data.SqlClient.SqlCommand coAddLista = new System.Data.SqlClient.SqlCommand();
            coAddLista.Connection = connection;
            coAddLista.CommandText = "sp_AddPessoa";
            coAddLista.CommandType = CommandType.StoredProcedure;
            coAddLista.Parameters.AddWithValue("@PessoaNome", pessoa.Nome);
            coAddLista.Parameters.AddWithValue("@PessoaEmail", pessoa.Email);
            coAddLista.Parameters.AddWithValue("@PessoaIdade", pessoa.Idade);
            coAddLista.Parameters.AddWithValue("@PessoaProfissao", (byte)pessoa.Profissao);
            coAddLista.Parameters.AddWithValue("@PessoaStatus", (byte)pessoa.Status);

            SqlParameter outputIdParam = new SqlParameter("@PessoaId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            coAddLista.Parameters.Add(outputIdParam);

            coAddLista.ExecuteNonQuery();

            return (outputIdParam.Value as int? ?? 0);

        }

        /// <summary>
        /// Remove uma instancia da classe Pessoa do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        public void Del(long id)
        {
            System.Data.SqlClient.SqlCommand coDelPessoa = new System.Data.SqlClient.SqlCommand("sp_DelPessoa", connection);

            coDelPessoa.Parameters.AddWithValue("@PessoaId", id);

            coDelPessoa.ExecuteNonQuery();

        }

        /// <summary>
        /// Atualiza uma instancia no Banco de Dados00
        /// </summary>
        /// <param name="pessoa"></param>
        public void UpdatePessoa(Pessoa pessoa)
        {
            Del(pessoa.Id.Value);
            Add(pessoa);

        }

        /// <summary>
        /// Retorna o numero de entradas no Banco de Dados
        /// 
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            System.Data.SqlClient.SqlCommand coCountPessoa = new System.Data.SqlClient.SqlCommand("sp_CountPessoa", connection);

            var returnValue =  coCountPessoa.ExecuteScalar();
            return (int)(returnValue ?? 0);
        }


    }

}


