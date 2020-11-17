namespace FlatUI.Examples
{
	partial class Twitter
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.FDList = new System.Windows.Forms.OpenFileDialog();
            this.FDlistSave = new System.Windows.Forms.SaveFileDialog();
            this.FormSkin = new FlatUI.FormSkin();
            this.FlatAlertBox = new FlatUI.FlatAlertBox();
            this.flatTabControl1 = new FlatUI.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TxtFrom = new FlatUI.FlatTextBox();
            this.flatLabel4 = new FlatUI.FlatLabel();
            this.TxtTo = new FlatUI.FlatTextBox();
            this.RTStatus = new System.Windows.Forms.RichTextBox();
            this.flatLabel5 = new FlatUI.FlatLabel();
            this.IntInterval = new FlatUI.FlatNumeric();
            this.flatLabel3 = new FlatUI.FlatLabel();
            this.IntVoteOption = new FlatUI.FlatNumeric();
            this.ProgressButton = new FlatUI.FlatButton();
            this.flatLabel2 = new FlatUI.FlatLabel();
            this.TxtPostID = new FlatUI.FlatTextBox();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AccountsList = new System.Windows.Forms.DataGridView();
            this.TxtCount = new FlatUI.FlatTextBox();
            this.BtnDeleteAccounts = new FlatUI.FlatButton();
            this.BtnRemoveCookies = new FlatUI.FlatButton();
            this.BtnAddAccounts = new FlatUI.FlatButton();
            this.FlatMini = new FlatUI.FlatMini();
            this.FlatClose = new FlatUI.FlatClose();
            this.FlatProgressBar = new FlatUI.FlatProgressBar();
            this.FormSkin.SuspendLayout();
            this.flatTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsList)).BeginInit();
            this.SuspendLayout();
            // 
            // FDList
            // 
            this.FDList.Filter = "All|*.txt;*.xls;*.xlsx|Text|*.txt|Excel|*.xls;*.xlsx";
            // 
            // FormSkin
            // 
            this.FormSkin.BackColor = System.Drawing.Color.White;
            this.FormSkin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.FormSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.FormSkin.Controls.Add(this.FlatAlertBox);
            this.FormSkin.Controls.Add(this.flatTabControl1);
            this.FormSkin.Controls.Add(this.FlatMini);
            this.FormSkin.Controls.Add(this.FlatClose);
            this.FormSkin.Controls.Add(this.FlatProgressBar);
            this.FormSkin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormSkin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.FormSkin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormSkin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.FormSkin.HeaderMaximize = false;
            this.FormSkin.Location = new System.Drawing.Point(0, 0);
            this.FormSkin.Name = "FormSkin";
            this.FormSkin.Size = new System.Drawing.Size(730, 400);
            this.FormSkin.TabIndex = 0;
            this.FormSkin.Text = "Twitter Auto Voter";
            // 
            // FlatAlertBox
            // 
            this.FlatAlertBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.FlatAlertBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlatAlertBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FlatAlertBox.kind = FlatUI.FlatAlertBox._Kind.Info;
            this.FlatAlertBox.Location = new System.Drawing.Point(10, 46);
            this.FlatAlertBox.Name = "FlatAlertBox";
            this.FlatAlertBox.Size = new System.Drawing.Size(706, 42);
            this.FlatAlertBox.TabIndex = 25;
            this.FlatAlertBox.Text = "This is a FlatAlertBox";
            this.FlatAlertBox.Visible = false;
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatTabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatTabControl1.Controls.Add(this.tabPage1);
            this.flatTabControl1.Controls.Add(this.tabPage2);
            this.flatTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatTabControl1.ItemSize = new System.Drawing.Size(120, 40);
            this.flatTabControl1.Location = new System.Drawing.Point(0, 91);
            this.flatTabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.Size = new System.Drawing.Size(730, 284);
            this.flatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.flatTabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage1.Controls.Add(this.TxtFrom);
            this.tabPage1.Controls.Add(this.flatLabel4);
            this.tabPage1.Controls.Add(this.TxtTo);
            this.tabPage1.Controls.Add(this.RTStatus);
            this.tabPage1.Controls.Add(this.flatLabel5);
            this.tabPage1.Controls.Add(this.IntInterval);
            this.tabPage1.Controls.Add(this.flatLabel3);
            this.tabPage1.Controls.Add(this.IntVoteOption);
            this.tabPage1.Controls.Add(this.ProgressButton);
            this.tabPage1.Controls.Add(this.flatLabel2);
            this.tabPage1.Controls.Add(this.TxtPostID);
            this.tabPage1.Controls.Add(this.flatLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(722, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run";
            // 
            // TxtFrom
            // 
            this.TxtFrom.BackColor = System.Drawing.Color.Transparent;
            this.TxtFrom.FocusOnHover = false;
            this.TxtFrom.IntegerOnly = false;
            this.TxtFrom.Location = new System.Drawing.Point(304, 24);
            this.TxtFrom.MaxLength = 32767;
            this.TxtFrom.Multiline = false;
            this.TxtFrom.Name = "TxtFrom";
            this.TxtFrom.ReadOnly = false;
            this.TxtFrom.Size = new System.Drawing.Size(75, 29);
            this.TxtFrom.TabIndex = 34;
            this.TxtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtFrom.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtFrom.UseSystemPasswordChar = false;
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(304, 2);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(33, 13);
            this.flatLabel4.TabIndex = 33;
            this.flatLabel4.Text = "From";
            // 
            // TxtTo
            // 
            this.TxtTo.BackColor = System.Drawing.Color.Transparent;
            this.TxtTo.FocusOnHover = false;
            this.TxtTo.IntegerOnly = false;
            this.TxtTo.Location = new System.Drawing.Point(398, 25);
            this.TxtTo.MaxLength = 32767;
            this.TxtTo.Multiline = false;
            this.TxtTo.Name = "TxtTo";
            this.TxtTo.ReadOnly = false;
            this.TxtTo.Size = new System.Drawing.Size(75, 29);
            this.TxtTo.TabIndex = 32;
            this.TxtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtTo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtTo.UseSystemPasswordChar = false;
            // 
            // RTStatus
            // 
            this.RTStatus.Location = new System.Drawing.Point(17, 71);
            this.RTStatus.Margin = new System.Windows.Forms.Padding(2);
            this.RTStatus.Name = "RTStatus";
            this.RTStatus.ReadOnly = true;
            this.RTStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RTStatus.Size = new System.Drawing.Size(694, 160);
            this.RTStatus.TabIndex = 31;
            this.RTStatus.Text = "";
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(491, 6);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(97, 13);
            this.flatLabel5.TabIndex = 30;
            this.flatLabel5.Text = "Interval (Seconds)";
            // 
            // IntInterval
            // 
            this.IntInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.IntInterval.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.IntInterval.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.IntInterval.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.IntInterval.ForeColor = System.Drawing.Color.White;
            this.IntInterval.Location = new System.Drawing.Point(491, 28);
            this.IntInterval.Maximum = ((long)(9999999));
            this.IntInterval.Minimum = ((long)(0));
            this.IntInterval.Name = "IntInterval";
            this.IntInterval.Size = new System.Drawing.Size(75, 30);
            this.IntInterval.TabIndex = 29;
            this.IntInterval.Value = ((long)(0));
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(398, 3);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(18, 13);
            this.flatLabel3.TabIndex = 26;
            this.flatLabel3.Text = "To";
            // 
            // IntVoteOption
            // 
            this.IntVoteOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.IntVoteOption.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.IntVoteOption.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.IntVoteOption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.IntVoteOption.ForeColor = System.Drawing.Color.White;
            this.IntVoteOption.Location = new System.Drawing.Point(202, 28);
            this.IntVoteOption.Maximum = ((long)(9999999));
            this.IntVoteOption.Minimum = ((long)(0));
            this.IntVoteOption.Name = "IntVoteOption";
            this.IntVoteOption.Size = new System.Drawing.Size(75, 30);
            this.IntVoteOption.TabIndex = 25;
            this.IntVoteOption.Value = ((long)(0));
            // 
            // ProgressButton
            // 
            this.ProgressButton.BackColor = System.Drawing.Color.Transparent;
            this.ProgressButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.ProgressButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProgressButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ProgressButton.Location = new System.Drawing.Point(610, 24);
            this.ProgressButton.Name = "ProgressButton";
            this.ProgressButton.Rounded = false;
            this.ProgressButton.Size = new System.Drawing.Size(100, 29);
            this.ProgressButton.TabIndex = 0;
            this.ProgressButton.Text = "Start";
            this.ProgressButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ProgressButton.Click += new System.EventHandler(this.ProgressButton_Click);
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(202, 6);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(70, 13);
            this.flatLabel2.TabIndex = 18;
            this.flatLabel2.Text = "Vote Option";
            // 
            // TxtPostID
            // 
            this.TxtPostID.BackColor = System.Drawing.Color.Transparent;
            this.TxtPostID.FocusOnHover = false;
            this.TxtPostID.IntegerOnly = false;
            this.TxtPostID.Location = new System.Drawing.Point(17, 25);
            this.TxtPostID.MaxLength = 32767;
            this.TxtPostID.Multiline = false;
            this.TxtPostID.Name = "TxtPostID";
            this.TxtPostID.ReadOnly = false;
            this.TxtPostID.Size = new System.Drawing.Size(163, 29);
            this.TxtPostID.TabIndex = 3;
            this.TxtPostID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtPostID.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtPostID.UseSystemPasswordChar = false;
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(17, 6);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(47, 13);
            this.flatLabel1.TabIndex = 16;
            this.flatLabel1.Text = "Post Uri";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage2.Controls.Add(this.AccountsList);
            this.tabPage2.Controls.Add(this.TxtCount);
            this.tabPage2.Controls.Add(this.BtnDeleteAccounts);
            this.tabPage2.Controls.Add(this.BtnRemoveCookies);
            this.tabPage2.Controls.Add(this.BtnAddAccounts);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(722, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Accounts";
            // 
            // AccountsList
            // 
            this.AccountsList.AllowUserToAddRows = false;
            this.AccountsList.AllowUserToDeleteRows = false;
            this.AccountsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountsList.Location = new System.Drawing.Point(9, 45);
            this.AccountsList.Margin = new System.Windows.Forms.Padding(2);
            this.AccountsList.Name = "AccountsList";
            this.AccountsList.ReadOnly = true;
            this.AccountsList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AccountsList.RowHeadersWidth = 51;
            this.AccountsList.RowTemplate.Height = 24;
            this.AccountsList.Size = new System.Drawing.Size(706, 196);
            this.AccountsList.TabIndex = 31;
            // 
            // TxtCount
            // 
            this.TxtCount.BackColor = System.Drawing.Color.Transparent;
            this.TxtCount.FocusOnHover = false;
            this.TxtCount.IntegerOnly = false;
            this.TxtCount.Location = new System.Drawing.Point(631, 11);
            this.TxtCount.MaxLength = 32767;
            this.TxtCount.Multiline = false;
            this.TxtCount.Name = "TxtCount";
            this.TxtCount.ReadOnly = true;
            this.TxtCount.Size = new System.Drawing.Size(84, 29);
            this.TxtCount.TabIndex = 28;
            this.TxtCount.Text = "0";
            this.TxtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtCount.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TxtCount.UseSystemPasswordChar = false;
            // 
            // BtnDeleteAccounts
            // 
            this.BtnDeleteAccounts.BackColor = System.Drawing.Color.Transparent;
            this.BtnDeleteAccounts.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.BtnDeleteAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeleteAccounts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnDeleteAccounts.Location = new System.Drawing.Point(215, 10);
            this.BtnDeleteAccounts.Name = "BtnDeleteAccounts";
            this.BtnDeleteAccounts.Rounded = false;
            this.BtnDeleteAccounts.Size = new System.Drawing.Size(152, 29);
            this.BtnDeleteAccounts.TabIndex = 26;
            this.BtnDeleteAccounts.Text = "Delete All Accounts";
            this.BtnDeleteAccounts.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnDeleteAccounts.Click += new System.EventHandler(this.BtnDeleteAccounts_Click);
            // 
            // BtnRemoveCookies
            // 
            this.BtnRemoveCookies.BackColor = System.Drawing.Color.Transparent;
            this.BtnRemoveCookies.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.BtnRemoveCookies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemoveCookies.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnRemoveCookies.Location = new System.Drawing.Point(424, 10);
            this.BtnRemoveCookies.Name = "BtnRemoveCookies";
            this.BtnRemoveCookies.Rounded = false;
            this.BtnRemoveCookies.Size = new System.Drawing.Size(152, 29);
            this.BtnRemoveCookies.TabIndex = 24;
            this.BtnRemoveCookies.Text = "Remove Cookies";
            this.BtnRemoveCookies.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnRemoveCookies.Click += new System.EventHandler(this.BtnRemoveCookies_Click);
            // 
            // BtnAddAccounts
            // 
            this.BtnAddAccounts.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddAccounts.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.BtnAddAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddAccounts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BtnAddAccounts.Location = new System.Drawing.Point(9, 10);
            this.BtnAddAccounts.Name = "BtnAddAccounts";
            this.BtnAddAccounts.Rounded = false;
            this.BtnAddAccounts.Size = new System.Drawing.Size(152, 29);
            this.BtnAddAccounts.TabIndex = 23;
            this.BtnAddAccounts.Text = "Add Accounts";
            this.BtnAddAccounts.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.BtnAddAccounts.Click += new System.EventHandler(this.BtnAddAccounts_Click);
            // 
            // FlatMini
            // 
            this.FlatMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlatMini.BackColor = System.Drawing.Color.White;
            this.FlatMini.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.FlatMini.Font = new System.Drawing.Font("Marlett", 12F);
            this.FlatMini.Location = new System.Drawing.Point(676, 12);
            this.FlatMini.Name = "FlatMini";
            this.FlatMini.Size = new System.Drawing.Size(18, 18);
            this.FlatMini.TabIndex = 5;
            this.FlatMini.Text = "Minimize";
            this.FlatMini.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // FlatClose
            // 
            this.FlatClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlatClose.BackColor = System.Drawing.Color.White;
            this.FlatClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.FlatClose.Font = new System.Drawing.Font("Marlett", 10F);
            this.FlatClose.Location = new System.Drawing.Point(700, 12);
            this.FlatClose.Name = "FlatClose";
            this.FlatClose.Size = new System.Drawing.Size(18, 18);
            this.FlatClose.TabIndex = 4;
            this.FlatClose.Text = "Exit";
            this.FlatClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // FlatProgressBar
            // 
            this.FlatProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.FlatProgressBar.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.FlatProgressBar.Location = new System.Drawing.Point(0, 358);
            this.FlatProgressBar.Maximum = 100;
            this.FlatProgressBar.Name = "FlatProgressBar";
            this.FlatProgressBar.Pattern = false;
            this.FlatProgressBar.PercentSign = true;
            this.FlatProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.FlatProgressBar.ShowBalloon = false;
            this.FlatProgressBar.Size = new System.Drawing.Size(730, 42);
            this.FlatProgressBar.TabIndex = 1;
            this.FlatProgressBar.Text = "Progress";
            this.FlatProgressBar.Value = 0;
            // 
            // Twitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 400);
            this.Controls.Add(this.FormSkin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Twitter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlatUI Example";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormSkin.ResumeLayout(false);
            this.flatTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccountsList)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private FormSkin FormSkin;
		private FlatButton ProgressButton;
		private FlatProgressBar FlatProgressBar;
		private FlatMini FlatMini;
		private FlatClose FlatClose;
    private FlatLabel flatLabel2;
    private FlatLabel flatLabel1;
    private FlatTextBox TxtPostID;
    private System.Windows.Forms.OpenFileDialog FDList;
    private System.Windows.Forms.SaveFileDialog FDlistSave;
        private FlatTabControl flatTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FlatButton BtnDeleteAccounts;
        private FlatButton BtnRemoveCookies;
        private FlatButton BtnAddAccounts;
        private FlatLabel flatLabel5;
        private FlatNumeric IntInterval;
        private FlatLabel flatLabel3;
        private FlatNumeric IntVoteOption;
        private FlatTextBox TxtCount;
        private System.Windows.Forms.DataGridView AccountsList;
        private FlatAlertBox FlatAlertBox;
        private System.Windows.Forms.RichTextBox RTStatus;
        private FlatTextBox TxtTo;
        private FlatTextBox TxtFrom;
        private FlatLabel flatLabel4;
    }
}

