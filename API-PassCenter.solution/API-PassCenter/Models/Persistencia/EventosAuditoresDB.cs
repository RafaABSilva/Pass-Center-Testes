﻿using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class EventosAuditoresDB
    {
        public static int Insert(EventosAuditores eau)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "INSERT INTO eventos_auditores (eau_periodo_identificacao, eau_estado, eau_data_abertura, pes_codigo, eve_codigo, eau_operacao, ins_codigo)" +
                    " VALUES(?eau_periodo_identificacao, ?eau_estado, ?eau_data_abertura, ?pes_codigo, ?eve_codigo, ?eau_operacao, ?ins_codigo);" +
                    "SELECT LAST_INSERT_ID();";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?eau_periodo_identificacao", eau.Eau_periodo_identificacao));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_estado", eau.Eau_estado));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_operacao", eau.Eau_operacao));
                objCommand.Parameters.Add(Mapped.Parameter("?eau_data_abertura", eau.Eau_data_abertura));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", eau.Pes_codigo.Pes_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?eve_codigo", eau.Eve_codigo.Eve_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", eau.Ins_codigo.Ins_codigo));

                retorno = Convert.ToInt32(objCommand.ExecuteScalar());

                objConexao.Close();
                objCommand.Dispose();
                objConexao.Dispose();
            }
            catch (Exception e)
            {
                retorno = -2;
            }
            return retorno;
        }

        public static DataSet Select(int instituicao)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from eventos_auditores " +
                "inner join pessoas using (pes_codigo) " +
                "inner join eventos using (eve_codigo) " +
                "where pessoas.ins_codigo = ?ins_codigo";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectADM()
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from eventos_auditores " +
                "inner join pessoas using (pes_codigo) " +
                "inner join eventos using (eve_codigo);";
            objCommand = Mapped.Command(sql, objConexao);

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectPeriodosIdentificacao(int pessoa)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "SELECT eau_periodo_identificacao FROM " +
                "eventos_auditores where pes_codigo = ?pes_codigo " +
                "group by eau_periodo_identificacao;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pessoa));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
        public static DataSet SelectParticipantesPeriodosIdentificacao(int usuario)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "SELECT eau_periodo_identificacao FROM eventos_auditores inner join turmas using(eau_codigo) " +
                "where usu_codigo = ?usu_codigo " +
                "group by eau_periodo_identificacao;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usuario));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
        public static DataSet SelectDisciplinaHistorico(int pessoa, String identificacao)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "SELECT * FROM eventos_auditores inner join eventos using(eve_codigo) " +
                "where eau_periodo_identificacao = ?eau_periodo_identificacao and pes_codigo = ?pes_codigo;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_periodo_identificacao", identificacao));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pessoa));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectParticipantesDisciplinaHistorico(int usuario, String identificacao)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "SELECT * FROM eventos_auditores inner join eventos using(eve_codigo) inner join turmas using(eau_codigo) " +
                "where eau_periodo_identificacao = ?eau_periodo_identificacao and eau_estado = 0 and usu_codigo = ?usu_codigo;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_periodo_identificacao", identificacao));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usuario));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectDisciplinas(int pes_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from eventos_auditores " +
                "inner join eventos using (eve_codigo) " +
                "where pes_codigo = ?pes_codigo and eau_estado = 1";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?pes_codigo", pes_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectPorNome(string nome, int instituicao)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select eau_codigo, eve_nome, eve_sigla , pes_nome, pes_sobrenomes from eventos_auditores eau " +
                "inner join eventos using(eve_codigo) " +
                "inner join pessoas using (pes_codigo) " +
                "where eve_nome like ?eve_nome and eau.ins_codigo = ?ins_codigo and tev_codigo = 1;";
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eve_nome", nome));
            objCommand.Parameters.Add(Mapped.Parameter("?ins_codigo", instituicao));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}