using UnityEngine;

public class FallingHurt : NatureHurt {
	[SerializeField]float heightTooLow;

	override protected bool hurtCondition() {
		return gameObject.transform.position.y < heightTooLow;
	}
}
