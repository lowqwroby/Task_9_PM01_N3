using System;
using System.Text;
using System.IO;
using System.Reflection;

namespace Variant10
{
	class Program
	{
		static void Main()
		{
			try
			{
				Console.Write("Введите число количества чисел: ");
				int n = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Введите последовательность из чисел");
				double[] numbers = new double[n];

				for (int i = 0; i < numbers.Length; i++)
				{
					numbers[i] = Convert.ToDouble(Console.ReadLine());
				}

				FileStream f = new FileStream("t.dat", FileMode.Open);
				BinaryWriter fOut = new BinaryWriter(f);

				for (int i = 0; i < numbers.Length; i++)
				{
					fOut.Write(numbers[i]);
				}

				fOut.Close();
				f = new FileStream("t.dat", FileMode.Open);
				BinaryReader fIn = new BinaryReader(f);
				long m = f.Length;

				Console.Write("Введите число, которое будет использоваться для определения нужных чисел: ");
				double num = Convert.ToDouble(Console.ReadLine());

				using (StreamWriter sw = new StreamWriter(File.Open("t.txt", FileMode.Create)))
				{
					for (long i = 0; i < m; i += 16)
					{
						f.Seek(i, SeekOrigin.Begin);
						double a = fIn.ReadDouble();
						if (a <= num)
						{
							Console.Write(a + " ");
							sw.Write(a + " ");
						}
					}
				}

				fIn.Close();
				f.Close();
			}
			catch
			{
				Console.WriteLine("Введены неверные значения");
			}
		}
	}
}