﻿using API_PassCenter.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Persistencia
{
    public class PresencasDB
    {
        public static int InsertPresencaProcedure(PresencasProcedure presencas)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "call InserirPresenca(?vEau_codigo, ?vPes_codigo, ?list_of_ids, ?vPre_horario_entrada, ?vPre_horario_saida, ?vSes_codigo);";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?vPre_horario_entrada", presencas.Pre_horario_entrada));
                objCommand.Parameters.Add(Mapped.Parameter("?vPre_horario_saida", presencas.Pre_horario_saida));
                objCommand.Parameters.Add(Mapped.Parameter("?list_of_ids", presencas.list_of_ids));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?vEau_codigo", presencas.vEau_codigo.Eau_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?vPes_codigo", presencas.vPes_codigo.Pes_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?vSes_codigo", presencas.Ses_codigo.Ses_codigo));

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

        public static int InsertPresenca(Presencas presencas)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "insert into presencas values(?Ses_codigo, ?Ide_codigo, ?Pre_horario_entrada, null, ?Pre_sessao_automatico);";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?Pre_horario_entrada", presencas.Pre_horario_entrada));
                objCommand.Parameters.Add(Mapped.Parameter("?Pre_sessao_automatico", presencas.Pre_sessao_automatico));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?Ses_codigo", presencas.Ses_codigo.Ses_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Ide_codigo", presencas.Ide_codigo.Ide_codigo));


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

        public static int deletePresenca(Presencas presencas)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "delete from presencas where ses_codigo = ?Ses_codigo and ide_codigo = ?Ide_codigo;";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                //FK e PK
                objCommand.Parameters.Add(Mapped.Parameter("?Ses_codigo", presencas.Ses_codigo.Ses_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Ide_codigo", presencas.Ide_codigo.Ide_codigo));


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


        public static int InsertPresencaTotem(Presencas presencas)
        {
            int retorno = 0;
            try
            {
                IDbConnection objConexao; // Abre a conexao
                IDbCommand objCommand; // Cria o comando
                string sql = "insert into presencas values(?Ses_codigo, ?Ide_codigo, ?Pre_horario_entrada, null, ?Pre_sessao_automatico);";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?Pre_horario_entrada", presencas.Pre_horario_entrada));
                objCommand.Parameters.Add(Mapped.Parameter("?Pre_sessao_automatico", presencas.Pre_sessao_automatico));
                //FK
                objCommand.Parameters.Add(Mapped.Parameter("?Ses_codigo", presencas.Ses_codigo.Ses_codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?Ide_codigo", presencas.Ide_codigo.Ide_codigo));
                
                
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

        public static DataSet Select(int ses_codigo, int eau_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select concat(pes_nome, ' ', pes_sobrenomes) as 'nomes_concatenados', pes_matricula, ses_codigo, pre_horario_entrada, ide_codigo from turmas " +
                "left join usuarios using (usu_codigo) " +
                 "inner join pessoas using (pes_codigo) " +
                "inner join identificadores using (usu_codigo) " +
                "left join (select * from presencas where ses_codigo = ?ses_codigo) as p using (ide_codigo) " +
                "where eau_codigo = ?eau_codigo ORDER BY concat(pes_nome, ' ', pes_sobrenomes) ASC";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?ses_codigo", ses_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectPresencas(int usu_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "SELECT eau_codigo, eve_nome, eve_sigla, eau_periodo_identificacao, " +
                "(select count(*) from sessoes where eau_codigo = e.eau_codigo) as 'sessoes', " +
                 "(select count(*) from presencas inner join sessoes using(ses_codigo) inner join identificadores using(ide_codigo) where usu_codigo = ?usu_codigo and eau_codigo = e.eau_codigo) as 'presencas' " +
                "FROM eventos_auditores e inner join eventos using(eve_codigo) inner join turmas using(eau_codigo) " +
                "where eau_estado = 1 and usu_codigo=?usu_codigo;";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usu_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }


        public static DataSet SelectPresencasRelatorio(int eau_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "SELECT (select concat(pes_nome,' ', pes_sobrenomes) from pessoas inner join usuarios using(pes_codigo) where usu_codigo = t.usu_codigo) as 'nome', " +
                "(select count(*) from sessoes where eau_codigo = e.eau_codigo) as 'sessoes', " +
                 "(select count(*) from presencas inner join sessoes using(ses_codigo) inner join identificadores using(ide_codigo) where usu_codigo = t.usu_codigo and eau_codigo = e.eau_codigo) as 'presencas' " +
                "FROM eventos_auditores e " +
                "inner join eventos using(eve_codigo) "+
                "inner join turmas t using(eau_codigo) "+
                "inner join pessoas using(pes_codigo) "+
                "where eau_codigo = ?eau_codigo and eau_estado = 1;";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectPresencasDiasFaltas(int usu_codigo, int eau_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "select * from sessoes where eau_codigo = ?eau_codigo and ses_codigo not in " +
                "(select ses_codigo from presencas " +
                 "inner join identificadores using (ide_codigo) " +
                "inner join sessoes using(ses_codigo) where eau_codigo=?eau_codigo and usu_codigo=?usu_codigo);";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usu_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?eau_codigo", eau_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }

        public static DataSet SelectPresencasPorPeriodoIdentificacao(string eau_periodo_identificacao, int usu_codigo)
        {
            //Imagine um DataSet como umamatriz de dados;

            DataSet ds = new DataSet();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataAdapter objDataAdapter;

            objConexao = Mapped.Connection();

            string sql = "SELECT eve_nome, eve_sigla, eau_periodo_identificacao, " +
                "(select count(*) from sessoes where eau_codigo = e.eau_codigo) as 'sessoes', " +
                 "(select count(*) from presencas inner join sessoes using(ses_codigo) inner join identificadores using(ide_codigo) where usu_codigo = ?usu_codigo and eau_codigo = e.eau_codigo) as 'presencas' " +
                "FROM eventos_auditores e inner join eventos using(eve_codigo) inner join turmas using(eau_codigo) " +
                "where eau_periodo_identificacao = ?eau_periodo_identificacao and usu_codigo=?usu_codigo;";

            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?eau_periodo_identificacao", eau_periodo_identificacao));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_codigo", usu_codigo));

            objDataAdapter = Mapped.Adapter(objCommand);

            objDataAdapter.Fill(ds);

            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();

            return ds;

        }
    }
}