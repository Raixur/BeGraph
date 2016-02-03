using System;
using System.Windows.Forms;

namespace BeGraph {
	partial class MainWnd {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.newToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(587, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolbarItem,
            this.saveToolbarItem,
            this.openToolbarItem,
            this.exitToolbarItem});
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
			this.toolStripDropDownButton1.Text = "File";
			this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
			// 
			// newToolbarItem
			// 
			this.newToolbarItem.Name = "newToolbarItem";
			this.newToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.newToolbarItem.Text = "New";
			this.newToolbarItem.Click += new System.EventHandler(this.newToolbarItem_Click);
			// 
			// saveToolbarItem
			// 
			this.saveToolbarItem.Name = "saveToolbarItem";
			this.saveToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolbarItem.Text = "Save";
			this.saveToolbarItem.Click += new System.EventHandler(this.saveToolbarItem_Click);
			// 
			// openToolbarItem
			// 
			this.openToolbarItem.Name = "openToolbarItem";
			this.openToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.openToolbarItem.Text = "Open";
			this.openToolbarItem.Click += new System.EventHandler(this.openToolbarItem_Click);
			// 
			// exitToolbarItem
			// 
			this.exitToolbarItem.Name = "exitToolbarItem";
			this.exitToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolbarItem.Text = "Exit";
			this.exitToolbarItem.Click += new System.EventHandler(this.exitToolbarItem_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// MainWnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(587, 461);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "MainWnd";
			this.Text = "BeGraph";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}



		#endregion

		private GraphBox graphBox;
		private ToolStrip toolStrip1;
		private ToolStripMenuItem exitToolbarItem;
		private ToolStripMenuItem openToolbarItem;
		private ToolStripMenuItem saveToolbarItem;
		private ToolStripMenuItem newToolbarItem;
		private ToolStripDropDownButton toolStripDropDownButton1;
		private ToolStripButton toolStripButton1;
	}
}

