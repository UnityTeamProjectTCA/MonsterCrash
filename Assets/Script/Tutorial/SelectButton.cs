using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BUTTON {
	LEFT_BUTTON,
	RIGHT_BUTTON
}

public class SelectButton : MonoBehaviour {
	[SerializeField] Button[ ] _button = null;
	bool _selected = false;
	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _button[ ( int )BUTTON.LEFT_BUTTON ].IsActive( ) && !_selected ) {
			_button[ ( int )BUTTON.RIGHT_BUTTON ].Select( );
			_selected = true;
		}
		if ( Input.GetAxisRaw( "Horizontal" ) >= 0.5 ) {
			_button[ ( int )BUTTON.RIGHT_BUTTON ].Select( );
		}
		if ( Input.GetAxisRaw( "Horizontal" ) <= -0.5 ) {
			_button[ ( int )BUTTON.LEFT_BUTTON ].Select( );
		}
	}
}
