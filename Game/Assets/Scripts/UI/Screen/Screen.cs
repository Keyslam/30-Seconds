using Framework.Dependency;
using UnityEngine;

namespace Seconds.UI.Screen
{
	public abstract class Screen : MonoBehaviour
	{
		[SerializeField]
		private bool showOnStart = false;

		private ScreenManager screenManager = null;

		public virtual void OnEnter() { }
		public virtual void OnExit() { }

		public void Switch()
		{
			screenManager.Switch(this);
		}


		protected virtual void Start()
		{
			screenManager = SceneOrganizer.Get<ScreenManager>();
			screenManager.RegisterScreen(this, showOnStart);
		}
	}
}
