using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour {
	Skill sk1, sk2; 
	Text hp;
	//float sk1Time, sk2Time;

	void getUI () {
		hp = this.gameObject.transform.Find("HP/Text").GetComponent<Text>();

		sk1.go = this.gameObject.transform.Find("Skill1").gameObject;
		sk1.text = this.gameObject.transform.Find("Skill1/Text").GetComponent<Text>();
		sk1.img = sk1.go.GetComponent<Image>();

		sk2.go = this.gameObject.transform.Find("Skill2").gameObject;
		sk2.text = this.gameObject.transform.Find("Skill2/Text").GetComponent<Text>();
		sk2.img = sk2.go.GetComponent<Image>();
	}

	struct Skill {
		public GameObject go;
		public Image img;
		public Text text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SetHP(float value) {
		if (hp == null)
			getUI();
		hp.text = "HP " + value;
	}

	public void SetSk1Time(float duration, float coolTime) {
		Debug.Log("SetSk1Time");
		Debug.Log(sk1.go.name);
		StartCoroutine(showWhite(sk1, new WaitForSeconds(duration), new WaitForSeconds(coolTime - duration)));
	}

	public void SetSk2Time(float coolTime) {
		StartCoroutine(showRed(sk2, new WaitForSeconds(coolTime)));
	}

	private IEnumerator showWhite(Skill sk, WaitForSeconds t1, WaitForSeconds t2) {
		Debug.Log("showWhite");
		sk.go.SetActive(true);
		sk.img.color = new Color32(225, 225, 225, 160);

		yield return t1;
		StartCoroutine(showRed(sk, t2));
	}

	private IEnumerator showRed(Skill sk, WaitForSeconds t) {
		sk.go.SetActive(true);
		sk.img.color = new Color32(225, 0, 0, 160);

		yield return t;
		sk.go.SetActive(false);
	}
}
