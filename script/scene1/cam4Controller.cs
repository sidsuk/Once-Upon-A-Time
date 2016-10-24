using UnityEngine;
using System.Collections;

public class cam4Controller : MonoBehaviour {
	public Animator anim;
	private float Timer;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (wait () >= 29) {
			anim.SetBool ("isCam4", true);
		}
	}

	float wait(){
		Timer += Time.deltaTime;
		return Timer;
	}
}
