using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public enum TEXT_SET_NUM {
		SET_1,
		SET_2,
		SET_3,
		SET_4,
		SET_5,
		SET_6,
        SET_7
	}

    public enum PURPOSE_TEXT { 
        CRASH,
        ENEMY,
        DEATHBLOW
    }

	[SerializeField] AudioSource SE_Text = null;
	[SerializeField] Text _text = null;
	[SerializeField] string[ ] _text_set_1 = new string[ 1 ];
	[SerializeField] string[ ] _text_set_2 = new string[ 1 ];
	[SerializeField] string[ ] _text_set_3 = new string[ 1 ];
	[SerializeField] string[ ] _text_set_4 = new string[ 1 ];
	[SerializeField] string[ ] _text_set_5 = new string[ 1 ];
	[SerializeField] string[ ] _text_set_6 = new string[ 1 ];
    [SerializeField] string[ ] _text_set_7 = new string[ 1 ];

    [SerializeField] Text _purpose_text = null;
    [SerializeField] string[ ] _purpose_text_set = new string[ 1 ];

    TEXT_SET_NUM _text_set_num = TEXT_SET_NUM.SET_1;
    PURPOSE_TEXT _purpose_text_num = PURPOSE_TEXT.CRASH;
	int _text_index = -1;
	bool[ ] _talk_end_flag = new bool[ 7 ];
	//bool _is_talk;
	// Use this for initialization
	void Start( ) {
	}
	
	// Update is called once per frame
	void Update( ) {

	}

    //終わったテキストに終了フラグを立てる----------------
	void TalkEnd( ) {
		_text.gameObject.SetActive( false );
		_text_index = -1;
		_talk_end_flag[ ( int )_text_set_num ] = true;
	}
    //----------------------------------------------------

    //トークを進める処理------------------------------------------
	public void Talk( ) {
        //テキストが非表示だったら表示する
		if ( !_text.gameObject.activeInHierarchy ) {
			_text.gameObject.SetActive( true );
		}

        //終了フラグが立っているテキストだったら終了する
		if ( _talk_end_flag[ ( int )_text_set_num ] ) {
			return;
		}

		_text_index++;
		SE_Text.Play ();

        //対応したテキストを進める
		switch ( _text_set_num ) {
		case TEXT_SET_NUM.SET_1:
			if ( _text_index > _text_set_1.Length - 1 ) {
				TalkEnd( );
				return;
			}

			_text.text = _text_set_1[ _text_index ];
			break;

		case TEXT_SET_NUM.SET_2:
			if ( _text_index > _text_set_2.Length - 1 ) {
				TalkEnd( );
				return;
			}

			_text.text = _text_set_2[ _text_index ];
			break;

		case TEXT_SET_NUM.SET_3:
			if ( _text_index > _text_set_3.Length - 1 ) {
				TalkEnd( );
				return;
			}

			_text.text = _text_set_3[ _text_index ];
			break;

		case TEXT_SET_NUM.SET_4:
			if ( _text_index > _text_set_4.Length - 1 ) {
				TalkEnd( );
				return;
			}

			_text.text = _text_set_4[ _text_index ];
			break;

		case TEXT_SET_NUM.SET_5:
			if ( _text_index > _text_set_5.Length - 1 ) {
				TalkEnd( );
				return;
			}

			_text.text = _text_set_5[ _text_index ];
			break;

		case TEXT_SET_NUM.SET_6:
			if ( _text_index > _text_set_6.Length - 1 ) {
				TalkEnd( );
				return;
			}

			_text.text = _text_set_6[ _text_index ];
			break;

        case TEXT_SET_NUM.SET_7:
			if ( _text_index > _text_set_7.Length - 1 ) {
				TalkEnd( );
				return;
			}

			_text.text = _text_set_7[ _text_index ];
			break;

		default:
			break;
		}
	}
    //----------------------------------------------------------

    //目的表示------------------------------------------------
    public void PurposeText( ) {
        _purpose_text.text = _purpose_text_set[ ( int )_purpose_text_num ];
    }
    //---------------------------------------------------------

    public void setPurposeText( PURPOSE_TEXT text ) { 
        _purpose_text_num = text;
    }

    //テキストが終わったかどうかを取得する
    public bool getTextEndFlag( TEXT_SET_NUM text_set ) {
		return _talk_end_flag[ ( int )text_set ];
	}

    //どのテキストを進めるか値を入れる
	public void setTextSetNum( TEXT_SET_NUM text_set ) {
		_text_set_num = text_set;
	}
}
