using System;
using System.Windows.Forms;

namespace BeGraph {
	public static class Program {
		/// <summary>
		///     Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		private static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWnd());
		}
	}
}