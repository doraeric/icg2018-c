using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlider : MonoBehaviour {
	Slider mouseSlider;
	void Start() {
		mouseSlider = this.transform.GetComponentInChildren<Slider>();
	}

	public void OnValueChange() {
		GameManager.Instance.InputController.MouseSensitive = mouseSlider.value;
	}
}
