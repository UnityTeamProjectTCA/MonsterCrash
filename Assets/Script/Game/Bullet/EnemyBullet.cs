using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	float _shot_speed = 0;
	
	GameObject _player = null;
	// Use this for initialization
	void Start ( ) {
		_shot_speed = PrefabCSV._shot_speed;
		_player = GameObject.FindGameObjectWithTag( "Player" );
	}

	// Update is called once per frame
	void Update ( ) {
		Vector3 player_pos = Vector3.Scale( _player.transform.position, new Vector3( 1, 0, 1 ) );
		Vector3 enemy_pos = Vector3.Scale( transform.position, new Vector3( 1, 0, 1 ) );
		transform.forward = ( player_pos - enemy_pos ).normalized;
		transform.position += transform.forward * _shot_speed;
	}

	void OnCollisionEnter ( Collision other ) {
		if ( other.gameObject.tag != "Floor" ) {
			Destroy( gameObject );
		}
	}
}
