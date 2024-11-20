using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadePattern.Dominio;

namespace FacadePattern.Incentivo
{
    public class IncentivoBo
    {
        public List<Dominio.Incentivo> ObtenerIncentivosEmpleado(string idEmpleado)
        {
            // ... Buscar incentivos otorgados al empleado con reglas de negocio.

            return new List<Dominio.Incentivo>()
            {
                new Dominio.Incentivo {Concepto = "Bono por cumplimiento", Valor = 200000},
                new Dominio.Incentivo {Concepto = "Bono por felicitaciones del cliente", Valor = 200000}
            };
        }
    }
}
