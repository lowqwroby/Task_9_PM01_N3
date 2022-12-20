using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Variant10
{
	class Program
	{
		static void Main()
		{
			try
			{
				StreamReader fileIn = new StreamReader("text.txt");
				string text = fileIn.ReadToEnd();
				fileIn.Close();
				string[] newText = Regex.Split(text, "[\n]+");
				for(int i = 0; i < newText.Length; i++)
				{
					for(int j = 0; j < newText[i].Length; j++)
					{
						if(newText[i][j] == ' ')
						{
							Console.WriteLine(newText[i]);
							break;
						}
					}
				}
			}
			catch
			{
				Console.WriteLine("Неизвестная ошибка");
			}
		}
	}
}