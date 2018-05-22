using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour {
	PlayerSkill playerSkill;
	SkillUI sk1, sk2;
	Text hp;

	void showWhite(SkillUI sk) {
		Debug.Log("showWhite");
		sk.go.SetActive(true);
		sk.img.color = new Color32(225, 225, 225, 160);
	}

	void showRed(SkillUI sk) {
		sk.go.SetActive(true);
		sk.img.color = new Color32(225, 0, 0, 160);
	}
	void hideUI(SkillUI sk) {
		sk.go.SetActive(false);
	}

	void Start() {
		getUI();
		PlayerHealth playerHealth = GameManager.Instance.LocalPlayer.GetComponent<PlayerHealth>();
		hp.text = "HP " + playerHealth.HP;
		playerHealth.onHit.AddListener( delegate {
			hp.text = "HP " + playerHealth.HP;
		});
		playerSkill = GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>();
		playerSkill.onSkill1Ready.AddListener( delegate {
			hideUI(sk1);
		});
		playerSkill.onSkill1Start.AddListener( delegate {
			showWhite(sk1);
		});
		playerSkill.onSkill1Stop.AddListener( delegate {
			showRed(sk1);
		});
		playerSkill.onSkill2Start.AddListener( delegate {
			showRed(sk2);
		});
		playerSkill.onSkill2Ready.AddListener( delegate {
			hideUI(sk2);
		});
	}

	void getUI () {
		hp       = gameObject.transform.Find("HP/Text").GetComponent<Text>();
		sk1.go   = gameObject.transform.Find("Skill1").gameObject;
		sk1.text = gameObject.transform.Find("Skill1/Text").GetComponent<Text>();
		sk1.img  = sk1.go.GetComponent<Image>();
		sk2.go   = gameObject.transform.Find("Skill2").gameObject;
		sk2.text = gameObject.transform.Find("Skill2/Text").GetComponent<Text>();
		sk2.img  = sk2.go.GetComponent<Image>();
	}
	struct SkillUI {
		public GameObject go;
		public Image img;
		public Text text;
	}

}
