using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Game2048;

namespace _2048
{
	public partial class PrettyForm : Form, IMainForm
	{
		public event EventHandler<DirectionEventArgs> OnPlayerKeyDown;
		public event EventHandler AutoStart;
		public event EventHandler AutoStop;
		public event EventHandler ResetAll;
		public event EventHandler OneStep;

		private TileUserControl[] controls;

		public PrettyForm()
		{
			InitializeComponent();

			KeyPreview = true;

			buttonExit.Click += (s, e) => Close();
			buttonRun.Click += (s, e) => AutoStart?.Invoke(s, e);
			buttonStop.Click += (s, e) => AutoStop?.Invoke(s, e);
			buttonReset.Click += (s, e) => ResetAll?.Invoke(s, e);
			buttonStep.Click += (s, e) => OneStep?.Invoke(s, e);
		}

		public void InitTiles(int[,] data, ISkin skin)
		{
			List<TileUserControl> list = new List<TileUserControl>();
			for(int i = 0; i < data.Length; i++)
			{
				TileUserControl con = new TileUserControl(skin);
				con.Dock = DockStyle.Fill;
				list.Add(con);
			}
			controls = list.ToArray();
			tableLayoutPanel1.Controls.AddRange(controls);
		}

		private void OnControlPreviewKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					OnPlayerKeyDown?.Invoke(null, new DirectionEventArgs(Direction.Left));
					break;
				case Keys.Up:
					OnPlayerKeyDown?.Invoke(null, new DirectionEventArgs(Direction.Up));
					break;
				case Keys.Right:
					OnPlayerKeyDown?.Invoke(null, new DirectionEventArgs(Direction.Right));
					break;
				case Keys.Down:
					OnPlayerKeyDown?.Invoke(null, new DirectionEventArgs(Direction.Down));
					break;
				default:
					// nothing
					break;
			}
		}

		public void ShowMessage(string msg)
		{
			MessageBox.Show(msg);
		}

		public int[,] Data
		{
			set
			{
				int index = 0;
				for (int i = 0; i < value.GetLength(0); i++)
				{
					for (int j = 0; j < value.GetLength(1); j++)
					{
						controls[index].SetValue(value[i, j]);
						index++;
					}
				}
				tableLayoutPanel1.Focus();
			}
		}

		public int Score
		{
			set
			{
				label2.Text = value.ToString();
				tableLayoutPanel1.Focus();
			}
		}

		//private const int CsDropshadow = 0x20000;
		//private const int WmNchittest = 0X84;
		//private const int Htcaption = 2;
		//protected override void WndProc(ref Message m)
		//{
		//	if (m.Msg == WmNchittest) // Trap WmNchittest
		//	{
		//		m.Result = (IntPtr)Htcaption;  // Htcaption - tells windows that the click was in the title bar
		//		return;
		//	}

		//	base.WndProc(ref m);
		//}

		//protected override CreateParams CreateParams
		//{
		//	get
		//	{
		//		CreateParams cp = base.CreateParams;
		//		cp.ClassStyle |= CsDropshadow;
		//		return cp;
		//	}
		//}

		//http://stackoverflow.com/questions/25696507/in-winforms-previewkeydown-never-fired-for-any-key
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Up || keyData == Keys.Down ||
				keyData == Keys.Left || keyData == Keys.Right)
			{
				object sender = FromHandle(msg.HWnd);
				KeyEventArgs e = new KeyEventArgs(keyData);
				OnControlPreviewKeyDown(sender, e);
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

	}
}
