using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
	[SerializeField]float speed;
	[SerializeField]float timeToLive;
	[SerializeField]float damage;

	void Start() {
		Destroy(gameObject, timeToLive);
	}

	void Update() {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		// should never happen, all goes to trigger
		Debug.Log("OnCollisionEnter");
		Destroy(gameObject);
	}

	protected virtual void OnTriggerEnter(Collider other) {

		// hit walls
		if (!other.isTrigger && other.tag != "Player") {
			Debug.Log("hit walls");
			Destroy(gameObject);
			return;
		}

		var destructable = other.transform.GetComponent<Destructable>();
		if (destructable == null)
			destructable = other.transform.GetComponentInParent<Destructable>();
		if (destructable == null) {
			Debug.Log(other.name + " is not destructable");
			return;
		}

		if (other.tag == "Player") {
			
			BasicBehaviour player = GameManager.Instance.LocalPlayer;
			PlayerHealth ph = player.GetComponent<PlayerHealth>();
			if (ph.Intangible) {
				Debug.Log ("hide " + ph.Intangible);
				return;
			}
		}

		destructable.TakeDamege(damage);
		Destroy(gameObject);
	}
}
