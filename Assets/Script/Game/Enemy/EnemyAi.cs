using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour {
	AudioSource _enemy_attack_sound;
	enum STATUS {
		ATTACK,
		ESCAPE
	}

	[SerializeField] GameObject _bullet = null;

	STATUS _status = STATUS.ATTACK;
	EnemyAniCtrl _enemy_anim_ctrl = null;
	EscapeArea[ ] _escape_area = new EscapeArea[ 4 ];
	EscapePoint _escape_point = null;
	NavMeshAgent _agent = null;
	GameObject _player = null;
	float _attack_wait_count = 0;       //攻撃する感覚の時間
	int _escape_area_num = 0;           //逃げるエリアの番号
	bool _attack = false;               //攻撃するかどうか
    
	bool _arrival = true;               //目的地に到達したかどうか
	bool _initial_destination = false;  //初期目的地

	//bool _is_Avoid = true;

	float _bullet_pos = 0;          //弾の位置
	float _attack_wait_time = 0;    //攻撃する感覚の時間
	float _attack_time = 0;         //攻撃する時間
	float _avoid_distance = 0;      //プレイヤーから離れる距離
	float _attack_distance = 0;     //攻撃をする距離

	// Use this for initialization
	void Start( ) {
		_bullet_pos = PrefabCSV._bullet_pos;
		_attack_wait_time = PrefabCSV._attack_wait_time;
		_attack_time = PrefabCSV._attack_time;
		_avoid_distance = PrefabCSV._avoid_distance;
		_attack_distance = PrefabCSV._attack_distance;

		_enemy_attack_sound = GameObject.Find( "SE_Enemy_Attack" ).GetComponent<AudioSource>( );
		GameObject[ ] escape_area = GameObject.FindGameObjectsWithTag( "EscapeArea" );
		for ( int i = 0; i < escape_area.Length; i++ ) {
			_escape_area[ i ] = escape_area[ i ].GetComponent<EscapeArea>( );
		}

		_player = GameObject.FindGameObjectWithTag( "Player" );
		_agent = GetComponent<NavMeshAgent>( );
		_attack_wait_count = _attack_wait_time;
		_enemy_anim_ctrl = GetComponent<EnemyAniCtrl>( );
	}

	

	// Update is called once per frame
	void Update( ) {
		switch ( _status ) {
			case STATUS.ATTACK:
				Attack( );
				break;

			case STATUS.ESCAPE:
				Escape( );
				break;

		}
	}

	//攻撃をする-------------------------------------------------------------------------------------------------------------------
	void Attack( ) {
        //自分がエネミーCだったら
		if ( this.gameObject.tag == "EnemyC" ) {
			_status = STATUS.ESCAPE;
		}


        //攻撃待機時間が残っていたら減らしていく
		if ( _attack_wait_count > 0 ) {
			_attack_wait_count -= Time.deltaTime;
		}

		EnemyAction( );

		//条件によってアニメーションのフラグを立てる
		if ( _attack_wait_count < 0 && _attack ) {
            _enemy_anim_ctrl.setAttackAnimFlag( true );
            _enemy_anim_ctrl.setWalkAnimFlag( false );
		} else if ( _attack ) {
            _enemy_anim_ctrl.setAttackAnimFlag( false );
            _enemy_anim_ctrl.setWalkAnimFlag( false );
        } else { 
            _enemy_anim_ctrl.setAttackAnimFlag( false );
            _enemy_anim_ctrl.setWalkAnimFlag( true );
        }

       AttackTimeCount( );

	}
	//-------------------------------------------------------------------------------------------------------------------------------

	//逃げる-----------------------------------------------------------------------------------
	void Escape( ) {

		//目的地に到達していたら次の目的地を探す
		if ( _arrival ) {

            //バグ回避のため最初だけ強制的に逃げる場所を決める---------------------------------------------------------------------
			if ( !_initial_destination ) {
				_escape_area_num = Random.Range( 0, _escape_area.Length );
				GameObject initial_escape_area = _escape_area[ _escape_area_num ].gameObject;
				int initial_escape_point_num = Random.Range( 0, initial_escape_area.transform.childCount );
				GameObject initial_escape_point = initial_escape_area.transform.GetChild( initial_escape_point_num ).gameObject;
				_escape_point = initial_escape_point.GetComponent<EscapePoint>( );
				_agent.SetDestination( initial_escape_point.transform.position );

				_initial_destination = true;
			}
            //---------------------------------------------------------------------------------------------------------------------

			//怪獣が居ないエリアを探す-------------------------------------------
			int count = 0;      //ループで探す回数（バグ回避用）
			do {
				_escape_area_num = Random.Range( 0, _escape_area.Length );
				count++;
				if ( count > 10 )
					return;
			} while ( _escape_area[ _escape_area_num ].getIntrusionArea( ) );
			//----------------------------------------------------------------

			//見つけたエリアのGameObjectを取得
			GameObject escape_area = _escape_area[ _escape_area_num ].gameObject;

			//見つけたエリアのポイントをランダムに決定
			int escape_point_num = Random.Range( 0, escape_area.transform.childCount );

			//見つけたエリアのポイントの情報を取得
			GameObject escape_point = escape_area.transform.GetChild( escape_point_num ).gameObject;
			_escape_point = escape_point.GetComponent<EscapePoint>( );

			//ポイントまで逃げる
			_agent.SetDestination( escape_point.transform.position );

			//目的地に着いていないことにする
            _enemy_anim_ctrl.setWalkAnimFlag( true );                //移動アニメーションフラグを立てる
			_arrival = false;
		}

		//ポイントに入ったらに変更する
		if ( _escape_point.getIntrusionPoint( ) ) {
            _enemy_anim_ctrl.setWalkAnimFlag( false );               //移動アニメーションフラグを消す
			_arrival = true;    //目的地についたことにする
		}
	}
	//------------------------------------------------------------------------------------------

	void EnemyAction( ) {
		Vector3 check_pos = ( _player.transform.position - transform.position ).normalized;
		float length = _attack_distance - ( _attack_distance - _avoid_distance ) / 2;				//移動する長さ
		LayerMask playerLayer = 1 << LayerMask.NameToLayer( "Player" );

		if ( Physics.CheckSphere( transform.position, _avoid_distance, playerLayer ) ) {             //第一範囲内にいたらプレイヤーから離れる
			_attack = false;                                                                        //攻撃フラグを消す
                    
			_agent.SetDestination( _player.transform.position + -check_pos * length );				//プレイヤーから一定距離離れる

		} else if ( Physics.CheckSphere( transform.position, _attack_distance, playerLayer ) ) {    //第二範囲内にいたら停止する
			_attack = true;                                                                         //攻撃フラグを立てる

			_agent.SetDestination( _player.transform.position + -check_pos * length );              //第二範囲内の中央に移動する
			transform.LookAt( _player.transform.position );                                         //常にプレイヤーの方向に向いているようにする

		} else {
			_attack = false;                                                                        //攻撃フラグを消す    
      
			_agent.SetDestination( _player.transform.position );                                    //プレイヤーを追従する
		}
	}

	void AttackTimeCount( ) {
		 //攻撃時間を減らしていく
		_attack_time -= Time.deltaTime;

		//攻撃する時間が過ぎたら逃げるパートへ
		if ( _attack_time < 0 ) {
            _enemy_anim_ctrl.setAttackAnimFlag( false );
            _enemy_anim_ctrl.setWalkAnimFlag( true );
			_status = STATUS.ESCAPE;
		}
	}

    public void BulletInstantiate( ) { 
        Vector3 shell_pos = transform.position + ( _player.transform.position - transform.position ).normalized * _bullet_pos;
	    Instantiate( _bullet, shell_pos, Quaternion.identity );
        _enemy_attack_sound.Play( );

		_attack_wait_count = _attack_wait_time;
    }
}
