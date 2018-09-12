using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextArrow : MonoBehaviour {
	[SerializeField] float _speed = 1f;

	Color _initial_color = new Color( 0, 0, 0, 0 );
	Color _arrow_color = new Color( 0, 0, 0, 0 );
	bool _transmission = true;
	// Use this for initialization
	void Start( ) {
		_initial_color = gameObject.GetComponent<Image>( ).color;
		_arrow_color = _initial_color;
	}
	
	// Update is called once per frame
	void Update( ) {
		FlashingJudge( );
		Flashing( );
		if ( !this.gameObject.activeInHierarchy ) ResetArrowColor( );
	}

	//点滅------------------------------------------------
	void Flashing( ) {
		//透明フラグが立っていたら透明にする。いなかったら元に戻す
		if ( _transmission ) {
			_arrow_color.a -= _speed * Time.deltaTime;
		} else {
			_arrow_color.a += _speed * Time.deltaTime;
		}

		GetComponent<Image>( ).color = _arrow_color;
	}
	//----------------------------------------------------

	//透明にするか元に戻すかの判定------------------
	void FlashingJudge( ) {
		//透明度が最小値までいったら透明フラグを消す
		if ( _arrow_color.a < 0 ) {
			_transmission = false;
		}

		//透明度が最大値までいったら透明フラグを立てる
		if ( _arrow_color.a > 1 ) {
			_transmission = true;
		}
	}
	//-----------------------------------------

	public void ResetArrowColor( ) {
		_arrow_color = _initial_color;
	}

}
