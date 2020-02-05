using System.Collections.Generic;

namespace Seconds
{
	public class Game
	{
		private const int DEFAULT_ROUND_TIME = 30;
		private const int DEFAULT_SCORE_TARGET = 30;

		public List<Team> teams = new List<Team>();

		private int currentTeamIndex = 0;
		public Team CurrentTeam
		{
			get { return teams[currentTeamIndex]; }
		}

		public int roundTime   = DEFAULT_ROUND_TIME;
		public int scoreTarget = DEFAULT_SCORE_TARGET;

		public void AddTeam(Team team)
		{
			teams.Add(team);
		}

		public void ProgressTeams()
		{
			currentTeamIndex++;

			if (currentTeamIndex == teams.Count)
				currentTeamIndex = 0;
		}

		public bool HasTeamWon()
		{
			return CurrentTeam.score == scoreTarget;
		}
	}
}
