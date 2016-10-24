using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GrannyController : MonoBehaviour {
	//animator parameter: standUp,isWalk,StandToWalk,isIdle,sitDown,isTalk

	enum sceneState { standUp, walk, sitDown, fireplace};

	public Animator anim;
	public float speed = 5.0f;
	public float rotationSpeed = 50f;
	public Camera[] cam;
	public GameObject buttonStart;
	//public Vector3[] targetPosition;
	public musicController music;
	private float Timer;
	private sceneState currentState;
	private float step;
	// Use this for initialization

	public Text title;

	//private GameObject Granny1Ref;
	//private GraController GraControllerRef;

	//private GameObject Granny2Ref;
	//private GrannController GrannControllerRef;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("standUp", false);
		anim.SetBool ("isWalk", false);
		anim.SetBool ("isIdle", false);
		currentState = sceneState.standUp;
		title.text = "";
		buttonStart.SetActive (false);
		music.isFade = false;
		//Granny1Ref = GameObject.Find ("Granny1");
		//GraControllerRef = Granny1Ref.GetComponent<GraController> ();

		//Granny2Ref = GameObject.Find ("Granny2");
		//GrannControllerRef = Granny2Ref.GetComponent<GrannController> ();
	}
	
	// Update is called once per frame
	void Update () {
		camEnabled ();
		switch (currentState) {
		case sceneState.standUp:
			anim.SetBool ("isIdle",false);
			break;
		case sceneState.walk:
			anim.SetBool ("isWalk", true);
			anim.SetBool ("isIdle", true);
			//step = speed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards (targetPosition [0], targetPosition [1], step);
			break;
		case sceneState.sitDown:
			anim.SetBool ("isWalk", false);
			anim.SetBool ("sitDown", false);
			anim.SetBool ("isIdle", false);
			break;
		case sceneState.fireplace:
			anim.SetBool ("isWalk", false);
			anim.SetBool ("isIdle", false);
			anim.SetBool ("sitDown", false);
			if (wait () >= 120) {
				title.text = "Once Upon A Time";
				buttonStart.SetActive (true);
			} //else if (wait () >= 150) {
			//	FadeToBlack ();
			//}
			break;

		}
	}

	//functions
	float wait(){
		Timer += Time.deltaTime;
		return Timer;
	}

	void camEnabled (){
		if (wait () <= 4.4) {
			currentState = sceneState.standUp;
			cam [0].enabled = true;
			cam [1].enabled = false;
			cam [2].enabled = false;
			cam [3].enabled = false;
		} else if (wait () <= 25) {
			currentState = sceneState.walk;
			cam [0].enabled = false;
			cam [1].enabled = true;
			cam [2].enabled = false;
			cam [3].enabled = false;
		} else if (wait () <= 70) {
			currentState = sceneState.sitDown;
			cam [0].enabled = false;
			cam [1].enabled = false;
			cam [2].enabled = true;
			cam [3].enabled = false;
		} else {
			currentState = sceneState.fireplace;
			cam [0].enabled = false;
			cam [1].enabled = false;
			cam [2].enabled = false;
			cam [3].enabled = true;
		}
	}

	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		//GUITexture.color = Color.Lerp(GUITexture.color, Color.black, 1.5f * Time.deltaTime);
	}

	IEnumerator setNextScene(){
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("scene2");
	}

	public void clickButton(){
		music.isFade = true;
		StartCoroutine(setNextScene ());
	}
}
