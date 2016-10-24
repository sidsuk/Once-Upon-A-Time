using UnityEngine;
using System.Collections;

public class DoorControllerForScene3 : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onOpen() {
		anim.SetBool ("isOpen", true);
		Debug.Log ("open the door");
	}
}
