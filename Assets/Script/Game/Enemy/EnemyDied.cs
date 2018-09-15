using UnityEngine;

public class EnemyDied : MonoBehaviour {
	//[SerializeField] float _death_move_distance = 0;
	[SerializeField] float _death_rotate_speed = 0;
	[SerializeField] float _disappear_time = 0;

	float _x_speed = 1;
	float _y_speed = 0.7f;
	float _z_speed = 1;
	float _timer = 0;
	GameObject _player = null;
	Vector3 _start_pos = Vector3.zero;

	// Use this for initialization
	void Start ( ) {
		_death_rotate_speed = GameCSV._death_rotate_speed;
		_disappear_time = GameCSV._death_disappear_time;

		_player = GameObject.FindGameObjectWithTag( "Player" );
		_start_pos = transform.position;
		_timer = _disappear_time;
	}

	// Update is called once per frame
	void Update ( ) {
		deathMove( );
		deathRotate( );
	}

	void deathMove ( ) {
		Vector3 vec = _start_pos - _player.transform.position;
		_timer -= Time.deltaTime;
		if ( vec.x < 0 ) {
			_x_speed = -1;
		}
		if ( vec.z < 0 ) {
			_z_speed = -1;
		}
		transform.position += new Vector3( _x_speed, _y_speed, _z_speed ) * Time.deltaTime * 60;

		if ( _timer <= 0 ) {
			Destroy( gameObject );
		}
	}

	void deathRotate ( ) {
		transform.RotateAround( transform.position, Vector3.up, Time.deltaTime * _death_rotate_speed );
	}
}
