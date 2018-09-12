using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	[SerializeField] Text _timer = null;
	[SerializeField] Text _score = null;
	[SerializeField] Player _player = null;
	[SerializeField] GameObject _game_start = null;
	[SerializeField] GameObject _time_up = null;
	[SerializeField] GameObject _speed_buff_image = null;
	[SerializeField] GameObject _range_buff_image = null;
	[SerializeField] GameObject _time_limit_warning = null;
	[SerializeField] GameObject[ ] _countdown = null;
	[SerializeField] GameObject[ ] _deathblow_image = null;

	float _wait_time = 0;
	float _time_limit = 0;
	float _count_time = 4.0f;
	GameObject _load_scene = null;


	// Use this for initialization
	void Start ( ) {
		_wait_time = GameCSV._wait_time;
		_time_limit = GameCSV._time_limit;

		_load_scene = GameObject.Find( "LoadScreen" );
		_speed_buff_image.SetActive( false );
		_range_buff_image.SetActive( false );

		for ( int i = 0; i < _deathblow_image.Length; i++ ) {
			_deathblow_image[ i ].SetActive( false );
		}
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _count_time >= 0 ) {
			Player._playable = false;
			countDown( );
			return;
		}
		if ( _time_limit > 0 ) {
			Player._playable = true;
			game( );
		} else {
			Player._playable = false;
			timeUp( );
		}
	}

	void countDown ( ) {
		//ロード画面だったらカウントダウンを始めない
		if ( _load_scene != null ) {
			return;
		}

		_count_time -= Time.deltaTime;

		if ( ( int )_count_time < 4 && ( int )_count_time != 0 ) {
			if ( GameObject.FindGameObjectWithTag( "CountDown" ) == null ) {
				GameObject countdown = Instantiate( _countdown[ ( int )_count_time - 1 ] );
				countdown.transform.SetParent( transform, false );
			}
		}

		if ( ( int )_count_time == 0 ) {
			if ( GameObject.FindGameObjectWithTag( "CountDown" ) == null ) {
				GameObject start = Instantiate( _game_start );
				start.transform.SetParent( transform, false );
			}
		}
	}

	void game ( ) {
		showScore( );
		showBuffUI( );
		showDeathBlowCount( );

		if ( CutIn._cutin_flag ) {
			return;
		}
		calTime( );
		if ( ( int )_time_limit == 10 ) {
			TimeLimitWarning( );
		}
	}

	void showBuffUI ( ) {
		if ( Player._speedup_flag ) {
			_speed_buff_image.SetActive( true );
		} else {
			_speed_buff_image.SetActive( false );
		}
		if ( Player._rangeup_flag ) {
			_range_buff_image.SetActive( true );
		} else {
			_range_buff_image.SetActive( false );
		}
	}

	void showScore ( ) {
		_score.text = "Score " + ScoreManager._score.ToString( );
	}

	void calTime ( ) {
		_time_limit -= Time.deltaTime;
		_timer.text = ( ( int )_time_limit / 60 ).ToString( ) + " : " + ( ( int )_time_limit % 60 ).ToString( "D2" );
	}

	void showDeathBlowCount ( ) {
		for ( int i = 0; i < _deathblow_image.Length; i++ ) {
			_deathblow_image[ i ].SetActive( false );
		}
		for ( int i = 0; i < _player.getDeathblowCount( ); i++ ) {
			_deathblow_image[ i ].SetActive( true );
		}
	}

	void timeUp ( ) {
		if ( GameObject.FindGameObjectWithTag( "Finish" ) == null ) {
			GameObject time_up = Instantiate( _time_up );
			time_up.transform.SetParent( transform, false );
		}
		_timer.text = "";
		_wait_time -= Time.deltaTime;
		if ( _wait_time <= 0 ) {
			SceneManager.LoadScene( "Result" );
		}
	}

	void TimeLimitWarning ( ) {
		if ( GameObject.FindGameObjectWithTag( "Warning" ) == null ) {
			GameObject warning = Instantiate( _time_limit_warning );
			warning.transform.SetParent( transform, false );
		}
	}
}