using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireStamina : MonoBehaviour {
	[SerializeField] Player _player = null;

	Text _text = null;
	// Use this for initialization
	void Start( ) {
		_text = GetComponent<Text>( );
	}
	
	// Update is called once per frame
	void Update( ) {
		_text.text = _player.getFireStamina( ).ToString( );
	}
}
