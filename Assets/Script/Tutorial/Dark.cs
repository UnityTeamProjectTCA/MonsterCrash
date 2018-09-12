using UnityEngine;
using UnityEngine.UI;

public class Dark : MonoBehaviour {
	enum DARK_STATUS {
		FADE_IN,
		WAIT,
		FADE_OUT
	};
		
	[SerializeField] float _setTime = 2f;   		//暗転する時間
	[SerializeField] float _fade_speed = 1f;		//フェードイン・アウトする速さ
	[SerializeField] Player _player = null;

	DARK_STATUS _dark_status = DARK_STATUS.FADE_IN;
	float _time = 0;                            	//暗転の残り時間
	bool _dark = false;								//暗転しているかどうか
	Color _brack = new Color ( 0, 0, 0, 0 );		//黒色の板

	// Use this for initialization
	void Start( ) {
	}
	
	// Update is called once per frame
	void Update( ) {
		DarkFlow( );
	}

	//ステータスでやったほうがいいかも
	//暗転(初期位置に戻す)------------------------------------------------------
	void DarkFlow( ) {
		if ( !_dark ) {
			return;
		}

		switch (_dark_status) {
		case DARK_STATUS.FADE_IN:
			DarkFadeIn( );
			break;

		case DARK_STATUS.WAIT:
			DarkWait( );
			break;

		case DARK_STATUS.FADE_OUT:
			DarkFadeOut( );
			break;

		default:
			break;
		}
	}
	//-------------------------------------------------------------------------


	//暗転（フェードイン）-----------------------------------
	void DarkFadeIn( ) {
		_brack.a += _fade_speed * Time.deltaTime;
		gameObject.GetComponent<Image>( ).color = _brack;

		if ( _brack.a > 1 ) {
			_dark_status = DARK_STATUS.WAIT;
		}
	}
	//---------------------------------------------------


	//暗転（待機）------------------------------------
	void DarkWait( ) {
		_time -= Time.deltaTime;
		_player.ResetPosAndDir( );

		if ( _time < 0 ) {
			_dark_status = DARK_STATUS.FADE_OUT;
		}
	}
	//---------------------------------------------


	//暗転（フェードアウト）------------------------------------
	void DarkFadeOut( ) {
		_brack.a -= _fade_speed * Time.deltaTime;
		gameObject.GetComponent<Image>( ).color = _brack;

		if ( _brack.a < 0 ) {
			_dark_status = DARK_STATUS.FADE_IN;
			_dark = false;
		}
	}
	//------------------------------------------------------


	//暗転をスタートさせる関数
	public void StartDark( ) {
		_time = _setTime;
		_dark = true;
	}

	public bool getDark( ) {
		return _dark;
	}

}
