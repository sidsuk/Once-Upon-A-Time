using UnityEngine;
using System.Collections;

public class parentController1 : MonoBehaviour {
	public GameObject dad;
	public GameObject mom;
	public GameObject granny;
	//private GameObject GrannyRef;
	//private grannyController GrannyControllerRef;

	// Use this for initialization
	void Start () {
		//GrannyRef = GameObject.Find ("granny");
		//GrannyControllerRef = GrannyRef.GetComponent<grannyController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (granny.GetComponent<grannyController>().isHide) {
			dad.SetActive (false);
			mom.SetActive (false);
		}
	}
}
