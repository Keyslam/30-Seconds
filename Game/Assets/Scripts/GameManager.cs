using UnityEngine;

namespace Seconds
{
	public class GameManager : MonoBehaviour
	{
		public static Game currentGame = null;

		public static GameManager Instance
		{
			get;
			private set;
		} = null;

		public enum GameState
		{
			NONE,
			SETUP,
			DISPLAY_TEAM,
			COUNT_DOWN,
			GUESSING,
			ENDING,
		}

		[SerializeField]
		private ScreenSettings screenSettings = null;

		[SerializeField]
		private ScreenTeamDisplay screenTeamDisplay = null;

		[SerializeField]
		private ScreenCountDown screenCountdown = null;

		[SerializeField]
		private ScreenGuessing screenGuessing = null;

		[SerializeField]
		private ScreenResults screenResults = null;

		private GameState gameState = GameState.NONE;

		public void Awake()
		{
			Instance = this;
		}

		public void StartGame()
		{
			currentGame = new Game();
			Continue();
		}

		public void Continue()
		{
			switch (gameState)
			{
				case GameState.NONE:
					Setup();
					break;
				case GameState.SETUP:
					DisplayTeam();
					break;
				case GameState.DISPLAY_TEAM:
					DoCountDown();
					break;
				case GameState.COUNT_DOWN:
					DoRound();
					break;
				case GameState.GUESSING:
					EndRound();
					break;
				case GameState.ENDING:
					EndGame();
					break;
			}
		}

		private void Setup()
		{
			gameState = GameState.SETUP;
			ScreenManager.Instance.Switch(screenSettings);

			screenSettings.ButtonPlayClicked += OnScreenSettingsContinue;
		}

		private void OnScreenSettingsContinue()
		{
			screenSettings.ButtonPlayClicked -= OnScreenSettingsContinue;
			
			// TODO: Set up game from settings
   
			Continue();
		}

		private void DisplayTeam()
		{
			gameState = GameState.DISPLAY_TEAM;
			ScreenManager.Instance.Switch(screenTeamDisplay);
		}

		private void ScreenDisplayContinue()
		{

		}

		public void DoCountDown()
		{
			gameState = GameState.COUNT_DOWN;
		}

		private void DoRound()
		{
			gameState = GameState.GUESSING;
		}

		private void EndRound()
		{
			gameState = GameState.ENDING;
		}

		private void EndGame()
		{
			gameState = GameState.ENDING;
		}
	}
}
