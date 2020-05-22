namespace COVID19Map
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.statisticsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsMenu});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(800, 33);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "menubar";
            // 
            // statisticsMenu
            // 
            this.statisticsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginsInfoToolStripMenuItem});
            this.statisticsMenu.Name = "statisticsMenu";
            this.statisticsMenu.Size = new System.Drawing.Size(96, 29);
            this.statisticsMenu.Text = "Statistics";
            // 
            // pluginsInfoToolStripMenuItem
            // 
            this.pluginsInfoToolStripMenuItem.Name = "pluginsInfoToolStripMenuItem";
            this.pluginsInfoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.pluginsInfoToolStripMenuItem.Text = "Plugins info";
            this.pluginsInfoToolStripMenuItem.Click += new System.EventHandler(this.pluginsInfoToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "COVID19";
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem statisticsMenu;
        private System.Windows.Forms.ToolStripMenuItem pluginsInfoToolStripMenuItem;
    }
}

