using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletHealth : Destructable {
	public override void Die() {
		base.Die();

		Destroy(gameObject);
	}
}
