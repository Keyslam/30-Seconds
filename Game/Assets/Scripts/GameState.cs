using Framework.Dependency;
using UnityEngine;

namespace Seconds
{
	public class GameState : MonoBehaviour
	{
		public Game currentGame = null;


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