public class TurretBulletHealth : Destructable {
	public override void Die() {
		base.Die();

		Destroy(gameObject);
	}
}
