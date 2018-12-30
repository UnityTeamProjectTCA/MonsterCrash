using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMap : MonoBehaviour {
    [SerializeField] EnemySpawn _enemy_make = null;

    [SerializeField] GameObject _player = null;
    [SerializeField] GameObject _camera = null;
    [SerializeField] GameObject _generation_enemy_point = null;
    [SerializeField] GameObject _generation_attention_cursor = null;


	[SerializeField] List<RectTransform> _enemy_points = new List<RectTransform>( );      //エネミーの点を格納する
	[SerializeField] List<DeathJudge> _enemys = new List<DeathJudge>( );            //エネミーを格納する
	[SerializeField] List<RectTransform> _attention_cursors = new List<RectTransform>( ); //注目カーソルを格納する

    float _max_search_range = 0f;                                  //最大探知距離半径
	RectTransform _enemy_point = null;

    // Use this for initialization
    void Start( ) {
		_max_search_range = GameCSV._max_search_range;
    }

    // Update is called once per frame
    void Update( ) {


		EnemyLoad( );
        EnemyDelete( );
        MinMapUpdate( );

        //AttentionCursorDelete( );
        AttentionCursorUpdate( );
    }

    //エネミーが生成された時の処理----------------------------------------------------------------------
    void EnemyLoad( ) {
        GameObject enemy = _enemy_make.getEnemy( );
        if ( enemy == null ) return;                                                                        								//エネミーが生成されているかどうか


		_enemys.Add( enemy.GetComponent<DeathJudge>( ) );                                                                               								//エネミーリストに追加
		_enemy_point = Instantiate( _generation_enemy_point, transform.position, Quaternion.identity ).GetComponent<RectTransform>( );     //エネミーポイント生成
        _enemy_points.Add( _enemy_point );                                                                 									//エネミーポイントリストに追加
        _enemy_point.transform.SetParent( transform, false );                                               								//生成したエネミーポイントをMinMapの子にする


		RectTransform attention_cursor = Instantiate( _generation_attention_cursor, _enemy_point.transform.position, Quaternion.identity ).GetComponent<RectTransform>( );
        _attention_cursors.Add( attention_cursor );
        attention_cursor.transform.SetParent( transform, false );

    }
    //--------------------------------------------------------------------------------------------------

    //エネミーが死んだときの処理-----------------------------------------------------------------
    void EnemyDelete( ) {
        if ( _enemys.Count == 0 ) return;

        int i = 0;
        for ( i = 0; i < _enemys.Count; i++ ) {

			if ( _enemys[ i ].getDeathFlag( ) ) {            //エネミーが死んでいるかどうか判定
                _enemys.RemoveAt( i );                      //エネミーリストから削除
                Destroy( _enemy_points[ i ].gameObject );   //エネミーポイントオブジェクトを削除
                _enemy_points.RemoveAt( i );                //エネミーポイントリストから削除

				if ( _attention_cursors[ i ] != null ) Destroy( _attention_cursors[ i ].gameObject );
				_attention_cursors.RemoveAt( i );
                i = 0;                                      //エネミーが同時に死んだときように念のため削除したあとに最初から見直す

            }
        }
    }
    //------------------------------------------------------------------------------------------

    //ミニマップの更新処理---------------------------------------------------------------------------------------------
    void MinMapUpdate( ) {
        if ( _enemys.Count == 0 )
            return;

        if ( _enemy_point == null ) return;

        RectTransform rect_transform = GetComponent<RectTransform>( );
        float min_map_range = rect_transform.rect.width / 2;                                                        //ミニマップの半径を取得


        for ( int i = 0; i < _enemys.Count; i++ ) {
            Vector2 player = new Vector2( _player.transform.position.x, _player.transform.position.z );             //プレイヤー座標を2Dに変換
            Vector2 enemy = new Vector2( _enemys[ i ].transform.position.x, _enemys[ i ].transform.position.z );    //エネミー座標を2Dに変換

            float distance = Vector2.Distance( player, enemy );                                                     //プレイヤーとエネミーの距離を取得
            float min_map_dir = min_map_range / _max_search_range * distance;                                       //ミニマップの半径と最大探知距離半径の割合からミニマップに表示する距離を計算

            if ( min_map_range < min_map_dir ) {                                                                    //ミニマップに表示する距離がミニマップの半径の大きさを超えていたら半径の大きさにする
                min_map_dir = min_map_range;
            }

            //Vector3 direction = _camera.transform.InverseTransformDirection( _enemys[ i ].transform.position ).normalized;  
            Vector3 direction = _camera.transform.InverseTransformPoint( _enemys[ i ].transform.position ).normalized;  //カメラの向いている向きからエネミーいる方向を計算
            Vector2 direction2 = new Vector2( direction.x, direction.z );                                           //カメラの向いている向きからエネミーいる方向を2Dに変換

			_enemy_points[ i ].localPosition = direction2 * min_map_dir;                                               //エネミーポイントに方向と距離を入れる
        }
    }
    //---------------------------------------------------------------------------------------------------------------------------

    void AttentionCursorUpdate( ) {
        if ( _attention_cursors.Count == 0 ) return;
		if ( _enemy_point == null ) return;

        for ( int i = 0; i < _attention_cursors.Count; i++ ) {
			if ( _attention_cursors[ i ] == null ) continue;

			_attention_cursors[ i ].transform.position = _enemy_point.transform.position;
        }

    }

    void AttentionCursorDelete( ) {
        if ( _attention_cursors.Count == 0 ) return;

        int i = 0;
        for ( i = 0; i < _attention_cursors.Count; i++ ) {
            if ( _attention_cursors[ i ] == null ) {
                _attention_cursors.RemoveAt( i );
                i = 0;
            }
        }

    }
}