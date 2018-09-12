using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {


   // public AudioClip MusicClip;

    public AudioSource monsterSound;

    public AudioSource walkSound;

	// Use this for initialization
	void Start () {
		//MusicSource.clip = MusicClip;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Space))
			monsterSound.Play ();

		if ((Mathf.Abs(Input.GetAxisRaw ("Horizontal") ) >= 0.1 ||
			Mathf.Abs(Input.GetAxisRaw ("Vertical") ) >= 0.1) &&
		   !walkSound.isPlaying) {
			walkSound.Play ();
		}

		if ( Mathf.Abs(Input.GetAxisRaw ("Horizontal")) < 0.1 &&
			Mathf.Abs(Input.GetAxisRaw ("Vertical")) < 0.1 &&
			 walkSound.isPlaying ) {
			walkSound.Pause ();
		}
	}
}
