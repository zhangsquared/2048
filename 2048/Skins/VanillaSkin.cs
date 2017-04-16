using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Skins
{
	internal sealed class VanillaSkin : ISkin
	{
		internal override string DisplayString(int x)
		{
			return x.ToString();
		}
	}
}
