using UnityEngine;

public class Building : MonoBehaviour {
	public enum BUILDING_TYPE {
		SMALL_TYPE_1,
		SMALL_TYPE_2,
		BIG_TYPE_1,
		BIG_TYPE_2,
		BIG_TYPE_3,
		MAX_TYPE
	}

	[SerializeField] GameObject _explosion = null;
	//[SerializeField] GameObject _debris = null;
	[SerializeField] AudioSource breaking_SE = null;
	//int _debris_num = 0;
	float _stop_time_small1 = 0;
	float _stop_time_small2 = 0;

	ScoreManager _score_manager = null;
	bool _crash = false;                         //一回壊したかどうか	


	void Start ( ) {
		//_debris_num = PrefabCSV._debris_num;
		_stop_time_small1 = PrefabCSV._stop_time_small1;
		_stop_time_small2 = PrefabCSV._stop_time_small2;
		
		_score_manager = GameObject.Find( "ScoreManager" ).GetComponent<ScoreManager>( );
	}

	// Update is called once per frame
	void Update ( ) {
	}

	void OnCollisionEnter ( Collision collision ) {
		if ( collision.gameObject.tag != "Player" ) {
			return;
		}

		Player._movable = false;

		if ( gameObject.tag == "BuildingSmallType1" ) {
			Player._stop_time = _stop_time_small1;
			CrashJudge( BUILDING_TYPE.SMALL_TYPE_1 );
		}

		if ( gameObject.tag == "BuildingSmallType2" ) {
			Player._stop_time = _stop_time_small2;
			CrashJudge( BUILDING_TYPE.SMALL_TYPE_2 );
		}
	}

	private void OnParticleCollision ( GameObject other ) {
		if ( other.tag != "Fire" && other.tag != "DeathBlowEffect" )
			return;

		if ( gameObject.tag == "BuildingSmallType1" )
			CrashJudge( BUILDING_TYPE.SMALL_TYPE_1 );

		if ( gameObject.tag == "BuildingSmallType2" )
			CrashJudge( BUILDING_TYPE.SMALL_TYPE_2 );

		if ( gameObject.tag == "BuildingBigType1" )
			CrashJudge( BUILDING_TYPE.BIG_TYPE_1 );

		if ( gameObject.tag == "BuildingBigType2" )
			CrashJudge( BUILDING_TYPE.BIG_TYPE_2 );

		if ( gameObject.tag == "BuildingBigType3" )
			CrashJudge( BUILDING_TYPE.BIG_TYPE_3 );
	}

	//壊れた建物のタイプに応じての処理-----------------------------------------------------
	void CrashJudge ( BUILDING_TYPE type ) {
		if ( _crash ){
			return;                      //一回も壊していなかったら壊す
		}
		switch ( type ) {
			case BUILDING_TYPE.SMALL_TYPE_1:
				_score_manager.AddScore( ScoreManager.SCORE_TYPE.BUILDING_SMALL_TYPE_1 );
				break;

			case BUILDING_TYPE.SMALL_TYPE_2:
				_score_manager.AddScore( ScoreManager.SCORE_TYPE.BUILDING_SMALL_TYPE_2 );
				break;

			case BUILDING_TYPE.BIG_TYPE_1:
				_score_manager.AddScore( ScoreManager.SCORE_TYPE.BUILDING_BIG_TYPE_1 );
				break;

			case BUILDING_TYPE.BIG_TYPE_2:
				_score_manager.AddScore( ScoreManager.SCORE_TYPE.BUILDING_BIG_TYPE_2 );
				break;

			case BUILDING_TYPE.BIG_TYPE_3:
				_score_manager.AddScore( ScoreManager.SCORE_TYPE.BUILDING_BIG_TYPE_3 );
				break;

			default:
				break;
		}

		BuildingCrash( );

		_crash = true;      //一回壊したらフラグを立てる
	}
	//----------------------------------------------------------------------------------

	//建物が壊れる瞬間の処理-------------------------------------------------------
	void BuildingCrash ( ) {
		breaking_SE.Play( );

		//瓦礫生成
        //モデルが無いため一時的にコメントアウト
		/*for ( int i = 0; i < _debris_num; i++ ) {
			Instantiate( _debris, transform.position, Quaternion.identity );
		}*/

        Vector3 explosion_shift_pos = new Vector3( 5, 0, 0 ); //エフェクトの中心座標がずれているための緊急措置
		Instantiate( _explosion, transform.position + explosion_shift_pos, Quaternion.identity );     //爆発生成


		Destroy( gameObject );                                                  //建物削除
		//gameObject.SetActive( false );										//建物復活用
	}
	//--------------------------------------------------------------------------

	public void ReCrash ( ) {
		_crash = false;
	}
}