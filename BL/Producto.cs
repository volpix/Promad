using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Proovedor Proovedor { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }
        public List<object> Productos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DL.PromadEntities context = new DL.PromadEntities())
                {
                    var query = context.ProductosGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Producto productos = new Producto();
                            productos.IdProducto = obj.IdProducto;

                            productos.Proovedor = new Proovedor();
                            productos.Proovedor.IdProovedor = obj.IdProovedor.Value;

                            productos.Codigo = obj.Codigo;
                            productos.Descripcion = obj.Descripcion;
                            productos.Unidad = obj.Unidad;
                            productos.Costo = obj.Costo.Value;

                            result.Objects.Add(productos);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static Result Add(Producto producto)
        {
            Result result = new Result();
            try
            {
                using (DL.PromadEntities context = new DL.PromadEntities())
                {
                    var query = context.ProductosAdd(producto.Proovedor.IdProovedor,producto.Codigo,producto.Descripcion,producto.Unidad,producto.Costo);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se Agrego correctamente el Empleado";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
