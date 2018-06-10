using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTexureSetup : MonoBehaviour {

	public Camera cameraCenter;
	public Camera cameraAround;
	public Material cameraMatCenter;
	public Material cameraMatAround;

	// Use this for initialization
	void Start () {
		if (cameraCenter.targetTexture != null) {
			cameraCenter.targetTexture.Release();
		}

		if (cameraAround.targetTexture != null) {
			cameraAround.targetTexture.Release();
		}
		cameraCenter.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraAround.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

		cameraMatAround.mainTexture = cameraAround.targetTexture;
		cameraMatCenter.mainTexture = cameraCenter.targetTexture;
	}
}
