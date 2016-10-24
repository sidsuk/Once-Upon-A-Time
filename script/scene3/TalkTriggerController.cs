using UnityEngine;
using System.Collections;

public class TalkTriggerController : MonoBehaviour {
	public GameObject granny;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject==granny){
			granny.GetComponent<grannyController> ().setTalking ();
			Debug.Log("collider set talking");
		}
	}
}
