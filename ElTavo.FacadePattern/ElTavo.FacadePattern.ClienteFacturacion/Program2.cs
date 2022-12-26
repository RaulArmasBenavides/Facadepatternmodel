using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElTavo.FacadePattern.ClienteFacturacion
{
    class Program2
    {
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
            Console.WriteLine("Tiempo consumido por ProcesosThread es: " +  control.ElapsedTicks.ToString());
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
    }
}
