using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {
	float _disappear_time = 0;
	float _power = 0;

	GameObject _player = null;
	// Use this for initialization
	void Start( ) {
		_disappear_time = GameCSV._debris_disappear_time;
		_power = GameCSV._debris_addpower;

		_player = GameObject.FindGameObjectWithTag( "Player" );
		
		Vector3 dir = Vector3.zero;
		dir.x = Random.Range( -1f, 1f );
		dir.z = 1f;
		dir.y = Random.Range( 0, 1f );

		Rigidbody _rigidbody = GetComponent<Rigidbody>( );
		_rigidbody.AddForce( _player.transform.TransformVector( dir ) * _power );
		//_rigidbody.velocity = _player.transform.TransformVector( dir ) * _power;
	}
	
	// Update is called once per frame
	void Update( ) {
		_disappear_time -= Time.deltaTime;
		if ( _disappear_time < 0 ) Destroy( gameObject );
	}
}
