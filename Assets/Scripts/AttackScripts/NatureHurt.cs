using System.Collections;
using UnityEngine;

public abstract class NatureHurt : MonoBehaviour {
	[SerializeField]protected float hurtSec = 1f;
	[SerializeField]protected int hurtDamage = 1;
	protected abstract bool hurtCondition();

	PlayerHealth playerHealth;
	Coroutine hurtCoroutine;

	public void Awake() {
		playerHealth = GameManager.Instance.LocalPlayer.GetComponent<PlayerHealth>();
	}

	public void Update() {
		if (hurtCondition() && hurtCoroutine == null) {
			hurtCoroutine = StartCoroutine(TakeDamege());
		} else if (!hurtCondition()) {
			StopCoroutine(hurtCoroutine);
			hurtCoroutine = null;
		}
	}

	IEnumerator TakeDamege() {
		playerHealth.TakeDamege(hurtDamage);
		yield return new WaitForSeconds(hurtSec);
		hurtCoroutine = null;
	}
}
