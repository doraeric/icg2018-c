using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	/*public float Vertical;
	public float Horizontal;
	public Vector2 MouseInput;
	public bool Fire1;

	void Update () {
		Vertical = Input.GetAxis("Vertical");
		Horizontal = Input.GetAxis("Horizontal");
		MouseInput = new Vector2(Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		Fire1 = Input.GetButton("Fire1");
	}*/

	public float MouseSensitive = 1f;

	public bool GetButtonDown(string name) {
		if (UIManager.Instance.IsClear()) {
			return Input.GetButtonDown(name);
		} else {
			return false;
		}
	}

	public bool GetButton(string name) {
		if (UIManager.Instance.IsClear()) {
			return Input.GetButton(name);
		} else {
			return false;
		}
	}

	public float GetAxis (string name) {
		// Horizontal & Vertical for WASD
		// Mouse X & Mouse Y for mouse
		if (UIManager.Instance.IsClear()) {
			if (name == "Mouse X" || name == "Mouse Y") {
				return Input.GetAxis(name) * MouseSensitive;
			}
			return Input.GetAxis(name);
		} else {
			return 0.0f;
		}
	}
}
