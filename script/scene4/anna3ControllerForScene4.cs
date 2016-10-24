using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class anna3ControllerForScene4 : MonoBehaviour {
	public Vector3[] pos;
	private Vector3 originalPos;
	private Vector3 posChange;
	private bool isText = false;
	public Text dialogueText;
	private int count = 1;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		dialogueText.text = "";
		originalPos = transform.position;
		posChange = pos [0] + originalPos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = posChange;
		if (isText) {
			if (count == 1) {
				dialogueText.text = "Girl: What are you looking for?";
				timer += Time.deltaTime;
				if (timer > 5) {
					count++;
					timer = 0;
				}
			} else if (count == 2) {
				dialogueText.text = "You: I am looking for Rapunzel.";
				timer += Time.deltaTime;
				if (timer > 5) {
					count++;
					timer = 0;
				}
			} else if (count == 3) {
				dialogueText.text = "Girl: I am not real Rapunzel.";
				timer += Time.deltaTime;
				if (timer > 5) {
					count++;
					timer = 0;
				}
			} else if (count == 4) {
				dialogueText.text = "Girl: You can check other rooms.";
				timer += Time.deltaTime;
				if (timer >= 5) {
					//count++;
					dialogueText.text = "";
				}
			}
		}
	}

	public void setPos(int situation){
		posChange = pos [situation] + originalPos;
	}

	public void setText(){
		Debug.Log ("enter set text");
		isText = true;
	}
}
