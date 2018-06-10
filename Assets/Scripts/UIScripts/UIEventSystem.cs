using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventSystem : MonoBehaviour {
    void Awake() {
        UIManager.Instance.EventSystemRoot = gameObject.GetComponent<EventSystem>();
    }
}
