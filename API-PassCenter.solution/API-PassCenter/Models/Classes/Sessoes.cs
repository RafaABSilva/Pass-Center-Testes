﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Classes {
    public class Sessoes {
        public int Ses_codigo { get; set; }
        public DateTime Ses_horario_inicio { get; set; }
        public DateTime Ses_horario_fim { get; set; }
        public Totens Tot_codigo { get; set; }
        public Eventos Eve_codigo { get; set; }
        public HorariosEventos Hev_codigo { get; set; }
        public TiposInsercoes Tin_codigo { get; set; }
    }
}