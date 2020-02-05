using UnityEngine;

namespace Seconds
{
	public class Team
	{
		private const int DEFAULT_REROLLS = 3;
		private const int MAX_REROLLS = 3;

		public string name = string.Empty;
		public int score   = 0;
		public int rerolls = 0;

		public Team(string name, int score = 0, int rerolls = DEFAULT_REROLLS)
		{
			this.name    = name;
			this.score   = score;
			this.rerolls = rerolls;
		}

		public void GiveReroll(int refillCount = 1)
		{
			rerolls = Mathf.Min(MAX_REROLLS, rerolls + refillCount);
		}
	}
}
