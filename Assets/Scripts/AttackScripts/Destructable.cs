using System.Collections;
using UnityEngine;

public class Destructable : MonoBehaviour {

	[SerializeField]int hitPoints = 5;
	[SerializeField]protected bool damageInfo;

	protected int damageTaken;

	public int HitPointRemaining {
		get {
			return hitPoints - damageTaken;
		}
	}

	public bool isAlive {
		get {
			return HitPointRemaining > 0;
		}
	}

	public virtual void Die() {
		gameObject.SetActive(false);
	}

	public virtual void TakeDamege(int amount) {
		damageTaken += amount;
		if (damageInfo)
			Debug.Log (name + " hp: " + HitPointRemaining);

		if (!isAlive) {
			Die();
		}
	}

	public void Reset() {
		damageTaken = 0;
	}
}
