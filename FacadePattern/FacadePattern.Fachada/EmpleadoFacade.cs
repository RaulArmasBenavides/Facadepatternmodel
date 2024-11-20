using System.Linq;
using FacadePattern.Beneficios;

using domino = FacadePattern.Dominio;

namespace FacadePattern.Fachada
{
    public class EmpleadoFacade
    {
        public double ObtenerTotalIngresosEmpleado(string idEmpleado)
        {
            var nomina = new Nomina.Nomina();
            var beneficio = new Beneficio();
            var incentivo = new Incentivo();

            var salario = nomina.ObtenerSalarioEmpleado(idEmpleado);
            var totalBeneficios = beneficio.ObtenerrBeneficiosEmpleado(idEmpleado).Sum(c => c.Valor);
            var totalIncentivos = incentivo.ObtenerIncentivosEmpleado(idEmpleado).Sum(c => c.Valor);

            return salario + totalBeneficios + totalIncentivos;
        }
    }
}
