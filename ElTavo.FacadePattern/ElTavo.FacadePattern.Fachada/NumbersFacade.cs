using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElTavo.FacadePattern.Fachada
{
    public class NumbersFacade
    {

        public void Tarea()
        {
            int[] valores1 = { 7, 9, 23, 56, 23, 34, 66, 78, 79, 34, 12, 16, 15 };
            int[] valores2 = { 721, 9, 423, 56, 23, 34, 966, 78, 79, 3664, 12, 5516, 15 };
            int[] numeros3 = { 5, 8, 6, 4, 8, 25, 4, 2, 8, 12, 45, 12, 6, 7, 8 };
            int nropares=0, nroimpares = 0;
            foreach (var item in valores1)
            {
                if (item % 2 == 0)
                {
                    nropares++;
                }
                else
                   nroimpares++;
            }
        }
   



    }
}
