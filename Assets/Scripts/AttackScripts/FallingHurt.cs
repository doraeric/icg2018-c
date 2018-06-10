using UnityEngine;

public class FallingHurt : NatureHurt {
	[SerializeField]float heightTooLow;

	bool hurtCondition() {
		return gameObject.transform.position.y < heightTooLow;
	}
}
