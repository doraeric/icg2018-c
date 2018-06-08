using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
	public GameObject CanvasRoot;
	public bool autoCursorVisibility;

	private string UI_GAMEPANEL_ROOT = "Prefabs/GamePanel/";
	private static UIManager _instance;

	public static UIManager Instance {
		get {
			if (_instance == null) {
				_instance = new UIManager();
			}
			return _instance;
		}
	}

	public Dictionary<string, BasePanel> m_PanelList = new Dictionary<string, BasePanel>();

	public bool IsClear() {
		foreach (KeyValuePair<string, BasePanel> item in m_PanelList) {
			if (item.Value.NeedCursor && item.Value.gameObject.activeSelf) {
				return false;
			}
		}
		return true;
	}

	private bool CheckCanvasRootIsNull() {
		if (CanvasRoot == null) {
			Debug.LogError("CanvasRoot is Null, Please in your Canvas add UIRootHandler.cs");
			return true;
		}
		else {
			return false;
		}
	}

	public bool IsPanelCreated(string name) {
		return m_PanelList.ContainsKey(name);
	}

	public bool IsPaneVisible(string name) {
		return m_PanelList[name].gameObject.activeSelf;
	}

	public BasePanel CreatePanel(string name) {
		if (CheckCanvasRootIsNull())
			return null;

		if (IsPanelCreated(name)) {
			Debug.LogErrorFormat("[{0}] is Created, if you want to show, please close first!!", name);
			return null;
		}

		BasePanel loadGo = Resources.Load<BasePanel>(UI_GAMEPANEL_ROOT + name);
		if (loadGo == null)
			return null;

		BasePanel panel = InstantiateBasePanel(CanvasRoot, loadGo);
		panel.name = name;

		m_PanelList.Add(name, panel);
		if (autoCursorVisibility && panel.NeedCursor) {
			showCursor(true);
		}

		return panel;
	}

	public void TogglePanel(string name) {
		if (IsPaneVisible(name)) {
			TogglePanel(name, false);
		} else {
			TogglePanel(name, true);
		}
	}

	public void TogglePanel(string name, bool isOn) {
		if (IsPanelCreated(name)) {
			if (m_PanelList[name] != null) {
				m_PanelList[name].gameObject.SetActive(isOn);
				if (autoCursorVisibility) {
					if (IsClear()) {
						showCursor(false);
					} else {
						showCursor(true);
					}
				}
			}
		} else {
			BasePanel ret = CreatePanel(name);
			m_PanelList[name].gameObject.SetActive(isOn);
			if (!ret)
				Debug.LogErrorFormat("TogglePanel [{0}] not found.", name);
		}
	}

	public void ClosePanel(string name) {
		if (IsPanelCreated(name)) {
			if (m_PanelList[name] != null)
				Object.Destroy(m_PanelList[name]);

			m_PanelList.Remove(name);
			if (autoCursorVisibility) {
				if (IsClear()) {
					showCursor(false);
				} else {
					showCursor(true);
				}
			}
		} else {
			Debug.LogErrorFormat("ClosePanel [{0}] not found.", name);
		}
	}

	public void CloseAllPanel() {
		foreach (KeyValuePair<string, BasePanel> item in m_PanelList) {
			if (item.Value != null)
				Object.Destroy(item.Value);
		}

		m_PanelList.Clear();
		if (autoCursorVisibility)
			showCursor(true);
	}

	public Vector2 GetCanvasSize() {
		if (CheckCanvasRootIsNull())
			return Vector2.one * -1;

		RectTransform trans = CanvasRoot.transform as RectTransform;

		return trans.sizeDelta;
	}

	BasePanel InstantiateBasePanel(GameObject parent, BasePanel prefab) {
		return InstantiateGameObject(parent, prefab.gameObject).GetComponent<BasePanel>();
	}

	GameObject InstantiateGameObject(GameObject parent, GameObject prefab) {

		GameObject go = GameObject.Instantiate(prefab) as GameObject;

		if (go != null && parent != null) {
			Transform t = go.transform;
			t.SetParent(parent.transform);
			t.localPosition = Vector3.zero;
			t.localRotation = Quaternion.identity;
			t.localScale = Vector3.one;

			RectTransform rect = go.transform as RectTransform;
			if (rect != null) {
				rect.anchoredPosition = Vector3.zero;
				rect.localRotation = Quaternion.identity;
				rect.localScale = Vector3.one;

				//判斷anchor是否在同一點
				if (rect.anchorMin.x != rect.anchorMax.x && rect.anchorMin.y != rect.anchorMax.y) {
					rect.offsetMin = Vector2.zero;
					rect.offsetMax = Vector2.zero;
				}
			}

			go.layer = parent.layer;
		}
		return go;
	}

	void showCursor(bool show) {
		if (show) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			CharacterInput.lock_input = true;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			CharacterInput.lock_input = false;
		}
	}
}
