using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour {

	public enum OBJECT {
		ENEMY,
		START,
		BRACK_BOARD,
		TEXT_BACKGROUND,
		TEXT,
		TEXT_ARROW,
        PURPOSE_TEXT
    };


	[SerializeField] GameObject[ ] _object = new GameObject[ 1 ];

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
	}

	//GameObjectのActiveを切り替える処理--------------------
	public void Active (  OBJECT obj, bool active ) {
		if ( ( int )obj > _object.Length - 1 ) return;
		_object[ ( int )obj ].SetActive( active );

	}
	//---------------------------------------------------

	//GameObjectを消す処理--------------------------------
	public void ActiveDestroy ( OBJECT obj ) {

		if ( ( int )obj > _object.Length - 1 ) return;
		Destroy( _object[ ( int )obj ] );

	}
	//---------------------------------------------------

	//GameObjectのActive状態を調べる処理--------------------
	public bool SearchActive ( OBJECT obj ) {

		if ( ( int )obj > _object.Length - 1) return false;
		return _object[ ( int )obj ].activeInHierarchy;

	}
	//------------------------------------------------------

	//GameObjectが存在しているかどうかを調べる処理-----------------------
	public bool SearchDestroy ( string gameObjectName ) {
		GameObject gameObject = GameObject.Find( gameObjectName );

		if ( gameObject == null ) {
			return false;
		} else {
			return true;
		}
	}
	//--------------------------------------------------------------

	//全てのGameObjectのActiveを切り替える処理---------------------
	public void AllActive ( bool active ) {

		for ( int i = 0; i < _object.Length; i++ ) {
			_object[ i ].SetActive( active );
		}

	}
	//---------------------------------------------------------
}