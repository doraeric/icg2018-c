using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Destructable))]
public class TurretShoot : MonoBehaviour {

	[SerializeField]float detectDist = 10;

	Shooter weapon;
	void Awake() {
		weapon = GetComponent<Shooter>();
	}
	void Update () {
		var player = GameManager.Instance.LocalPlayer;
		Transform target = player.transform.Find("Center").transform;
		if (target == null)
			target = player.transform;

		Transform from = this.transform.Find("Center");
		if (from == null) {
			from = this.transform;
		}
		float dist = Vector3.Distance(target.position, from.position);
		if (dist < detectDist) {
			Vector3 relativePos = target.position - from.position;
			Quaternion toRotation = Quaternion.LookRotation(relativePos);
			// transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.time * 0.1f);
			transform.rotation = toRotation;
			weapon.Fire();
		}
	}
}
