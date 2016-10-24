using UnityEngine;
using System.Collections;

public class GraController : MonoBehaviour {
	public Animator anim;
	//private bool iswalk=false;
	public float speed = 0.6f;
	public Vector3 targetPosition;
	private float Timer;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (wait () >= 4.4 && wait () <= 25) {
			anim.SetBool ("walk", true);
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
		} else {
			anim.SetBool ("walk", false);
		}
	}

	float wait(){
		Timer += Time.deltaTime;
		return Timer;
	}
}
