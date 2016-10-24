using UnityEngine;
using System.Collections;

public class Camera2Controller : MonoBehaviour {
	private float Timer;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (wait () >= 14 && wait () <= 37) {
			anim.SetBool ("isCam", true);
		} else {
			anim.SetBool ("isCam", false);
		}
	}

	float wait(){
		Timer += Time.deltaTime;
		return Timer;
	}
}
