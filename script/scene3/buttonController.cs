using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonController : MonoBehaviour {
	public GameObject buttonyes;
	public GameObject buttonno;
	public GameObject buttonreturn;
	public GameObject buttonNext;
	// Use this for initialization
	void Start () {
		/*buttonyes.SetActive (false);
		buttonno.SetActive (false);*/
		hideButton ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showButtonForTalk() {
		buttonyes.SetActive (true);
		buttonno.SetActive (true);
		buttonreturn.SetActive (false);
		buttonNext.SetActive (false);
	}
	public void showButtonForReturn() {
		buttonyes.SetActive (false);
		buttonno.SetActive (false);
		buttonreturn.SetActive (true);
		buttonNext.SetActive (false);
	}

	public void hideButton(){
		buttonyes.SetActive (false);
		buttonno.SetActive (false);
		buttonreturn.SetActive (false);
		buttonNext.SetActive (false);
	}

	public void showButtonForNext(){
		buttonyes.SetActive (false);
		buttonno.SetActive (false);
		buttonreturn.SetActive (false);
		buttonNext.SetActive (true);
	}
}
