using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class annaControllerForScene4 : MonoBehaviour {
	public Text dialogueText;
	public Text missionText;
	public Text operationText;
	public Renderer rend;
	public float fadeSpeed = 0.02f;

	private float alpha = 1.0f;
	private Color originalColor;
	private Color newColor;
	private int count = 1;
	private bool isText = false;
	private bool isFade = false;
	private float timer=0;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		originalColor = rend.material.color;
		dialogueText.text = "";
		missionText.text = "Mission: Find the real Rapunzel.";
		operationText.text = "Use your mouse to control the direction, and keyboard arrows to move.";
	}
	
	// Update is called once per frame
	void Update () {

		//show the dialogue
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
				dialogueText.text = "Girl: But I think she is on the upper floor.";
				timer += Time.deltaTime;
				if (timer >= 5) {
					Debug.Log ("enter 1111");
					dialogueText.text = "";
				}
			}
		}


		//fade out
		if (isFade) {
			alpha = alpha - fadeSpeed * Time.deltaTime;
			Debug.Log (alpha);
			alpha = alpha <= 0 ? 0 : alpha;
			newColor = new Color (originalColor.r, originalColor.g, originalColor.b, alpha);
			rend.material.SetColor ("_Color", newColor);
		}
	}
		

	public void setText(){
		//Debug.Log (isText);
		isText = true;
	}

	/*public void fadeOut(){
		Debug.Log (isFade);
		isFade = true;
	}*/
		
}
