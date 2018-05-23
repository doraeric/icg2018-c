using UnityEngine;
using UnityEngine.UI;

public class WheelPanel : BasePanel {
	[SerializeField]Button shadowButton;
	[SerializeField]Button impactButton;

	void Start () {
		shadowButton.onClick.AddListener( delegate { ClickShadowButton(); } );
		impactButton.onClick.AddListener( delegate { ClickImpactButton(); } );
	}
	public void ClickShadowButton() {
		UIManager.Instance.TogglePanel("WeaponWheel", false);
		GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>().StartSkill1();
	}
	public void ClickImpactButton() {
		UIManager.Instance.TogglePanel("WeaponWheel", false);
		GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>().StartSkill2();
	}
}
