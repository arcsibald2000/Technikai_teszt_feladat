using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technikai_teszt_feladat
{
    class Program
    {
        delegate void UsingMethod(ref int[] arrays, ref int[] evenArrays);
        static void Main(string[] args)
        {
            Random r = new Random();

            List<int[]> arrays = GenerateArrays(20, 20, true, r); //Számok tömbjeinek listája.
            List<int[]> evenArrays = GenerateArrays(20, 20, false); //Páros számok tömbjeinek listája.

            ListIterator(ref arrays, ref evenArrays, MoveEvenNum);
            ListIterator(ref arrays, ref evenArrays, WriteOut);

            Console.Write("Nyomjon meg bármilyen gombot a kilépéshez...");
            Console.ReadKey();
        }

        /// <summary>
        /// Legenerálja a használni kívánt listát.
        /// </summary>
        /// <param name="listSize">Megadja a használni kívánt lista hosszát</param>
        /// <param name="arraySize">Megadja a tömbök hosszát.</param>
        /// <param name="fill">Logikai változó, fel kell e tölteni a tömböt vagy nem.</param>
        /// <param name="r">Random</param>
        /// <returns>A létrehozott int tömbökből álló listával tér vissza.</returns>
        static List<int[]> GenerateArrays(int listSize, int arraySize, bool fill, Random r = null)
        {
            List<int[]> arrays = new List<int[]>();
            for (int i = 0; i < listSize; i++)
            {
                arrays.Add(new int[arraySize]);

                if (fill)
                {
                    for (int j = 0; j < arraySize; j++)
                    {
                        arrays[i][j] = r.Next(1, 501);
                    }
                }
                
            }

            return arrays;
        }

        /// <summary>
        /// A listák kezeléséért felelős algoritmus.
        /// </summary>
        /// <param name="arrays">Számok teljes listája.</param>
        /// <param name="evenArrays">Páros számok listája.</param>
        /// <param name="UseMethod">Listák kezeléséhez használni kívánt metódus.</param>
        static void ListIterator(ref List<int[]> arrays, ref List<int[]> evenArrays, UsingMethod UseMethod)
        {
            for (int i = 0; i < arrays.Count; i++)
            {
                int[] temp = arrays[i];
                int[] eventemp = evenArrays[i];
                UseMethod(ref temp, ref eventemp);
                arrays[i] = temp;
                evenArrays[i] = eventemp;   
            }
        }

        /// <summary>
        /// A páros számok kiválogatására használt metódus.
        /// </summary>
        /// <param name="numbers">Számok teljes tömbje.</param>
        /// <param name="evenNums">Páros számok tömbje.</param>
        static void MoveEvenNum(ref int[] numbers, ref int[] evenNums)
        {
            int id = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNums[id] = numbers[i];
                    id++;
                }
            }


            int[] temp = evenNums;
            if(id == 0) evenNums = new int[0];
            else evenNums = new int[id];
            for (int i = 0; i < evenNums.Length; i++)
            {
                evenNums[i] = temp[i];
            }
            Array.Sort(evenNums);
        }

        /// <summary>
        /// Tömbök a consolra való kiíratásáért felelős metódus.
        /// </summary>
        ///  <param name="numbers">Számok teljes tömbje.</param>
        /// <param name="evenNums">Páros számok tömbje.</param>
        static void WriteOut(ref int[] numbers, ref int[] evenNums)
        {
            Console.WriteLine("Alap tömb elemei:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]}; ");
            }
            Console.WriteLine("\nPáros elemek: ");
            for (int i = 0; i < evenNums.Length; i++)
            {
                Console.Write($"{evenNums[i]}; ");
            }
            Console.WriteLine("\n");
        }
    }
}
