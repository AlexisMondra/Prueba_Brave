using Data_Brive;
using Entity_Brive;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Buss_Brive
{
    public class BBrive
    {
        DBrive data = new DBrive();

        public List<EBrive> Obtener()
        {
            DataTable dt = data.Obtener();
            List<EBrive> list = new List<EBrive>();

            foreach (DataRow dr in dt.Rows)
            {

                EBrive producto = new EBrive();

                producto.Id = Convert.ToInt32(dr["Id"]);
                producto.Nombre_Prod = Convert.ToString(dr["Nombre"]);
                producto.Codigo_B= Convert.ToInt32(dr["Codigo_Barras"]);
                producto.Canti = Convert.ToInt32(dr["Cantidad"]);
                producto.Precio_U = Convert.ToInt32(dr["Precio_Uni"]);
                producto.Sucursal = Convert.ToString(dr["Sucursal"]);


                list.Add(producto);

            }
            return list;
        }
        
        //------

        public void Agregar(EBrive pr)
        {
            
            int resultado = data.Agregar(pr.Nombre_Prod, pr.Codigo_B, pr.Canti, pr.Precio_U,pr.Sucursal);
            if (resultado != 1)
                throw new ApplicationException($"Error al agregar el producto {pr.Nombre_Prod}");
        }

        public EBrive ObtenerId(int id)
        {
            DataRow dr = data.ObtenerId(id);
            EBrive producto = new EBrive();

            producto.Id = Convert.ToInt32(dr["Id"]);
            producto.Nombre_Prod = Convert.ToString(dr["Nombre"]);
            producto.Codigo_B = Convert.ToInt32(dr["Codigo_Barras"]);
            producto.Canti = Convert.ToInt32(dr["Cantidad"]);
            producto.Precio_U = Convert.ToInt32(dr["Precio_Uni"]);
            producto.Sucursal = Convert.ToString(dr["Sucursal"]);


            return producto;
        }
        public void Editar(EBrive pr)

        { 
            int fa = data.Editar(pr.Id,pr.Nombre_Prod, pr.Codigo_B, pr.Canti, pr.Precio_U, pr.Sucursal);

            if (fa != 1)
            {
                throw new ApplicationException($"Error al editar el producto {pr.Nombre_Prod}");

            }
        }

        public void Eliminar(EBrive pr)
        {
            int fa = data.Eliminar(pr.Id);

            if (fa != 1)
            {
                throw new ApplicationException($"Error al eliminar el producto {pr.Nombre_Prod}");

            }
        }

        public List<EBrive> Buscar(string Buscar)
        {
            DataTable dt = data.Buscar(Buscar);
            List<EBrive> list = new List<EBrive>();

            foreach (DataRow dr in dt.Rows)
            {

                EBrive producto = new EBrive();


                producto.Id = Convert.ToInt32(dr["Id"]);
                producto.Nombre_Prod = Convert.ToString(dr["Nombre"]);
                producto.Codigo_B = Convert.ToInt32(dr["Codigo_Barras"]);
                producto.Canti = Convert.ToInt32(dr["Cantidad"]);
                producto.Precio_U = Convert.ToInt32(dr["Precio_Uni"]);
                producto.Sucursal = Convert.ToString(dr["Sucursal"]);

                list.Add(producto);

            }
            return list;
        }


    }
}
