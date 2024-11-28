using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var editor = new TextEditor();
            var history = new History();

            editor.SetContent("Versión 1");
            history.Push(editor.Save()); // Guardar estado
            Console.WriteLine("Contenido actual: " + editor.GetContent());

            editor.SetContent("Versión 2");
            history.Push(editor.Save()); // Guardar estado
            Console.WriteLine("Contenido actual: " + editor.GetContent());

            editor.SetContent("Versión 3");
            Console.WriteLine("Contenido actual: " + editor.GetContent());

            // Deshacer cambios
            if (history.HasHistory())
            {
                editor.Restore(history.Pop());
                Console.WriteLine("Deshacer: " + editor.GetContent());
            }

            if (history.HasHistory())
            {
                editor.Restore(history.Pop());
                Console.WriteLine("Deshacer: " + editor.GetContent());
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
