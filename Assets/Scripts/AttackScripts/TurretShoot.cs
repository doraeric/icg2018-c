using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Destructable))]
public class TurretShoot : MonoBehaviour {

	[SerializeField]float detectDist = 10;
	[SerializeField]Transform columnAxis;
	[SerializeField]Transform rotationalHead;
	Transform target;
	Transform orig;

	Shooter weapon;
	void Awake() {
		weapon = GetComponent<Shooter>();
	}
	void Update () {
		if (!target) {
			target = GameManager.Instance.LocalPlayer.transform;
			if (target.Find("Center")) {
				target = target.Find("Center").transform;
			}
		}

		if (!orig) {
			orig = transform.Find("Center");
			if (orig == null) {
				orig = transform;
			}
		}

		float dist = Vector3.Distance(target.position, orig.position);
		if (dist < detectDist) {
			if (columnAxis) {
				Vector3 relativePos = target.position - orig.position;
				columnAxis.rotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0, relativePos.z));
			} else {
				Vector3 relativePos = target.position - orig.position;
				transform.rotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0, relativePos.z));
			}
			if (rotationalHead) {
				rotationalHead.LookAt(target);
			} else {
				transform.LookAt(target);
			}
			weapon.Fire();
		}
	}
}
