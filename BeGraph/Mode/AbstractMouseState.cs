using System.Windows.Forms;

namespace BeGraph.Mode {
	public class AbstractMouseState : IMouseState {
		protected internal bool Active { get; set; }

		protected internal bool Dragging { get; private set; }

		public virtual void MouseClick(object sender, MouseEventArgs me) {}

		public virtual void MouseDown(object sender, MouseEventArgs me) {
			Dragging = true;
		}

		public virtual void MouseUp(object sender, MouseEventArgs me) {
			Dragging = false;
		}

		public virtual void MouseDrag(object sender, MouseEventArgs me) {}

		public void Switch() {
			Active = !Active;
		}
	}
}