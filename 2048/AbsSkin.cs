using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
	public abstract class ISkin
	{
		internal abstract string DisplayString(int x);
		internal virtual Color GetColor(int x)
		{
			if (x <= 0) { return Color.Gainsboro; }
			if (x <= 2) { return Color.LightCyan; }
			if (x <= 4) { return Color.PaleTurquoise; }
			if (x <= 8) { return Color.DarkGoldenrod; }
			if (x <= 16) { return Color.Orange; }
			if (x <= 32) { return Color.Salmon; }
			if (x <= 64) { return Color.Red; }
			if (x <= 128) { return Color.OliveDrab; }
			if (x <= 256) { return Color.ForestGreen; }
			if (x <= 512) { return Color.SkyBlue; }
			if (x <= 1024) { return Color.Blue; }
			if (x <= 2048) { return Color.MediumAquamarine; }
			if (x <= 4096) { return Color.Olive; }
			return Color.Crimson; 
		}
	}

	public enum SkinType
	{
		Vanilla,
		MIACApp
	}

	public static class SkinFactory
	{
		internal static ISkin Generate(SkinType type)
		{
			switch(type)
			{
				case SkinType.Vanilla:
					return new VanillaSkin();
				case SkinType.MIACApp:
					return new MIACAppSkin();
				default:
					throw new InvalidOperationException("Cannot find this type of skin");
			}
		}
	}

}
