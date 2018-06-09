using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Destructable {
	public UnityEvent onHit = new UnityEvent();
	public UnityEvent onHeal = new UnityEvent();

	Coroutine healingCoroutine;

	public override void TakeDamege(int amount) {
		base.TakeDamege(amount);
		onHit.Invoke();
		if (healingCoroutine == null) {
			healingCoroutine = StartCoroutine(Healing1());
		} else {
			StopCoroutine(healingCoroutine);
			healingCoroutine = StartCoroutine(Healing1());
		}
	}

	public int HP {
		get { return HitPointRemaining; }
	}

	public override void Die() {
		// call ui
		// Controll in HealthPanel
	}

	IEnumerator Healing1() {
		yield return new WaitForSeconds(10f);
		healingCoroutine = StartCoroutine(Healing2());
	}
	IEnumerator Healing2() {
		if (damageInfo)
			Debug.Log (name + " hp: " + HitPointRemaining);
		damageTaken--;
		onHeal.Invoke();
		if (damageTaken > 0) {
			yield return new WaitForSeconds(1f);
			healingCoroutine = StartCoroutine(Healing2());
		} else {
			healingCoroutine = null;
		}
	}
}
