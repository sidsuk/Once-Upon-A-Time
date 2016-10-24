using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class stateController : MonoBehaviour {
	enum sceneState { heal, run, end }
	private sceneState currentScene = sceneState.heal;

	public musicController music;
	public Camera[] cam;
	public GameObject anna1;
	public GameObject anna2;
	public GameObject anna3;
	public GameObject anna4;
	public GameObject granny;
	public GameObject effect;
	public GameObject cam3;
	public Text textD;
	//public Text text;
	private float timer;
	// Use this for initialization
	void Start () {
		//effect.SetActive (false);
		//music.isFade = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentScene) {
		case sceneState.heal:
			cam [0].enabled = true;
			cam [1].enabled = false;
			anna1.SetActive (true);
			anna2.SetActive (false);
			anna3.SetActive (false);
			anna4.SetActive (false);
			granny.SetActive (true);
			effect.SetActive (true);
			cam3.SetActive (false);
			timer += Time.deltaTime;
			if (timer <= 17) {
				granny.GetComponent<Animator> ().SetBool ("isHeal", true);
				if (timer <= 8.5) {
					textD.text = "Granny healed the girl with magic.";
				} else {
					textD.text = "Then, they lived a happy life together.";
				}
			} else {
				timer = 0;
				currentScene = sceneState.run;
			}
			break;
		case sceneState.run:
			textD.text = "";
			timer += Time.deltaTime;
			cam [0].enabled = false;
			cam [1].enabled = true;
			cam [1].GetComponent<Animator> ().SetBool ("isMove", true);
			anna1.SetActive (false);
			anna2.SetActive (true);
			anna4.SetActive (false);
			granny.SetActive (false);
			effect.SetActive (false);
			cam3.SetActive (false);
			if (timer <= 15) {
				anna3.SetActive (false);
			} else if (timer <= 30) {
				anna3.SetActive (true);
			} else {
				timer = 0;
				currentScene = sceneState.end;
			}
			break;
		case sceneState.end:
			timer += Time.deltaTime;
			cam [0].enabled = false;
			cam [1].enabled = false;
			cam3.SetActive (true);
			anna1.SetActive (false);
			anna2.SetActive (false);
			anna4.SetActive (false);
			granny.SetActive (false);
			effect.SetActive (false);
			anna4.SetActive (true);
			if (timer >= 20) {
				nextScene ();
			}
			break;
		}
	}
	void nextScene(){
		//music.isFade = true;
		StartCoroutine(setNextScene ());
	}

	IEnumerator setNextScene(){
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("scene6");
	}
		
}
