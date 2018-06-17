using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	[SerializeField]float rateOfFire;
	[SerializeField]Projectile projectile;
	[SerializeField]bool isPlayer;
	[SerializeField]bool projectileVerbose;

	// [HideInInspector]
	public Transform muzzle;

	float nextFireAllowed;
	protected bool canFire;
	private LineRenderer laserLine;

	void Awake() {
		if (!muzzle)
			muzzle = transform.Find("Muzzle");
		if (isPlayer) laserLine = GetComponent<LineRenderer>();
	}

	public virtual void Fire() {
		canFire = false;
		if (Time.time < nextFireAllowed)
			return;
		nextFireAllowed = Time.time + rateOfFire;

		Instantiate(projectile, muzzle.position, muzzle.rotation).verbose = projectileVerbose;
		canFire = true;
	}

	public virtual void weaponAim(bool aiming) {
		if (!isPlayer)
			return;
		if (!aiming) {
			laserLine.enabled = false;
			//transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, 1);
			transform.localRotation = Quaternion.identity;
			return;
		}
		laserLine.enabled = true;
		Vector3 direction = muzzle.transform.forward;
		direction *= 100;
		laserLine.SetPosition(0, muzzle.position);
		laserLine.SetPosition(1, muzzle.position + direction);

		transform.rotation = GameManager.Instance.tpsCamera.transform.rotation;
		//transform.rotation = Quaternion.Lerp(transform.rotation, camera.rotation, 1);
	}
}
