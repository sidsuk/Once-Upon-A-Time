using UnityEngine;
using System.Collections;

public class annaBoom : MonoBehaviour {
	public GameObject anna;
	public GameObject boom;
	public GameObject status;
	private Vector3 pos;
	private float timer;
	private bool isBoom = false;
	public Vector3 posChange;
	// Use this for initialization
	void Start () {
		//pos = anna.transform.position;
		anna.SetActive (true);
		boom.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//posChange (0.0f, 1.0f, 0.0f);
		if (isBoom) {
			pos = anna.transform.position;
			boom.transform.position = pos+posChange;
			boom.SetActive (true);
			timer += Time.deltaTime;
			if (timer >= 3) {
				status.GetComponent<statusController> ().setEnd ();
			}
		}
	}

	public void setBoom(){
		isBoom = true;
	}
}
