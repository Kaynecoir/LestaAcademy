using System;
using System.Collections.Generic;
using System.Text;

namespace LestaAcademyWork1
{
	class Cell
	{
		public int Value;
		public Cell Top;
		public Cell Right;
		public Cell Down;
		public Cell Left;

		public Cell(int v = 0)
		{
			Value = v;
			Top = null;
			Right = null;
			Down = null;
			Left = null;
		}

		public void Connect(int move, Cell c)
		{
			if (move == 1) { Top = c; Top.Down = this; }
			if (move == 2) { Right = c; Right.Left = this; }
			if (move == 3) { Down = c; Down.Top = this; }
			if (move == 4) { Left = c; Left.Right = this; }
		}

		public bool AbleToMove(int move)
		{
			if (this.Value < 1) return false;
			Cell curmove = null;

			if(move == 0)
			{
				for(int i = 1; i < 5; i++)
				{
					if (AbleToMove(i)) return true;
				}
			}

			if (move == 1) curmove = Top;
			else if (move == 2) curmove = Right;
			else if (move == 3) curmove = Down;
			else if (move == 4) curmove = Left;

			if (curmove == null) return false;
			if (curmove.Value == 0) return true;
			return false;
		}

		public Cell Move(int move)
		{
			if(AbleToMove(move))
			{
				Cell curmove = null;
				if (move == 1) curmove = Top;
				else if (move == 2) curmove = Right;
				else if (move == 3) curmove = Down;
				else if (move == 4) curmove = Left;
				int k = curmove.Value;
				curmove.Value = this.Value;
				this.Value = k;

				return curmove;
			}
			return null;
		}
	}
}
