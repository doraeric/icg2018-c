using UnityEngine;

[RequireComponent(typeof(BasicBehaviour))]
[RequireComponent(typeof(MoveBehaviour))]
[RequireComponent(typeof(Rigidbody))]
public class PositionUpdater : MonoBehaviour {
	BasicBehaviour bb;
	MoveBehaviour mb;
	Rigidbody rb;
	void Awake() {
		bb = GetComponent<BasicBehaviour>();
		mb = GetComponent<MoveBehaviour>();
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		if (bb.IsMoving() && bb.IsGrounded()) {
			rb.MovePosition(transform.position + bb.GetLastDirection() * mb.walkSpeed * Time.deltaTime * 30);
		}
		else if (bb.IsSprinting() && bb.IsGrounded()) {
			rb.MovePosition(transform.position + bb.GetLastDirection() * mb.sprintSpeed * Time.deltaTime * 30);
		}
	}
}
