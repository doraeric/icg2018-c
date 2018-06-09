using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod01 : Shooter {
    public GameObject Bulletmusic;
	public override void Fire() {
		base.Fire();

        Instantiate(Bulletmusic, Vector2.zero, Quaternion.identity);

		if (canFire) {
		}
	}
}
