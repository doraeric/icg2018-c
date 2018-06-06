using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginScreen : MonoBehaviour {
	public void StartGame() {
		UIManager.Instance.CloseAllPanel();
		SceneManager.LoadScene("ShootingRange", LoadSceneMode.Single);
	}
	public void StopGame() {
		Application.Quit();
	}
}
