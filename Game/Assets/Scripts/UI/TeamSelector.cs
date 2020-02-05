using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds.UI
{
	public class TeamSelector : MonoBehaviour
	{
		public delegate void OnStateChangedHandler(TeamSelector teamSelector);
		public event OnStateChangedHandler OnStateChanged;


		[SerializeField]
		private bool enabledDefault = true;


		[SerializeField]
		private TMP_InputField inputFieldTeamName = null;

		[SerializeField]
		private Toggle toggleEnabled = null;


		public bool IsEnabled()
		{
			return toggleEnabled.isOn;
		}

		public bool HasTeamName()
		{
			return !string.IsNullOrWhiteSpace(inputFieldTeamName.text);
		}

		public string GetTeamName()
		{
			return inputFieldTeamName.text;
		}


		private void Awake()
		{
			inputFieldTeamName.onValueChanged.AddListener(OnInputFieldTeamNameValueChanged);
			toggleEnabled.onValueChanged.AddListener(OnToggleEnabledValueChanged);

			toggleEnabled.isOn = enabledDefault;
		}

		private void OnDestroy()
		{
			inputFieldTeamName.onValueChanged.RemoveListener(OnInputFieldTeamNameValueChanged);
			toggleEnabled.onValueChanged.RemoveListener(OnToggleEnabledValueChanged);
		}

		private void OnInputFieldTeamNameValueChanged(string newValue)
		{
			OnStateChanged?.Invoke(this);
		}

		private void OnToggleEnabledValueChanged(bool newValue)
		{
			inputFieldTeamName.interactable = newValue;

			OnStateChanged?.Invoke(this);
		}


		private void OnValidate()
		{
			toggleEnabled.isOn = enabledDefault;
			inputFieldTeamName.interactable = enabledDefault;
		}
	}
}