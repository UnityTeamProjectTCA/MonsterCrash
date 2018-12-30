using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	[SerializeField] GameObject _enemy_A = null;
	[SerializeField] GameObject _enemy_B = null;
	[SerializeField] GameObject _enemy_C = null;
	[SerializeField] UIManager _timer = null;

	float _near_distance = 0;
	float _far_distance = 0;
	int _enemy_max = 0;
	float _wait_time = 0;
	float _appear_rate = 0;
	float _A_rate = 0;

	[SerializeField] float _C_spawn_time = 0;

	float _wait_count = 0;
	int _appear_count = 0;                              //敵が生成された回数
	GameObject _player = null;

	GameObject _create_enemy = null;                    //生成されたエネミー

	// Use this for initialization
	void Start( ) {
		_near_distance = GameCSV._near_distance;
		_far_distance = GameCSV._far_distance;
		_enemy_max = GameCSV._enemy_max;
		_wait_time = GameCSV._appear_wait_time;
		_appear_rate = GameCSV._appear_rate;
		_A_rate = GameCSV._A_rate;

		_C_spawn_time = Random.Range( 30f, 60f );

		_player = GameObject.FindGameObjectWithTag( "Player" );
		_wait_count = _wait_time;
	}

	// Update is called once per frame
	void Update( ) {
		if ( !Player._playable ) {
			return;
		}
		float _enemy_appear = Random.Range( 0f, 1f );
		_wait_count -= Time.deltaTime;

		//出現するかどうか
		if ( _wait_count <= 0 ) {
			if ( _enemy_appear <= _appear_rate ) {
				enemySpawn( );
			}
			_wait_count = _wait_time;
		}

		if ( Mathf.Abs( _timer.getTime( ) - _C_spawn_time ) <= 0.01f ) {
			CSpawn( Random.Range( _near_distance, _far_distance ) );
		}
	}


	bool isCountLimit( ) {
		//エネミーが指定回数以上生成されていたら生成しない
		if ( _appear_count >= _enemy_max ) {
			return true;
		}

		return false;
	}

	bool isAppearLimit( Vector3 pos ) {
		float field_x = GetComponent<Renderer>( ).bounds.size.x;
		float field_z = GetComponent<Renderer>( ).bounds.size.z;

		if ( pos.x <= transform.position.x - field_x / 4 ||
			 pos.x >= transform.position.x + field_x / 4 ||
			 pos.z <= transform.position.z - field_z / 4 ||
			 pos.z >= transform.position.z + field_z / 4 ) {
			return true;
		}
		return false;
	}

	void ASpawn( Vector3 pos ) {
		if ( isAppearLimit( pos ) ) {
			return;
		}

		_create_enemy = Instantiate( _enemy_A, pos + new Vector3( 0, _enemy_A.transform.position.y - _player.transform.position.y, 0 ), Quaternion.identity );
		_appear_count++;
	}

	void BSpawn( Vector3 pos ) {
		if ( isAppearLimit( pos ) ) {
			return;
		}

		_create_enemy = Instantiate( _enemy_B, pos + new Vector3( 0, _enemy_B.transform.position.y - _player.transform.position.y, 0 ), Quaternion.identity );
		_appear_count++;
	}

	void CSpawn( float range ) {
		if ( GameObject.FindGameObjectWithTag( "EnemyC" ) != null ) {
			return;
		}
		Vector3 _C_pos = _player.transform.position + _player.transform.forward * range;
		if ( isAppearLimit( _C_pos ) ) {
			return;
		}
		_create_enemy = Instantiate( _enemy_C, _C_pos + new Vector3( 0, _enemy_C.transform.position.y - _player.transform.position.y, 0 ), Quaternion.identity );
		_appear_count++;
	}

	void enemySpawn( ) {
		//enemy数上限
		if ( isCountLimit( ) ) {
			return;
		}

		//出現場所
		float _enemy_appear_range = Random.Range( _near_distance, _far_distance );
		float _appear_angle = Random.Range( 0f, 360 * Mathf.Deg2Rad );
		Vector3 _dir = new Vector3( Mathf.Cos( _appear_angle ), 0, Mathf.Sin( _appear_angle ) ).normalized;
		Vector3 _enemy_pos = _player.transform.position +
							 _dir * ( _near_distance + _far_distance - _enemy_appear_range );

		float _appear = Random.Range( 0f, 1f );
		if ( _appear <= _A_rate ) {
			ASpawn( _enemy_pos );
		} else {
			BSpawn( _enemy_pos );
		}
	}

	//MinMap用----------------------------
	public GameObject getEnemy( ) {

		if ( _create_enemy != null ) {
			GameObject create_enemy = _create_enemy;
			_create_enemy = null;     //生成したことを1回とれたらリセットする
			return create_enemy;
		} else {
			return null;
		}

	}
	//-------------------------------------
}