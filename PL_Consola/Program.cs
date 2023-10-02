namespace PL_Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la Accion:");
            Console.WriteLine("1)Agregar Receta");
            Console.WriteLine("2)Eliminar Receta");
            Console.WriteLine("3)Alterar Receta");
            Console.WriteLine("4)Ver toda la tabla");
            Console.WriteLine("5)Consulta por ID");
            int opc = int.Parse(s: Console.ReadLine());

            switch (opc)
            {
                case 1:
                    PL_Consola.RecetaMedica.Add();
                    Console.ReadKey();
                break;

                case 2:
                    PL_Consola.RecetaMedica.Dell();
                    Console.ReadKey();
                break;

                case 3:
                    PL_Consola.RecetaMedica.Update();
                    Console.ReadKey();
                break;

                case 4:
                    PL_Consola.RecetaMedica.GetAll();
                    Console.ReadKey();
                break;
                
                case 5:
                    PL_Consola.RecetaMedica.GetById();
                    Console.ReadKey();
                break;
            }
        }
    }
}