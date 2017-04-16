using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Skins
{
	internal class MIACAppSkin : ISkin
	{
		internal override string DisplayString(int x)
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

		private readonly string[] apps = { "Market Shield", "Asset Forum", "VeriFi", "Bond Agent", "Vision",
			"Data Raptor", "TBA Fixing","Win OAS", "VAST", "CTrac", "Book Creator","Trade Blotter","Security Tool"};
	}

}
