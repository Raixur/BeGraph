using System.Windows.Forms;

namespace BeGraph {
	public partial class InputDialog : Form {
		public InputDialog(string text, string caption) {
			InitializeComponent();
			label.Text = text;
			Text = caption;
		}

		public string InputText => textBox.Text;
	}
}