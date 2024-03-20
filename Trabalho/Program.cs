internal class Program
{
    static Queue<object> fila = new Queue<object>();
    static Stack<object> pilha = new Stack<object>();
    static List<object> lista = new List<object>();
    static Queue<object> filaau = new Queue<object>();
    static List<object> listaau = new List<object>();
    static object f = "";
    static object z = "";

    private static void Main(string[] args)
    {

        Menu();


    }


    static void Menu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        Console.WriteLine("|           SEJA BEM VINDO           |");
        Console.WriteLine("|         SELECIONE A OPÇÃO          |");
        Console.WriteLine("|       SETACIMA=1, SETABAIX=2,      |");
        Console.WriteLine("|       SETAESQ=3,  SETADIRE=4       |\n\n");
        Console.WriteLine("|     1.ADDNOMES   |   2.EDTNOMES    |");
        Console.WriteLine("|     3.VERNOMES   |   4.FINALIZAR   |");

        var dpadInput = GetDpadInput();


        while (dpadInput == dpadInput)
        {

            switch (dpadInput)
            {
                case DpadDirection.Up:
                    addnome();
                    break;

                case DpadDirection.Left:
                    vernomes();
                    break;

                case DpadDirection.Down:
                    edtmenu();
                    break;

                case DpadDirection.Right:
                    string x = "";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("DESEJA REALMENTE SAIR? (y/n)");
                    x = Console.ReadLine();
                    if(x == "y")
                    {
                        
                        Console.WriteLine("TENHA UM BOM DIA");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Menu();
                    }
                    
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("OPÇÃO INVALIDA TENTE NOVAMENTE");
                    Console.ReadKey();
                    Menu();
                    break;

            }
        }
    }

    static void addnome()
    {
        object x;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("DIGITE O NOME DESEJADO");
        x = Console.ReadLine();
        fila.Enqueue(x);
        lista.Add(x);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("NOME ADICONADO COM SUCESSO APERTE ENTER PARA CONTINUAR");
        Console.ReadKey();

        Console.Clear();


        if (fila.Count > 0)
        {
            Console.WriteLine("DESEJA ADICIONAR OUTRO NOME? (y/n)");
            string opc = "";
            opc = Console.ReadLine();

            if (opc == "y")
            {
                return;
            }
            else
            {
                Menu();
            }
        }

    }

    static void vernomes()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("SEGUE OS NOMES REGISTRADOS");

        Console.WriteLine("---NOMES--EM--FILA---");
        foreach (var item in fila)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("---NOMES--EM--LISTA");
        foreach (var item in lista)
        {
            Console.WriteLine(item.ToString());
        }
        Console.ReadKey();

        Menu();

    }

    static void edtmenu()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("|         MENU DE EDIÇAO       |\n");
        Console.WriteLine("|  SELECIONE A OPÇAO DESEJADA  |");
        Console.WriteLine("|   1=SETACIMA  |  2=SETABAIX  |");
        Console.WriteLine("|           3=SETAESQ          |\n\n");
        Console.WriteLine("|   1.REMNOMES  |  2.RESNOMES  |");
        Console.WriteLine("|          3.RETORNAR          |");

        var dpadInput = GetDpadInput();

        while (dpadInput == dpadInput)
        {
            switch (dpadInput)
            {
                case DpadDirection.Up:
                    remnomes();
                    break;
                case DpadDirection.Down:
                    resnomes();
                    break;
                case DpadDirection.Left:
                    Console.Clear();
                    string p = "";
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("DESEJA RETORNAR AO MENU INICIAL? (y/n)");
                    p = Console.ReadLine();
                    if (p == "y")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("VOLTANDO PARA O MENU");
                        Console.WriteLine("APERTE ENTER PARA CONTINUAR");
                        Console.ReadKey();
                        Menu();
                    }
                    else
                    {
                        
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("OPÇÃO INVALIDA TENTE NOVAMENTE");
                    Console.ReadKey();
                    edtmenu();
                    break;
            }
        }

    }

    static void remnomes()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("REMOVER O PRIMEIRO NOME DA LISTA?" + "(y/n)");
        string x = "";
        x = Console.ReadLine();
        if (x == "y")
        {
           
                if(lista.Count > 0) { 
                f = fila.Dequeue();
                filaau.Enqueue(f);
                pilha.Push(f);
                lista.Remove(f);
                listaau.Add(f);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("NOME REMOVIDO COM SUCESSO");

                Menu();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NAO HÁ NOMES PARA SEREM APAGADOS");

                    remnomes();
                }
            

        }
        else
        {
            Menu();
        }


    }

    static void resnomes()
    {
        Console.Clear();
        string x = "";
        Console.WriteLine("DESEJA RETORNAR O ULTIMO NOME REMOVIDO A LISTA?" + "(y/n)");
        x = Console.ReadLine();
        if (x == "y")
        {

            if (filaau.Count > 0)
            {
                z = filaau.Dequeue();
                fila.Enqueue(z);
                pilha.Pop();
                listaau.Remove(z);
                lista.Add(z);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("NOME RESTAURADO COM SUCESSO");
                Console.WriteLine("APERTE ENTER PARA VOLTAR");
                Console.ReadKey();

                Menu();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NAO HÁ NOME PARA RESTAURAR");
                Console.WriteLine("APERTE ENTER PARA VOLTAR");
                Console.ReadKey();

                edtmenu();
            }
        }
        else
        {
            Menu();
        }
    }

    static DpadDirection GetDpadInput()
    {
        if (Console.KeyAvailable == false)
        {
            var key = Console.ReadKey(intercept: false).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return DpadDirection.Up;

                case ConsoleKey.DownArrow:
                    return DpadDirection.Down;

                case ConsoleKey.LeftArrow:
                    return DpadDirection.Left;

                case ConsoleKey.RightArrow:
                    return DpadDirection.Right;

                default:
                    return DpadDirection.None;

            }
        }
        return DpadDirection.None;
    }


    enum DpadDirection
    {
        Up,
        Left,
        Down,
        Right,
        None
    }
}
