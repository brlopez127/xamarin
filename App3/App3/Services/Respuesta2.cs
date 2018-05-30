using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Services
{
   

    class RespuestaDocente2
    {
        public int success { get; set; }
        public int responseCode { get; set; }
        public string message { get; set; }
        public List<data2> data { get; set; }
    }

    public class data2
    {
        public string est_id { get; set; }
        public string est_nombre { get; set; }
        public string est_apellido { get; set; }
        public string ce_primera_nota { get; set; }
        public string ce_segunda_nota { get; set; }
        public string ce_tercera_nota { get; set; }
        public string ce_semestre { get; set; }
        public string car_nombre { get; set; }
        public string car_nornada { get; set; }
    }
}
