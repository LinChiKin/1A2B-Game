using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1A2B_猜數字
{
    internal class Program
    {   
        public static string input;
        public static bool main_thread = true;
        public static Random rand = new Random();
        public static int[] ran_arr=new int[4];
        public static string ran_str="";
        public static int var_a;
        public static int var_b;
        public static void Main(string[] args)
        {
            /////////////////////////////////////////////start
            Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");
            Console.WriteLine("------");
            while (main_thread)
            {
                /////////////////////////////////////////random
                bool loop_ran = true;
                int ran_arr_index = 1;
                for (int i = 0; i < 4; i++)
                {
                    while (loop_ran)
                    {
                        int temp_int = rand.Next(0, 9);
                        bool is_repeated = false;
                        for (int k = 0; k < ran_arr_index; k++)
                        {
                            if (temp_int == ran_arr[k])
                            {
                                is_repeated = true;
                            }
                        }
                        if (!is_repeated)
                        {
                            ran_arr[i] = temp_int;
                            ran_arr_index++;
                            break;
                        }
                    }
                }

                for(int w=0;w<ran_arr.Length; w++)
                 {
                     Console.WriteLine($"Log>>ran_arr[{w}] : {ran_arr[w]}");
                 }

                ran_str = "";
                for(int i = 0; i < ran_arr.Length; i++)
                {
                    ran_str+=ran_arr[i];
                }
                //////////////////////////////////////////user turn             
                bool is_game_start = true;
                while (is_game_start)
                {
                    bool loop4 = true;
                    while (loop4)
                    {
                        Console.Write("請輸入 4 個數字： ");
                        input = Console.ReadLine();
                        try
                        {
                            if (input.Length != 4)
                            {

                                throw new Exception("Error");

                            }
                            int temp_input = int.Parse(input);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error ! Please enter 4 digit");
                        }
                    }
                    /////////
                    var_a = 0;
                    var_b = 0;
                    for (int i = 0; i < ran_str.Length; i++)
                    {
                        if (input[i] == ran_str[i])
                        {
                            var_a++;
                            continue;
                        }
                        for (int j = 0; j < ran_str.Length; j++)
                        {
                            if (input[i] == ran_str[j])
                            {
                                var_b++;
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"判定結果是 {var_a}A{var_b}B");
                    if (var_a == 4)
                    {
                        Console.WriteLine("恭喜你！猜對了！！");
                        Console.WriteLine("------");
                        break;
                    }
                    Console.WriteLine("------");
                }
                //////////////////////////////////////////again?
                bool loop2 = true;
                while (loop2)
                {
                    Console.Write("你要繼續玩嗎？(y / n):");
                    input = Console.ReadLine();
                    if (input == "n")
                    {
                        main_thread = false;
                        Console.WriteLine("遊戲結束，下次再來玩喔～");
                        Console.ReadKey();
                        break;
                    }else if(input == "y")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error ! Value must be \'y\' or \'n\'");
                    }
                }
            }
        }
    }
}
