using Framework.Dependency;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds.UI.Screen
{
	public class ScreenManager : MonoBehaviour
	{
		[SerializeField, Required]
		private Canvas canvas = null;

		[SerializeField, Required]
		private Image overlay = null;

		[SerializeField]
		private float fadeTime = 0.1f;

		private Screen currentScreen = null;


		public void RegisterScreen(Screen screen, bool shown)
		{
			screen.transform.SetParent(canvas.transform);
			screen.transform.localPosition = Vector3.zero;
			screen.gameObject.SetActive(false);

			if (shown)
			{
				if (currentScreen != null)
					Debug.LogError("Start screen was already set");
				else
					Switch(screen);
			}
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
		}

		private void OnDestroy()
		{
			SceneOrganizer.Unregister(this);	
		}
	}
}