using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class statusController : MonoBehaviour {
	enum sceneStatus { intro , guide , story , find , end };

	public GameObject rigidbodyController;
	public Camera[] cam;

	public GameObject buttonReturn1;
	public GameObject buttonReturn2;
	public GameObject buttonGuide;
	public GameObject buttonPlay;
	public GameObject buttonStory;
	public GameObject buttonNext1;
	public GameObject buttonNext2;
	public GameObject scrollGuidance;
	public GameObject scrollStory1;
	public GameObject scrollStory2;
	public GameObject missionText;
	public GameObject dialogueText;
	public GameObject operationText;
	public GameObject noneText;
	public musicController music;
	public Text nameText;

	private sceneStatus currentStatus = sceneStatus.intro;
	private bool isStoryEnd = false;
	//private float timer = 0.0f;


	// Use this for initialization
	void Start () {
		music.isFade = false;
		rigidbodyController.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentStatus) {
		case sceneStatus.intro:
			cam [0].enabled = true;
			cam [1].enabled = false;
			buttonGuide.SetActive (true);
			buttonPlay.SetActive (true);
			buttonReturn1.SetActive (false);
			buttonReturn2.SetActive (false);
			buttonStory.SetActive (true);
			buttonNext1.SetActive (false);
			buttonNext2.SetActive (false);
			scrollGuidance.SetActive (false);
			scrollStory1.SetActive (false);
			scrollStory2.SetActive (false);
			missionText.SetActive (false);
			operationText.SetActive (false);
			noneText.SetActive (false);
			dialogueText.SetActive (false);
			nameText.text = "Welcome to Tower";
			break;
		case sceneStatus.story:
			cam [0].enabled = true;
			cam [1].enabled = false;
			buttonGuide.SetActive (false);
			buttonPlay.SetActive (false);
			buttonReturn1.SetActive (false);
			buttonReturn2.SetActive (true);
			buttonStory.SetActive (false);
			buttonNext1.SetActive (false);
			buttonNext2.SetActive (false);
			scrollGuidance.SetActive (false);
			scrollStory1.SetActive (true);
			scrollStory2.SetActive (false);
			nameText.text = "";
			missionText.SetActive (false);
			operationText.SetActive (false);
			noneText.SetActive (false);
			dialogueText.SetActive (false);
			break;
		case sceneStatus.guide:
			cam [0].enabled = true;
			cam [1].enabled = false;
			buttonGuide.SetActive (false);
			buttonPlay.SetActive (false);
			buttonReturn1.SetActive (true);
			buttonReturn2.SetActive (false);
			buttonStory.SetActive (false);
			buttonNext1.SetActive (false);
			buttonNext2.SetActive (false);
			scrollGuidance.SetActive (true);
			scrollStory1.SetActive (false);
			scrollStory2.SetActive (false);
			nameText.text = "";
			missionText.SetActive (false);
			operationText.SetActive (false);
			noneText.SetActive (false);
			dialogueText.SetActive (false);
			break;
		case sceneStatus.find:
			cam [0].enabled = false;
			cam [1].enabled = false;
			rigidbodyController.SetActive (true);
			Debug.Log (transform.position);
			buttonGuide.SetActive (false);
			buttonPlay.SetActive (false);
			buttonReturn1.SetActive (false);
			buttonReturn2.SetActive (false);
			buttonStory.SetActive (false);
			buttonNext1.SetActive (false);
			buttonNext2.SetActive (false);
			scrollGuidance.SetActive (false);
			scrollStory1.SetActive (false);
			scrollStory2.SetActive (false);
			nameText.text = "";
			missionText.SetActive (true);
			operationText.SetActive (true);
			noneText.SetActive (true);
			dialogueText.SetActive (true);
			break;
		case sceneStatus.end:
			cam [0].enabled = false;
			cam [1].enabled = true;
			rigidbodyController.SetActive (false);
			buttonGuide.SetActive (false);
			buttonPlay.SetActive (false);
			buttonReturn1.SetActive (false);
			buttonReturn2.SetActive (false);
			buttonStory.SetActive (false);
			scrollGuidance.SetActive (false);
			scrollStory1.SetActive (false);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			if (isStoryEnd) {
				nameText.text = "";
				scrollStory2.SetActive (true);
				buttonNext1.SetActive (false);
				buttonNext2.SetActive (true);
			} else {
				buttonNext1.SetActive (true);
				buttonNext2.SetActive (false);
				nameText.text = "You Win";
				scrollStory2.SetActive (false);
			}
			missionText.SetActive (false);
			operationText.SetActive (false);
			noneText.SetActive (false);
			dialogueText.SetActive (false);
			break;
		}
	}

	public void setFind(){
		currentStatus = sceneStatus.find;
	}

	public void setStory(){
		currentStatus = sceneStatus.story;
	}

	public void setEnd(){
		currentStatus = sceneStatus.end;
	}

	public void setGuide(){
		currentStatus = sceneStatus.guide;
	}

	public void setReturn(){
		Debug.Log ("enter set return");
		currentStatus = sceneStatus.intro;
	}

	public void setStoryAtEnd(){
		isStoryEnd = true;
	}

	IEnumerator setNextScene(){
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("scene5");
	}

	public void clickButton(){
		music.isFade = true;
		StartCoroutine(setNextScene ());
	}
}
