using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Threading;
using System.Configuration;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using EnvioCorreo;

namespace WSLeerPerformance
{
    /// <summary>
    /// Summary description for wsLeerPerformance
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsLeerPerformance : System.Web.Services.WebService
    {
        int iSegundosMuestra = int.Parse(ConfigurationManager.AppSettings["SegundosAdquisicion"].ToString());
        String nombreServidor = ConfigurationManager.AppSettings["NombreServidor"].ToString();

        [WebMethod (Description ="Obtiene el número de transacciones con código 00")]
        public MonitoreoData Autorizadas()
        {            
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                //cLogErrores.Escribir_Log_Evento("Se recibe una petición");
                //cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Autorizadas";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //TODO quita esta linea
                //iSuma = 10;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "AutorizadasTEN";

                //@200313 variable que obtiene una muestra del performance counter
                fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //TODO quita esta linea
                //iSuma = 10;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;

                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Autorizadas: " + ex.Message);                
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }


        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 02")]
        public MonitoreoData Codigo_2()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_2";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                //while (iContadorAux < iSegundosMuestra)//@200313 segundos
                //{
                //    fMuestra = fMuestra + oPC.NextValue();
                //    Thread.Sleep(500);
                //    iContadorAux = iContadorAux + 1;
                //}
                ////@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                //iSuma = (int)fMuestra;
                ////iSuma = 8;
                //datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_2TEN";
                //@200313 variable que obtiene una muestra del performance counter
                fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {                    
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 8;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_2: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 05")]
        public MonitoreoData Codigo_5()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_5";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 8;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_5TEN";
                //@200313 variable que obtiene una muestra del performance counter
                fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 8;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_5: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 35")]
        public MonitoreoData Codigo_35()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_35";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 9;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_35TEN";

                //@200313 variable que obtiene una muestra del performance counter
                fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 9;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_35: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 06")]
        public MonitoreoData Codigo_6()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_6";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 7;
                datosAdquiridos.contador = iSuma;

                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_6: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 65")]
        public MonitoreoData Codigo_65()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_65";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 6;
                datosAdquiridos.contador = iSuma;
                
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_65: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 66")]
        public MonitoreoData Codigo_66()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_66";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 5;
                datosAdquiridos.contador = iSuma;                
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_66: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 67")]
        public MonitoreoData Codigo_67()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_67";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 4;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_67TEN";

                //@200313 variable que obtiene una muestra del performance counter
                 fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                 iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                 iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 4;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_67: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 70")]
        public MonitoreoData Codigo_70()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_70";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 3;
                datosAdquiridos.contador = iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_70: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 71")]
        public MonitoreoData Codigo_71()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_71";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 2;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_71TEN";

                //@200313 variable que obtiene una muestra del performance counter
                 fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                 iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                 iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 2;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_71: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 72")]
        public MonitoreoData Codigo_72()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_72";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_72TEN";

                //@200313 variable que obtiene una muestra del performance counter
                fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_72: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 73")]
        public MonitoreoData Codigo_73()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_73";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_73TEN";

                //@200313 variable que obtiene una muestra del performance counter
                 fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                 iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                 iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_73: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 74")]
        public MonitoreoData Codigo_74()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();                
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                ////@200313 se le asigna el nombre de la categoria del contador a muestrear
                //oPC.CategoryName = "ServerPX";
                ////@200313 se le asigna el nombre del contador en el performance instanciado
                //oPC.CounterName = "Codigos_74";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                //while (iContadorAux < iSegundosMuestra)//@200313 segundos
                //{
                //    fMuestra = fMuestra + oPC.NextValue();
                //    Thread.Sleep(500);
                //    iContadorAux = iContadorAux + 1;
                //}
                ////@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                //iSuma = (int)fMuestra;
                ////iSuma = 1;
                //datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "pcCodigos74TEN";

                //@200313 variable que obtiene una muestra del performance counter
                fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_74: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 8")]
        public MonitoreoData Codigo_8()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_8";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_8TEN";

                //@200313 variable que obtiene una muestra del performance counter
                 fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                 iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                 iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_8: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 87")]
        public MonitoreoData Codigo_87()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_87";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = iSuma;                
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_87: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código genérico por intermitencias ligeras")]
        public MonitoreoData Codigo_Varios()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_Varios";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = iSuma;                
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_Varios: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }        

        [WebMethod(Description = "Método que realiza la comprobación de un puerto")]
        public string PuertoDisponible(string sPTO)
        {
            //@090114 instancio un objeto tcpclient que realiza el telnet
            TcpClient oTelnet = new TcpClient();
            try
            {
                //@090114 de la ip en string se hace un cast a ipaddress para trabajarla
                //IPAddress oIPAddress = IPAddress.Parse(ConfigurationSettings.AppSettings["IP local"].ToString());
                IPAddress oIPAddress = IPAddress.Parse(ConfigurationManager.AppSettings["IPlocal"].ToString());
                //@090114 se crea la instancia destino IP:PTO
                IPEndPoint oIP = new IPEndPoint(oIPAddress, int.Parse(sPTO));

                oTelnet.SendTimeout = 5;
                oTelnet.ReceiveTimeout = 5;
                //@090114 realizo el telnet
                oTelnet.Connect(oIP);

                //@090114 compruebo si se conectó
                if (oTelnet.Connected == true)
                {
                    oTelnet.Close();
                    return "Abierto, " + oIPAddress.ToString();
                }
                else
                {
                    return "Cerrado";
                }
            }
            catch (SocketException ex)
            {
                oTelnet.Close();
                return "Cerrado," + ex.Message;
            }
            catch (Exception ex)
            {
                oTelnet.Close();
                return "Cerrado," + ex.Message;
            }
            finally
            {
                //@090114 libero recursos
                GC.Collect();
            }
        }

        [WebMethod(Description = "Obtiene el número de transacciones con código 11")]
        public MonitoreoData Codigo_11()
        {
            MonitoreoData datosAdquiridos = new MonitoreoData();
            datosAdquiridos.nombreServidor = nombreServidor;
            try
            {
                //cLogErrores.sNombreLog = "WCFPerfo";
                //cLogErrores.sNombreOrigen = "WCFPerfo";
                ////cLogErrores.Crear_Log();
                //@200313 se instancia la clase performancecounter a un objeto a utilizar
                PerformanceCounter oPC = new PerformanceCounter();
                //@200313 se establece que a partir de aquí toda operación será de solo lectura
                oPC.ReadOnly = true;
                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "ServerPX";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_11";

                //@200313 variable que obtiene una muestra del performance counter
                float fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                int iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                int iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = iSuma;

                //@200313 se le asigna el nombre de la categoria del contador a muestrear
                oPC.CategoryName = "Tenserver";
                //@200313 se le asigna el nombre del contador en el performance instanciado
                oPC.CounterName = "Codigos_11TEN";

                //@200313 variable que obtiene una muestra del performance counter
                fMuestra = 0;
                //@200313 variable que almacena el valor final de la suma del muestreo
                iSuma = 0;
                //@200313 tomaré muestras cada medio segundo durante un periodo de tiempo para asegurar que se detecte una transacción
                iContadorAux = 0;
                while (iContadorAux < iSegundosMuestra)//@200313 segundos
                {
                    fMuestra = fMuestra + oPC.NextValue();
                    //@120218 Microsoft recomiendo minimo un segundo entre lectura
                    Thread.Sleep(1000);
                    iContadorAux = iContadorAux + 1;
                }
                //@200313 como el resultado del muestreo es flotante lo vamos a redondear a entero
                iSuma = (int)fMuestra;
                //iSuma = 1;
                datosAdquiridos.contador = datosAdquiridos.contador + iSuma;
                return datosAdquiridos;
            }
            catch (Exception)
            {
                //cLogErrores.Escribir_Log_Error("Codigo_8: " + ex.Message);
                return datosAdquiridos;
            }
            finally
            {
                GC.Collect();
            }
        }

        [WebMethod(Description = "Solo para envía de correo de apps que no tienen salida de SMTP")]        
        public RespuestaCorreo EnvioCorreoEspecial(configuracionMail configuracionMail, String titulo, String mensaje, Boolean esError)
        {
            EnviarCorreo enviarCorreo = new EnviarCorreo();
            RespuestaCorreo respuestaCorreo = new RespuestaCorreo();
            try
            {
                ConfiguracionCorreo configuracionCorreo = new ConfiguracionCorreo() {
                    conCertificado= configuracionMail.conCertificado,
                    listaDestinatarios= configuracionMail.listaDestinatarios,
                    listaDestinatariosError=configuracionMail.listaDestinatariosError,
                    pass= configuracionMail.pass,
                    pathLogo=configuracionMail.pathLogo,
                    puerto=configuracionMail.puerto,
                    remitente=configuracionMail.remitente,
                    smtp=configuracionMail.smtp,
                    usuario=configuracionMail.usuario,                    
                };
                respuestaCorreo = enviarCorreo.EnvioCorreo(configuracionCorreo, titulo, mensaje, esError);
                return respuestaCorreo;
            }
            catch (Exception ex)
            {
                respuestaCorreo.DescripcionError = ex.Message;
                return respuestaCorreo;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
