﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Presencas {
        public Sessoes Ses_codigo { get; set; }
        public Identificadores Ide_codigo { get; set; }
        public DateTime Pre_horario_entrada { get; set; }
        public DateTime Pre_horario_saida { get; set; }
        public bool Pre_sessao_automatico { get; set; }

    }
}