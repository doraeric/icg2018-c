using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		UIManager.Instance.ShowPanel("HealthPanel");
		UIManager.Instance.ShowPanel("WeaponWheel");
		UIManager.Instance.ShowPanel("PausePanel");
		UIManager.Instance.TogglePanel("PausePanel", false);
		UIManager.Instance.TogglePanel("WeaponWheel", false);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (UIManager.Instance.IsPaneVisible("PausePanel")) {
				UIManager.Instance.TogglePanel("PausePanel", false);
			} else {
				UIManager.Instance.TogglePanel("PausePanel", true);
			}
		}
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (!UIManager.Instance.IsPaneVisible("WeaponWheel") &&
				!UIManager.Instance.IsPaneVisible("PausePanel")) {
				UIManager.Instance.TogglePanel("WeaponWheel", true);
			} else if (UIManager.Instance.IsPaneVisible("WeaponWheel")) {
				UIManager.Instance.TogglePanel("WeaponWheel", false);
			}
		}
	}
}
