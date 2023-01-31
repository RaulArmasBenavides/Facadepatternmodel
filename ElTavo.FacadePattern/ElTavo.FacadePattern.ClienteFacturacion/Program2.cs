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
            //Console.WriteLine("Ejecución de Thread Pool");
            //control.Start();
            //ProcesosThreadPool();
            //control.Stop();
            //Console.WriteLine("Tiempo consumido por ProcesosThreadPool es: " + control.ElapsedTicks.ToString());
            //Console.WriteLine("Tiempo consumido por ProcesosThreadPool en ms: " + control.ElapsedMilliseconds.ToString());
            //control.Reset();
            //Console.WriteLine("Ejecución de Thread");
            //control.Start();
            //ProcesosThread();
            //control.Stop();
            //Console.WriteLine("Tiempo consumido por ProcesosThread es: " +  control.ElapsedTicks.ToString());
            //Console.WriteLine("Tiempo consumido por ProcesosThreadPool en ms: " + control.ElapsedMilliseconds.ToString());
            //

            //ejemplo 2 
            control.Start();
            BadOne1();
            control.Stop();
            Console.WriteLine("Tiempo consumido por BadOne1 es: " + control.ElapsedTicks.ToString());
            control.Reset();
            control.Start();
            BadOne2();
            control.Stop();
            Console.WriteLine("Tiempo consumido por BadOne2 es: " + control.ElapsedTicks.ToString());
            Console.ReadKey();
        }
        // Paso 4
        // Definimos los métodos que llamarán al método Proceso

        /* Paso 2
        Después debemos llamar a la clase de agrupación de threads  ThreadPool, para usar el objeto de agrupaciones de threads, debemos llamar al
        método "QueueUserWorkItem" que nos provee de una función de colas para una ejecución y una función que ejecuta cuando un thread está disponible desde el conjunto de threads.
        ThreadPool.QueueUserWorkItem toma un método sobrecargado llamado waitcallback que representa una función de devolución de llamada para ser
        ejecutada por un threadpool de threads. Si no hay un hilo disponible, esperará hasta que se libere uno.
        Donde Proceso () es el método que ejecutará un thread de threads.
        En este paso, compararemos cuánto tiempo tarda el objeto de thread y cuánto tiempo tarda el grupo de threads 
        en ejecutar cualquier método. */
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



        static void BadOne1()
        {
            Thread t = new Thread(o =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("BadOne1");
                    Thread.Sleep(1000);
                }
            });
            t.Start(null);
        }


        static void BadOne2()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("BadOne2");
                    Thread.Sleep(1000);
                }
            });
        }

        static void GoodOne1()
        {
            int i = 0;
            Timer t = null;
            t = new Timer(o =>
            {
                Console.WriteLine("GoodOne1");
                if (Interlocked.Increment(ref i) == 10)
                {
                    // could tick, still
                    t.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
                    t.Dispose(); // or somewhere else
                }
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        void GoodOne2()
        {
            int i = 0;
            Timer t = null;
            t = new Timer(o =>
            {
                Console.WriteLine("GoodOne2");
                if (Interlocked.Increment(ref i) == 10)
                {
                    // could tick, still
                    t.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
                    t.Dispose(); // or somewhere else
                }
                else
                {
                    t.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
                }
            }, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);
        }

        //void GoodOne3()
        //{
        //    IDisposable obs = null;
        //    obs = Observable
        //        .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
        //        .Take(10)
        //        .Subscribe(_ =>
        //        {
        //            Console.WriteLine("GoodOne3");
        //        }, () => obs.Dispose() /* or somewhere else */);
        //}
    }
}
