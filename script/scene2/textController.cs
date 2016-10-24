using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textController : MonoBehaviour {
	public string[] script = {"Once upon a time","There is a couple lives in woods.","They didn't have any child.",
		"However","One day, dad bring some rampions from somewhere faraway.","Then they have a daugther.","Since then they lived a happy life."};
	private float timer = 0.0f;
	public Text dialogueText;
	public GameObject buttonNext;
	// Use this for initialization
	void Start () {
		dialogueText.text = "";
		buttonNext.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 5.0f && timer <= 15.0f) {
			dialogueText.text = script [0];
		} else if (timer >= 15.0f && timer <= 25.0f) {
			dialogueText.text = script [1];
		} else if (timer >= 25.0f && timer <= 35.0f) {
			dialogueText.text = script [2];
		} else if (timer >= 35.0f && timer <= 45.0f) {
			dialogueText.text = script [3];
		} else if (timer >= 45.0f && timer <= 56.0f) {
			dialogueText.text = script [4];
		} else if (timer >= 56.0f && timer <= 65.0f) {
			dialogueText.text = script [5];
		} else if (timer >= 65.0f && timer <= 75.0f) {
			dialogueText.text = script [6];
		} else if (timer >= 75.0f ){
			dialogueText.text = "";
			buttonNext.SetActive (true);
		}
	
	}
}
