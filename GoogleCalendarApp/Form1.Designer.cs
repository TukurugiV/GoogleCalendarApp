namespace GoogleCalendarApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.formOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mailAdress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AuthJson = new System.Windows.Forms.Button();
            this.getEvent = new System.Windows.Forms.Button();
            this.CheckBoxPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fontBox = new System.Windows.Forms.ComboBox();
            this.ColorDialog = new System.Windows.Forms.Button();
            this.SettingsSubmit = new System.Windows.Forms.Button();
            this.finishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formOpenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.finishToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 76);
            // 
            // formOpenToolStripMenuItem
            // 
            this.formOpenToolStripMenuItem.Name = "formOpenToolStripMenuItem";
            this.formOpenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formOpenToolStripMenuItem.Text = "FormOpen";
            this.formOpenToolStripMenuItem.Click += new System.EventHandler(this.formOpenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // mailAdress
            // 
            this.mailAdress.Location = new System.Drawing.Point(12, 41);
            this.mailAdress.Name = "mailAdress";
            this.mailAdress.Size = new System.Drawing.Size(287, 19);
            this.mailAdress.TabIndex = 1;
            this.mailAdress.Text = "取得したいカレンダーのメールアドレス";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "登録";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AuthJson
            // 
            this.AuthJson.Location = new System.Drawing.Point(12, 12);
            this.AuthJson.Name = "AuthJson";
            this.AuthJson.Size = new System.Drawing.Size(188, 23);
            this.AuthJson.TabIndex = 3;
            this.AuthJson.Text = "Google 認証情報 JSON";
            this.AuthJson.UseVisualStyleBackColor = true;
            this.AuthJson.Click += new System.EventHandler(this.AuthJson_Click);
            // 
            // getEvent
            // 
            this.getEvent.Location = new System.Drawing.Point(12, 213);
            this.getEvent.Name = "getEvent";
            this.getEvent.Size = new System.Drawing.Size(108, 23);
            this.getEvent.TabIndex = 5;
            this.getEvent.Text = "イベントを取得";
            this.getEvent.UseVisualStyleBackColor = true;
            this.getEvent.Click += new System.EventHandler(this.getEvent_Click);
            // 
            // CheckBoxPanel
            // 
            this.CheckBoxPanel.ColumnCount = 2;
            this.CheckBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.57265F));
            this.CheckBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.42735F));
            this.CheckBoxPanel.Location = new System.Drawing.Point(12, 95);
            this.CheckBoxPanel.Name = "CheckBoxPanel";
            this.CheckBoxPanel.RowCount = 2;
            this.CheckBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CheckBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CheckBoxPanel.Size = new System.Drawing.Size(351, 112);
            this.CheckBoxPanel.TabIndex = 6;
            // 
            // fontBox
            // 
            this.fontBox.FormattingEnabled = true;
            this.fontBox.Location = new System.Drawing.Point(416, 41);
            this.fontBox.Name = "fontBox";
            this.fontBox.Size = new System.Drawing.Size(121, 20);
            this.fontBox.TabIndex = 8;
            // 
            // ColorDialog
            // 
            this.ColorDialog.BackColor = System.Drawing.Color.Black;
            this.ColorDialog.Location = new System.Drawing.Point(416, 81);
            this.ColorDialog.Name = "ColorDialog";
            this.ColorDialog.Size = new System.Drawing.Size(55, 53);
            this.ColorDialog.TabIndex = 9;
            this.ColorDialog.UseVisualStyleBackColor = false;
            this.ColorDialog.Click += new System.EventHandler(this.ColorDialog_Click);
            // 
            // SettingsSubmit
            // 
            this.SettingsSubmit.Location = new System.Drawing.Point(416, 152);
            this.SettingsSubmit.Name = "SettingsSubmit";
            this.SettingsSubmit.Size = new System.Drawing.Size(188, 23);
            this.SettingsSubmit.TabIndex = 10;
            this.SettingsSubmit.Text = "決定";
            this.SettingsSubmit.UseVisualStyleBackColor = true;
            this.SettingsSubmit.Click += new System.EventHandler(this.SettingsSubmit_Click);
            // 
            // finishToolStripMenuItem
            // 
            this.finishToolStripMenuItem.Name = "finishToolStripMenuItem";
            this.finishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.finishToolStripMenuItem.Text = "Finish";
            this.finishToolStripMenuItem.Click += new System.EventHandler(this.finishToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SettingsSubmit);
            this.Controls.Add(this.ColorDialog);
            this.Controls.Add(this.fontBox);
            this.Controls.Add(this.CheckBoxPanel);
            this.Controls.Add(this.getEvent);
            this.Controls.Add(this.AuthJson);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mailAdress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TextBox mailAdress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AuthJson;
        private System.Windows.Forms.Button getEvent;
        private System.Windows.Forms.TableLayoutPanel CheckBoxPanel;
        private System.Windows.Forms.ComboBox fontBox;
        private System.Windows.Forms.Button ColorDialog;
        private System.Windows.Forms.Button SettingsSubmit;
        private System.Windows.Forms.ToolStripMenuItem finishToolStripMenuItem;
    }
}

