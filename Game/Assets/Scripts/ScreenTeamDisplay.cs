using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds
{
	public class ScreenTeamDisplay : Screen
	{
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

		}
	}
}