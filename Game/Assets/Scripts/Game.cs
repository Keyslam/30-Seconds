using System;
using System.Collections.Generic;
using UnityEngine;

namespace Seconds
{
	public class Game
	{
		private const int DEFAULT_ROUND_TIME = 30;
		private const int DEFAULT_SCORE_TARGET = 30;


		private int currentTeamIndex = 0;
		public Team CurrentTeam
		{
			get { return teams[currentTeamIndex]; }
		}


		public List<Team> teams = new List<Team>();
		public List<string> topics = new List<string>();

		private List<Category> categories = new List<Category>();

		public int roundTime   = DEFAULT_ROUND_TIME;
		public int scoreTarget = DEFAULT_SCORE_TARGET;
		

		public Game(IEnumerable<string> teamNames, List<Category> categories)
		{
			foreach (string teamName in teamNames)
			{
				Team team = new Team(teamName);
				teams.Add(team);
			}

			foreach (Category category in categories)
				this.categories.Add(category);

			LoadTopics();
		}

		public string PopTopic()
		{
			if (topics.Count == 0)
				LoadTopics();

			int index = topics.Count - 1;

			string topic = topics[index];
			topics.RemoveAt(index);

			return topic;
		}


		private System.Random rng = new System.Random();
		private void LoadTopics()
		{
			topics.Clear();

			foreach (Category category in categories)
			{
				foreach (string topic in category.topics)
					topics.Add(topic);
			}

			int n = topics.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				string value = topics[k];
				topics[k] = topics[n];
				topics[n] = value;
			}
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
