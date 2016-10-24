using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class grannyController : MonoBehaviour {
	enum sceneState { laying, crying, walking, talking, gameover, departure, end};

	public Camera[] cam;
	public Animator anim;
	public GameObject mom_in_scene_2;
	public GameObject dad_in_scene_4;
	public GameObject mom_in_scene_4;
	public GameObject buttonShow;
	public bool isHide=false;
	public float speed = 0.05f;
	public float rotateSpeed = 1.0f;
	public Text dialogueText;
	public Text missionText;
	public Text gameOverText;
	public Text depatureText;
	public Text operationText;
	public musicController music;

	private float Timer;
	private sceneState currentScene = sceneState.laying;
	private int count = 0;
	private bool setted = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		dialogueText.text = "";
		missionText.text = "";
		operationText.text = "";
		gameOverText.text = "";
		depatureText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		sceneSet ();
		switch (currentScene) {
		case sceneState.laying:
			break;
		case sceneState.crying:
			mom_in_scene_2.GetComponent<Animator> ().SetBool ("isCry", true);
			break;
		case sceneState.walking:
			float translation = Input.GetAxis ("Vertical") * speed;
			float rotation = Input.GetAxis ("Horizontal") * rotateSpeed;
			transform.Translate (0, 0, translation);
			transform.Rotate (0, rotation, 0);
			if (translation!=0) {
				anim.SetBool ("isWalk", true);
			} else {
				anim.SetBool ("isWalk", false);
			}
			missionText.text = "Mission: You find the sick girl. Now find her parents and talk to them.";
			operationText.text = " Use keyboard arrows to control Granny.";
			break;
		case sceneState.talking:
			//Debug.Log ("enter scene talking");
			//camera set and animation set
			cam [0].enabled = false;
			cam [1].enabled = false;
			cam [2].enabled = false;
			cam [3].enabled = true;
			anim.SetBool ("isTalk", true);
			anim.SetBool ("isNod", false);
			dad_in_scene_4.GetComponent<Animator> ().SetBool ("isTalk", true);

			//dialogue
			missionText.text = "Mission: Talk to Dad.";
			operationText.text = "Click Granny to continue the dialogue.";
			gameOverText.text = "";
			depatureText.text = "";
			if (count == 0) {
				dialogueText.text = "You: Your daughter was a rampion in my garden.";
			}
			if (count == 1) {
				dialogueText.text = "You: She is heavily sick because of being far away from me.";
			}
			if (count == 2) {
				dialogueText.text = "Dad: Can you save her?";
			}
			if (count == 3) {
				dialogueText.text = "You: What do you want me to do?";
			}
			if (count == 4) {
				dialogueText.text = "Dad: Can you take her away?";
			}
			if (count == 5) {
				missionText.text = "Mission: Choose to take girl away or not.";
				dialogueText.text = "";
				operationText.text = "";
				buttonShow.GetComponent<buttonController> ().showButtonForTalk ();
			}
			break;
		case sceneState.departure:
			anim.SetBool ("isNod", true);
			buttonShow.GetComponent<buttonController> ().showButtonForNext ();
			missionText.text = "";
			operationText.text = "";
			gameOverText.text = "";
			depatureText.text = "YOU DECIDE TO TAKE GIRL AWAY.";
			break;
		case sceneState.gameover:
			buttonShow.GetComponent<buttonController> ().showButtonForReturn ();
			missionText.text = "";
			operationText.text = "";
			gameOverText.text = "GAME OVER";
			break;
		case sceneState.end:
			break;
		}
	}

	float wait(){
		Timer += Time.deltaTime;
		return Timer;
	}

	void sceneSet(){
		if (wait () <= 14) {
			currentScene = sceneState.laying;
			cam [0].enabled = true;
			cam [1].enabled = false;
			cam [2].enabled = false;
			cam [3].enabled = false;
		} else if (wait () <= 37) {
			currentScene = sceneState.crying;
			cam [0].enabled = false;
			cam [1].enabled = true;
			cam [2].enabled = false;
			cam [3].enabled = false;
		} else if(setted == false){
			cam [0].enabled = false;
			cam [1].enabled = false;
			cam [2].enabled = true;
			isHide = true;
			cam [3].enabled = false;
			currentScene = sceneState.walking;
		}
			
	}

	bool hide(){
		return isHide;
	}

	public void setTalking(){
		currentScene = sceneState.talking;
		setted = true;
		count = 0;
		//Debug.Log ("call the function");
	}

	void OnMouseDown() {
		Debug.Log (count);
		count++;
	}

	public void setGameOver(){
		currentScene = sceneState.gameover;
	}

	public void setDepature(){
		currentScene = sceneState.departure;
	}

	public void returnTalk(){
		currentScene = sceneState.talking;
	}
		

	IEnumerator setNextScene(){
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("scene4");
	}

	public void clickButton(){
		music.isFade = true;
		StartCoroutine(setNextScene ());
	}
}
