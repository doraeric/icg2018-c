using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {

	public Animator[] doors;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.O)){
			for(int i=0;i<doors.Length;i++){
				openTheDoor(doors[i]);
			}
		}else{
			for(int i=0;i<doors.Length;i++){
				closeTheDoor(doors[i]);
			}
		}
	}

	void openTheDoor(Animator door){
		door.SetBool("character_nearby", true);
	}
	void closeTheDoor(Animator door){
		door.SetBool("character_nearby", false);
	}
}
