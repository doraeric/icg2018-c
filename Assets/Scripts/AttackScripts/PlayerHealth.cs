using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Destructable {

	private HealthPanel _hp;
	private HealthPanel hp {
		get {
			if(_hp == null){
				_hp = GameObject.FindWithTag("HealthPanel").GetComponent<HealthPanel>();
			}
			return _hp;
		}
	}

	[SerializeField]static float sk1duration = 7f;
	[SerializeField]static float sk1coolTime = 10f;
	[SerializeField]static float sk2coolTime = 20f;
	[SerializeField]static float sk2Strength = 200f;
	private float nextIntangible;
	private float nextSk2;
	private bool _intangible = false;
	public bool Intangible {
		get {
			return _intangible;
		}
		set {
			bool v = value;
			if (v == true && Time.time > nextIntangible) {
				nextIntangible = Time.time + sk1coolTime;
				StartCoroutine(Skill1Effect());
			}
		}
	}

	private WaitForSeconds duration = new WaitForSeconds(sk1duration);
	private IEnumerator Skill1Effect(){
		hp.SetSk1Time(sk1duration, sk1coolTime);
		_intangible = true;
		yield return duration;
		_intangible = false;
	}

	public void Skill2(){
		if (Time.time > nextSk2) {
			nextSk2 = Time.time + sk2coolTime;
			hp.SetSk2Time(sk2coolTime);
			GameObject[] turretBullet = GameObject.FindGameObjectsWithTag("TurretBullet");
			foreach (GameObject bullet in turretBullet) {
				Rigidbody rb = bullet.GetComponent<Rigidbody>();
				Vector3 origin = GameManager.Instance.LocalPlayer.transform.position;
				Vector3 direction = bullet.transform.position - origin;
				rb.AddForce(direction * sk2Strength);
			}
		}
	}

	public override void TakeDamege(float amount) {
		base.TakeDamege(amount);
		hp.SetHP(HitPointRemaining);
	}

	void Start() {
		hp.SetHP(HitPointRemaining);
	}

	public override void Die() {
		// call ui
		Application.Quit();
	}
}
