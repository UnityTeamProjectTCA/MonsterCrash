using UnityEngine;

public class Player : MonoBehaviour {
	//アタック
	[SerializeField] ParticleSystem _fire = null;
	bool _fire_flag = false;
	float _fire_pos_y = 0;
	float _fire_pos_z = 0;
	float _stamina_max = 0;
	float _stamina_speed = 0;
	float _fire_stamina = 0;

	//必殺技
	[SerializeField] GameObject _deathblow_bullet = null;
	bool _deathblow_prepare = false;
	int _deathblow_count = 0;

	//制御
	public static bool _playable = true;
	public static bool _movable = true;
	public static float _stop_time = 0;
	float _wait_time_count = 0;

	//スピード制御
	Vector3 _speed = Vector3.zero;
	float _velocity = 0;
	public static float _player_velocity = 0;
	Vector3 latestPos = Vector3.zero;
	float _origin_velocity = 0;
	float _raised_velocity = 0;

	// buff
	public static bool _rangeup_flag;
	public static bool _speedup_flag;
	float _speedup_time = 0;
	float _rangeup_time = 0;
	float _speedup_count = 0;
	float _rangeup_count = 0;

	//カットイン
	[SerializeField] GameObject _canvas = null;
	[SerializeField] GameObject _cutin = null;

	//ペナルティ
	float _demirit_time = 0;
	float _demirit_time_count = 0;
	public static bool _demirit = false;


	Vector3 _initial_pos = Vector3.zero;    //初期位置
	Quaternion _initial_dir;                //初期角度

	// Use this for initialization
	void Start ( ) {
		_fire_pos_y = GameCSV._fire_pos_y;
		_fire_pos_z = GameCSV._fire_pos_z;
		_stamina_max = GameCSV._stamina_max;
		_stamina_speed = GameCSV._stamina_speed;
		_origin_velocity = GameCSV._origin_velocity;
		_raised_velocity = GameCSV._raised_velocity;
		_speedup_time = GameCSV._speedup_time;
		_rangeup_time = GameCSV._rangeup_time;
		_demirit_time = GameCSV._demirit_time;

		_deathblow_count = 1;
		_speedup_count = _speedup_time;
		_rangeup_count = _rangeup_time;
		_fire_stamina = _stamina_max;

		_demirit_time_count = _demirit_time;
		_demirit = false;

		_initial_pos = transform.position;
		_initial_dir = transform.rotation;
	}

	// Update is called once per frame
	void Update ( ) {
		if ( !_playable ) {
			_fire.Stop( );
			return;
		}

		if ( _demirit ) {
			Demirit( );
			return;
		}

		if ( CutIn_Vertical._cutin_flag ) {
			_fire.Stop( );
			return;
		}

		fireMakeing( );
		deathblowMakeing( );
		calStamina( );
		calPlayerSpeed( );
		speedUpBuff( );
		rangeUpBuff( );

		if ( !_movable ) {
			_wait_time_count -= Time.deltaTime;
			if ( _wait_time_count <= 0 ) {
				_wait_time_count = _stop_time;
				_movable = true;
			}
			return;
		}

		charaMove( );
	}


	void fireMakeing ( ) {
		_fire.transform.position = transform.position + transform.up * _fire_pos_y + transform.forward * _fire_pos_z;
		if ( MonAniCtrl._attack_flag ) {
			_movable = false;
		}
		if ( Input.GetButtonUp( "Fire1" ) || _fire_stamina <= 0 ) {
			_wait_time_count = 0;
			_movable = true;
			_fire.Stop( );
			_fire_flag = false;
		}
	}

	void deathblowMakeing ( ) {
		_deathblow_prepare = false;
		if ( _deathblow_count > 0 ) {
			if ( Input.GetButton( "Fire2" ) ) {
				_deathblow_prepare = true;
			}
			if ( _deathblow_prepare && Input.GetButtonDown( "Fire1" ) ) {
				//必殺技生成
				Instantiate( _deathblow_bullet, transform.position + transform.up * 10, Quaternion.identity );
				//カットイン生成
				CutIn_Vertical._cutin_flag = true;
				GameObject cutin = Instantiate( _cutin );
				cutin.transform.SetParent( _canvas.transform, false );
			}
		}
	}

	void charaMove ( ) {
		float _horizontal_move = Input.GetAxisRaw( "Horizontal" );
		float _vertical_move = Input.GetAxisRaw( "Vertical" );
		Vector3 camera_forward = Vector3.Scale( Camera.main.transform.forward, new Vector3( 1, 0, 1 ) ).normalized;
		Vector3 move_dir = camera_forward * _vertical_move + Camera.main.transform.right * _horizontal_move;

		if ( Mathf.Abs( _horizontal_move ) > 0.05f || Mathf.Abs( _vertical_move ) > 0.05f ) {
			Quaternion targetRotation = Quaternion.LookRotation( move_dir );
			transform.rotation = Quaternion.Slerp( transform.rotation, targetRotation, Time.deltaTime * 20 );
			_speed = move_dir * _velocity;
			transform.localPosition += _speed * Time.deltaTime;
		}
	}

	void speedUpBuff ( ) {
		if ( _speedup_flag ) {
			_velocity = _raised_velocity;
			_speedup_count -= Time.deltaTime;
		} else {
			_velocity = _origin_velocity;
		}
		if ( _speedup_count <= 0 ) {
			_speedup_count = _speedup_time;
			_speedup_flag = false;
		}
	}

	void rangeUpBuff ( ) {
		if ( _rangeup_flag ) {
			_rangeup_count -= Time.deltaTime;
		}
		if ( _rangeup_count <= 0 ) {
			_rangeup_count = _rangeup_time;
			_rangeup_flag = false;
		}
	}

	void calPlayerSpeed ( ) {
		float player_velocity = ( transform.position - latestPos ).magnitude;
		latestPos = transform.position;
		if ( player_velocity < 0.01 ) {
			_player_velocity = 0;
		} else {
			_player_velocity = _velocity;
		}
	}

	void calStamina ( ) {
		if ( _fire_stamina < _stamina_max && !_fire_flag ) {
			_fire_stamina += Time.deltaTime * _stamina_speed;
		}
		if ( _fire_stamina > 0 && _fire_flag ) {
			_fire_stamina -= Time.deltaTime * _stamina_speed;
		}
		if ( _fire_stamina > _stamina_max ) {
			_fire_stamina = _stamina_max;
		}
		if ( _fire_stamina < 0 ) {
			_fire_stamina = 0;
		}
	}

	void Demirit ( ) {
		_demirit_time_count -= Time.deltaTime;
        _fire.Stop( );
        _fire_flag = false;
		if ( _demirit_time_count < 0 ) {
			_playable = true;
			_demirit = false;
			_demirit_time_count = _demirit_time;
		}
	}

	private void OnParticleCollision ( GameObject other ) {
		if ( other.gameObject.tag == "enemybullet" && !CutIn_Vertical._cutin_flag ) {
			_demirit = true;
		}
	}


	public float getFireStamina ( ) {
		return _fire_stamina;
	}

	public void deathblowIncrease ( int delta ) {
		_deathblow_count += delta;
	}

	public int getDeathblowCount ( ) {
		return _deathblow_count;
	}

	//初期位置と初期角度に戻す
	public void ResetPosAndDir ( ) {
		transform.position = _initial_pos;
		transform.rotation = _initial_dir;
	}

	public void OpenFire ( ) {
		_fire.Play( );
		_fire_flag = true;
	}
}