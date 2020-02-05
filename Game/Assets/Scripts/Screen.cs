using UnityEngine;

namespace Seconds
{
	public abstract class Screen : MonoBehaviour
	{
		public virtual void OnEnter() { }
		public virtual void OnExit() { }
	}
}
