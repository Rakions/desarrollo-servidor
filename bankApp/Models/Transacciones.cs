using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Models
{
    public class Transacciones
    {
        public DateTime FechaTransaccion { get; set; }
        public int NumeroCuenta { get; set; }
        public decimal Cantidad { get; set; }

        public Transacciones(DateTime _fechaTransaccion, int _numeroCuenta, decimal _cantidad)
        {
            FechaTransaccion = _fechaTransaccion;
            NumeroCuenta = _numeroCuenta;
            Cantidad = _cantidad;
        }

        public override string ToString()
        {
            return "Fecha: " + this.FechaTransaccion + "| Cuenta: " + this.NumeroCuenta + "| Cantidad: " + this.Cantidad + "€";
        }

        public void EscribirTransaccion()
        {
            try
            {
                AgregarTransaccion(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la transacción: " + ex.Message);
            }
        }

        private void AgregarTransaccion(Transacciones nuevaTransaccion)
        {
            const string archivoJson = "./transacciones.json";

            List<Transacciones> transacciones = new List<Transacciones>();

            if (File.Exists(archivoJson))
            {
                string json = File.ReadAllText(archivoJson);
                transacciones = JsonConvert.DeserializeObject<List<Transacciones>>(json);
            }

            if (transacciones == null)
            {
                transacciones = new List<Transacciones>();
            }

            transacciones.Add(nuevaTransaccion);

            File.WriteAllText(archivoJson, JsonConvert.SerializeObject(transacciones, Formatting.Indented));
        }
    }
}
