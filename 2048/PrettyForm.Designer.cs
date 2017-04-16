namespace _2048
{
	partial class PrettyForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrettyForm));
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.buttonStep = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonRun = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(713, 661);
			this.panel2.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel3.Controls.Add(this.tableLayoutPanel1);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(10);
			this.panel3.Size = new System.Drawing.Size(709, 657);
			this.panel3.TabIndex = 5;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 601);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(10, 611);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.panel1.Size = new System.Drawing.Size(689, 36);
			this.panel1.TabIndex = 5;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel4.Controls.Add(this.buttonStep);
			this.panel4.Controls.Add(this.buttonReset);
			this.panel4.Controls.Add(this.buttonStop);
			this.panel4.Controls.Add(this.buttonRun);
			this.panel4.Controls.Add(this.buttonExit);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(689, 34);
			this.panel4.TabIndex = 2;
			// 
			// buttonStep
			// 
			this.buttonStep.FlatAppearance.BorderSize = 0;
			this.buttonStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonStep.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStep.ForeColor = System.Drawing.Color.DodgerBlue;
			this.buttonStep.Location = new System.Drawing.Point(382, 6);
			this.buttonStep.Name = "buttonStep";
			this.buttonStep.Size = new System.Drawing.Size(112, 24);
			this.buttonStep.TabIndex = 6;
			this.buttonStep.Text = "Just One Step";
			this.buttonStep.UseVisualStyleBackColor = true;
			// 
			// buttonReset
			// 
			this.buttonReset.FlatAppearance.BorderSize = 0;
			this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonReset.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonReset.ForeColor = System.Drawing.Color.DodgerBlue;
			this.buttonReset.Location = new System.Drawing.Point(558, 6);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(51, 24);
			this.buttonReset.TabIndex = 5;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			// 
			// buttonStop
			// 
			this.buttonStop.FlatAppearance.BorderSize = 0;
			this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonStop.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStop.ForeColor = System.Drawing.Color.DodgerBlue;
			this.buttonStop.Location = new System.Drawing.Point(264, 5);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(50, 25);
			this.buttonStop.TabIndex = 4;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			// 
			// buttonRun
			// 
			this.buttonRun.FlatAppearance.BorderSize = 0;
			this.buttonRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRun.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonRun.ForeColor = System.Drawing.Color.DodgerBlue;
			this.buttonRun.Location = new System.Drawing.Point(216, 6);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(52, 24);
			this.buttonRun.TabIndex = 3;
			this.buttonRun.Text = "Run";
			this.buttonRun.UseVisualStyleBackColor = true;
			// 
			// buttonExit
			// 
			this.buttonExit.FlatAppearance.BorderSize = 0;
			this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonExit.ForeColor = System.Drawing.Color.DodgerBlue;
			this.buttonExit.Location = new System.Drawing.Point(615, 6);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(41, 24);
			this.buttonExit.TabIndex = 2;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
			this.label2.Location = new System.Drawing.Point(83, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
			this.label1.Location = new System.Drawing.Point(21, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Score";
			// 
			// PrettyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(713, 661);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PrettyForm";
			this.Text = "2048";
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.Button buttonStep;
	}
}