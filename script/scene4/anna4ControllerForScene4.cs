using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class anna4ControllerForScene4 : MonoBehaviour {
	public Text dialogueText;
	private bool isText = false;
	private int count = 1;
	private float timer = 0.0f;
	// Use this for initialization
	void Start () {
		dialogueText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
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
				dialogueText.text = "Girl: I am!";
				timer += Time.deltaTime;
				if (timer > 5) {
					dialogueText.text = "";
				}
			}
		}
	}

	public void setText(){
		//Debug.Log (isText);
		isText = true;
	}
}
