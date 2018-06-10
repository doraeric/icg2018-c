using UnityEngine;

public static class CharacterInput {
	public static bool lock_input = false;
	public static float GetAxis(string axisName) {
		return lock_input ? 0f : Input.GetAxis(axisName);
	}
	public static bool GetAxisPos(string axisName) {
		return !lock_input && Input.GetAxis(axisName) > 0f;
	}
	public static bool GetAxisNeg(string axisName) {
		return !lock_input && Input.GetAxis(axisName) < 0f;
	}
	public static float GetAxisRaw(string axisName) {
		return lock_input ? 0f : Input.GetAxisRaw(axisName);
	}
	public static bool GetButton(string buttonName) {
		return !lock_input && Input.GetButton(buttonName);
	}
	public static bool GetButtonDown(string buttonName) {
		return !lock_input && Input.GetButtonDown(buttonName);
	}
	public static bool GetButtonUp(string buttonName) {
		return !lock_input && Input.GetButtonUp(buttonName);
	}
	public static bool GetKey(string name) {
		return !lock_input && Input.GetKey(name);
	}
	public static bool GetKey(KeyCode key) {
		return !lock_input && Input.GetKey(key);
	}
	public static bool GetKeyDown(string name) {
		return !lock_input && Input.GetKeyDown(name);
	}
	public static bool GetKeyDown(KeyCode key) {
		return !lock_input && Input.GetKeyDown(key);
	}
	public static bool GetKeyUp(string name) {
		return !lock_input && Input.GetKeyUp(name);
	}
	public static bool GetKeyUp(KeyCode key) {
		return !lock_input && Input.GetKeyUp(key);
	}
	public static bool GetMouseButton(int button) {
		return !lock_input && Input.GetMouseButton(button);
	}
	public static bool GetMouseButtonDown(int button) {
		return !lock_input && Input.GetMouseButtonDown(button);
	}
	public static bool GetMouseButtonUp(int button) {
		return !lock_input && Input.GetMouseButtonUp(button);
	}
}
