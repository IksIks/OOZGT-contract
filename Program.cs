using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООЗГТ_контрактники
{
    class Program
    {
		public static int[] fillingArray(int[] scoreAndNumber, int[] array, int vip = 0)
		{
			int symbol = scoreAndNumber[0];
			int numberOfSymbol = scoreAndNumber[1];
			if (scoreAndNumber.Length > 2 && symbol == 2)
			{
				for (int i = 2; i < scoreAndNumber.Length; i++)
				{
					int position = scoreAndNumber[i];
					array[position - 1] = symbol;
				}
			}
			else
			{
				int execute = 0;        //число которое будет исключаться из списка после присвоения
				for (int i = 0; i < numberOfSymbol; i++)
				{
					int test = 0;
					while (true)
					{
						test = sortingRandom(vip, array.Length, execute);    //случайное число переданное из функции ниже
						if (array[test] == 0)
						{
							array[test] = symbol;
							break;
						}
						else execute = test;
					}
				}
			}
			return array;
		}
		/// <summary>
		/// случайная генерация чисел с учетом не повторения уже выданных чмсел
		/// </summary>
		/// <param name="range">диапазон максимально генерируемого числа</param>
		/// <param name="executable">массив использованных чисел</param>
		/// <returns></returns>
		public static int sortingRandom(int rangeMin, int rangeMax, params int[] executable)
		{
			Random r = new Random();
			int[] validValues = Enumerable.Range(0, rangeMax).Except(executable).ToArray();
			return validValues[r.Next(rangeMin, validValues.Length)];
		}
		static void Main(string[] args)
        {
            string[] fileScore = File.ReadAllLines("оценки.txt");
            string[] pattern = new string[] { " ", "-", "(", ")", "," };
            int[] five = fileScore[0].Split(pattern, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] four = fileScore[1].Split(pattern, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] three = fileScore[2].Split(pattern, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] two = fileScore[3].Split(pattern, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            
            Random r = new Random();

            int random = 0;
            string[] fio = File.ReadAllLines("ФИО.txt");
            int[] temp = new int[fio.Length];
            int[] overallScore = fillingArray(five, fillingArray(four, fillingArray(three, fillingArray(two, temp))));

        }
    }
}
