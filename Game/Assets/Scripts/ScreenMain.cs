using UnityEngine;
using UnityEngine.UI;

namespace Seconds
{
	public class ScreenMain : Screen
	{
		[SerializeField]
		private Button buttonPlay = null;

		[SerializeField]
		private Screen screenSettings = null;

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
			GameManager.Instance.StartGame();
		}
	}
}