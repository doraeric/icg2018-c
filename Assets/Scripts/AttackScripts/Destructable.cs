using System.Collections;
using UnityEngine;

public class Destructable : MonoBehaviour {

	[SerializeField]float hitPoints = 5;

	float damageTaken;

	public float HitPointRemaining {
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

	public virtual void TakeDamege(float amount) {
		damageTaken += amount;
		Debug.Log (name + " hp: " + HitPointRemaining);

		if (!isAlive) {
			Die();
		}
	}

	public void Reset() {
		damageTaken = 0;
	}
}
