using System.Windows.Forms;

namespace InputDialog {
	public partial class InputDialog : Form {

		public string InputText {
			get {
				return textBox.Text;
			}
		}

		public InputDialog(string text, string caption) {
			InitializeComponent();
			this.label.Text = text;
			this.Text = caption;
		}
	}
}
