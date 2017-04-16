using System.Drawing;
using System.Windows.Forms;

namespace _2048
{
	public partial class TileUserControl : UserControl
	{
		private ISkin skin;
		public TileUserControl(ISkin skin)
		{
			InitializeComponent();
			this.skin = skin;
		}

		public void SetValue(int val)
		{
			SetColor(val);
			SetNumber(val);
		} 

		private void SetColor(int x)
		{
			Color color = skin.GetColor(x);
			if(x <= 0)
			{
				label1.ForeColor = label1.BackColor = color;
			}
			else
			{
				label1.ForeColor = Color.Black;
				label1.BackColor = color;
			}
		}

		private void SetNumber(int x)
		{
			label1.Text = skin.DisplayString(x);
		}
		
	}
}
