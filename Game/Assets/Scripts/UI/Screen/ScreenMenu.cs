using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds.UI.Screen
{
	public class ScreenMenu : Screen
	{
		[SerializeField, Required]
		private Button buttonPlay = null;

		[SerializeField, Required]
		private ScreenGameSettings screenGameSettings = null;


		private void Awake()
		{
			buttonPlay.onClick.AddListener(OnButtonPlayClicked);
		}

		private void OnDestroy()
		{
			buttonPlay.onClick.RemoveListener(OnButtonPlayClicked);
		}

		private void OnButtonPlayClicked()
		{
			screenGameSettings.Switch();
		}
	}
}