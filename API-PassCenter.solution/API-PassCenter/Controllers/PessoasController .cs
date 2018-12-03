﻿using API_PassCenter.Models.Classes;
using API_PassCenter.Models.PasetoToken;
using API_PassCenter.Models.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_PassCenter.Controllers {
    public class PessoasController : ApiController {

        [HttpPost, Route("api/Pessoas")]
        // POST: api/Instituicoes
        public IHttpActionResult Post([FromBody]Pessoas pessoas) {

            if (autenticar.autenticacao(Request, 3) == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            Pessoas pes = new Pessoas();

            pes.Pes_nome = pessoas.Pes_nome;
            pes.Pes_sobrenomes = pessoas.Pes_sobrenomes;
            pes.Pes_cpf = pessoas.Pes_cpf;
            pes.Pes_rg = pessoas.Pes_rg;
            pes.Pes_matricula = pessoas.Pes_matricula;
            pes.Pes_sexo = pessoas.Pes_sexo;
            pes.Pes_tel_residencial = pessoas.Pes_tel_residencial;
            pes.Pes_tel_celular = pessoas.Pes_tel_celular;
            pes.Pes_info_adicionais = pessoas.Pes_info_adicionais;
            pes.End_codigo = pessoas.End_codigo;
            pes.Ins_codigo = pessoas.Ins_codigo;

            int retorno = PessoasDB.Insert(pes);

            if (retorno == -2) {
                return BadRequest();
            } else {
                return Ok(retorno);
            }
        }

        [HttpGet, Route("api/Pessoas")]
        // POST: api/Instituicoes
        public IHttpActionResult Get() {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            return Ok(PessoasDB.SelectID(Convert.ToInt32(credenciais.Pes_codigo)));
        }

        [HttpPut, Route("api/Pessoas")]
        // POST: api/Instituicoes
        public IHttpActionResult Put([FromBody]Pessoas pessoas) {

            Indentificacao credenciais = autenticar.autenticacao(Request, 5);

            if (credenciais == null) {
                return Content(HttpStatusCode.Forbidden, "Credenciais Invalidas!"); ;
            }

            pessoas.Pes_codigo = Convert.ToInt32(credenciais.Pes_codigo);

            if (PessoasDB.Update(pessoas) == -2) {
                return BadRequest();
            } else {
                return Ok();
            }
        }


    }
}