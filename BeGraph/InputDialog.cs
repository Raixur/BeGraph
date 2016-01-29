using System.Windows.Forms;

namespace InputDialog {
	public partial class InputDialog : Form {
		public InputDialog(string text, string caption) {
			InitializeComponent();
			this.label.Text = text;
			this.Text = caption;
		}

		public string getInput() {
			return this.textBox.Text;
		}
	}
}
