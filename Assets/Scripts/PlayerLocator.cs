public class PlayerLocator : BasicBehaviour {
	public void Awake() {
		GameManager.Instance.LocalPlayer = this;
	}
}
