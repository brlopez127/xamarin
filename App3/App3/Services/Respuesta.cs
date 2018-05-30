using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Services
{
    class RespuestaDocente
    {
        public int success { get; set; }
        public int responseCode { get; set; }
        public string message { get; set; }
        public data data { get; set; }
    }

    public class data
    {
        public int est_id { get; set; }
        public string est_nombre { get; set; }
        public string est_apellido { get; set; }
        public string est_semestre { get; set; }
        public string est_email { get; set; }
    }
}
