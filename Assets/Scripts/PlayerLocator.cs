public class PlayerLocator : BasicBehaviour {
	public void Start() {
		GameManager.Instance.LocalPlayer = this;
	}
}
