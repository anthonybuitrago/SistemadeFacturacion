using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Facturas
    {
        private CD_Facturas objetoCD = new CD_Facturas();

        public void GuardarFactura(string num, string cliente, string montoTexto)
        {
            decimal monto = Convert.ToDecimal(montoTexto);
            decimal itbis = monto * 0.18m;
            decimal total = monto + itbis;
            objetoCD.Insertar(num, cliente, monto, itbis, total);
        }
        public DataTable MostrarFacturas()
        {
            return objetoCD.Listar();
        }
        public void AnularFactura(string num)
        {
            objetoCD.Anular(num);
        }
    }
}