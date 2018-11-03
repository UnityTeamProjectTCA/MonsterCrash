using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {
   //[SerializeField] Slider _slider          = null;
   //[SerializeField] GameObject _load_UI     = null;
   // AsyncOperation _async   = null;
   [SerializeField] Dark _feid_in = null;
    AudioSource _submit_SE  = null;
	bool _sound_flag        = false;

	// Use this for initialization
	void Start ( ) {
        _submit_SE = GameObject.Find( "Submit_SE" ).GetComponent< AudioSource >( );
	}

	// Update is called once per frame
	void Update ( ) {
        /*フェードインをしているときはボタンを押しても反応しないようにしたはずだが
        *フェードイン中にボタンを押すとCanvasが削除されるまでの時間が長くなる(バグ？理由不明)*/
		if ( Input.GetButtonDown( "Submit" ) && !_sound_flag && !_feid_in.getDark( ) ) {
			_submit_SE.Play( );
			_sound_flag = true;
		}
		if ( ( _submit_SE.time >= _submit_SE.clip.length ) && !_feid_in.getDark( ) ) {
			_sound_flag = false;
			ScoreManager._score = 0;
			SceneManager.LoadScene( "Game" );
            //NextScene( );
		}
	}

    /*void NextScene( ) { 
        _load_UI.SetActive( true );
        _slider.gameObject.SetActive( true );
        StartCoroutine( "LoadData" );   //シーンを非同期にロードする
    }

    IEnumerator LoadData( ) { 
        _async = SceneManager.LoadSceneAsync( "Game" );
        
        while( !_async.isDone ) {   //読み込みが完了したかどうか 
            float progressval = Mathf.Clamp01( _async.progress / 0.9f );        //0～1の間で値を返す
            _slider.value = progressval;
            yield return null;
        }
    }*/

}