using UnityEngine;
using System.Collections;

public class peasantgirlController : MonoBehaviour {
	public Animator anim;
	public GameObject dadRef;
	public GameObject girlRef;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.T)) {
			anim.SetBool ("start", true);
			dadRef.GetComponent<Animator> ().SetBool ("start", true);
		}
		/*if (Input.GetKey (KeyCode.J)) {
			anim.SetBool ("isJump", true);
			//dadRef.GetComponent<Animator> ().SetBool ("isJump", true);
		}
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("isWave", true);
			//dadRef.GetComponent<Animator> ().SetBool ("isWave", true);
		}
		if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("isSpin", true);
			//dadRef.GetComponent<Animator> ().SetBool ("isSpin", true);
		}*/
		if (Input.GetKey (KeyCode.I)) {
			anim.SetBool ("isIdle", true);
			dadRef.GetComponent<Animator> ().SetBool ("isIdle", true);
		}
		if (Input.GetKey (KeyCode.J)) {
			anim.SetBool ("isIdle", false);
			dadRef.GetComponent<Animator> ().SetBool ("isIdle", false);
		}
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("isNew", true);
			dadRef.GetComponent<Animator> ().SetBool ("isNew", true);
			//girlRef.GetComponent<Animator> ().SetBool ("isNew", true);
		}

	}
	//float wait(){
		
}
