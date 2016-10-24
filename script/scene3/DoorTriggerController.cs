using UnityEngine;
using System.Collections;

public class DoorTriggerController : MonoBehaviour {
	public GameObject granny;
	public GameObject door;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject == granny) {
			door.BroadcastMessage("onOpen");
			//Debug.Log ("collision detected");
		}
	}
}
