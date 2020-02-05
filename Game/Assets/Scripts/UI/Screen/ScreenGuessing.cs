using Framework.Dependency;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds.UI.Screen
{
	public class ScreenGuessing : Screen
	{
		[SerializeField, Required]
		private TMP_Text labelTeamName = null;

		[SerializeField, Required]
		private TMP_Text labelTeamScore = null;

		[SerializeField, Required]
		private TMP_Text labelTimeleft = null;

		[SerializeField]
		private List<Topic> topics = new List<Topic>();

		[SerializeField, Required]
		private Button buttonNext = null;

		[SerializeField, Required]
		private ScreenTeamDisplay screenTeamDisplay = null;

		private GameState gameState = null;

		private bool canGuess = false;
		private float timeLeft = 0;

		public override void OnEnter()
		{
			base.OnEnter();

			labelTeamName.text = gameState.currentGame.CurrentTeam.name;
			labelTeamScore.text = string.Format("{0} / {1}", gameState.currentGame.CurrentTeam.score, gameState.currentGame.scoreTarget);

			foreach (Topic topic in topics)
				topic.Setup(gameState.currentGame.PopTopic(), gameState.currentGame.CurrentTeam.rerolls > 0);

			StartTimer();
		}

		protected override void Start()
		{
			base.Start();

			gameState = SceneOrganizer.Get<GameState>();

			foreach (Topic topic in topics)
			{
				topic.OnRerollClicked += OnTopicRerollClicked;
			}
				
			buttonNext.onClick.AddListener(OnButtonNextClicked);
		}

		private void OnDestroy()
		{
			buttonNext.onClick.RemoveListener(OnButtonNextClicked);
		}

		private void OnTopicRerollClicked(Topic topic)
		{
			if (gameState.currentGame.CurrentTeam.rerolls <= 0)
				return;

			topic.SetTopic(gameState.currentGame.PopTopic());

			gameState.currentGame.CurrentTeam.rerolls--;

			if (gameState.currentGame.CurrentTeam.rerolls <= 0)
			{
				foreach (Topic otopic in topics)
					otopic.SetReroll(false);
			}
		}

		private void OnButtonNextClicked()
		{
			// TODO: Check if game is over

			gameState.currentGame.CurrentTeam.score += Random.Range(1, 3);

			gameState.currentGame.ProgressTeams();

			screenTeamDisplay.Switch();
		}

		private void StartTimer()
		{
			int time = gameState.currentGame.roundTime;
			StartCoroutine(TimerRoutine(time));
		}

		private IEnumerator TimerRoutine(int time)
		{
			canGuess = true;
			timeLeft = time;

			while (timeLeft > 0.0f)
			{
				yield return null;

				timeLeft -= Time.deltaTime;

				labelTimeleft.text = Mathf.Ceil(timeLeft).ToString();
			}

			timeLeft = 0.0f;
			labelTimeleft.text = "Time up!";
			// TODO: Play a sound?

			canGuess = false;
			Debug.Log("Time up");
		}
	}
}