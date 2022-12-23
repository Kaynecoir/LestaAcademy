using System;

namespace LestaAcademyWork1
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] array = new int[][] {
				new int[]{1, -1, 2, -1, 3},
				new int[]{1,  0, 2,  0, 3},
				new int[]{1, -1, 2, -1, 3},
				new int[]{1,  0, 2,  0, 3},
				new int[]{1, -1, 2, -1, 3}};
			Cell[][] CellMap = new Cell[5][]
			{
				new Cell[5],
				new Cell[5],
				new Cell[5],
				new Cell[5],
				new Cell[5]
			};

			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					CellMap[i][j] = new Cell(array[i][j]);
					if (i > 0) CellMap[i][j].Connect(1, CellMap[i - 1][j]);
					if (j > 0) CellMap[i][j].Connect(4, CellMap[i][j - 1]);
				}
			}

			Random rnd = new Random();
			Cell oldcell = null;
			for (int n = 0; n < 1000; n++)
			{
				int ni = rnd.Next(0, 5);
				int nj = rnd.Next(0, 5);
				if (CellMap[ni][nj] == oldcell || !CellMap[ni][nj].AbleToMove(0))
				{
					n--;
					continue;
				}
				for (int k = 1; k < 5; k++)
				{
					oldcell = CellMap[ni][nj].Move(k);
					if (oldcell != null) break;
				}

				//Console.WriteLine("-----"+n.ToString());
				//for (int i = 0; i < 5; i++)
				//{
				//	for (int j = 0; j < 5; j++)
				//	{
				//		Console.Write(CellMap[i][j].Value.ToString());
				//		Console.Write("\t");
				//	}
				//	Console.WriteLine();
				//}
			}
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					Console.Write(CellMap[i][j].Value.ToString());
					Console.Write("\t");
				}
				Console.WriteLine();
			}
			string name = Console.ReadLine();
			Console.WriteLine($"Fuck you, {name}");
		}
	}
}
