using UnityEngine;
using System.Collections;

public class musicController : MonoBehaviour {
	public AudioClip music;
	public AudioSource audio;
	public bool isFade = false;
	public float volume = 1.0f;
	public float speed = 0.4f;

	// Use this for initialization
	void Start () {
		audio = this.GetComponent<AudioSource> ();
		music = this.GetComponent<AudioSource> ().clip;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFade) {
			volume -= speed*Time.deltaTime;
			volume = Mathf.Clamp01 (volume);
			StartFade(volume);
		}
	}

	public void SetStart()
	{
		volume = 1.0f;
		isFade = true;
	}
	public void StartFade(float volume)
	{
		audio.volume = volume;
	}
}
