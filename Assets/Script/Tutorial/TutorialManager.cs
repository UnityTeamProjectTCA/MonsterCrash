using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
	
//	enum CHECK_POINT {
//		TEXT_SET_1_SAW,
//		BUILDING_CRASH,
//		TEXT_SET_2_SAW,
//		TEXT_SET_3_SAW,
//		ENEMY_DEFEAT,
//		TEXT_SET_4_SAW,
//		TEXT_SET_5_SAW,
//		DEATHBLOW_USE,
//		TEXT_SET_6_SAW,
//        TEXT_SET_7_SAW,
//		TUTORIAL_END
//	}   


//	enum PART {
//		TEXT,
//		PLAYER_ACTION,
//		WAIT
//	}

//	[SerializeField] GameObject _obj_player = null;
//	[SerializeField] ActiveManager _activeManager = null;
//	[SerializeField] MaterialChange _player_marerial_change = null;
//	//[SerializeField] MaterialChange _enemy_marerial_change = null;
//	[SerializeField] TextManager _text_manager = null;
//	[SerializeField] Dark _dark = null;
//	[SerializeField] TextArrow _text_arrow = null;
//	[SerializeField] DeathBlowEffect _deathblow_effect = null;
//	[SerializeField] SceneChanger _scene_changer = null;
//	[SerializeField] CameraScript _camera = null;

//	[SerializeField] int _crash_num = 3;    //壊す建物の数

//	Player _player = null;
//	MonAniCtrl _mon_ctrl = null;
//	CHECK_POINT _check_point;
//	PART _part = PART.TEXT;
//	bool _fast_talk = false;					//文章を最初だけ表示する
//	bool _is_player_move = false;               //怪獣が移動できるかどうか
//	bool _is_player_attack = false;             //怪獣が攻撃できるかどうか
//	bool _is_player_deathblow = false;          //怪獣が必殺技ができるかどうか
//	bool _is_walk_anim = false;                 //怪獣が移動アニメーションをするかどうか
//	bool _is_attack_anim = false;               //怪獣が攻撃アニメーションをするかどうか
//	//bool _camera_move =false;					//カメラを動かせるかどうか

//    // Use this for initialization
//    void Start ( ) {
//		_player = _obj_player.GetComponent<Player>( );
//		_mon_ctrl = _obj_player.GetComponent<MonAniCtrl>( );
//		_check_point = CHECK_POINT.TEXT_SET_1_SAW;
//		_part = PART.TEXT;
//		_fast_talk = false;					//文章を最初だけ表示する
//		_is_player_move = false;               //怪獣が移動できるかどうか
//		_is_player_attack = false;             //怪獣が攻撃できるかどうか
//		_is_player_deathblow = false;          //怪獣が必殺技ができるかどうか
//		_is_walk_anim = false;                 //怪獣が移動アニメーションをするかどうか
//		_is_attack_anim = false;               //怪獣が攻撃アニメーションをするかどうか

//		Player._playable = true;			   //怪獣を動けるようにする
//	}

//	// Update is called once per frame
//	void Update ( ) {

//		switch ( _part ) {
//		case PART.TEXT:
//			TextPart( );
//			break;

//		case PART.PLAYER_ACTION:
//			PlayerActionPart( );
//			break;

//		case PART.WAIT:
//			WaitPart( );
//			break;

//		default:
//			break;
//		}
			
//		CheckPointUpdate( );
//	}


//	void TextPart( ) {
//		//プレイヤーの操作をすべて止める---------
//		_player.setIsMove( false );
//		_player.setIsShot( false );
//		_player.setIsDeathblow( false );
//		_player.StopFire( );
//		_mon_ctrl.setIsWalkAnim( false );
//		_mon_ctrl.setIsAttackAnim( false );
//		_camera.setIsMove( false );
//		//----------------------------------

//		//TextBackgoundが表示されていなかったら表示する------------------------------------
//		if ( !_activeManager.SearchActive( ActiveManager.OBJECT.TEXT_BACKGROUND ) ) {
//			_activeManager.Active( ActiveManager.OBJECT.TEXT_BACKGROUND, true );
//		}
//		//----------------------------------------------------------------------------


//        if ( _activeManager.SearchActive( ActiveManager.OBJECT.PURPOSE_TEXT ) ) { 
//            _activeManager.Active( ActiveManager.OBJECT.PURPOSE_TEXT, false );    
//        }


//		//TextArrow処理-------------------------------------------------------------------------------
//		if ( !_activeManager.SearchActive( ActiveManager.OBJECT.TEXT_ARROW ) && !_dark.getDark( ) ) {	//表示されていなくて暗転状態でなかったら表示する
//			_activeManager.Active( ActiveManager.OBJECT.TEXT_ARROW, true );

//		} else if ( _dark.getDark( ) ) {																//暗転状態だったら非表示にする
//			_activeManager.Active( ActiveManager.OBJECT.TEXT_ARROW, false );

//		}
//		//--------------------------------------------------------------------------------------------

//		//最初のトークをしていなくて暗転状態でなかったら------------
//		if ( !_fast_talk && !_dark.getDark( ) ) {
//			_text_manager.Talk( );				//トークを進める
//			_fast_talk = true;					//最初の一回だけ
//			return;								//不具合回避
//		}
//		//--------------------------------------------------


//		//ボタンを押して暗転状態でなかったら----------------------------------
//		if ( Input.GetButtonDown( "Decision" ) && !_dark.getDark( ) ) {
//			_text_manager.Talk( );				//トークを進める
//			_text_arrow.ResetArrowColor( );		//TextArrowの点滅をリセットする（見栄え）
//		}
//		//--------------------------------------------------------------
//	}

//	void PlayerActionPart( ) {
//		//プレイヤーの操作を縛る-----------------------------
//		_player.setIsMove( _is_player_move );
//		_player.setIsShot( _is_player_attack );
//		_player.setIsDeathblow( _is_player_deathblow );
//		_mon_ctrl.setIsWalkAnim( _is_walk_anim );
//		_mon_ctrl.setIsAttackAnim( _is_attack_anim );
//		_camera.setIsMove( true );
//		//-----------------------------------------------

//		//テキスト関連のものが表示されていたら非表示にする------------------------------------
//		if ( _activeManager.SearchActive( ActiveManager.OBJECT.TEXT_BACKGROUND ) ) {
//			_activeManager.Active( ActiveManager.OBJECT.TEXT_BACKGROUND, false );
//		}

//		if ( _activeManager.SearchActive( ActiveManager.OBJECT.TEXT_ARROW ) ) {
//			_activeManager.Active( ActiveManager.OBJECT.TEXT_ARROW, false );
//		}
//		//----------------------------------------------------------------------------

//        if ( !_activeManager.SearchActive( ActiveManager.OBJECT.PURPOSE_TEXT ) ) { 
//            _activeManager.Active( ActiveManager.OBJECT.PURPOSE_TEXT, true );    
//        }
        
//        _text_manager.PurposeText( );

//	}

//	void WaitPart( ) {
//		//プレイヤーの操作を全て操作不能にしてText関連のものも全て非表示にする

//		_player.setIsMove( false );
//		_player.setIsShot( false );
//		_player.setIsDeathblow( false );
//		_player.StopFire( );
//		_mon_ctrl.setIsWalkAnim( false );
//		_mon_ctrl.setIsAttackAnim( false );

//		if ( _activeManager.SearchActive (ActiveManager.OBJECT.TEXT_BACKGROUND ) ) {
//			_activeManager.Active( ActiveManager.OBJECT.TEXT_BACKGROUND, false );
//		}

//		if ( _activeManager.SearchActive( ActiveManager.OBJECT.TEXT_ARROW ) ) {
//			_activeManager.Active( ActiveManager.OBJECT.TEXT_ARROW, false );
//		}

//        if ( _activeManager.SearchActive( ActiveManager.OBJECT.PURPOSE_TEXT ) ) { 
//            _activeManager.Active( ActiveManager.OBJECT.PURPOSE_TEXT, false );    
//        }
//	}
		
//    //チェックポイントを超えたら次に備えてする処理--------------------------------------
//	void CheckPointUpdate( ) {
//		switch ( _check_point ) {
//        //テキスト１を読む----------------------------------------------------------------------------------
//		case CHECK_POINT.TEXT_SET_1_SAW:
//			if (  _text_manager.getTextEndFlag( TextManager.TEXT_SET_NUM.SET_1 ) ) {    //テキスト１を読んだら
//				_check_point = CHECK_POINT.BUILDING_CRASH;                              //チェックポイント更新

//				_player_marerial_change.setIsFlashing( false );                         //怪獣の点滅を止める

//				SetPlayerActionPart( true, false, false, TextManager.PURPOSE_TEXT.CRASH );                              //プレイヤー操作パートへ
//			}
//			break;
//        //--------------------------------------------------------------------------------------------------
        

//        //建物を一定数壊す----------------------------------------------------------------------------------
//		case CHECK_POINT.BUILDING_CRASH:
//			if ( _player.getCrashCount( ) >= _crash_num ) {                             //建物を一定数壊したら
//				_check_point = CHECK_POINT.TEXT_SET_2_SAW;                              //チェックポイント更新

//				SetTextPart( TextManager.TEXT_SET_NUM.SET_2 );                          //テキストパートへ
//			}
//			break;
//        //--------------------------------------------------------------------------------------------------


//        //テキスト２を読む----------------------------------------------------------------------------------
//		case CHECK_POINT.TEXT_SET_2_SAW:
//			if ( _text_manager.getTextEndFlag( TextManager.TEXT_SET_NUM.SET_2 ) ) {     //テキスト２を読んだら
//				_check_point = CHECK_POINT.TEXT_SET_3_SAW;                              //チェックポイント更新

//				_activeManager.Active( ActiveManager.OBJECT.ENEMY, true );              //エネミー表示
//				_dark.StartDark( );                                                           //暗転(初期位置に戻す)

//				SetTextPart( TextManager.TEXT_SET_NUM.SET_3 );                          //テキストパートへ
//			}
//			break;
//        //---------------------------------------------------------------------------------------------------


//        //テキスト３を読む----------------------------------------------------------------------------------
//		case CHECK_POINT.TEXT_SET_3_SAW:
//			if ( _text_manager.getTextEndFlag( TextManager.TEXT_SET_NUM.SET_3 ) ) {     //テキスト３を読んだら
//				_check_point = CHECK_POINT.ENEMY_DEFEAT;                                //チェックポイント更新

//				//_enemy_marerial_change.setIsFlashing( false );

//				SetPlayerActionPart( true, true, false, TextManager.PURPOSE_TEXT.ENEMY );                               //プレイヤー操作パートへ
//			}
//			break;
//        //---------------------------------------------------------------------------------------------------


//        //エネミーを倒す-------------------------------------------------------------------------------------
//		case CHECK_POINT.ENEMY_DEFEAT:
//			if ( !_activeManager.SearchDestroy( "Enemy1" ) ) {                          //エネミーを倒したら
//				_check_point = CHECK_POINT.TEXT_SET_4_SAW;                              //チェックポイント更新

//				SetTextPart( TextManager.TEXT_SET_NUM.SET_4 );                          //テキストパートへ
//			}
//			break;
//        //---------------------------------------------------------------------------------------------------


//        //テキスト４を読む----------------------------------------------------------------------------------
//		case CHECK_POINT.TEXT_SET_4_SAW:
//			if ( _text_manager.getTextEndFlag( TextManager.TEXT_SET_NUM.SET_4 ) ) {     //テキスト４を読んだら
//				_check_point = CHECK_POINT.TEXT_SET_5_SAW;                              //チェックポイント更新

//				_dark.StartDark( );                                                           //暗転(初期位置に戻す)

//				SetTextPart( TextManager.TEXT_SET_NUM.SET_5 );                          //テキストパートへ
//			}
//			break;
//        //---------------------------------------------------------------------------------------------------


//        //テキスト５を読む----------------------------------------------------------------------------------
//		case CHECK_POINT.TEXT_SET_5_SAW:
//			if ( _text_manager.getTextEndFlag( TextManager.TEXT_SET_NUM.SET_5 ) ) {     //テキスト５を読んだら
//				_check_point = CHECK_POINT.DEATHBLOW_USE;                               //チェックポイント更新

//				SetPlayerActionPart( false, false, true, TextManager.PURPOSE_TEXT.DEATHBLOW );                              //プレイヤー操作パートへ
//			}
//			break;
//        //---------------------------------------------------------------------------------------------------


//        //必殺技を使う---------------------------------------------------------------------------------------
//		case CHECK_POINT.DEATHBLOW_USE:
//			if ( _deathblow_effect.getEndEffect( ) ) {                                  //必殺技を最後まで再生したら                  
//				_check_point = CHECK_POINT.TEXT_SET_6_SAW;                              //チェックポイント更新

//				SetTextPart( TextManager.TEXT_SET_NUM.SET_6 );                          //テキストパートへ
//			}
//			break;
//        //----------------------------------------------------------------------------------------------------

        
//        //テキスト６を読む----------------------------------------------------------------------------------
//		case CHECK_POINT.TEXT_SET_6_SAW:
//			if ( _text_manager.getTextEndFlag( TextManager.TEXT_SET_NUM.SET_6 ) ) {     //テキスト６を読んだら
//				_check_point = CHECK_POINT.TEXT_SET_7_SAW;                              //チェックポイント更新

//                _dark.StartDark( );                                                           //暗転(初期位置に戻す)

//                SetTextPart( TextManager.TEXT_SET_NUM.SET_7 );                          //テキストパートへ
//			}
//			break;
//        //----------------------------------------------------------------------------------------------------
        

//        //テキスト７を読む----------------------------------------------------------------------------------
//        case CHECK_POINT.TEXT_SET_7_SAW:
//			if ( _text_manager.getTextEndFlag( TextManager.TEXT_SET_NUM.SET_7 ) ) {     //テキスト７を読んだら
//				_check_point = CHECK_POINT.TUTORIAL_END;                                //チェックポイント更新

//				_activeManager.Active( ActiveManager.OBJECT.START, true );        //スタートボタンを表示

//				_part = PART.WAIT;
//			}
//			break;
//        //----------------------------------------------------------------------------------------------------

//		case CHECK_POINT.TUTORIAL_END:
//			if ( Input.GetButtonDown( "Decision" ) ) {
//				_scene_changer.sceneChange( );
//			}
//			break;
		
//		default:
//			break;
//		} 

//	}
//    //--------------------------------------------------------------------------------------


//    //プレイヤーに縛りをかけるための関数--------------------------------------
//	void PlayerRstriction( bool is_move, bool is_attack, bool is_deathblow ) {
//		_is_player_move = is_move;
//		_is_walk_anim = is_move;

//		_is_player_attack = is_attack;
//		_is_attack_anim = is_attack;

//		_is_player_deathblow = is_deathblow;
//	}
//    //------------------------------------------------------------------------

//    //テキストパートに入るときの準備関数------------------------------------------
//   void SetTextPart( TextManager.TEXT_SET_NUM text_num ) {
//        _part = PART.TEXT;                                     //パート切り替え
//	    _fast_talk = false;                                    //最初のテキストを表示する
//	    _text_manager.setTextSetNum( text_num );               //表示するテキスト

//    } 
//    //----------------------------------------------------------------------------

//    //プレイヤー操作パートに入るときの準備関数------------------------------------
//    void SetPlayerActionPart( bool move, bool attack, bool deathblow, TextManager.PURPOSE_TEXT purpose_text ) {
//        _text_manager.setPurposeText( purpose_text );
//        _part = PART.PLAYER_ACTION;                            //パート切り替え
//	    PlayerRstriction( move, attack, deathblow );	       //怪獣の操作を縛る(移動・攻撃・必殺技)

//    }
//    //----------------------------------------------------------------------------

}