using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadePattern.Dominio;

namespace FacadePattern.Beneficios
{
    public class BeneficioBo
    {
        public List<Beneficio> ObtenerrBeneficiosEmpleado(string idEmpleado)
        {
            // ... Buscar beneficios del empleado en particular.

            // ... Calculos para determinar si el empleado tiene un beneficio o no.

            return new List<Beneficio>()
            {
                new Beneficio {Nombre = "Prima extralegal 1", Valor = 2000000},
                new Beneficio {Nombre = "Prima extralegal 2", Valor = 1000000},
                new Beneficio {Nombre = "Subsidio para hijos", Valor = 500000}
            };
        }
    }
}
