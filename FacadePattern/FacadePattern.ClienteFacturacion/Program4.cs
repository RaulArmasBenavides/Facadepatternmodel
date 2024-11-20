using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FacadePattern.ClienteFacturacion
{
    public class Program4
    {
        //Hosted web API REST Service base url
        //string Baseurl = "http://apiv3.geovictoria.com/";
        public static string signa = "HMAC-SHA1";
        public static string key = "56db35";
        public static string kag = "FxeClqdpBHUo68RWkNEJYZkxJeYyuN76";
        public static string tsello = "1655827023";
        public static string tauth = "1.0";

        public static string signature = "Qigv9YLEqTZX2bsZRutzLIzWlI8%3D";
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://apiv3.geovictoria.com/api/"),
            DefaultRequestHeaders = {
                                { "Authorization", $"OAuth oauth_consumer_key={key}, oauth_nonce={kag}, oauth_signature={signature}, oauth_signature_method={signa}, oauth_timestamp={tsello}, oauth_version={tauth}" },
            }
        };
        static void Main(string[] args)
        {
            /*Paso 5
            Ahora solo necesitamos llamar estos métodos a nuestro método 
            principal, ya que estamos probando el consumo de tiempo, por lo que llamaremos
            estos métodos entre el inicio y el final del cronómetro.*/
            Stopwatch control = new Stopwatch();
            Console.WriteLine("Ejecución de Thread Pool");
            control.Start();
            ProcesosThreadPool();
            control.Stop();

            Console.WriteLine("Tiempo consumido por ProcesosThreadPool es: " + control.ElapsedTicks.ToString());
            Console.WriteLine("Tiempo consumido por ProcesosThreadPool en ms: " + control.ElapsedMilliseconds.ToString());
            control.Reset();
            Console.WriteLine("Ejecución de Thread");
            control.Start();
            ProcesosThread();
            control.Stop();
            Console.WriteLine("Tiempo consumido por ProcesosThread es: " + control.ElapsedTicks.ToString());
            Console.WriteLine("Tiempo consumido por ProcesosThreadPool en ms: " + control.ElapsedMilliseconds.ToString());
            Console.ReadKey();
        }
        // Paso 4
        // Definimos los métodos que llamarán al método Proceso

        /* Paso 2
        Después debemos llamar a la clase de agrupación de threads  ThreadPool, 
        para usar el objeto de agrupaciones de threads, debemos llamar al
        método "QueueUserWorkItem" que nos provee de una función de colas para una
        ejecución y una función que ejecuta cuando un thread está disponible desde el conjunto de threads.
        ThreadPool.QueueUserWorkItem toma un método sobrecargado 
        llamado waitcallback que representa una función de devolución de llamada para ser
        ejecutada por un threadpool de threads. Si no hay un hilo disponible, esperará
        hasta que se libere uno.
        // Donde Proceso () es el método que ejecutará un thread de 
        threads.En este paso, compararemos cuánto tiempo tarda el objeto de thread y
        cuánto tiempo tarda el grupo de threads en ejecutar cualquier método. */
        static void ProcesosThreadPool()
        {
            for (int i = 0; i <= 700; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Proceso));
            }
        }
        // Paso 4
        // Definimos los métodos que llamarán al método Proceso
        static void ProcesosThread()
        {
            for (int i = 0; i <= 700; i++)
            {
                Thread hilo = new Thread(Proceso);
                hilo.Start();
            }
        }
        // Paso 3
        // Para ello, crearemos dos métodos llamados ProcesosThread() y 
        //ProcesosThreadPool() y dentro crearemos un bucle que itere 10 veces.Estos dos
        //métodos llamarán a un método simple llamado "Proceso()" que tiene un objeto de
        //entrada como parámetro ya que waitcallback necesita un parámetro de entrada para
        //las devoluciones de llamada.
        // Este método se llamarán mediante dos métodos para ejecutar: ProcesosThread() y ProcesosThreadPool()
        static void Proceso(object callback)
        {
        }

        //public async Task<RespServiceGeoVictoria> SyncGeoVictoriaAsync(int numsemanaactual)
        //{
        //    RespServiceGeoVictoria res = new RespServiceGeoVictoria();
        //    bool SyncTurno = true;
        //    bool SyncCargo = true;
        //    bool SyncTienda = true;

        //    bool FlagEliminar = true;
        //    bool FlagActualizar = true;
        //    bool FlagRegistrar = true;
        //    try
        //    {
        //        int contnew = 0;
        //        int contout = 0;
        //        List<EmpleadoTO> EmpInfo = new List<EmpleadoTO>();
        //        ObtenerFlags(1, ref SyncTurno, ref SyncCargo, ref SyncTienda);
        //        ObtenerFlags(2, ref SyncTurno, ref SyncCargo, ref SyncTienda);
        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Post,
        //            RequestUri = new Uri("http://apiv3.geovictoria.com/api/User/List"),
        //            Headers =
        //                {
        //                    { "Authorization", $"OAuth oauth_consumer_key={key}, oauth_nonce={kag}, oauth_signature={signature}, oauth_signature_method={signa}, oauth_timestamp={tsello}, oauth_version={tauth}" },
        //                },
        //        };
        //        using (var response = await _httpClient.SendAsync(request))
        //        {
        //            response.EnsureSuccessStatusCode();
        //            var body = await response.Content.ReadAsStringAsync();
        //            EmpInfo = JsonConvert.DeserializeObject<List<EmpleadoTO>>(body, new JsonSerializerSettings()
        //            {
        //                ContractResolver = new CustomContractResolver()
        //            });
        //        }
        //        List<EmpleadoTO> listemployeess = _EmpDataAccess.ReadEmployeesAllFromDataBase(Constantes.TIPO_EMPLEADO.TODOS);
        //        List<EmpleadoTO> listemployeessReactivate = _EmpDataAccess.ReadEmployeesAllFromDataBaseRemoved();
        //        List<EmpleadoTO> listemployeesToUpdate = new List<EmpleadoTO>();
        //        List<TiendaTO> listlocals = _TiendaDataAccess.ReadAllLocalsFromDataBase();

        //        //reactivar empleados
        //        foreach (var itemd in listemployeessReactivate)
        //        {
        //            if (EmpInfo.Where(p => p.DNI == itemd.DNI && p.Estado == "1").FirstOrDefault() != null)
        //            {
        //                _EmpDataAccess.ReactivateEmployee(itemd);
        //            }
        //        }

        //        //desactivar empleados que ya no están activos en geovictoria 
        //        foreach (var itemd in listemployeess)
        //        {
        //            if (EmpInfo.Where(p => p.DNI == itemd.DNI && p.Estado == "1").ToList().Count <= 0)
        //            {
        //                if (FlagEliminar)
        //                {
        //                    _EmpDataAccess.DisableEmployee(itemd);
        //                }
        //                contout++;
        //            }
        //            else
        //            {
        //                listemployeesToUpdate.Add(itemd);
        //            }
        //        }

        //        if (FlagActualizar)
        //        {
        //            foreach (var itemupdate in listemployeesToUpdate)
        //            {
        //                var itemfound = EmpInfo.First(p => p.DNI == itemupdate.DNI);

        //                //se sincronizará campo por campo de acuerdo a cómo esté parametrizado
        //                if (SyncTienda)
        //                {
        //                    itemfound.IdTienda = GetLocalIdFromList(itemfound.Tienda, listlocals);
        //                    //traslados
        //                    if (itemupdate.IdTienda != itemfound.IdTienda)
        //                    {
        //                        itemupdate.Idproxlocal = itemfound.IdTienda;
        //                        itemupdate.Observaciones = "SINCRONIZACIÓN GEOVICTORIA";
        //                        _EmpDataAccess.UpdateStatusDotEmployee(itemupdate, numsemanaactual, "traslado");
        //                    }
        //                }
        //                if (SyncCargo)
        //                {
        //                    itemupdate.Cargo = itemfound.Cargo;
        //                }

        //                if (SyncTurno)
        //                {
        //                    itemupdate.Turno = itemfound.Turno;
        //                }

        //                //estados de cese
        //                if (itemupdate.idstatusdot == 67)
        //                {
        //                    if ((numsemanaactual - 2 < _ParamDataAccess.CalcularSemana(itemupdate.fec_cese))
        //                        && _ParamDataAccess.CalcularSemana(itemupdate.fec_cese) < numsemanaactual)
        //                    {
        //                        itemupdate.idstatusdot = 68; //CESE SEMANA ACTUAL -> CESE SEMANA ANTERIOR
        //                    }
        //                }
        //                else
        //                if (itemupdate.idstatusdot == 68)
        //                {
        //                    if (_ParamDataAccess.CalcularSemana(itemupdate.fec_cese) < (numsemanaactual - 1))
        //                    {
        //                        itemupdate.idstatusdot = 1074;//CESE SEMANA ANTERIOR -> CESADO
        //                    }
        //                }
        //                else
        //                if (itemupdate.idstatusdot == 6)
        //                {
        //                    if (_ParamDataAccess.CalcularSemana(itemupdate.fec_cese) == (numsemanaactual))
        //                    {
        //                        itemupdate.idstatusdot = 67; //PROX CESE INMEDIATO -> CESE SEMANA ACTUAL
        //                    }
        //                }
        //                else
        //                if (itemupdate.idstatusdot == 5)
        //                {
        //                    if (_ParamDataAccess.CalcularSemana(itemupdate.fec_cese) == (numsemanaactual + 1))
        //                    {
        //                        //PROX CESE -> PROX CESE INMEDIATO
        //                        itemupdate.idstatusdot = 6;
        //                    }
        //                }

        //                else if (itemupdate.idstatusdot == (int)Constantes.ESTATUS.DMEDICO || itemupdate.idstatusdot == (int)Constantes.ESTATUS.DMEDEXTENSO || itemupdate.idstatusdot == (int)Constantes.ESTATUS.DMEDICOSINDOC)
        //                {
        //                    if (itemupdate.fec_fin_dmed < DateTime.Today)
        //                    {
        //                        itemupdate.idstatusdot = 12; //A TIENDA
        //                    }
        //                }
        //                else if (itemupdate.idstatusdot == (int)Constantes.ESTATUS.VACAS)
        //                {
        //                    if (itemupdate.fec_fin_vac < DateTime.Today)
        //                    {
        //                        itemupdate.idstatusdot = 12; //A TIENDA
        //                    }
        //                }
        //                else if (itemupdate.idstatusdot == (int)Constantes.ESTATUS.LICENCIA_CONGOCE || itemupdate.idstatusdot == (int)Constantes.ESTATUS.LICENCIA_SINGOCE || itemupdate.idstatusdot == (int)Constantes.ESTATUS.LICENCIA_CUARENTENA ||
        //                         itemupdate.idstatusdot == (int)Constantes.ESTATUS.LICENCIA_MATERNIDAD || itemupdate.idstatusdot == (int)Constantes.ESTATUS.LICENCIA_PATERNIDAD)
        //                {
        //                    if (itemupdate.fec_fin_lic < DateTime.Today)
        //                    {
        //                        itemupdate.idstatusdot = 12; //A TIENDA
        //                    }
        //                }
        //                //normalizar turno
        //                string cargoaux2 = itemupdate.Cargo;
        //                if (cargoaux2.Trim().ToUpper() == "CAMPAÑERO")
        //                {
        //                    itemupdate.Turno = "TC";
        //                }
        //                //_EmpDataAccess.UpdateStatusDotEmployee(itemupdate, numsemanaactual, "");
        //                _EmpDataAccess.UpdateStatusDotEmployeePorCampos(itemupdate);
        //            }
        //        }

        //        //registrar nuevos empleados 
        //        if (FlagRegistrar)
        //        {
        //            foreach (var item in EmpInfo)
        //            {
        //                if (item.Estado == "1") //usuario activo
        //                {
        //                    if (listemployeess.Where(p => p.DNI == item.DNI).ToList().Count <= 0)
        //                    {
        //                        item.IdTienda = GetLocalIdFromList(item.Tienda, listlocals);
        //                        //item.idmotcese = GetLocalIdFromList(item.Tienda, listlocals);
        //                        if (item.IdTienda >= 0)
        //                        {
        //                            contnew++;
        //                            //item.idmotcese = GetLocalIdFromList(item.Tienda, listlocals);
        //                            if (item.motivoceseaux != "" && item.motivoceseaux != null)
        //                            {
        //                                //item.idstatusdot = 5;
        //                                item.fec_cese = DateTime.ParseExact(item.fec_cese_t, "dd/MM/yyyy", CultureInfo.InvariantCulture); //Convert.ToDateTime(item.fec_cese_t);
        //                                int fec_proxcese = _ParamDataAccess.CalcularSemana(item.fec_cese);
        //                                if (fec_proxcese == numsemanaactual)
        //                                {
        //                                    item.idstatusdot = 67;
        //                                }
        //                                else if (fec_proxcese == numsemanaactual - 1)
        //                                {
        //                                    item.idstatusdot = 68;
        //                                }
        //                                else if (fec_proxcese == numsemanaactual + 1)
        //                                {
        //                                    item.idstatusdot = 6;
        //                                }
        //                                else if (fec_proxcese == numsemanaactual + 2)
        //                                {
        //                                    item.idstatusdot = 5;
        //                                }
        //                                else
        //                                    item.idstatusdot = 6;
        //                            }
        //                            else
        //                            {
        //                                item.idstatusdot = 12;
        //                            }

        //                            //normalizar turno
        //                            string cargoaux = item.Cargo;
        //                            if (cargoaux.Trim().ToUpper() == "CAMPAÑERO")
        //                            {
        //                                item.Turno = "TC";
        //                            }

        //                            if (item.DNI != null && StringHelper.VerificarTodosDigitos(item.DNI) && item.Turno != "Sin Turno" && item.Turno != null && item.UserProfile != "Operaciones - Jefe Zonal")
        //                            {
        //                                res = _EmpDataAccess.RegisterEmployee(item, numsemanaactual);
        //                            }
        //                            else
        //                            {
        //                                res.Code = true;
        //                            }

        //                            if (!res.Code)
        //                            {
        //                                return res;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (res.Code)
        //        {
        //            res.Code = true;
        //            res.CountIn = contnew;
        //            res.CountOut = contout;
        //            res.MessageResponse = " Actualización correcta";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.Code = false;
        //        res.MessageResponse = " Ocurrió un error en el servicio : " + ex.Message;
        //    }
        //    return res;
        //}
    }
}
