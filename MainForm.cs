using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRepls
{
	public partial class MainForm : Form
	{
		private Dictionary<string, string> _rpls = new Dictionary<string, string>();

		public bool Modified { get; set; } = false;
		private LineDb LangDb { set; get; } = null;

		public MainForm()
		{
			InitializeComponent();

			//
			RegistryKey rk = Registry.CurrentUser.OpenSubKey(Setting.RsPuruLive, true);
			if (rk != null)
			{
				try
				{
					if (rk.GetValue("TextReplsLastRepl") is string lastrepl)
					{
						Setting.LastReplList = lastrepl;
						ReadReplList(Setting.LastReplList);
					}

					if (rk.GetValue("TextReplsLastBatchConv") is string lastbatch)
					{
						Setting.LastBatchConv = lastbatch;
					}
				}
				catch
				{
				}
			}

			// 
			btnReplSave.BackColor = SystemColors.Control;

			// 언어 처리
#if DEBUG
			LineDb ldb = new LineDb(Properties.Resources.lang_ko) ;
#else
			LineDb ldb = Thread.CurrentThread.CurrentUICulture == CultureInfo.GetCultureInfo("ko-KR") ?
				new LineDb(Properties.Resources.lang_ko) :
				new LineDb(Properties.Resources.lang_en);
#endif

			System.Version sv = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			DateTime bdt = new DateTime(2000, 1, 1).AddDays(sv.Build).AddSeconds(sv.Revision * 2);

			//this.Text = ldb["name"] + " - " + bdt.ToShortDateString();			
			this.Text = ldb["name"];
			btnAddAdd.Text = ldb["btnadd"];
			lblAddOrg.Text = ldb["lbladdorg"];
			lblAddNew.Text = ldb["lbladdnew"];
			btnReplSave.Text = ldb["btnreplsave"];
			btnReplRead.Text = ldb["btnreplread"];
			columnHeader1.Text = ldb["lstreplsclmorg"];
			columnHeader2.Text = ldb["lstreplsclmnew"];
			tabPage1.Text = ldb["tabtextconv"];
			tabPage2.Text = ldb["tabbatchconv"];
			btnGoReplace.Text = ldb["btngoreplace"];
			lblBatchFileList.Text = ldb["lblbatchfilelist"];
			columnHeader3.Text = ldb["lstconvfilesclmfilename"];
			columnHeader4.Text = ldb["lstconvfilesclmpath"];
			btnBatchSave.Text = ldb["btnbatchsave"];
			btnBatchRead.Text = ldb["btnbatchopen"];
			btnBatchRun.Text = ldb["btnbatchrun"];

			LangDb = ldb;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Modified)
			{
				var res = MessageBox.Show(this, LangDb["warningclose"], LangDb["needconfirm"],
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (res != DialogResult.Yes)
					e.Cancel = true;
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			RegistryKey rk = Registry.CurrentUser.OpenSubKey(Setting.RsPuruLive, true);
			if (rk == null)
				rk = Registry.CurrentUser.CreateSubKey(Setting.RsPuruLive);

			rk.SetValue("TextReplsLastRepl", Setting.LastReplList);
			rk.SetValue("TextReplsLastBatchConv", Setting.LastBatchConv);
		}

		private void BtnReplRead_Click(object sender, EventArgs e)
		{
			if (Modified)
			{
				var res = MessageBox.Show(this, LangDb["warningreplread"], LangDb["needconfirm"],
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (res != DialogResult.Yes)
					return;
			}

			OpenFileDialog dlg = new OpenFileDialog()
			{
				Title = LangDb["dlgopentitle"],
				Filter = LangDb["dlgfilefilter"],
				DefaultExt = LangDb["dlgdefaultext"],
			};

			try
			{
				dlg.InitialDirectory = Path.GetDirectoryName(Setting.LastReplList);
				dlg.FileName = Path.GetFileName(Setting.LastReplList);
			}
			catch
			{
			}

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				ReadReplList(dlg.FileName);

				Modified = false;
				btnReplSave.BackColor = SystemColors.Control;

				Setting.LastReplList = dlg.FileName;
			}
		}

		private void BtnReplSave_Click(object sender, EventArgs e)
		{
			if (!Modified)
				return;

			SaveFileDialog dlg = new SaveFileDialog()
			{
				Title = LangDb["dlgsavetitle"],
				Filter = LangDb["dlgfilefilter"],
				DefaultExt = LangDb["dlgdefaultext"],
				OverwritePrompt = false,
			};

			try
			{
				dlg.InitialDirectory = Path.GetDirectoryName(Setting.LastReplList);
				dlg.FileName = Path.GetFileName(Setting.LastReplList);
			}
			catch
			{
			}

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					using (StreamWriter sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
					{
						foreach (var i in _rpls)
							sw.WriteLine("{0}〓{1}", i.Key, i.Value);
					}
				}
				catch
				{
					MessageBox.Show(this, LangDb["errorsave"], LangDb["neederror"]);
				}

				Modified = false;
				btnReplSave.BackColor = SystemColors.Control;

				Setting.LastReplList = dlg.FileName;
			}
		}

		private void BtnGoReplace_Click(object sender, EventArgs e)
		{
			WorkWorkWork();
		}

		private void BtnAddAdd_Click(object sender, EventArgs e)
		{
			if (txtAddNew.TextLength > 0 && txtAddNew.Text.Contains('〓'))
			{
				MessageBox.Show(this, LangDb["errorinvalidequal"]);
				return;
			}

			AddReplListItem();

			txtAddOrg.Clear();
			txtAddNew.Clear();

			txtAddOrg.Focus();
		}

		private void TxtAddOrg_Enter(object sender, EventArgs e)
		{
			//txtAddNew.SelectAll();
		}

		private void TxtAddOrg_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtAddNew.Text.Contains('〓'))
				{
					MessageBox.Show(this, LangDb["errorinvalidequal"], LangDb["neederror"]);
					return;
				}

				txtAddNew.Clear();
				txtAddNew.Focus();
			}
		}

		private void TxtAddNew_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				AddReplListItem();

				txtAddOrg.Clear();
				txtAddNew.Clear();

				txtAddOrg.Focus();
			}
		}

		private void TsiReplListRemove_Click(object sender, EventArgs e)
		{
			if (lstRepls.SelectedItems.Count == 0)
				return;

			var prevcnt = _rpls.Count;

			foreach (var i in lstRepls.SelectedItems)
			{
				var s = i.ToString();
				_rpls.Remove(s);
			}

			UpdateReplList();

			if (_rpls.Count != prevcnt)
			{
				Modified = true;
				btnReplSave.BackColor = Color.PaleGreen;
			}
		}

		// 리플 목록 읽기
		private void ReadReplList(string filename)
		{
			try
			{
				var ldb = new LineDb(filename, Encoding.UTF8);
				_rpls = ldb.CloneDb();

				UpdateReplList();
			}
			catch { }
		}

		// 추가
		private void AddReplListItem()
		{
			var so = txtAddOrg.Text.Trim();
			var sn = txtAddNew.Text.Trim();

			if (so.Length == 0)
				txtAddOrg.Focus();
			else if (sn.Length == 0)
				txtAddNew.Focus();
			else
			{
				if (_rpls.ContainsKey(so))
					_rpls.Remove(so);

				_rpls.Add(so, sn);

				UpdateReplList();

				//
				if (!Modified)
				{
					Modified = true;
					btnReplSave.BackColor = Color.PaleGreen;
				}
			}
		}

		// 리스트 업뎃
		private void UpdateReplList()
		{
			lstRepls.BeginUpdate();
			lstRepls.Items.Clear();

			foreach (var i in _rpls)
			{
				ListViewItem li = new ListViewItem(new string[] { i.Key, i.Value });
				lstRepls.Items.Add(li);
			}

			lstRepls.EndUpdate();
		}

		// 하나만 일해
		private string WorkWorkWork(string ctx)
		{
			string ss = ctx;

			foreach (var i in _rpls)
				ss = ss.Replace(i.Key, i.Value);

			return ss;
		}


		// 일해
		private void WorkWorkWork()
		{
			rtxDst.Text = WorkWorkWork(rtxSrc.Text);
		}

		private void LstConvFiles_DragDrop(object sender, DragEventArgs e)
		{
			string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop);

			foreach (var i in ss)
			{
				bool yes = false;

				foreach (ListViewItem u in lstConvFiles.Items)
				{
					var n = u.Tag as string;
					if (n.Equals(i))
					{
						yes = true;
						break;
					}
				}

				if (!yes)
				{
					ListViewItem li = new ListViewItem(new string[]
					{
						Path.GetFileName(i),
						Path.GetDirectoryName(i),
					})
					{
						Tag = i,
					};

					lstConvFiles.Items.Add(li);
				}
			}
		}

		private void LstConvFiles_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void BtnBatchSave_Click(object sender, EventArgs e)
		{
			if (lstConvFiles.Items.Count == 0)
				return;

			SaveFileDialog dlg = new SaveFileDialog()
			{
				Title = LangDb["dlgbatchsavetitle"],
				Filter = LangDb["dlgfilefilter"],
				DefaultExt = LangDb["dlgdefaultext"],
				OverwritePrompt = true,
			};

			try
			{
				dlg.InitialDirectory = Path.GetDirectoryName(Setting.LastBatchConv);
				dlg.FileName = Path.GetFileName(Setting.LastBatchConv);
			}
			catch
			{
			}

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					using (StreamWriter sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
					{
						foreach (ListViewItem i in lstConvFiles.Items)
						{
							var s = i.Tag as string;
							sw.WriteLine(s);
						}
					}
				}
				catch
				{
					MessageBox.Show(this, LangDb["errorinvalidequal"], LangDb["neederror"]);
				}

				Setting.LastBatchConv = dlg.FileName;
			}
		}

		private void BtnBatchRead_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog()
			{
				Title = LangDb["dlgbatchopentitle"],
				Filter = LangDb["dlgfilefilter"],
				DefaultExt = LangDb["dlgdefaultext"],
			};

			try
			{
				dlg.InitialDirectory = Path.GetDirectoryName(Setting.LastBatchConv);
				dlg.FileName = Path.GetFileName(Setting.LastBatchConv);
			}
			catch
			{
			}

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				lstConvFiles.BeginUpdate();
				lstConvFiles.Items.Clear();

				string txt = File.ReadAllText(dlg.FileName, Encoding.UTF8);

				var ss = txt.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

				foreach (var l in ss)
				{
					var s = l.Trim();

					if (s.Length > 0 && File.Exists(s))
					{
						ListViewItem li = new ListViewItem(new string[]
{
						Path.GetFileName(s),
						Path.GetDirectoryName(s),
})
						{
							Tag = s,
						};

						lstConvFiles.Items.Add(li);
					}
				}

				lstConvFiles.EndUpdate();

				Setting.LastBatchConv = dlg.FileName;
			}
		}

		private void BtnBatchRun_Click(object sender, EventArgs e)
		{
			if (lstConvFiles.Items.Count == 0)
				return;

			var ms = MessageBox.Show(this, string.Format(LangDb["warningbeforebatch"], lstConvFiles.Items.Count),
				LangDb["needconfirm"], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (ms != DialogResult.Yes)
				return;

			foreach (ListViewItem li in lstConvFiles.Items)
			{
				var s = li.Tag as string;

				try
				{
					var txt = File.ReadAllText(s, Encoding.UTF8);
					txt = WorkWorkWork(txt);
					File.WriteAllText(s, txt, Encoding.UTF8);
				}
				catch { }
			}
		}
	}
}
