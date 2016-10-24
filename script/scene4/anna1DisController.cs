using UnityEngine;
using System.Collections;

public class anna1DisController : MonoBehaviour {
	public GameObject anna;
	public GameObject effect;
	private Vector3 pos;
	private bool isDis = false;
	private float timer = 0.0f;
	// Use this for initialization
	void Start () {
		anna.SetActive (true);
		effect.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isDis) {
			float t = wait ();
			pos = anna.transform.position;
			effect.transform.position = pos;
			effect.SetActive (true);
			if (t >= 5 && t <= 10) {
				anna.SetActive (false);
			} else if (t >= 10) {
				effect.SetActive (false);
			}
				
				
		}
	}

	public void setDis(){
		isDis = true;
	}

	float wait(){
		timer += Time.deltaTime;
		return timer;
	}
	
}
