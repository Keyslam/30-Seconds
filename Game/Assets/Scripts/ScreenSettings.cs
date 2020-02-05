using UnityEngine;
using UnityEngine.UI;

namespace Seconds
{
	public class ScreenSettings : Screen
	{
		public delegate void ButtonPlayClickedHandler();
		public event ButtonPlayClickedHandler ButtonPlayClicked;

		[SerializeField]
		private Button buttonStart = null;

		public void Awake()
		{
			buttonStart.onClick.AddListener(OnButtonStartClicked);
		}

		public void OnDestroy()
		{
			buttonStart.onClick.RemoveListener(OnButtonStartClicked);
		}

		public void OnButtonStartClicked()
		{
			ButtonPlayClicked?.Invoke();
		}
	}
}