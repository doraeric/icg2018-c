using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSkill : MonoBehaviour {
	[SerializeField]float sk1duration = 7f;
	[SerializeField]float sk1coolTime = 10f;
	[SerializeField]float sk2coolTime = 20f;
	[SerializeField]float sk2Strength = 200f;

	public UnityEvent onSkill1Ready = new UnityEvent();
	public UnityEvent onSkill1Start = new UnityEvent();
	public UnityEvent onSkill1Stop  = new UnityEvent();
	public UnityEvent onSkill2Ready = new UnityEvent();
	public UnityEvent onSkill2Start = new UnityEvent();
	public UnityEvent onSkill2Stop  = new UnityEvent();

	public void StartSkill1() {
		StartCoroutine(Skill1Effect());
	}

	public void StartSkill2() {
		StartCoroutine(Skill2Effect());
	}

	bool _skill1ing;
	bool _skill2ing;
	// intangible
	bool _skill1working;
	public bool skill1working {
		get { return _skill1working; }
	}

	void Start() {
		onSkill2Start.AddListener(delegate { _Sk2Effect(); });
		onSkill1Ready.Invoke();
		onSkill2Ready.Invoke();
	}

	IEnumerator Skill1Effect(){
		if (!_skill1ing) {
			_skill1ing = true;
			_skill1working = true;
			onSkill1Start.Invoke();
			Debug.Log("start skill 1");
			yield return new WaitForSeconds(sk1duration);
			_skill1working = false;
			onSkill1Stop.Invoke();
			Debug.Log("cooling skill1");
			yield return new WaitForSeconds(sk1coolTime);
			_skill1ing = false;
			onSkill1Ready.Invoke();
			Debug.Log("skill1 ready!");
		} else {
			Debug.Log("skill 1 not ready");
		}
	}

	IEnumerator Skill2Effect(){
		if (!_skill2ing) {
			_skill2ing = true;
			Debug.Log("start skill 2");
			onSkill2Start.Invoke();
			Debug.Log("cooling skill2");
			onSkill2Stop.Invoke();
			yield return new WaitForSeconds(sk2coolTime);
			onSkill2Ready.Invoke();
			_skill2ing = false;
			Debug.Log("skill2 ready!");
		} else {
			Debug.Log("skill 2 not ready");
		}
	}

	void _Sk2Effect() {
		GameObject[] turretBullet = GameObject.FindGameObjectsWithTag("TurretBullet");
		foreach (GameObject bullet in turretBullet) {
			Rigidbody rb = bullet.GetComponent<Rigidbody>();
			Vector3 origin = GameManager.Instance.LocalPlayer.transform.position;
			Vector3 direction = bullet.transform.position - origin;
			rb.AddForce(direction * sk2Strength);
		}
	}
}
