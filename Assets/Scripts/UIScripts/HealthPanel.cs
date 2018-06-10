using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : BasePanel {
	[SerializeField]bool showHP;

	PlayerSkill playerSkill;
	SkillUI sk1, sk2;
	Text hp;

	void showWhite(SkillUI sk) {
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

		// HP info
		if (showHP) {
			hp.text = "HP " + playerHealth.HP;
			playerHealth.onHit.AddListener( delegate {
				hp.text = "HP " + playerHealth.HP;
			});
		}

		// Player skill effect
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
		if (!showHP) {
			gameObject.transform.Find("HP").gameObject.SetActive(false);
		}
	}

	struct SkillUI {
		public GameObject go;
		public Image img;
		public Text text;
	}

	void Update() {
		// Put here because when controlled by joystick, player skill panel is never active
		if (CharacterInput.GetAxisNeg("SkillX")) {
			GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>().StartSkill1();
		}
		if (CharacterInput.GetAxisPos("SkillX")) {
			GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>().StartSkill2();
		}
	}
}
