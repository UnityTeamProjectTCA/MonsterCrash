using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
	[SerializeField] AudioSource _submit_SE = null;
	bool _sound_flag = false;
	string _scene = "";

	// Use this for initialization
	void Start ( ) {
		string _scene_name = SceneManager.GetActiveScene( ).name;
		if ( _scene_name == "Title" ) {
			_scene = TitleCSV._target_scene;
		}
		if ( _scene_name == "Result" ) {
			_scene = ResultCSV._target_scene;
		}
	}

	// Update is called once per frame
	void Update ( ) {
		if ( Input.GetButtonDown( "Submit" ) && !_sound_flag ) {
			_submit_SE.Play( );
			_sound_flag = true;
		}
		if ( _submit_SE.time >= _submit_SE.clip.length ) {
			_sound_flag = false;
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