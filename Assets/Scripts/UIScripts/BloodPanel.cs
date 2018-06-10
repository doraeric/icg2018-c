using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodPanel : BasePanel {
	GameObject blood1, blood2, dead;
	bool playerDead;

	// Use this for initialization
	void Start () {
		getUI();

		// Blood splatter effect
		PlayerHealth playerHealth = GameManager.Instance.LocalPlayer.GetComponent<PlayerHealth>();
		playerHealth.onHit.AddListener( delegate {
			UpdateSplatter(playerHealth);
		});
		playerHealth.onHeal.AddListener( delegate {
			UpdateSplatter(playerHealth);
		});
	}

	// Update is called once per frame
	void Update () {
		if (playerDead && Input.anyKeyDown) {
			UIManager.Instance.CloseAllPanel();
			// Sometimes unity editor cannot load the scene whose build
			// index is less than the current one. Maybe it's a bug?
			SceneManager.LoadScene("BeginScene", LoadSceneMode.Single);
		}
	}

	void getUI () {
		blood1   = gameObject.transform.Find("Blood1").gameObject;
		blood2   = gameObject.transform.Find("Blood2").gameObject;
		dead     = gameObject.transform.Find("Dead").gameObject;
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

}
