using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Brive
{
    public class EBrive
    {
        public int Id { get; set; }
        public string Nombre_Prod { get; set; }

        public int Codigo_B { get; set; }

        public int Canti { get; set; }

        public float Precio_U { get; set; }

        public string Sucursal { get; set; }


    
    }
}
