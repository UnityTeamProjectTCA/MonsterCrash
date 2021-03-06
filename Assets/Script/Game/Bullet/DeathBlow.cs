﻿using UnityEngine;

public class DeathBlow : MonoBehaviour {
	const float CHARGE_SIZE = 2;

	[SerializeField] GameObject _effect = null;

	float _deathblow_pos_y = 0;
	float _deathblow_pos_z = 0;

	float _deathblow_speed = 0;             //弾丸スピード
	float _gravity = 0;
	float _charge_speed = 0;
	float _sway_time = 0;

	GameObject _player_obj = null;
	Player _player = null;
	ParticleSystem _deathblow_effect = null;
	AudioSource _deathblow_se = null;
	float _deathblow_scale = 0;

	// Use this for initialization
	void Start ( ) {
		_deathblow_pos_y = GameCSV._deathblow_pos_Y;
		_deathblow_pos_z = GameCSV._deathblow_pos_Z;

		_deathblow_speed = GameCSV._deathblow_speed;
		_gravity = GameCSV._gravity;
		_charge_speed = GameCSV._charge_speed;
		_sway_time = GameCSV._sway_time;

		_player_obj = GameObject.FindGameObjectWithTag( "Player" );
		_player = _player_obj.GetComponent<Player>( );
		_deathblow_effect = GameObject.Find( "Deathblow" ).GetComponent<ParticleSystem>( );
		_deathblow_se = GameObject.Find( "SE_hissatsu" ).GetComponent<AudioSource>( );

		transform.forward = _player.transform.forward;
		transform.localScale = Vector3.zero;
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _deathblow_scale < CHARGE_SIZE ) {
			deathblowCharge( );
			return;
		}

		deathlblowMove( );
	}

	void deathlblowMove ( ) {
		transform.position += ( transform.forward * _deathblow_speed + transform.up * -_gravity * Time.deltaTime ) * Time.deltaTime;
	}

	void deathblowCharge ( ) {
			_deathblow_scale += _charge_speed * Time.deltaTime;
			transform.localScale = new Vector3( _deathblow_scale, _deathblow_scale, _deathblow_scale );
			transform.position = _player_obj.transform.position + transform.up * _deathblow_pos_y + transform.forward * _deathblow_pos_z;
	}
	
	void OnParticleCollision ( GameObject other ) {
		if ( other.tag == "Floor" ) {
			_player.deathblowIncrease( -1 );
			_deathblow_effect.transform.position = transform.position;
			CameraScript._sway_flag = true;
			CameraScript._sway_time_count = _sway_time;
			Destroy( gameObject );
			_deathblow_se.Play( );
			_deathblow_effect.Play( );
			Instantiate( _effect, transform.position + transform.up * 2, Quaternion.Euler( 0, 0, 0 ) );
		}
	}
}