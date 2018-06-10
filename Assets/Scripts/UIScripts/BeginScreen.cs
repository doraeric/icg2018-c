using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginScreen : MonoBehaviour {
	[SerializeField]Dropdown sceneChoice;

	public void StartGame() {
		UIManager.Instance.CloseAllPanel();
		string targetScene = sceneChoice ? sceneChoice.captionText.text : "";
		if (Application.CanStreamedLevelBeLoaded(targetScene)) {
			SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
		} else {
			Debug.LogErrorFormat("Scene '{0}' couldn't be loaded because it has not been added to the build settings or the AssetBundle has not been loaded.\nTo add a scene to the build settings use the menu File->Build Settings...\nLoading the default scene", targetScene);
			SceneManager.LoadScene("ShootingRange", LoadSceneMode.Single);
		}
	}
	public void StopGame() {
		Application.Quit();
		Debug.Log("BeginScreen: Application.Quit()");
	}
}
