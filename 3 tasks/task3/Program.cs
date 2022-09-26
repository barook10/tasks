
class Program
{
    static char[,] minefield ={
      {'x','v','x','x','x'},
      {'x','x','v','x','x'},
      {'x','x','x','v','x'},
      {'x','x','x','v','x'},
      {'x','x','v','x','x'}
    };
    // array store safe path
    List<int[]> safePath = new List<int[]>();

    static int toshikaStep = -1;

    // Get size of minefield
    static int rows = minefield.GetLength(0);
    static int cols = minefield.GetLength(1);
    // Adjacent path coordinates 
    int[] adjacent_r = { -1, -1, -1, 0, 0, 1, 1, 1 };
    int[] adjacent_c = { -1, 0, 1, -1, 1, -1, 0, 1 };

    public bool isSafe(int horiz, int virti)
    {
        return minefield[horiz, virti] == 'v';
    }

    public bool isValid(int horiz, int virti)
    {
        return horiz < rows && virti < cols && horiz >= 0 && virti >= 0;
    }

    public void displayField()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(minefield[i, j] + "\t");
            }
            Console.WriteLine('\n');
        }
        Console.WriteLine("-----------------\n");
    }

    public void findPath(int horiz, int virti)
    {
        if (isSafe(horiz, virti))
        {
            if (horiz == 0)
            {
                // safePath.Add(new int[] {horiz,virti});
                safePath.Clear();
            }
            // Totoshka steps forward
            minefield[horiz, virti] = 'T';
            Console.WriteLine("Totoshka:" + horiz + ", " + virti);
            // Ally steps forward where Totoshka was
            if (toshikaStep > 0)
            {
                minefield[safePath[toshikaStep - 1][0], safePath[toshikaStep - 1][1]] = 'A';
                Console.WriteLine("Ally:" + safePath[toshikaStep - 1][0] + ", " + safePath[toshikaStep - 1][1] + "\n");
            }
            // mark visited
           if (toshikaStep > 1)
            {
                minefield[safePath[toshikaStep - 2][0], safePath[toshikaStep - 2][1]] = 'o';
            }
        
            displayField();
            safePath.Add(new int[] { horiz, virti });
            toshikaStep = safePath.Count;
            for (int i = 0; i < 8; i++)
            {
                if (isValid(horiz + adjacent_r[i], virti + adjacent_c[i]))
                {
                    if (safePath[toshikaStep - 1][0] == rows - 1)
                    {
                        break;
                    }
                    findPath(horiz + adjacent_r[i], virti + adjacent_c[i]);
                }
            }

        }//end if
    }//end findPath
    public void exit()
    {
        Console.WriteLine("Totoshka: Safe Zone");
        minefield[safePath[toshikaStep - 1][0], safePath[toshikaStep - 1][1]] = 'A';
        Console.WriteLine("Ally:" + safePath[toshikaStep - 1][0] + ", " + safePath[toshikaStep - 1][1] + "\n");
        minefield[safePath[toshikaStep - 2][0], safePath[toshikaStep - 2][1]] = 'o';
        displayField();

        Console.WriteLine("Totoshka: Safe Zone");
        Console.WriteLine("Ally: Safe Zone\n");
        minefield[safePath[toshikaStep - 1][0], safePath[toshikaStep - 1][1]] = 'o';
        displayField();

    }

    public static void Main(string[] args)
    {
        Program p = new Program();
        for (int i = 0; i < cols; i++)
        {
            p.findPath(0, i);
        }

        //exit function is called once Totoshka and Ally find the exit 
        p.exit();

       
        Console.WriteLine("====SAFE ZONE====\n");
        Console.WriteLine((char)2);
        
        
        Console.ReadLine();
    }


    // end of main


}