using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour {
	[SerializeField] AudioSource _submit_SE = null;
	bool _sound_flag = false;
	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
		if ( Input.GetButtonDown( "Submit" ) && !_sound_flag ) {
			_submit_SE.Play( );
			_sound_flag = true;
		}
		if ( _submit_SE.time >= _submit_SE.clip.length ) {
			_sound_flag = false;
			SceneManager.LoadScene( "Title" );
		}
	}
}