using Framework.Dependency;
using System.Collections.Generic;
using UnityEngine;

namespace Seconds
{
	public class ScreenManager : MonoBehaviour
	{
		public static ScreenManager Instance
		{
			get;
			private set;
		}

		[SerializeField]
		private Canvas canvas = null;

		[SerializeField]
		private Screen startScreen = null;

		[SerializeField]
		private List<Screen> screens = new List<Screen>();

		private Screen currentScreen = null;


		public void RegisterScreen()
		{

		}

		public void Switch(Screen to)
		{
			if (currentScreen != null)
			{
				currentScreen.gameObject.SetActive(false);
				currentScreen.OnExit();
			}

			currentScreen = to;

			to.gameObject.SetActive(true);
			to.OnEnter();
		}

		private void Awake()
		{
			SceneOrganizer.Register(this);

			foreach (Screen screen in screens)
			{
				screen.transform.SetParent(canvas.transform);
				screen.transform.localPosition = Vector3.zero;

				screen.gameObject.SetActive(false);
			}

			Switch(startScreen);
		}

		
	}
}