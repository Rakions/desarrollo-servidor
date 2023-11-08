namespace Models;
using Newtonsoft.Json;
public class Cuenta
{
    public int NumeroCuenta { get; set; }
    public string Owner { get; set; }
    public decimal Balance { get; set; } = 0;
    private List<Transacciones> MovimientosLista;
    private static int NumeroCuentaSeed = 1000;

    public Cuenta()
    {
        MovimientosLista = new List<Transacciones>();
    }
    public Cuenta(string _owner) : this()
    {
        Owner = _owner;
        NumeroCuenta = NumeroCuentaSeed;
        NumeroCuentaSeed++;
    }
    public Cuenta(string _owner, decimal _balance) : this(_owner)
    {
        Balance = _balance;
    }

    public void agregarDinero(decimal cantidad)
    {
        if (cantidad < 0)
        {
            throw new ArgumentOutOfRangeException("No puedes agregar dinero negativo");
        }
        this.Balance += cantidad;
        MovimientosLista.Add(new Transacciones(DateTime.Now, this.NumeroCuenta, cantidad));
        System.Console.WriteLine("Dinero depositado con éxito");
    }

    public void retirarDinero(decimal cantidad)
    {
        if (cantidad < 0)
        {
            throw new ArgumentOutOfRangeException("Indica cuanto quieres retirar con un número positivo");
        }

        if (Balance < cantidad)
        {
            throw new ArgumentOutOfRangeException("No puedes retirar más de lo que tienes");
        }
        this.Balance -= cantidad;
        MovimientosLista.Add(new Transacciones(DateTime.Now, this.NumeroCuenta, -cantidad));
        System.Console.WriteLine("Dinero retirado con éxito");
    }

    public void getTransacciones()
    {
        foreach (var t in MovimientosLista)
        {
            t.EscribirTransaccion();
        }
        System.Console.WriteLine(File.ReadAllText("./transacciones.json"));
    }

    public override string ToString()
    {
        return "Número de cuenta: " + this.NumeroCuenta + "| Propietario: " + this.Owner + "| Balance: " + this.Balance + "€";
    }


}