using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Seconds.UI
{
	public class Topic : MonoBehaviour
	{
		public delegate void OnSelectToggledHandler(Topic topic, bool newValue);
		public event OnSelectToggledHandler OnSelectToggled;

		public delegate void OnRerollClickedHandler(Topic topic);
		public event OnRerollClickedHandler OnRerollClicked;


		[SerializeField, Required]
		private Toggle toggleSelect = null;

		[SerializeField, Required]
		private TMP_Text labelTopic = null;

		[SerializeField, Required]
		private Button buttonReroll = null;

		
		public void Setup(string topic, bool rerollEnabled)
		{
			toggleSelect.isOn = false;

			SetTopic(topic);
			SetReroll(rerollEnabled);
		}

		public void SetTopic(string topic)
		{
			labelTopic.text = topic;
		}

		public void SetReroll(bool enabled)
		{
			buttonReroll.interactable = enabled;
		}

		private void Awake()
		{
			toggleSelect.onValueChanged.AddListener(OnSelectValueChanged);
			buttonReroll.onClick.AddListener(OnButtonRerollClicked);
		}

		private void OnDestroy()
		{
			toggleSelect.onValueChanged.RemoveListener(OnSelectValueChanged);
			buttonReroll.onClick.RemoveListener(OnButtonRerollClicked);
		}

		private void OnSelectValueChanged(bool newValue)
		{
			OnSelectToggled?.Invoke(this, newValue);
		}

		private void OnButtonRerollClicked()
		{
			OnRerollClicked?.Invoke(this);
		}
	}
}