using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGraph {
    abstract class Figure {
        public int id {
			get; private set;
		}
        static int nextID = 0;

        public Figure() {
            id = nextID++;
        }


		public abstract void draw(System.Windows.Forms.PictureBox pb);
    }
}
