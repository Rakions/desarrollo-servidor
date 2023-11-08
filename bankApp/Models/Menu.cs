using Models;

public class Menu
{
    public Menu()
    {
        int opcion = 0;
        Cuenta cuenta = null;
        while (opcion != 6)
        {
            // Mostrar menu por pantalla
            System.Console.WriteLine("---------------MENU---------------");
            System.Console.WriteLine("Que quieres hacer: \n 1.Crear cuenta \n 2.Depositar dinero \n 3.Retirar dinero \n 4.Ver movimientos \n 5.Ver información de la cuenta \n 6.Salir");
            opcion = leerNumero();
            switch (opcion)
            {
                case 1:
                    // Crear cuenta (1 por ejecucion)
                    if (cuenta == null)
                    {
                        System.Console.WriteLine("---------------CREAR CUENTA--------------- \n Introduce tu nombre: ");
                        string nombre = Console.ReadLine();
                        if (nombre == null || nombre == "")
                        {
                            System.Console.WriteLine("Nombre no introducido, saliendo del programa");
                        }
                        else
                        {
                            cuenta = new Cuenta(nombre);
                            System.Console.WriteLine("Cuenta creada con exito");
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("Cuenta ya creada");
                    }
                    break;
                case 2:
                    // Agregar dinero
                    if (cuenta != null)
                    {
                        System.Console.WriteLine("---------------DEPOSITAR DINERO--------------- \n ¿Cuánto deseas depositar?");
                        cuenta.agregarDinero(leerDecimal());
                    }
                    else
                    {
                        System.Console.WriteLine("Primero debes crear una cuenta.");
                    }
                    break;
                case 3:
                    // Retirar dinero
                    if (cuenta != null)
                    {
                        System.Console.WriteLine("---------------RETIRAR DINERO--------------- \n ¿Cuanto quieres retirar?");
                        cuenta.retirarDinero(leerDecimal());
                    }
                    else
                    {
                        System.Console.WriteLine("Primero debes crear una cuenta.");
                    }

                    break;
                case 4:
                    // Lista de movimientos
                    if (cuenta != null)
                    {
                        System.Console.WriteLine("---------------LISTA DE MOVIMIENTOS---------------");
                        cuenta.getTransacciones();
                    }
                    else
                    {
                        System.Console.WriteLine("Primero debes crear una cuenta.");
                    }
                    break;
                case 5:
                    //Ver información de la cuenta
                    if (cuenta != null)
                    {
                        System.Console.WriteLine("---------------INFORMACIÓN DE LA CUENTA---------------");
                        System.Console.WriteLine(cuenta.ToString());
                    }
                    else
                    {
                        System.Console.WriteLine("Primero debes crear una cuenta.");
                    }
                    break;
                case 6:
                    // Salir
                    System.Console.WriteLine("Saliendo del programa");
                    break;

            }
        }
    }
    int leerNumero()
    {
        string numeroStr = Console.ReadLine();
        int numero;
        Int32.TryParse(numeroStr, out numero);
        return numero;
    }

    decimal leerDecimal()
    {
        string numeroStr = Console.ReadLine();
        decimal numero;
        Decimal.TryParse(numeroStr, out numero);
        return numero;
    }
}