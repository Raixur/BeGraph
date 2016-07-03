using System.Windows.Forms;

namespace BeGraph.Mode {
	public interface IMouseState {
		void MouseClick(object sender, MouseEventArgs me);
		void MouseDown(object sender, MouseEventArgs me);
		void MouseUp(object sender, MouseEventArgs me);
		void MouseDrag(object sender, MouseEventArgs me);
	}
}