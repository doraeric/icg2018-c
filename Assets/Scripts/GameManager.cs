using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

	private GameObject _gameObject;
	private static GameManager _Instance;

	public static GameManager Instance {
		get {
			if (_Instance == null) {
				_Instance = new GameManager();
				_Instance._gameObject = new GameObject("GameManager");
				_Instance._gameObject.AddComponent<GameController>();
			}
			return _Instance;
		}
	}


	private BasicBehaviour _LocalPlayer;
	public BasicBehaviour LocalPlayer {
		get { return _LocalPlayer; }
		set { _LocalPlayer = value; }
	}

	private ThirdPersonOrbitCamBasic _tpsCamera;
	public ThirdPersonOrbitCamBasic tpsCamera {
		get { return _tpsCamera; }
		set { _tpsCamera = value; }
	}
}
