namespace BudgetApp.Data
{
	public class DrawingService
	{
		private static List<Rectangle> Rectangles = new List<Rectangle>();
		public async Task<bool> AddRectangle(Rectangle newRectangle)
		{
			Rectangles.Add(newRectangle);
			return true;
		}

		public async Task<List<Rectangle>> GetAllRectangles()
		{
			return Rectangles;
		}
		public async Task<bool> CheckOverlap(int x, int y, int l, int w)
		{
			var l2 = (x, y);
			var r2 = (x:x + l, y:y + w);


            foreach (Rectangle rectangle in Rectangles)
			{
                var l1 = (x:rectangle.X, y:rectangle.Y);
                var r1 = (x:rectangle.X + l, y:rectangle.Y + w);
				if (DoOverlap(l1, r1, l2, r2))
				{
					return true;
				}
            }
			return false;
		}

		private bool DoOverlap((int x, int y) l1, (int x, int y) r1,
						  (int x, int y) l2, (int x, int y) r2)
		{
			// if rectangle has area 0, no overlap
			if (l1.x == r1.x || l1.y == r1.y || r2.x == l2.x || l2.y == r2.y)
			{
				return false;
			}

			// If one rectangle is on left side of other 
			if (l1.x > r2.x || l2.x > r1.x)
			{
				return false;
			}

			// If one rectangle is above other 
			if (r1.y < l2.y || r2.y < l1.y)
			{
				return false;
			}
			return true;
		}

	}
}
