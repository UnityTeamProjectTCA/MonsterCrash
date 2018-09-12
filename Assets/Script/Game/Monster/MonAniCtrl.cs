﻿using UnityEngine;

public class MonAniCtrl : MonoBehaviour {
	[SerializeField] AudioSource attack_sound = null;
	[SerializeField] AudioSource walk_sound = null;
	[SerializeField] Animator _anim = null;
	[SerializeField] Player _player = null;

	bool _attack_flag = false;
	bool _walk_flag = false;
	bool _deathblow_flag = false;
	bool _idle_flag = true;

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {

		_anim.SetBool( "Walk", _walk_flag );
		_anim.SetBool( "Idle", _idle_flag );
		_anim.SetBool( "Attack", _attack_flag );
		_anim.SetBool( "Deathblow", _deathblow_flag );

		if ( !Player._playable ) {
			_walk_flag = false;
			_attack_flag = false;
			return;
		}
		if ( CutIn._cutin_flag ) {
			_deathblow_flag = true;
			_idle_flag = false;
			_walk_flag = false;
			_attack_flag = false;
			return;
		} else {
			_deathblow_flag = false;
		}

		MonAnim( );
	}

	void MonAnim ( ) {
		float _horizontal_pos = Input.GetAxisRaw( "Horizontal" );
		float _vertical_pos = Input.GetAxisRaw( "Vertical" );

		if ( ( Mathf.Abs( _horizontal_pos ) > 0.05f || Mathf.Abs( _vertical_pos ) > 0.05f ) && !_attack_flag ) {
			_walk_flag = true;
			_attack_flag = false;
			_idle_flag = false;
			walk_sound.Play( );
		} else {
			_walk_flag = false;
			walk_sound.Pause( );
		}

		if ( Input.GetButtonDown( "Fire1" ) ) {
			_attack_flag = true;
			_walk_flag = false;
			_idle_flag = false;
			attack_sound.Play( );
		}

		if ( Input.GetButtonUp( "Fire1" ) || _player.getFireStamina( ) <= 0 ) {
			_attack_flag = false;
		}

		if ( !_attack_flag && !_deathblow_flag && !_walk_flag ) {
			_idle_flag = true;
		}
	}

	void onMotionEnd ( ) {
		CutIn._cutin_flag = false;
	}
}
