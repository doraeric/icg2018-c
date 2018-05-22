using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactButton : MonoBehaviour {
	public void OnBtnClick() {
		UIManager.Instance.TogglePanel("WeaponWheel", false);
		GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>().StartSkill2();
	}
}
