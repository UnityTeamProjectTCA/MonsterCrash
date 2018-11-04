using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieSwitch : MonoBehaviour {
	[SerializeField] GameObject _title_canvas_prefub = null;
	[SerializeField] GameObject _movie_prefub        = null; 
    [SerializeField] GameObject _title_canvas        = null;

    [SerializeField] Dark _feid_in             = null;
    [SerializeField] float _set_timer = 10f;

    GameObject _movie = null;
    Vector3 _title_canvas_pos = Vector3.zero;
    Vector3 _move_pos = new Vector3( 0, 1, 1 );
    Vector3 _move_dir = new Vector3( -90, 0, 0 );
	float _timer = 0;
    bool  _is_feid_in = false;

	// Use this for initialization
	void Start( ) {
        _title_canvas_pos = _title_canvas.GetComponent< RectTransform >( ).transform.position;
	}
	
	// Update is called once per frame
	void Update( ) {
	    if ( Input.anyKeyDown && !_is_feid_in ) {
	    	_timer = 0;
	    }

        SwitchMovie( );
		SwitchTitleScene( );
	}

    //デモムービーに切り替える処理--------------------------------------------------------
    void SwitchMovie( ) { 
        if ( _title_canvas == null && _feid_in == null && _movie != null ) {
            return;
        }

	    _timer += Time.deltaTime;

		if ( _timer > _set_timer ) {

            //フェードインをしていなくて一度もフェードインをしていなかったら--
            if( !_feid_in.getDark( ) && !_is_feid_in ) {
                _feid_in.StartDark( );      //フェードイン開始
                _is_feid_in = true;         //フェードインしたかどうか
            }
            //----------------------------------------------------------------

            //フェードインをしていなくて一度フェードインをしていたら---------------------
            if ( !_feid_in.getDark( ) && _is_feid_in ) {
			    Destroy ( _title_canvas );
			    _movie = Instantiate ( _movie_prefub, _move_pos, Quaternion.identity );
                _movie.transform.eulerAngles = _move_dir;
                _is_feid_in = false;        //フェードインフラグをリセット
            }
            //---------------------------------------------------------------------------
		}
    }
    //--------------------------------------------------------------------------------------

    //タイトル画面に切り替える処理----------------------------------------------------------------------------
    void SwitchTitleScene( ) { 
        if ( _movie == null && _title_canvas ) {
            return;
        }

		if ( Input.anyKeyDown ) {
	        Destroy ( _movie );
            
            _title_canvas = Instantiate( _title_canvas_prefub, _title_canvas_pos, Quaternion.identity );
            _feid_in = GameObject.Find( "FeidIn" ).GetComponent< Dark >( );     //取得しなおし
		}
    }
    //--------------------------------------------------------------------------------------------------------

}
