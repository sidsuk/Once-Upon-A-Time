using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class firsrPersonControllerForScene4 : MonoBehaviour {
	public GameObject cubeTrigger;
	public Text noneText;
	private bool isIn = false;
	// Use this for initialization
	void Start () {
		noneText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (isIn) {
			noneText.text = "There is no one in this room!";
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject == cubeTrigger) {
			isIn = true;
		}
	}

	void onTriggerExit(Collider col){
		if (col.gameObject == cubeTrigger) {
			isIn = false;
		}
	}
}
