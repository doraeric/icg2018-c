using UnityEngine;
using UnityEngine.UI;

public class PausePanel : BasePanel {
	[SerializeField]Button resumeButton;
	[SerializeField]Button quitButton;
	[SerializeField]Slider sensitivitySlider;

	public void Start() {
		resumeButton.onClick.AddListener( delegate { ResumeGame(); });
		quitButton.onClick.AddListener( delegate { QuitGame(); });
		sensitivitySlider.onValueChanged.AddListener( delegate {
			ChangeMouseSensitivity(sensitivitySlider.value);
		});
	}

	public void ResumeGame() {
		UIManager.Instance.TogglePanel("PausePanel", false);
	}
	public void QuitGame() {
		// TODO FIXME
		Application.Quit();
	}
	public void ChangeMouseSensitivity(float value) {
		GameManager.Instance.tpsCamera.horizontalAimingSpeed = value;
		GameManager.Instance.tpsCamera.verticalAimingSpeed = value;
	}
}
