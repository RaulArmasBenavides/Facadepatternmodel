using System.Linq;
using FacadePattern.Beneficios;
using FacadePattern.Nomina;
using FacadePattern.Incentivo;
using domino = FacadePattern.Dominio;

namespace FacadePattern.Fachada
{
    public class EmpleadoFacade
    {
        public double ObtenerTotalIngresosEmpleado(string idEmpleado)
        {
            var nomina = new NominaBo();
            var beneficio = new BeneficioBo();
            var incentivo = new IncentivoBo();

            var salario = nomina.ObtenerSalarioEmpleado(idEmpleado);
            var totalBeneficios = beneficio.ObtenerrBeneficiosEmpleado(idEmpleado).Sum(c => c.Valor);
            var totalIncentivos = incentivo.ObtenerIncentivosEmpleado(idEmpleado).Sum(c => c.Valor);

            return salario + totalBeneficios + totalIncentivos;
        }
    }
}
