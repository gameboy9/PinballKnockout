namespace PinballKnockout
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			commonFormats = new ComboBox();
			p41 = new NumericUpDown();
			p42 = new NumericUpDown();
			p43 = new NumericUpDown();
			p44 = new NumericUpDown();
			p33 = new NumericUpDown();
			p32 = new NumericUpDown();
			p31 = new NumericUpDown();
			p22 = new NumericUpDown();
			p21 = new NumericUpDown();
			groupSize = new ComboBox();
			strikes = new NumericUpDown();
			endPlayers = new NumericUpDown();
			playerCount = new NumericUpDown();
			button1 = new Button();
			bestWinPct = new Label();
			bestScore = new TextBox();
			worstScore = new TextBox();
			Result = new Label();
			((System.ComponentModel.ISupportInitialize)p41).BeginInit();
			((System.ComponentModel.ISupportInitialize)p42).BeginInit();
			((System.ComponentModel.ISupportInitialize)p43).BeginInit();
			((System.ComponentModel.ISupportInitialize)p44).BeginInit();
			((System.ComponentModel.ISupportInitialize)p33).BeginInit();
			((System.ComponentModel.ISupportInitialize)p32).BeginInit();
			((System.ComponentModel.ISupportInitialize)p31).BeginInit();
			((System.ComponentModel.ISupportInitialize)p22).BeginInit();
			((System.ComponentModel.ISupportInitialize)p21).BeginInit();
			((System.ComponentModel.ISupportInitialize)strikes).BeginInit();
			((System.ComponentModel.ISupportInitialize)endPlayers).BeginInit();
			((System.ComponentModel.ISupportInitialize)playerCount).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 20);
			label1.Name = "label1";
			label1.Size = new Size(131, 20);
			label1.TabIndex = 0;
			label1.Text = "Number of Players";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 63);
			label2.Name = "label2";
			label2.Size = new Size(81, 20);
			label2.TabIndex = 2;
			label2.Text = "Group Size";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 110);
			label3.Name = "label3";
			label3.Size = new Size(128, 20);
			label3.TabIndex = 3;
			label3.Text = "Number of Strikes";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(12, 163);
			label4.Name = "label4";
			label4.Size = new Size(158, 20);
			label4.TabIndex = 4;
			label4.Text = "Number of players left";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(385, 20);
			label5.Name = "label5";
			label5.Size = new Size(127, 20);
			label5.TabIndex = 5;
			label5.Text = "Common Formats";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(385, 63);
			label6.Name = "label6";
			label6.Size = new Size(76, 20);
			label6.TabIndex = 6;
			label6.Text = "2P Groups";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(385, 110);
			label7.Name = "label7";
			label7.Size = new Size(76, 20);
			label7.TabIndex = 7;
			label7.Text = "3P Groups";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(385, 163);
			label8.Name = "label8";
			label8.Size = new Size(76, 20);
			label8.TabIndex = 8;
			label8.Text = "4P Groups";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(12, 226);
			label9.Name = "label9";
			label9.Size = new Size(121, 20);
			label9.TabIndex = 9;
			label9.Text = "Best player score";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(12, 270);
			label10.Name = "label10";
			label10.Size = new Size(131, 20);
			label10.TabIndex = 10;
			label10.Text = "Worst player score";
			// 
			// commonFormats
			// 
			commonFormats.FormattingEnabled = true;
			commonFormats.Items.AddRange(new object[] { "Fair strikes", "Progressive strikes", "Single strikes", "Lenient group strikes", "Strict group strikes", "Oprah strikes" });
			commonFormats.Location = new Point(592, 18);
			commonFormats.Name = "commonFormats";
			commonFormats.Size = new Size(151, 28);
			commonFormats.TabIndex = 11;
			commonFormats.SelectedIndexChanged += commonFormats_SelectedIndexChanged;
			// 
			// p41
			// 
			p41.Location = new Point(484, 161);
			p41.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p41.Name = "p41";
			p41.Size = new Size(49, 27);
			p41.TabIndex = 14;
			p41.TextAlign = HorizontalAlignment.Right;
			// 
			// p42
			// 
			p42.Location = new Point(550, 161);
			p42.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p42.Name = "p42";
			p42.Size = new Size(49, 27);
			p42.TabIndex = 15;
			p42.TextAlign = HorizontalAlignment.Right;
			// 
			// p43
			// 
			p43.Location = new Point(624, 161);
			p43.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p43.Name = "p43";
			p43.Size = new Size(49, 27);
			p43.TabIndex = 16;
			p43.TextAlign = HorizontalAlignment.Right;
			// 
			// p44
			// 
			p44.Location = new Point(694, 161);
			p44.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p44.Name = "p44";
			p44.Size = new Size(49, 27);
			p44.TabIndex = 17;
			p44.TextAlign = HorizontalAlignment.Right;
			// 
			// p33
			// 
			p33.Location = new Point(694, 110);
			p33.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p33.Name = "p33";
			p33.Size = new Size(49, 27);
			p33.TabIndex = 20;
			p33.TextAlign = HorizontalAlignment.Right;
			// 
			// p32
			// 
			p32.Location = new Point(624, 110);
			p32.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p32.Name = "p32";
			p32.Size = new Size(49, 27);
			p32.TabIndex = 19;
			p32.TextAlign = HorizontalAlignment.Right;
			// 
			// p31
			// 
			p31.Location = new Point(550, 110);
			p31.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p31.Name = "p31";
			p31.Size = new Size(49, 27);
			p31.TabIndex = 18;
			p31.TextAlign = HorizontalAlignment.Right;
			// 
			// p22
			// 
			p22.Location = new Point(694, 63);
			p22.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p22.Name = "p22";
			p22.Size = new Size(49, 27);
			p22.TabIndex = 22;
			p22.TextAlign = HorizontalAlignment.Right;
			// 
			// p21
			// 
			p21.Location = new Point(624, 63);
			p21.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
			p21.Name = "p21";
			p21.Size = new Size(49, 27);
			p21.TabIndex = 21;
			p21.TextAlign = HorizontalAlignment.Right;
			// 
			// groupSize
			// 
			groupSize.FormattingEnabled = true;
			groupSize.Items.AddRange(new object[] { "2", "3", "4" });
			groupSize.Location = new Point(188, 60);
			groupSize.Name = "groupSize";
			groupSize.Size = new Size(73, 28);
			groupSize.TabIndex = 23;
			// 
			// strikes
			// 
			strikes.Location = new Point(188, 108);
			strikes.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
			strikes.Name = "strikes";
			strikes.Size = new Size(73, 27);
			strikes.TabIndex = 24;
			strikes.TextAlign = HorizontalAlignment.Right;
			// 
			// endPlayers
			// 
			endPlayers.Location = new Point(188, 161);
			endPlayers.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
			endPlayers.Name = "endPlayers";
			endPlayers.Size = new Size(73, 27);
			endPlayers.TabIndex = 25;
			endPlayers.TextAlign = HorizontalAlignment.Right;
			// 
			// playerCount
			// 
			playerCount.Location = new Point(188, 18);
			playerCount.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
			playerCount.Name = "playerCount";
			playerCount.Size = new Size(73, 27);
			playerCount.TabIndex = 26;
			playerCount.TextAlign = HorizontalAlignment.Right;
			// 
			// button1
			// 
			button1.Location = new Point(623, 220);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 27;
			button1.Text = "Calc TGP";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// bestWinPct
			// 
			bestWinPct.AutoSize = true;
			bestWinPct.Location = new Point(332, 233);
			bestWinPct.Name = "bestWinPct";
			bestWinPct.Size = new Size(76, 20);
			bestWinPct.TabIndex = 28;
			bestWinPct.Text = "4P Groups";
			// 
			// bestScore
			// 
			bestScore.Location = new Point(176, 223);
			bestScore.Name = "bestScore";
			bestScore.Size = new Size(125, 27);
			bestScore.TabIndex = 29;
			bestScore.TextChanged += calcBestWorstChances;
			// 
			// worstScore
			// 
			worstScore.Location = new Point(176, 267);
			worstScore.Name = "worstScore";
			worstScore.Size = new Size(125, 27);
			worstScore.TabIndex = 30;
			worstScore.TextChanged += calcBestWorstChances;
			// 
			// Result
			// 
			Result.AutoSize = true;
			Result.Location = new Point(12, 315);
			Result.Name = "Result";
			Result.Size = new Size(82, 20);
			Result.TabIndex = 31;
			Result.Text = "Result here";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(Result);
			Controls.Add(worstScore);
			Controls.Add(bestScore);
			Controls.Add(bestWinPct);
			Controls.Add(button1);
			Controls.Add(playerCount);
			Controls.Add(endPlayers);
			Controls.Add(strikes);
			Controls.Add(groupSize);
			Controls.Add(p22);
			Controls.Add(p21);
			Controls.Add(p33);
			Controls.Add(p32);
			Controls.Add(p31);
			Controls.Add(p44);
			Controls.Add(p43);
			Controls.Add(p42);
			Controls.Add(p41);
			Controls.Add(commonFormats);
			Controls.Add(label10);
			Controls.Add(label9);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Pinball Strikes Knockout Calculator";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)p41).EndInit();
			((System.ComponentModel.ISupportInitialize)p42).EndInit();
			((System.ComponentModel.ISupportInitialize)p43).EndInit();
			((System.ComponentModel.ISupportInitialize)p44).EndInit();
			((System.ComponentModel.ISupportInitialize)p33).EndInit();
			((System.ComponentModel.ISupportInitialize)p32).EndInit();
			((System.ComponentModel.ISupportInitialize)p31).EndInit();
			((System.ComponentModel.ISupportInitialize)p22).EndInit();
			((System.ComponentModel.ISupportInitialize)p21).EndInit();
			((System.ComponentModel.ISupportInitialize)strikes).EndInit();
			((System.ComponentModel.ISupportInitialize)endPlayers).EndInit();
			((System.ComponentModel.ISupportInitialize)playerCount).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private ComboBox commonFormats;
		private NumericUpDown p41;
		private NumericUpDown p42;
		private NumericUpDown p43;
		private NumericUpDown p44;
		private NumericUpDown p33;
		private NumericUpDown p32;
		private NumericUpDown p31;
		private NumericUpDown p22;
		private NumericUpDown p21;
		private ComboBox groupSize;
		private NumericUpDown strikes;
		private NumericUpDown endPlayers;
		private NumericUpDown playerCount;
		private Button button1;
		private Label bestWinPct;
		private TextBox bestScore;
		private TextBox worstScore;
		private Label Result;
	}
}
