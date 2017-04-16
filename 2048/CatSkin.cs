using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
	public class CatSkin : ISkin
	{
		public override string DisplayString(int x)
		{
			if (x <= 0) { return ""; }
			if (x <= 2) { return apps[0]; }
			if (x <= 4) { return apps[1]; }
			if (x <= 8) { return apps[2]; }
			if (x <= 16) { return apps[3]; }
			if (x <= 32) { return apps[4]; }
			if (x <= 64) { return apps[5]; }
			if (x <= 128) { return apps[6]; }
			if (x <= 256) { return apps[7]; }
			if (x <= 512) { return apps[8]; }
			if (x <= 1024) { return apps[9]; }
			if (x <= 2048) { return apps[10]; }
			if (x <= 4096) { return apps[11]; }
			return apps[12];
		}

		private readonly string[] apps = { "猫毛", "猫头", "猫脖", "猫脊椎", "猫爪",
			"猫腿", "猫大腿","猫肚", "猫胸", "两个猫胸", "猫洞","小猫菊花","小猫牙"};
	}
}
