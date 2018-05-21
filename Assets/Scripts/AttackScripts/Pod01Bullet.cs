using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod01Bullet : Projectile {
	protected override void OnTriggerEnter(Collider other) {
		base.OnTriggerEnter(other);

		// Whatever it hits, destroy itself.
		Destroy(gameObject);
	}
}
