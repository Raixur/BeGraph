using System.Windows.Forms;

namespace BeGraph {
	partial class Form1 {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.graphBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.graphBox)).BeginInit();
			this.SuspendLayout();
			// 
			// graphBox
			// 
			this.graphBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.graphBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.graphBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.graphBox.Location = new System.Drawing.Point(12, 12);
			this.graphBox.Name = "graphBox";
			this.graphBox.Size = new System.Drawing.Size(536, 332);
			this.graphBox.TabIndex = 1;
			this.graphBox.TabStop = false;
			this.graphBox.Click += new System.EventHandler(this.graphBox_Click);
			this.graphBox.DoubleClick += new System.EventHandler(this.graphBox_DoubleClick);
			this.graphBox.MouseDown += new MouseEventHandler(this.graphBox_MouseDown);
			this.graphBox.MouseUp += new MouseEventHandler(this.graphBox_MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(587, 356);
			this.Controls.Add(this.graphBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "BeGraph";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.graphBox)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
		private System.Windows.Forms.PictureBox graphBox;
		
	}
}

