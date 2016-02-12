using System;


namespace BeGraph {
    abstract class Figure {

		// Identifer of figure
		private int id;

		public int ID{
			get {
				return id;
			}
		}

        private static int nextID = 0;

        public Figure() {
            id = nextID++;
        }

		public abstract void Draw(System.Drawing.Graphics gr);
    }
}
