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
			this.toolbar = new System.Windows.Forms.ToolStrip();
			this.fileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
			this.newToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolbarItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolbar
			// 
			this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDropDown});
			this.toolbar.Location = new System.Drawing.Point(0, 0);
			this.toolbar.Name = "toolbar";
			this.toolbar.Size = new System.Drawing.Size(587, 25);
			this.toolbar.TabIndex = 2;
			this.toolbar.Text = "Toolbar";
			// 
			// fileDropDown
			// 
			this.fileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolbarItem,
            this.saveToolbarItem,
            this.openToolbarItem,
            this.exitToolbarItem});
			this.fileDropDown.Name = "fileDropDown";
			this.fileDropDown.Size = new System.Drawing.Size(38, 22);
			this.fileDropDown.Text = "File";
			// 
			// newToolbarItem
			// 
			this.newToolbarItem.Name = "newToolbarItem";
			this.newToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.newToolbarItem.Text = "New";
			this.newToolbarItem.Click += new System.EventHandler(this.NewToolbarItem_Click);
			// 
			// saveToolbarItem
			// 
			this.saveToolbarItem.Name = "saveToolbarItem";
			this.saveToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolbarItem.Text = "Save";
			this.saveToolbarItem.Click += new System.EventHandler(this.SaveToolbarItem_Click);
			// 
			// openToolbarItem
			// 
			this.openToolbarItem.Name = "openToolbarItem";
			this.openToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.openToolbarItem.Text = "Open";
			this.openToolbarItem.Click += new System.EventHandler(this.OpenToolbarItem_Click);
			// 
			// exitToolbarItem
			// 
			this.exitToolbarItem.Name = "exitToolbarItem";
			this.exitToolbarItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolbarItem.Text = "Exit";
			this.exitToolbarItem.Click += new System.EventHandler(this.ExitToolbarItem_Click);
			// 
			// MainWnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(587, 461);
			this.Controls.Add(this.toolbar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "MainWnd";
			this.Text = "BeGraph";
			this.Load += new System.EventHandler(this.MainWnd_Load);
			this.toolbar.ResumeLayout(false);
			this.toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}


		#endregion

		private GraphBox graphBox;
		private ToolStrip toolbar;
		private ToolStripMenuItem exitToolbarItem;
		private ToolStripMenuItem openToolbarItem;
		private ToolStripMenuItem saveToolbarItem;
		private ToolStripMenuItem newToolbarItem;
		private ToolStripDropDownButton fileDropDown;
	}
}

