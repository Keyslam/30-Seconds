using Framework.Dependency;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds.UI.Screen
{
	public class ScreenGameSettings : Screen
	{
		[SerializeField]
		private TeamSelector[] teamSelectors = new TeamSelector[0];

		[SerializeField, Required]
		private Button buttonNext = null;

		[SerializeField]
		private List<Category> categories = new List<Category>();

		[SerializeField, Required]
		private ScreenTeamDisplay screenTeamDisplay = null;

		private GameState gameState = null;


		public override void OnEnter()
		{
			base.OnEnter();

			buttonNext.enabled = AreSettingsEligible();
		}


		private void Awake()
		{
			foreach (TeamSelector teamSelector in teamSelectors)
				teamSelector.OnStateChanged += OnTeamSelectorStateChanged;

			buttonNext.onClick.AddListener(OnButtonNextClicked);
		}

		protected override void Start()
		{
			base.Start();

			gameState = SceneOrganizer.Get<GameState>();
		}

		private void OnDestroy()
		{
			buttonNext.onClick.AddListener(OnButtonNextClicked);

			foreach (TeamSelector teamSelector in teamSelectors)
				teamSelector.OnStateChanged -= OnTeamSelectorStateChanged;
		}

		private void OnTeamSelectorStateChanged(TeamSelector teamSelector)
		{
			buttonNext.enabled = AreSettingsEligible();
		}

		private void OnButtonNextClicked()
		{
			List<string> teamNames = new List<string>(GetEnabledTeamCount());
			foreach (TeamSelector teamSelector in teamSelectors)
			{
				if (teamSelector.IsEnabled())
					teamNames.Add(teamSelector.GetTeamName());
			}

			gameState.currentGame = new Game(teamNames, categories);


			screenTeamDisplay.Switch();
		}

		private bool AreSettingsEligible()
		{
			if (GetEnabledTeamCount() < 2)
				return false;

			if (!AreTeamNamesEligible())
				return false;

			return true;
		}

		private int GetEnabledTeamCount()
		{
			int teamCount = 0;

			foreach (TeamSelector teamSelector in teamSelectors)
				teamCount += teamSelector.IsEnabled() ? 1 : 0;

			return teamCount;
		}

		private bool AreTeamNamesEligible()
		{
			foreach (TeamSelector teamSelector in teamSelectors)
			{
				if (!teamSelector.IsEnabled())
					continue;

				if (string.IsNullOrWhiteSpace(teamSelector.GetTeamName()))
					return false;
			}

			return true;
		}
	}
}