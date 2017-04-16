using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
	//The goal is to get PRICE!!

	//Prepayment Model+ Attribute =  Vol Prepayment
	//Default Model + Attribute = Invol Prepay
	//Vol Prepay +Invol prepay = CPR
	//Attribute + Attribute = Schedule Principal
	//CPR + Schedule Principal = Principal Reduce
	//Principal Reduce + Interest = Cashflow
	//Benchmark + Attribute = Yield
	//Yield+Cashflow =  Price

	//For Advance Mode: We can add Corp Advan, Escrow Model, Eco Model, and Loss Model into this game.

	public class CashFlowSkin : ISkin
	{
		public override string DisplayString(int x)
		{
			if (x <= 0) { return ""; }
			if (x <= 2) { return elements[0]; }
			if (x <= 4) { return elements[1]; }
			if (x <= 8) { return elements[2]; }
			if (x <= 16) { return elements[3]; }
			if (x <= 32) { return elements[4]; }
			if (x <= 64) { return elements[5]; }
			if (x <= 128) { return elements[6]; }
			if (x <= 256) { return elements[7]; }
			if (x <= 512) { return elements[8]; }
			if (x <= 1024) { return elements[9]; }
			if (x <= 2048) { return elements[10]; }
			if (x <= 4096) { return elements[11]; }
			return elements[12];
		}

		//TODO
		private readonly string[] elements = { "Attribute", "Vol Prepay", "Invol Prepay", "CPR", "Schedule Principal",
			"Principal Reduce", "Interest","Benchmark", "Corp Advan", "Escrow Model", "Loss Model","Yield","Price"};
	}



}
