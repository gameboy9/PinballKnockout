using System.Numerics;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PinballKnockout
{
	public partial class Form1 : Form
	{
		const int iterations = 10000;
		bool updating = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				using (TextReader reader = File.OpenText("lastKP.txt"))
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
				bestScore.Text = "40000000";
				worstScore.Text = "10000000";
				commonFormats.SelectedIndex = 0; // fair strikes
				p21.Value = 0;
				p22.Value = 2;
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

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			using (StreamWriter writer = File.CreateText("lastKP.txt"))
			{
				writer.WriteLine(playerCount.Value);
				writer.WriteLine(groupSize.SelectedIndex);
				writer.WriteLine(strikes.Value);
				writer.WriteLine(endPlayers.Value);
				writer.WriteLine(bestScore.Text);
				writer.WriteLine(worstScore.Text);
				writer.WriteLine(commonFormats.SelectedIndex);
				writer.WriteLine(p21.Value);
				writer.WriteLine(p22.Value);
				writer.WriteLine(p31.Value);
				writer.WriteLine(p32.Value);
				writer.WriteLine(p33.Value);
				writer.WriteLine(p41.Value);
				writer.WriteLine(p42.Value);
				writer.WriteLine(p43.Value);
				writer.WriteLine(p44.Value);
			}
		}

		private void calcBestWorstChances(object sender, EventArgs e)
		{
			Random r1 = new Random();

			int bestWins = 0;
			int worstWins = 0;
			try
			{
				// The randomizer tops out at "best - 1".
				int best = Convert.ToInt32(bestScore.Text) - 1;
				int worst = Convert.ToInt32(worstScore.Text) - 1;
				// Example - 400 vs 100 -> If worst score = 99, 299/400.  If worst score = 0, 399/400.  Ties are possible...
				double chance = (double)((best - 1) + (best - worst)) / ((best + 1) * 2);

				bestWinPct.Text = "Best player win %:  " + string.Format("{0:P1}", (decimal)chance);
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
			int topScore = 0;
			int lowScore = 0;
			try
			{
				topScore = Convert.ToInt32(bestScore.Text);
				lowScore = Convert.ToInt32(worstScore.Text);
			} catch
			{
				MessageBox.Show("Cannot calculate; best and worst scores must be integers.");
				return;
			}

			Random r1 = new Random();
			List<player> playerList = new List<player>();
			List<double> roundResult = new List<double>();
			int[] playerGames = new int[3];
			string firstIteration = "";

			for (int h = 0; h < iterations; h++)
			{
				int round = 0;
				double strightGames = 0.0f;

				playerList.Clear();
				for (int i = 0; i < players; i++)
				{
					playerList.Add(new player { id = i, chance = (int)(lowScore + ((topScore - lowScore) * ((double)i / (players - 1)))) });
				}
				while (playerList.Where(c => c.strikes < finalStrikes).Count() > finalPlayers)
				{
					int singlePlayers = playerList.Where(c => c.strikes < finalStrikes).Count();
					int[] singlePlayerMatches = new int[3];

					round++;

					List<player> allowed = playerList.Where(c => c.strikes < finalStrikes).ToList();

					while (allowed.Count > 0)
					{
						List<player> match = new List<player>();
						int matchPlayers = 4;
						if (allowed.Count == 9 || allowed.Count == 6 || allowed.Count == 5 || allowed.Count == 3)
						{ matchPlayers = 3; }
						else if (allowed.Count == 2)
						{ matchPlayers = 2; }

						playerGames[matchPlayers - 2]++;
						singlePlayerMatches[matchPlayers - 2]++;

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

							//rank = (int)((double)match[j].score / match[j].chance * matchPlayers) + 1;
							if (rank == 1 && matchPlayers == 2) playerList[match[j].id].strikes += Convert.ToInt32(p21.Value);
							if (rank == 2 && matchPlayers == 2) playerList[match[j].id].strikes += Convert.ToInt32(p22.Value);
							if (rank == 1 && matchPlayers == 3) playerList[match[j].id].strikes += Convert.ToInt32(p31.Value);
							if (rank == 2 && matchPlayers == 3) playerList[match[j].id].strikes += Convert.ToInt32(p32.Value);
							if (rank == 3 && matchPlayers == 3) playerList[match[j].id].strikes += Convert.ToInt32(p33.Value);
							if (rank == 1 && matchPlayers == 4) playerList[match[j].id].strikes += Convert.ToInt32(p41.Value);
							if (rank == 2 && matchPlayers == 4) playerList[match[j].id].strikes += Convert.ToInt32(p42.Value);
							if (rank == 3 && matchPlayers == 4) playerList[match[j].id].strikes += Convert.ToInt32(p43.Value);
							if (rank == 4 && matchPlayers == 4) playerList[match[j].id].strikes += Convert.ToInt32(p44.Value);
						}
					}
					if (h == 0)
						firstIteration += "R" + round + " -  Players:  " + singlePlayers + " - 4P:  " + singlePlayerMatches[2] + " - 3P:  " + singlePlayerMatches[1] + " - 2P:  " + singlePlayerMatches[0] + "\r\n";

					strightGames++;
				}

				roundResult.Add(round);

				totalRounds += round;
				if (round < minRounds) minRounds = round;
				if (round > maxRounds) maxRounds = round;
			}

			firstIterationDetail.Text = firstIteration;

			double stdDev = StandardDeviation(roundResult);
			double avg = roundResult.Average();
			double totalGames = playerGames[0] + playerGames[1] + playerGames[2];
			double totalTGP = playerGames[0] + (1.5 * playerGames[1]) + (2 * playerGames[2]);
			int pct5 = (int)(iterations * 0.05);
			int pct95 = (int)(iterations * 0.95);
			roundResult.Sort();

			Result.Text = "Average rounds:  " + string.Format("{0:##.00}", roundResult.Average()) +
				"\r\nAvg 2P games:  " + string.Format("{0:##.00}", (double)playerGames[0] / iterations) +
				"\r\nAvg 3P games:  " + string.Format("{0:##.00}", (double)playerGames[1] / iterations) +
				"\r\nAvg 4P games:  " + string.Format("{0:##.00}", (double)playerGames[2] / iterations) +
				"\r\nAvg total games:  " + string.Format("{0:##.00}", totalGames / iterations) +
				"\r\nMeaningful games:  " + string.Format("{0:##.00}", roundResult.Average() * totalTGP / totalGames) + // Iterations not needed because of roundResult.Average()
				"\r\nApprox. TGP:  " + string.Format("{0:P2}", roundResult.Average() * totalTGP / totalGames * 4 / 100) +
				"\r\nMost rounds:  " + maxRounds +
				"\r\nLeast rounds:  " + minRounds +
				"\r\n95% range (2 std. dev.):  " + string.Format("{0:##.00}", avg - (stdDev * 2)) + " to " + string.Format("{0:##.00}", avg + (stdDev * 2)) +
				"\r\n5th / 95th percentile:  " + roundResult[pct5] + " / " + roundResult[pct95];
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
			updating = true;
			switch (commonFormats.SelectedIndex)
			{
				case 0: // fair strikes
					p21.Value = 0; p22.Value = 2;
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
			updating = false;
		}

		private void clearCommonFormat(object sender, EventArgs e)
		{
			if (!updating)
			{
				if (p21.Value == 0 && p22.Value == 2 &&
					p31.Value == 0 && p32.Value == 1 && p33.Value == 2 &&
					p41.Value == 0 && p42.Value == 1 && p43.Value == 1 && p44.Value == 2)
					commonFormats.SelectedIndex = 0;
				else if (p21.Value == 0 && p22.Value == 1 &&
					p31.Value == 0 && p32.Value == 1 && p33.Value == 2 &&
					p41.Value == 0 && p42.Value == 1 && p43.Value == 2 && p44.Value == 3)
					commonFormats.SelectedIndex = 1;
				else if (p21.Value == 0 && p22.Value == 1 &&
					p31.Value == 0 && p32.Value == 0 && p33.Value == 1 &&
					p41.Value == 0 && p42.Value == 0 && p43.Value == 0 && p44.Value == 1)
					commonFormats.SelectedIndex = 2;
				else if (p21.Value == 0 && p22.Value == 1 &&
					p31.Value == 0 && p32.Value == 0 && p33.Value == 1 &&
					p41.Value == 0 && p42.Value == 0 && p43.Value == 1 && p44.Value == 1)
					commonFormats.SelectedIndex = 3;
				else if (p21.Value == 0 && p22.Value == 1 &&
					p31.Value == 0 && p32.Value == 1 && p33.Value == 1 &&
					p41.Value == 0 && p42.Value == 0 && p43.Value == 1 && p44.Value == 1)
					commonFormats.SelectedIndex = 4;
				else if (p21.Value == 0 && p22.Value == 1 &&
					p31.Value == 0 && p32.Value == 1 && p33.Value == 1 &&
					p41.Value == 0 && p42.Value == 1 && p43.Value == 1 && p44.Value == 1)
					commonFormats.SelectedIndex = 5;
				else
					commonFormats.SelectedIndex = -1;
			}
		}
	}
}
