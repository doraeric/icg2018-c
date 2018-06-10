﻿using UnityEngine;

public class GameController : MonoBehaviour {

	void Start() {
		UIManager.Instance.autoCursorVisibility = true;
		UIManager.Instance.CreatePanel("HealthPanel");
		UIManager.Instance.CreatePanel("WeaponWheel");
		UIManager.Instance.EventSystemRoot.firstSelectedGameObject =
			UIManager.Instance.CreatePanel("PausePanel").FirstSelected;
		UIManager.Instance.TogglePanel("PausePanel", false);
		UIManager.Instance.TogglePanel("WeaponWheel", false);
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
