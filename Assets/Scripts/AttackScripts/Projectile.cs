using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
	[SerializeField]float speed;
	[SerializeField]float timeToLive;
	[SerializeField]int damage;
	public bool verbose;

	void Start() {
		Destroy(gameObject, timeToLive);
	}

	void Update() {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		// should never happen, all goes to trigger
		if (verbose)
			Debug.Log("OnCollisionEnter");
		Destroy(gameObject);
	}

	protected virtual void OnTriggerEnter(Collider other) {

		// hit walls
		if (!other.isTrigger && other.tag != "Player") {
			if (verbose)
				Debug.Log("hit walls");
			Destroy(gameObject);
			return;
		}

		var destructable = other.transform.GetComponent<Destructable>();
		if (destructable == null)
			destructable = other.transform.GetComponentInParent<Destructable>();
		if (destructable == null) {
			if (verbose)
				Debug.Log(other.name + " is not destructable");
			return;
		}

		if (other.tag == "Player") {

			BasicBehaviour player = GameManager.Instance.LocalPlayer;
			PlayerSkill pk = player.GetComponent<PlayerSkill>();
			if (pk.skill1working) {
				if (verbose)
					Debug.Log ("Player are intangible now!");
				return;
			}
		}

		destructable.TakeDamege(damage);
		Destroy(gameObject);
	}
}
