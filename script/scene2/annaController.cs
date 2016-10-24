using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class annaController : MonoBehaviour {
	private float Timer;
	public GameObject Anna;
	public musicController music;
	// Use this for initialization
	void Start () {
		music.isFade = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (wait () > 40) {
			Anna.SetActive (true);
		} else {
			Anna.SetActive (false);
		}
	}

	float wait(){
		Timer += Time.deltaTime;
		return Timer;
	}

	IEnumerator setNextScene(){
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		//Debug.Log ("enter next");
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("scene3");
	}

	public void clickButton(){
		//Debug.Log ("enter click");
		music.isFade = true;
		StartCoroutine( setNextScene ());
	}
}
