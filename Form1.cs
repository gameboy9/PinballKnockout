using System.Numerics;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PinballKnockout
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				using (TextReader reader = File.OpenText("lastFF4FG.txt"))
				{
					playerCount.Value = Convert.ToDecimal(reader.ReadLine());
					groupSize.SelectedIndex = Convert.ToInt32(reader.ReadLine());
					strikes.Value = Convert.ToDecimal(reader.ReadLine());
					endPlayers.Value = Convert.ToDecimal(reader.ReadLine());
					bestScore.Text = reader.ReadLine();
					worstScore.Text = reader.ReadLine();
					commonFormats.SelectedIndex = Convert.ToInt32(reader.ReadLine());
					p21.Value = Convert.ToDecimal(reader.ReadLine());
					p22.Value = Convert.ToDecimal(reader.ReadLine());
					p31.Value = Convert.ToDecimal(reader.ReadLine());
					p32.Value = Convert.ToDecimal(reader.ReadLine());
					p33.Value = Convert.ToDecimal(reader.ReadLine());
					p41.Value = Convert.ToDecimal(reader.ReadLine());
					p42.Value = Convert.ToDecimal(reader.ReadLine());
					p43.Value = Convert.ToDecimal(reader.ReadLine());
					p44.Value = Convert.ToDecimal(reader.ReadLine());
				}
			}
			catch
			{
				// Default flags here
				playerCount.Value = 20;
				groupSize.SelectedIndex = 2; // 4 player groups
				strikes.Value = 6;
				endPlayers.Value = 1;
				bestScore.Text = "400";
				worstScore.Text = "100";
				commonFormats.SelectedIndex = 0; // fair strikes
				p21.Value = 0;
				p22.Value = 1;
				p31.Value = 0;
				p32.Value = 1;
				p33.Value = 2;
				p41.Value = 0;
				p42.Value = 1;
				p43.Value = 1;
				p44.Value = 2;

				calcBestWorstChances(null, null);
			}
		}

		private void calcBestWorstChances(object sender, EventArgs e)
		{
			Random r1 = new Random();

			int bestWins = 0;
			int worstWins = 0;
			try
			{
				for (int i = 0; i < 1000; i++)
				{
					if (r1.Next() % Convert.ToInt32(bestScore.Text) > r1.Next() % Convert.ToInt32(worstScore.Text)) bestWins++;
					else if (r1.Next() % Convert.ToInt32(bestScore.Text) < r1.Next() % Convert.ToInt32(worstScore.Text)) worstWins++;
				}

				bestWinPct.Text = "Best player win %:  " + string.Format("{0:P1}", (decimal)bestWins / 1000);
			}
			catch
			{
				bestWinPct.Text = "Best player win %:  N/A";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int players = Convert.ToInt32(playerCount.Value);
			int finalStrikes = Convert.ToInt32(strikes.Value);
			int finalPlayers = Convert.ToInt32(endPlayers.Value);

			int totalRounds = 0;
			int minRounds = 9999;
			int maxRounds = 0;
			int topScore = Convert.ToInt32(bestScore.Text);
			int lowScore = Convert.ToInt32(worstScore.Text);

			Random r1 = new Random();
			List<player> playerList = new List<player>();
			List<double> roundResult = new List<double>();

			for (int h = 0; h < 10000; h++)
			{
				int round = 0;

				playerList.Clear();
				for (int i = 0; i < players; i++)
				{
					playerList.Add(new player { id = i, chance = (int)(lowScore + ((topScore - lowScore) * ((double)i / (players - 1)))) });
				}
				while (playerList.Where(c => c.strikes < finalStrikes).Count() > finalPlayers)
				{
					round++;

					List<player> allowed = playerList.Where(c => c.strikes < finalStrikes).ToList();

					while (allowed.Count > 0)
					{
						List<player> match = new List<player>();
						int matchPlayers = 4;
						if (allowed.Count == 9 || allowed.Count == 6 || allowed.Count == 5 || allowed.Count == 3)
							matchPlayers = 3;
						else if (allowed.Count == 2)
							matchPlayers = 2;

						for (int j = 0; j < matchPlayers; j++)
						{
							int player = r1.Next() % allowed.Count;
							match.Add(allowed[player]);
							match[j].score = r1.Next() % match[j].chance;
							allowed.RemoveAt(player);
						}

						for (int j = 0; j < matchPlayers; j++)
						{
							int rank = 1;
							for (int k = 0; k < matchPlayers; k++)
							{
								if (k == j) continue;
								if (match[j].score < match[k].score) rank++;
							}
							if (rank == matchPlayers && matchPlayers >= 3) playerList[match[j].id].strikes += 2;
							else if (rank != 1) playerList[match[j].id].strikes += 1;
						}
					}
				}

				roundResult.Add(round);

				totalRounds += round;
				if (round < minRounds) minRounds = round;
				if (round > maxRounds) maxRounds = round;
			}

			double stdDev = StandardDeviation(roundResult);
			double avg = roundResult.Average();

			Result.Text = "Average rounds:  " + string.Format("{0:##.00}", roundResult.Average()) +
				"\r\nMost rounds:  " + maxRounds +
				"\r\nLeast rounds:  " + minRounds +
				"\r\nBest range:  " + string.Format("{0:##.00}", avg - stdDev) + " to " + string.Format("{0:##.00}", avg + stdDev);
		}

		private double StandardDeviation(IEnumerable<double> values)
		{
			double avg = values.Average();
			return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
		}

		internal class player
		{
			public int id;
			public int chance;
			public int strikes = 0;
			public int score = 0;
		}

		private void commonFormats_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (commonFormats.SelectedIndex)
			{
				case 0: // fair strikes
					p21.Value = 0; p22.Value = 1;
					p31.Value = 0; p32.Value = 1; p33.Value = 2;
					p41.Value = 0; p42.Value = 1; p43.Value = 1; p44.Value = 2;
					break;
				case 1: // progressive strikes
					p21.Value = 0; p22.Value = 1;
					p31.Value = 0; p32.Value = 1; p33.Value = 2;
					p41.Value = 0; p42.Value = 1; p43.Value = 2; p44.Value = 3;
					break;
				case 2: // single strikes
					p21.Value = 0; p22.Value = 1;
					p31.Value = 0; p32.Value = 0; p33.Value = 1;
					p41.Value = 0; p42.Value = 0; p43.Value = 0; p44.Value = 1;
					break;
				case 3: // lenient group strikes
					p21.Value = 0; p22.Value = 1;
					p31.Value = 0; p32.Value = 0; p33.Value = 1;
					p41.Value = 0; p42.Value = 0; p43.Value = 1; p44.Value = 1;
					break;
				case 4: // strict group strikes
					p21.Value = 0; p22.Value = 1;
					p31.Value = 0; p32.Value = 1; p33.Value = 1;
					p41.Value = 0; p42.Value = 0; p43.Value = 1; p44.Value = 1;
					break;
				case 5: // Opera strikes
					p21.Value = 0; p22.Value = 1;
					p31.Value = 0; p32.Value = 1; p33.Value = 1;
					p41.Value = 0; p42.Value = 1; p43.Value = 1; p44.Value = 1;
					break;
			}
		}
	}
}
