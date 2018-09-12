using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField] float _shot_speed = 0;             //弾丸スピード
	[SerializeField] float _range = 0;                  //射撃距離
	[SerializeField] float _original_range = 0;
	[SerializeField] float _raised_range = 0;

	GameObject _player = null;

	// Use this for initialization
	void Start ( ) {
		_player = GameObject.FindGameObjectWithTag( "Player" );
		transform.forward = _player.transform.forward;
	}

	// Update is called once per frame
	void Update ( ) {
		rangeUpBuff( );
		bulletMove( );
	}

	void bulletMove ( ) {
		//弾丸移動
		transform.position += transform.forward * ( _shot_speed + Player._player_velocity );
		//一定範囲に離れたら消滅
		if ( Vector3.Distance( transform.position, _player.transform.position ) >= _range ) {
			Destroy( gameObject );
		}
	}

	void rangeUpBuff ( ) {
		if ( Player._rangeup_flag ) {
			_range = _raised_range;
		} else {
			_range = _original_range;
		}
	}

	void OnTriggerEnter ( Collider other ) {
		if ( other.gameObject.tag == "EnemyA" ) {
			Destroy( other.gameObject );
			Player._rangeup_flag = true;
		}

		if ( other.gameObject.tag == "EnemyB" ) {
			Destroy( other.gameObject );
			Player._speedup_flag = true;
		}

		if ( other.gameObject.tag == "EnemyC" ) {
			Destroy( other.gameObject );
			_player.GetComponent<Player>( ).deathblowIncrease( 1 );
		}

		if ( other.gameObject.tag == "Floor" ) {
			Destroy( gameObject );
		}
	}
}