﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;


namespace API_PassCenter.Models.PasetoToken {
    public class autenticar {
        public static Indentificacao autenticacao(HttpRequestMessage re, int tipo) {
          
            try {
                var headers = re.Headers;
                string token = headers.Authorization.ToString().Replace("Bearer ", "");

                Indentificacao credenciais = Token.ValidarToken(token);

                if (credenciais.Tus_codigo <= tipo) {
                    return credenciais;
                }
                return null;
            } catch (Exception e) {
                return null;
            }


        }
    }
}