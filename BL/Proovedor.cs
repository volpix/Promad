using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proovedor
    {

        public int IdProovedor { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public int ContadorProductos { get; set; }
        public List<object> Proovedores { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using(DL.PromadEntities context = new DL.PromadEntities())
                {
                    var query = context.ProovedoresGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Proovedor proovedores = new Proovedor();
                            proovedores.IdProovedor = obj.IdProovedor;
                            proovedores.Codigo = obj.Codigo;
                            proovedores.RazonSocial = obj.RazonSocial;
                            proovedores.RFC = obj.RFC;
                            proovedores.ContadorProductos = obj.Productos.Value;
                            result.Objects.Add(proovedores);
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
        public static Result Add(Proovedor proovedor)
        {
            Result result = new Result();
            try
            {
                using (DL.PromadEntities context = new DL.PromadEntities())
                {
                    var query = context.ProovedoresAdd(proovedor.Codigo, proovedor.RazonSocial, proovedor.RFC);
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
        public static Result Update(Proovedor proovedor)
        {
            Result result = new Result();
            try
            {
                using (DL.PromadEntities context = new DL.PromadEntities())
                {
                    var query = context.ProovedoresUpdate(proovedor.IdProovedor,proovedor.Codigo, proovedor.RazonSocial, proovedor.RFC);
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
        public static Result Delete(Proovedor proovedor)
        {
            Result result = new Result();
            try
            {
                using (DL.PromadEntities context = new DL.PromadEntities())
                {
                    var query = context.ProovedoresDelete(proovedor.IdProovedor);
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
        public static Result GetById(int IdProovedor)
        {
            Result result = new Result();
            try
            {
                using (DL.PromadEntities context = new DL.PromadEntities())
                {
                    var query = context.ProovedoresGetById(IdProovedor).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        
                            Proovedor proovedores = new Proovedor();
                            proovedores.IdProovedor = query.IdProovedor;
                            proovedores.Codigo = query.Codigo;
                            proovedores.RazonSocial = query.RazonSocial;
                            proovedores.RFC = query.RFC;

                            result.Object = proovedores;
                        
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
    }
}
