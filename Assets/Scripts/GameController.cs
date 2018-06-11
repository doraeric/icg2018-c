using UnityEngine;

public class GameController : MonoBehaviour {

	void Start() {
		BasePanel pause;
		UIManager.Instance.autoCursorVisibility = true;
		UIManager.Instance.CreatePanel("HealthPanel");
		UIManager.Instance.CreatePanel("WeaponWheel");
		pause = UIManager.Instance.CreatePanel("PausePanel");
		UIManager.Instance.CreatePanel("BloodPanel");
		UIManager.Instance.CreatePanel("VictoryPanel");
		UIManager.Instance.TogglePanel("PausePanel", false);
		UIManager.Instance.TogglePanel("WeaponWheel", false);
		UIManager.Instance.TogglePanel("VictoryPanel", false);
		if (UIManager.Instance.EventSystemRoot)
			UIManager.Instance.EventSystemRoot.firstSelectedGameObject = pause.FirstSelected;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel")) {
			if (UIManager.Instance.IsPaneVisible("WeaponWheel")) {
				UIManager.Instance.TogglePanel("WeaponWheel");
			} else {
				UIManager.Instance.TogglePanel("PausePanel");
			}
		}
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (!UIManager.Instance.IsPaneVisible("PausePanel")) {
				UIManager.Instance.TogglePanel("WeaponWheel");
			}
		}
	}
}
