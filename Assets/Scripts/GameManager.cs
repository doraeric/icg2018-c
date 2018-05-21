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
				_Instance._gameObject.AddComponent<InputController>();
			}
			return _Instance;
		}
	}

	private InputController _InputController;
	public InputController InputController {
		get {
			if (_InputController == null)
				_InputController = _gameObject.GetComponent<InputController>();
			return _InputController;
		}
	}

	private BasicBehaviour _LocalPlayer;
	public BasicBehaviour LocalPlayer {
		get {
			return _LocalPlayer;
		}
		set {
			_LocalPlayer = value;
			/*if (OnLocalPlayerJoined != null)
				OnLocalPlayerJoined(_LocalPlayer);
				*/
		}
	}

	private GameObject _tpsCamera;
	public GameObject tpsCamera {
		get {
			return _tpsCamera;
		}
		set {
			_tpsCamera = value;
		}
	}
}
