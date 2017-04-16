using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
	public sealed class VanillaSkin : ISkin
	{
		public override string DisplayString(int x)
		{
			return x.ToString();
		}
	}
}
