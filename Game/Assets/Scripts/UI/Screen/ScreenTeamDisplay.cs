using Framework.Dependency;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds.UI.Screen
{
	public class ScreenTeamDisplay : Screen
	{
		[SerializeField, Required]
		private TMP_Text labelTeamName = null;

		[SerializeField, Required]
		private Button buttonStart = null;

		[SerializeField, Required]
		private ScreenGuessing screenGuessing = null;


		private GameState gameState = null;

		public override void OnEnter()
		{
			base.OnEnter();

			labelTeamName.text = gameState.currentGame.CurrentTeam.name;
		}

		private void Awake()
		{
			buttonStart.onClick.AddListener(OnButtonStartClicked);
		}

		protected override void Start()
		{
			base.Start();

			gameState = SceneOrganizer.Get<GameState>();
		}

		private void OnDestroy()
		{
			buttonStart.onClick.RemoveListener(OnButtonStartClicked);
		}

		private void OnButtonStartClicked()
		{
			screenGuessing.Switch();
		}
	}
}