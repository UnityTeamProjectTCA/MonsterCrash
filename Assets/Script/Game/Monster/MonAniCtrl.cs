using UnityEngine;

public class MonAniCtrl : MonoBehaviour {
	[SerializeField] AudioSource attack_sound = null;
	[SerializeField] AudioSource walk_sound = null;
	[SerializeField] Animator _anim = null;
	[SerializeField] Player _player = null;

	public static bool _attack_flag = false;
	bool _walk_flag = false;
	bool _deathblow_flag = false;
	bool _idle_flag = true;
	bool _shake_head_flag = false;
	bool _walk_sound = false;


	// Use this for initialization
	void Start( ) {
	}

	// Update is called once per frame
	void Update( ) {

		_anim.SetBool( "Walk", _walk_flag );
		_anim.SetBool( "Idle", _idle_flag );
		_anim.SetBool( "Attack", _attack_flag );
		_anim.SetBool( "Deathblow", _deathblow_flag );
		_anim.SetBool( "ShakeHead", _shake_head_flag );

		if ( !Player._playable ) {
			_walk_flag = false;
			_attack_flag = false;
			return;
		}

		//if ( Player._demirit ) {
		//	_anim.SetFloat( "WalkSpeed",0 );
		//	_anim.SetFloat( "IdleSpeed",0 );
		//	_anim.SetFloat( "AttackSpeed",0 );
		//    if ( _attack_flag ) { 
		//        _idle_flag = false;
		//        _walk_flag = false;
		//        _attack_flag = false;
		//    }
		//	return;
		//} else {
		//	_anim.SetFloat( "WalkSpeed", 1.0f );
		//	_anim.SetFloat( "IdleSpeed", 1.0f );
		//	_anim.SetFloat( "AttackSpeed", 1.0f );
		//}

		if ( CutIn_Vertical._cutin_flag ) {
			_deathblow_flag = true;
			_idle_flag = false;
			_walk_flag = false;
			_attack_flag = false;
			_shake_head_flag = false;
			return;
		} else {
			_deathblow_flag = false;
		}

		MonAnim( );
	}

	void MonAnim( ) {
		float _horizontal_pos = Input.GetAxisRaw( "Horizontal" );
		float _vertical_pos = Input.GetAxisRaw( "Vertical" );

		if ( ( Mathf.Abs( _horizontal_pos ) > 0.05f || Mathf.Abs( _vertical_pos ) > 0.05f ) && !_attack_flag ) {
			_walk_flag = true;
			_attack_flag = false;
			_shake_head_flag = false;
			_idle_flag = false;
			if ( !_walk_sound ) {
				walk_sound.Play( );
				_walk_sound = true;
			}
		} else {
			_walk_flag = false;
			if ( _walk_sound ) {
				walk_sound.Stop( );
				_walk_sound = false;
			}
		}

		if ( Input.GetButtonDown( "Fire1" ) ) {
			_attack_flag = true;
			_walk_flag = false;
			_idle_flag = false;
			_shake_head_flag = false;
			attack_sound.Play( );
		}

		if ( Input.GetButtonUp( "Fire1" ) || _player.getFireStamina( ) <= 0 ) {
			_attack_flag = false;
			_shake_head_flag = false;
			attack_sound.Stop( );
		}

		if ( !_attack_flag && !_deathblow_flag && !_walk_flag && !_shake_head_flag ) {
			_idle_flag = true;
		}
	}

	void ChangeToShake( ) {
		_attack_flag = false;
		_shake_head_flag = true;
	}

	void onMotionEnd ( ) {
		CutIn_Vertical._cutin_flag = false;
	}

	public bool getShakeFlag( ) {
		return _shake_head_flag;
	}
}