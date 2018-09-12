using UnityEngine;

public class EnemyC : MonoBehaviour {
	[SerializeField] float _a = 0;
	[SerializeField] float _b = 0;
	[SerializeField] float _move_speed = 0;
	[SerializeField] GameObject _player = null;
	float _time = 0;
	float _pos_x = 0;
	float _pos_z = 0;
	float _player_x = 0;
	float _player_z = 0;

	// Use this for initialization
	void Start ( ) {
		_player = GameObject.FindGameObjectWithTag( "Player" );
		_player_x = _player.transform.position.x;
		_player_z = _player.transform.position.z;
	}

	// Update is called once per frame
	void Update ( ) {
		move( );
	}


	void move ( ) {
		_time += Time.deltaTime * _move_speed;
		_pos_x = _a * Mathf.Cos( _time ) + _player_x;
		_pos_z = _b * Mathf.Sin( _time ) + _player_z;
		transform.position = new Vector3( _pos_x, transform.position.y, _pos_z );
		transform.LookAt( _player.transform.position );
	}
}
