using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Services
{
    interface IApi
    {
        Task<RespuestaDocente> EstudiantesApi ( string user, string password);
    }
}
