
namespace TextRepls
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnReplRead = new System.Windows.Forms.Button();
			this.btnGoReplace = new System.Windows.Forms.Button();
			this.txtAddOrg = new System.Windows.Forms.TextBox();
			this.lblAddOrg = new System.Windows.Forms.Label();
			this.lblAddNew = new System.Windows.Forms.Label();
			this.txtAddNew = new System.Windows.Forms.TextBox();
			this.btnAddAdd = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lstRepls = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ctxReplList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsiReplListRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.btnReplSave = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.rtxSrc = new System.Windows.Forms.RichTextBox();
			this.rtxDst = new System.Windows.Forms.RichTextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnBatchRead = new System.Windows.Forms.Button();
			this.btnBatchSave = new System.Windows.Forms.Button();
			this.btnBatchRun = new System.Windows.Forms.Button();
			this.lblBatchFileList = new System.Windows.Forms.Label();
			this.lstConvFiles = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1.SuspendLayout();
			this.ctxReplList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnReplRead
			// 
			this.btnReplRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReplRead.Location = new System.Drawing.Point(520, 3);
			this.btnReplRead.Name = "btnReplRead";
			this.btnReplRead.Size = new System.Drawing.Size(90, 46);
			this.btnReplRead.TabIndex = 0;
			this.btnReplRead.Text = "바꿀꺼\r\n읽기";
			this.btnReplRead.UseVisualStyleBackColor = true;
			this.btnReplRead.Click += new System.EventHandler(this.BtnReplRead_Click);
			// 
			// btnGoReplace
			// 
			this.btnGoReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGoReplace.Location = new System.Drawing.Point(575, 6);
			this.btnGoReplace.Name = "btnGoReplace";
			this.btnGoReplace.Size = new System.Drawing.Size(51, 385);
			this.btnGoReplace.TabIndex = 1;
			this.btnGoReplace.Text = "바꾸기";
			this.btnGoReplace.UseVisualStyleBackColor = true;
			this.btnGoReplace.Click += new System.EventHandler(this.BtnGoReplace_Click);
			// 
			// txtAddOrg
			// 
			this.txtAddOrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddOrg.Location = new System.Drawing.Point(94, 3);
			this.txtAddOrg.Name = "txtAddOrg";
			this.txtAddOrg.Size = new System.Drawing.Size(317, 20);
			this.txtAddOrg.TabIndex = 2;
			this.txtAddOrg.Enter += new System.EventHandler(this.TxtAddOrg_Enter);
			this.txtAddOrg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddOrg_KeyDown);
			// 
			// lblAddOrg
			// 
			this.lblAddOrg.AutoSize = true;
			this.lblAddOrg.Location = new System.Drawing.Point(59, 6);
			this.lblAddOrg.Name = "lblAddOrg";
			this.lblAddOrg.Size = new System.Drawing.Size(29, 13);
			this.lblAddOrg.TabIndex = 3;
			this.lblAddOrg.Text = "원래";
			// 
			// lblAddNew
			// 
			this.lblAddNew.AutoSize = true;
			this.lblAddNew.Location = new System.Drawing.Point(59, 32);
			this.lblAddNew.Name = "lblAddNew";
			this.lblAddNew.Size = new System.Drawing.Size(29, 13);
			this.lblAddNew.TabIndex = 4;
			this.lblAddNew.Text = "바꿈";
			// 
			// txtAddNew
			// 
			this.txtAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddNew.Location = new System.Drawing.Point(94, 29);
			this.txtAddNew.Name = "txtAddNew";
			this.txtAddNew.Size = new System.Drawing.Size(317, 20);
			this.txtAddNew.TabIndex = 5;
			this.txtAddNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtAddNew_KeyDown);
			// 
			// btnAddAdd
			// 
			this.btnAddAdd.Location = new System.Drawing.Point(3, 3);
			this.btnAddAdd.Name = "btnAddAdd";
			this.btnAddAdd.Size = new System.Drawing.Size(50, 46);
			this.btnAddAdd.TabIndex = 6;
			this.btnAddAdd.Text = "더하기";
			this.btnAddAdd.UseVisualStyleBackColor = true;
			this.btnAddAdd.Click += new System.EventHandler(this.BtnAddAdd_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lstRepls);
			this.panel1.Controls.Add(this.btnReplSave);
			this.panel1.Controls.Add(this.btnAddAdd);
			this.panel1.Controls.Add(this.lblAddNew);
			this.panel1.Controls.Add(this.btnReplRead);
			this.panel1.Controls.Add(this.txtAddNew);
			this.panel1.Controls.Add(this.lblAddOrg);
			this.panel1.Controls.Add(this.txtAddOrg);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(640, 208);
			this.panel1.TabIndex = 7;
			// 
			// lstRepls
			// 
			this.lstRepls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstRepls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lstRepls.ContextMenuStrip = this.ctxReplList;
			this.lstRepls.FullRowSelect = true;
			this.lstRepls.GridLines = true;
			this.lstRepls.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstRepls.HideSelection = false;
			this.lstRepls.Location = new System.Drawing.Point(3, 55);
			this.lstRepls.Name = "lstRepls";
			this.lstRepls.Size = new System.Drawing.Size(632, 148);
			this.lstRepls.TabIndex = 10;
			this.lstRepls.UseCompatibleStateImageBehavior = false;
			this.lstRepls.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "찾을 내용";
			this.columnHeader1.Width = 300;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "바꿀 내용";
			this.columnHeader2.Width = 300;
			// 
			// ctxReplList
			// 
			this.ctxReplList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiReplListRemove});
			this.ctxReplList.Name = "ctxReplList";
			this.ctxReplList.Size = new System.Drawing.Size(111, 26);
			// 
			// tsiReplListRemove
			// 
			this.tsiReplListRemove.Name = "tsiReplListRemove";
			this.tsiReplListRemove.Size = new System.Drawing.Size(110, 22);
			this.tsiReplListRemove.Text = "지우기";
			this.tsiReplListRemove.Click += new System.EventHandler(this.TsiReplListRemove_Click);
			// 
			// btnReplSave
			// 
			this.btnReplSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReplSave.Location = new System.Drawing.Point(424, 3);
			this.btnReplSave.Name = "btnReplSave";
			this.btnReplSave.Size = new System.Drawing.Size(90, 46);
			this.btnReplSave.TabIndex = 9;
			this.btnReplSave.Text = "바꿀꺼\r\n쓰기";
			this.btnReplSave.UseVisualStyleBackColor = true;
			this.btnReplSave.Click += new System.EventHandler(this.BtnReplSave_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(6, 6);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.rtxSrc);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.rtxDst);
			this.splitContainer1.Size = new System.Drawing.Size(563, 385);
			this.splitContainer1.SplitterDistance = 278;
			this.splitContainer1.TabIndex = 8;
			// 
			// rtxSrc
			// 
			this.rtxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxSrc.Location = new System.Drawing.Point(0, 0);
			this.rtxSrc.Name = "rtxSrc";
			this.rtxSrc.Size = new System.Drawing.Size(278, 385);
			this.rtxSrc.TabIndex = 0;
			this.rtxSrc.Text = "";
			// 
			// rtxDst
			// 
			this.rtxDst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxDst.Location = new System.Drawing.Point(0, 0);
			this.rtxDst.Name = "rtxDst";
			this.rtxDst.Size = new System.Drawing.Size(281, 385);
			this.rtxDst.TabIndex = 0;
			this.rtxDst.Text = "";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 226);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(640, 423);
			this.tabControl1.TabIndex = 9;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer1);
			this.tabPage1.Controls.Add(this.btnGoReplace);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(632, 397);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "문장 변환";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnBatchRead);
			this.tabPage2.Controls.Add(this.btnBatchSave);
			this.tabPage2.Controls.Add(this.btnBatchRun);
			this.tabPage2.Controls.Add(this.lblBatchFileList);
			this.tabPage2.Controls.Add(this.lstConvFiles);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(632, 397);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "파일 변환";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnBatchRead
			// 
			this.btnBatchRead.Location = new System.Drawing.Point(560, 160);
			this.btnBatchRead.Name = "btnBatchRead";
			this.btnBatchRead.Size = new System.Drawing.Size(66, 46);
			this.btnBatchRead.TabIndex = 13;
			this.btnBatchRead.Text = "목록\r\n읽기\r\n";
			this.btnBatchRead.UseVisualStyleBackColor = true;
			this.btnBatchRead.Click += new System.EventHandler(this.BtnBatchRead_Click);
			// 
			// btnBatchSave
			// 
			this.btnBatchSave.Location = new System.Drawing.Point(560, 108);
			this.btnBatchSave.Name = "btnBatchSave";
			this.btnBatchSave.Size = new System.Drawing.Size(66, 46);
			this.btnBatchSave.TabIndex = 12;
			this.btnBatchSave.Text = "목록\r\n쓰기\r\n";
			this.btnBatchSave.UseVisualStyleBackColor = true;
			this.btnBatchSave.Click += new System.EventHandler(this.BtnBatchSave_Click);
			// 
			// btnBatchRun
			// 
			this.btnBatchRun.Location = new System.Drawing.Point(560, 304);
			this.btnBatchRun.Name = "btnBatchRun";
			this.btnBatchRun.Size = new System.Drawing.Size(66, 87);
			this.btnBatchRun.TabIndex = 11;
			this.btnBatchRun.Text = "바꾸기";
			this.btnBatchRun.UseVisualStyleBackColor = true;
			this.btnBatchRun.Click += new System.EventHandler(this.BtnBatchRun_Click);
			// 
			// lblBatchFileList
			// 
			this.lblBatchFileList.AutoSize = true;
			this.lblBatchFileList.Location = new System.Drawing.Point(15, 3);
			this.lblBatchFileList.Name = "lblBatchFileList";
			this.lblBatchFileList.Size = new System.Drawing.Size(54, 13);
			this.lblBatchFileList.TabIndex = 1;
			this.lblBatchFileList.Text = "파일 목록";
			// 
			// lstConvFiles
			// 
			this.lstConvFiles.AllowDrop = true;
			this.lstConvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
			this.lstConvFiles.FullRowSelect = true;
			this.lstConvFiles.HideSelection = false;
			this.lstConvFiles.Location = new System.Drawing.Point(6, 19);
			this.lstConvFiles.Name = "lstConvFiles";
			this.lstConvFiles.Size = new System.Drawing.Size(548, 372);
			this.lstConvFiles.TabIndex = 0;
			this.lstConvFiles.UseCompatibleStateImageBehavior = false;
			this.lstConvFiles.View = System.Windows.Forms.View.Details;
			this.lstConvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstConvFiles_DragDrop);
			this.lstConvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstConvFiles_DragEnter);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "파일 이름";
			this.columnHeader3.Width = 230;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "경로";
			this.columnHeader4.Width = 283;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 661);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "텍스트 리플스";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ctxReplList.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnReplRead;
		private System.Windows.Forms.Button btnGoReplace;
		private System.Windows.Forms.TextBox txtAddOrg;
		private System.Windows.Forms.Label lblAddOrg;
		private System.Windows.Forms.Label lblAddNew;
		private System.Windows.Forms.TextBox txtAddNew;
		private System.Windows.Forms.Button btnAddAdd;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RichTextBox rtxSrc;
		private System.Windows.Forms.RichTextBox rtxDst;
		private System.Windows.Forms.Button btnReplSave;
		private System.Windows.Forms.ContextMenuStrip ctxReplList;
		private System.Windows.Forms.ToolStripMenuItem tsiReplListRemove;
		private System.Windows.Forms.ListView lstRepls;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnBatchRead;
		private System.Windows.Forms.Button btnBatchSave;
		private System.Windows.Forms.Button btnBatchRun;
		private System.Windows.Forms.Label lblBatchFileList;
		private System.Windows.Forms.ListView lstConvFiles;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
	}
}

