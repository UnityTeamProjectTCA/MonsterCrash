using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
	[SerializeField] AudioSource _submit_SE = null;

	string _scene = "";

	// Use this for initialization
	void Start ( ) {
		if ( SceneManager.GetActiveScene( ).name == "Title" ) {
			_scene = TitleCSV._target_scene;
		}
		if ( SceneManager.GetActiveScene( ).name == "Result" ) {
			_scene = ResultCSV._target_scene;
		}
	}

	// Update is called once per frame
	void Update ( ) {
		if ( Input.GetButtonDown( "Submit" ) ) {
			_submit_SE.Play( );
		}
		if ( _submit_SE.time >= _submit_SE.clip.length ) {
			sceneChange( _scene );
		}
	}

	void sceneChange ( string target_scene ) {
		if ( target_scene == "Game" ) {
			ScoreManager._score = 0;
		}
		SceneManager.LoadScene( target_scene );
	}
}