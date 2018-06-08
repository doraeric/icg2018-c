using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Destructable {
	public UnityEvent onHit = new UnityEvent();

	public override void TakeDamege(float amount) {
		base.TakeDamege(amount);
		onHit.Invoke();
	}

	public float HP {
		get { return HitPointRemaining; }
	}

	public override void Die() {
		// call ui
		// Controll in HealthPanel
	}
}
