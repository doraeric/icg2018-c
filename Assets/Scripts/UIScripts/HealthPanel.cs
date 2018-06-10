using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPanel : BasePanel {
	[SerializeField]bool showHP;

	public override bool NeedCursor {
		get { return false; }
	}

	PlayerSkill playerSkill;
	SkillUI sk1, sk2;
	Text hp;
	GameObject blood1, blood2, dead;
	bool playerDead;

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

		// Blood splatter effect
		playerHealth.onHit.AddListener( delegate {
			UpdateSplatter(playerHealth);
		});
		playerHealth.onHeal.AddListener( delegate {
			UpdateSplatter(playerHealth);
		});

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
		blood1   = gameObject.transform.Find("Blood1").gameObject;
		blood2   = gameObject.transform.Find("Blood2").gameObject;
		dead     = gameObject.transform.Find("Dead").gameObject;
		if (!showHP) {
			gameObject.transform.Find("HP").gameObject.SetActive(false);
		}
	}

	void UpdateSplatter(PlayerHealth playerHealth) {
		if (playerHealth.HP > 5) {
			blood1.SetActive(false);
			blood2.SetActive(false);
			dead.SetActive(false);
		} else if (playerHealth.HP <= 5 && playerHealth.HP > 3) {
			blood1.SetActive(true);
			blood2.SetActive(false);
			dead.SetActive(false);
		} else if (playerHealth.HP <= 3 && playerHealth.HP > 0) {
			blood1.SetActive(true);
			blood2.SetActive(true);
			dead.SetActive(false);
		} else {
			dead.SetActive(true);
			playerDead = true;
		}
	}

	struct SkillUI {
		public GameObject go;
		public Image img;
		public Text text;
	}

	void Update() {
		if (playerDead && Input.anyKeyDown) {
			UIManager.Instance.CloseAllPanel();
			// Sometimes unity editor cannot load the scene whose build
			// index is less than the current one. Maybe it's a bug?
			SceneManager.LoadScene("BeginScene", LoadSceneMode.Single);
		}

		// Put here because when controlled by joystick, player skill panel is never active
		if (CharacterInput.GetAxisNeg("SkillX")) {
			GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>().StartSkill1();
		}
		if (CharacterInput.GetAxisPos("SkillX")) {
			GameManager.Instance.LocalPlayer.GetComponent<PlayerSkill>().StartSkill2();
		}
	}
}
