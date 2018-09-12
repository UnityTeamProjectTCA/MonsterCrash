using UnityEngine;

public class BuildingsReActiveSystem : MonoBehaviour {
	[SerializeField]Transform[ ] _buildings = new Transform[ 1 ];	//BUILDING_TYPEの順番で入れる

	Player _player = null;
	ScoreManager _score_manager = null;
	bool[] _building_is_active = null;

	// Use this for initialization_
	void Start( ) {
		_player = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<Player>( );
		_score_manager = GameObject.Find ( "ScoreManager" ).GetComponent<ScoreManager>( );

		_building_is_active = new bool[ ( int )Building.BUILDING_TYPE.MAX_TYPE ];

		for ( int i = 0; i < _buildings.Length; i++ ) {
			_building_is_active[ i ] = true;
		}
	}

	// Update is called once per frame
	void Update( ) {
		BuildingIsActive( );
		AllCrash( );
	}

	void BuildingIsActive( ) {
		SmallType1IsActive( );	
		SmallType2IsActive( );
		BigType1IsActive( );
		BigType2IsActive( );
	}

	//あえて一つ一つの要素ごとに処理をつけることで余分に繰り返しするのを避けている（処理を軽くしているつもり）------------
	void SmallType1IsActive( ) {
		if ( !_building_is_active[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_1 ] ) return;	//すべて非表示のフラグがたっていたら
	
		for ( int i = 0; i < _buildings[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_1 ].transform.childCount; i++ ) {
			GameObject child = _buildings[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_1 ].transform.GetChild( i ).gameObject;
			if ( child.activeInHierarchy ) return;										//ひとつでも表示されていたら
		}

		_building_is_active[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_1 ] = false;			//すべて非表示だったらフラグを立てる
	}

	void SmallType2IsActive( ) {
		if ( !_building_is_active[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_2 ] ) return;	//すべて非表示のフラグがたっていたら

		for ( int i = 0; i < _buildings[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_2 ].transform.childCount; i++ ) {
			GameObject child = _buildings[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_2 ].transform.GetChild( i ).gameObject;
			if ( child.activeInHierarchy ) return;										//ひとつでも表示されていたら
		}

		_building_is_active[ ( int )Building.BUILDING_TYPE.SMALL_TYPE_2 ] = false;			//すべて非表示だったらフラグを立てる
	}

	void BigType1IsActive( ) {
		if ( !_building_is_active[ ( int )Building.BUILDING_TYPE.BIG_TYPE_1 ] ) return;	//すべて非表示のフラグがたっていたら

		for ( int i = 0; i < _buildings[ ( int )Building.BUILDING_TYPE.BIG_TYPE_1 ].transform.childCount; i++ ) {
			GameObject child = _buildings[ ( int )Building.BUILDING_TYPE.BIG_TYPE_1 ].transform.GetChild( i ).gameObject;
			if ( child.activeInHierarchy ) return;										//ひとつでも表示されていたら
		}

		_building_is_active[ ( int )Building.BUILDING_TYPE.BIG_TYPE_1 ] = false;			//すべて非表示だったらフラグを立てる
	}

	void BigType2IsActive( ) {
		if ( !_building_is_active[ ( int )Building.BUILDING_TYPE.BIG_TYPE_2 ] ) return;	//すべて非表示のフラグがたっていたら

		for ( int i = 0; i < _buildings[ ( int )Building.BUILDING_TYPE.BIG_TYPE_2 ].transform.childCount; i++ ) {
			GameObject child = _buildings[ ( int )Building.BUILDING_TYPE.BIG_TYPE_2 ].transform.GetChild( i ).gameObject;
			if ( child.activeInHierarchy ) return;										//ひとつでも表示されていたら
		}

		_building_is_active[ ( int )Building.BUILDING_TYPE.BIG_TYPE_2 ] = false;			//すべて非表示だったらフラグを立てる
	}
	//-----------------------------------------------------------------------------------------------------


	//すべてのタイプの建物が非表示になっていたら処理----------------------
	void AllCrash( ) {

		for ( int i = 0; i < _building_is_active.Length; i++ ) {
			if ( _building_is_active[ i ] ) return;					//一つでも表示されている建物のタイプがあったら
		}

		_player.ResetPosAndDir( );									//プレイヤーの位置を初期位置に戻す（バグ回避）
		_score_manager.AddScore( ScoreManager.SCORE_TYPE.BONUS );	//スコアにボーナスを加算する

		ReActive( );
	}
	//------------------------------------------------------------


	//全ての建物を再度表示する処理----------------------------------------------------
	void ReActive( ) {
		for ( int i = 0; i < _buildings.Length; i++ ) {
			for ( int j = 0; j < _buildings[ i ].transform.childCount; j++ ) {
				GameObject child = _buildings[ i ].transform.GetChild( j ).gameObject;
				child.SetActive( true );
				Building building = child.gameObject.GetComponent<Building>( );
				building.ReCrash( );
			}
		}


		//フラグリセット
		for ( int i = 0; i < _building_is_active.Length; i++ ) {
			_building_is_active[ i ] = true;
		}
	}
	//-----------------------------------------------------------------------------
}
