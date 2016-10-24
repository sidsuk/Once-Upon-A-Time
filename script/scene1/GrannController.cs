using UnityEngine;
using System.Collections;

public class GrannController : MonoBehaviour {
	public Animator anim;
	private float Timer;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (wait () >= 15) {
			anim.SetBool ("isSit", true);
		}
	}

	float wait(){
		Timer += Time.deltaTime;
		return Timer;
	}
		
}
