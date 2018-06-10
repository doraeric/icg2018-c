using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public Animator unitychanaudio;
	private bool isIdle = true;
	public GameObject Jumpmusic;
	public GameObject Runmusic;
	public AudioSource runaudio;

	public AudioSource backgroundmusic;


	void Start () {
		Instantiate(backgroundmusic, Vector2.zero, Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {
		if (!isIdle && unitychanaudio.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
			isIdle = true;
		}else{
			if (isIdle && unitychanaudio.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
				Instantiate(Jumpmusic, Vector2.zero, Quaternion.identity);
				isIdle = false;
			}
			if (unitychanaudio.GetCurrentAnimatorStateInfo(0).IsName("Locomotion")) {
				Instantiate(Runmusic, Vector2.zero, Quaternion.identity);
				runaudio.volume = Random.Range(0, 0.2f);
				isIdle = false;
			}
		}
	}

}

