using System;
using System.Dynamic;
using System.Net.NetworkInformation;

//Ejercicio 1: Encapsulación con la Clase Producto

class Producto
{
    private int id;
    private string nombre = "";
    private double precio;
    private int stock;

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public string getNombre()
    {
        return nombre;
    }

    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public double getPrecio()
    {
        return precio;
    }

    public void setPrecio(double precio)
    {
        if (precio < 0)
        {
            Console.WriteLine("Error: El precio no puede ser negativo.");
        }
        else
        {
            this.precio = precio;
        }
    }

    public int getStock()
    {
        return stock;
    }

    public void setStock(int stock)
    {
        if (stock < 0)
        {
            Console.WriteLine("Error: El stock no puede ser menor que 0.");
        }
        else
        {
            this.stock = stock;
        }
    }

    //metodo para descontar stock
    public void DescontarStock(int cantidad)
    {
        if (this.stock - cantidad < 0)
        {
            Console.WriteLine("Error: No hay suficiente stock.");
        }
        else
        {
            this.stock -= cantidad;
            Console.WriteLine("Stock descontado exitosamente.");
        }
    }

}

//Ejercicio 2: Constructores con la Clase Circulo

class Circulo
{
    private double radio;

    //constructor sin argumentos por defecto
    public Circulo()
    {
        this.radio = 1.0;
        Console.WriteLine("Circulo creado con radio por defecto: 1.0");
    }

    //contructor con argumentos
    public Circulo(double radio)
    {
        if (radio <= 0)
        {
            Console.WriteLine($"Error: El radio debe ser mayor que 0.");
            Console.WriteLine("Asignando radio por defecto: 1.0");
            this.radio = 1.0;
        }
        else
        {
            this.radio = radio;
            Console.WriteLine($"Circulo creado con radio: {radio}");
        }
    }

    public double getRadio()
    {
        return radio;
    }

    public void setRadio(double radio)
    {
        if (radio <= 0)
        {
            Console.WriteLine("Error: EL radio debe ser mayor que 0.");
        }
        else
        {
            this.radio = radio;
            Console.WriteLine($"Radio actualizado a: {radio}");
        }
    }

    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    public double CalcularCircunferencia()
    {
        return 2 * Math.PI * radio;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Radio: {radio}");
        Console.WriteLine($"Area: {CalcularArea()}");
        Console.WriteLine($"Circunferencia: {CalcularCircunferencia()}\n");
    }
}


class Program
{
    static void Main(string[] arg)
    {
        // Para el Ejercicio 1
        Console.WriteLine("EJERCICIO 1: CLASE PRODUCTO\n");

        Producto p1 = new Producto();

        //Asignacion de los valores 
        Console.WriteLine("1. Creando producto con valores validos:");
        Console.WriteLine("Asignando ID: 101");
        p1.setId(101);

        Console.WriteLine("Asignando nombre: Laptop Asus Rog Strix");
        p1.setNombre("Laptop Asus Rog Strix");

        Console.WriteLine("Asignando Precio: $50000.00");
        p1.setPrecio(50000.00);

        Console.WriteLine("Asignando Stock: 10 unidades");
        p1.setStock(10);


        //mostrar los valores usando getters
        Console.WriteLine("\n Productos creado exitosamente");
        Console.WriteLine("  Informacion del prducto");
        Console.WriteLine($"ID: {p1.getId()}");
        Console.WriteLine($"Nombre: {p1.getNombre()}");
        Console.WriteLine($"Precio: ${p1.getPrecio()}");
        Console.WriteLine($"Stock: {p1.getStock()}\n");

        //asignando valores validos e invalidos para comprovar validaciones
        Console.WriteLine("2. PROBANDO VALIDACION DE PRECIO\n");

        Console.WriteLine("Intentando asigna precio valido: $60000.00");
        p1.setPrecio(60000.00);
        Console.WriteLine($"Precio actualizado a: ${p1.getPrecio():F2}\n");

        Console.WriteLine("Intentando asignar precio NEGATIVO: $-500.00");
        p1.setPrecio(-500.00);
        Console.WriteLine($"Precio actual (sin cambios): ${p1.getPrecio():F2}\n");

        Console.WriteLine("Intentando asignar precio NEGATIVO: $-100.00");
        p1.setPrecio(-100.00);
        Console.WriteLine($"Precio actual (sin cambios): ${p1.getPrecio():F2}\n");



        //validaciones de stock


        Console.WriteLine("3. PROBANDO VALIDACION DE STOCK\n");
        Console.WriteLine($"Stock actual: {p1.getStock()} unidades");
        Console.WriteLine("Intentando asignar stock valido: 25 unidades\n");
        p1.setStock(25);
        Console.WriteLine($"Stock actualizado a: {p1.getStock()} unidades");

        Console.WriteLine("Intentando asignar stock NEGATIVO: -10 unidades");
        p1.setStock(-10);
        Console.WriteLine($"Stock actual (sin cambios): {p1.getStock()} unidades\n");

        Console.WriteLine("Intentando asignar stock NEGATIVO: -5 unidades");
        p1.setStock(-5);
        Console.WriteLine($"Stock actual (sin cambios): {p1.getStock()} unidades\n");


        //prueba de descontar stock

        Console.WriteLine("4. PROBANDO METODO DESCONTAR STOCK");

        Console.WriteLine($"Stock disponible: {p1.getStock()} unidades\n");

        //caso 1: descuento validos
        Console.WriteLine("CASO 1: Descontar 5 unidades");
        Console.WriteLine($" Stock antes: {p1.getStock()} unidades");
        p1.DescontarStock(5);
        Console.WriteLine($" Stock despues: {p1.getStock()} unidades");
        Console.WriteLine("Descuento exitoso\n");

        //caso 2: descuento validos
        Console.WriteLine("CASO 2: Descontar 10 unidades");
        Console.WriteLine($" Stock antes: {p1.getStock()} unidades");
        p1.DescontarStock(10);
        Console.WriteLine($" Stock despues: {p1.getStock()} unidades");
        Console.WriteLine("Descuento exitoso\n");

        //caso 3: intento de descuento mayor al stock disponible
        Console.WriteLine("CASO 3: Intentar descontar 20 unidades (Mas de lo disponible)");
        Console.WriteLine($" Stock actual: {p1.getStock()} unidades");
        Console.WriteLine(" Intentando descontar: 20 unidades");
        p1.DescontarStock(20);
        Console.WriteLine($" Stock despues del intento: {p1.getStock()} unidades");
        Console.WriteLine("Operacion rechazada - stock insuficiente\n");

        //caso 4: descuento exacto del stock disponible
        Console.WriteLine("CASO 4: Descontar exactamente el stock disponible");
        Console.WriteLine($" Stock actual: {p1.getStock()} unidades");
        Console.WriteLine($" Descontando: {p1.getStock()} unidades");
        int stockActual = p1.getStock();
        p1.DescontarStock(stockActual);
        Console.WriteLine($" Stock despues: {p1.getStock()} unidades");
        Console.WriteLine($"Stock agotado correctamente\n");

        //caso 5: intento de descuento con stock en cero
        Console.WriteLine("CASO 5: Intentar descontar cuando stock = 0");
        Console.WriteLine($" Stock actual: {p1.getStock()} unidades");
        Console.WriteLine($" Intentando descontar: 1 unidad");
        p1.DescontarStock(1);
        Console.WriteLine($" Stock despues del intento: {p1.getStock()} unidades");
        Console.WriteLine($"Operacion rechazada - sin stock dispinible\n");


        //resumen 
        Console.WriteLine("5. ESTADO FINAL DEL PRODUCTO");
        Console.WriteLine($"ID: {p1.getId()}");
        Console.WriteLine($"Nombre: {p1.getNombre()}");
        Console.WriteLine($"Precio: ${p1.getPrecio()}");
        Console.WriteLine($"Stock: {p1.getStock()} unidades");

        Console.WriteLine("\n");



        //Para el ejercicio 2
        Console.WriteLine("\nEJERCICIO 2: CLASE CIRCULO");
        Console.WriteLine("Prueba de Constructores\n");

        Console.WriteLine("1. PROBANDO CONSTRUCTOR SIN ARGUMENTOS\n");

        Console.WriteLine("Creando c1");
        Circulo c1 = new Circulo();
        c1.MostrarInformacion();

        Console.WriteLine("2. PROBANDO CONSTRUCTOR CON ARGUMENTOS\n");

        Console.WriteLine("Creando c2 con valor de 5.0");
        Circulo c2 = new Circulo(5.0);
        c2.MostrarInformacion();

        Console.WriteLine("3. VALIDACION: CONSTRUCTOR CON RADIO NEGATIVO\n");

        Console.WriteLine("Creando c3 con valor de -3.0");
        Circulo c3 = new Circulo(-3.0);
        c3.MostrarInformacion();

        Console.WriteLine("4. VALIDACION: CONSTRUCTOR CON RADIO CERO\n");

        Console.WriteLine("Creando c4 con valor de 0");
        Circulo c4 = new Circulo(0);
        c4.MostrarInformacion();

        Console.WriteLine("5. COMPARACION ENTRE C1 Y C2\n");

        Console.WriteLine("CIRCULO 1 (radio = 1.0):");
        Console.WriteLine($" Radio: {c1.getRadio()}");
        Console.WriteLine($" Area: {c1.CalcularArea()}");
        Console.WriteLine($" Circunferencia: {c1.CalcularCircunferencia()}");

        Console.WriteLine("\nCIRCULO 2 (radio = 5.0):");
        Console.WriteLine($" Radio: {c2.getRadio()}");
        Console.WriteLine($" Area: {c2.CalcularArea()}");
        Console.WriteLine($" Circunferencia: {c2.CalcularCircunferencia()}\n");

        Console.WriteLine("6. PROBANDO VALIDACION CON RADIO NEGATIVO\n");
        Console.WriteLine("Asignando radio negativo de -2.0");
        c1.setRadio(-2.0);
        Console.WriteLine("Asignando radio valido de 7.5");
        c1.setRadio(7.5);
        c1.MostrarInformacion();

        Console.WriteLine("Precione cualquier tecla para salir");
        Console.ReadKey();
    }
}