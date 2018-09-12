using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder( -1 )]

public class ResultCSV : LoadCSV {
	enum VARIABLE_NAME {
		TIME_COUNT,
		BLINK_SPEED,
		TARGET_SCENE
	};

	public static float _time_count = 0;
	public static float _blink_speed = 0;
	public static string _target_scene = "";

	// Use this for initialization
	void Start ( ) {
		loadCSV( );
		_time_count = float.Parse( _csvData[ ( int )VARIABLE_NAME.TIME_COUNT ][ ( int )PROPERTY.VALUE ] );
		_blink_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.BLINK_SPEED ][ ( int )PROPERTY.VALUE ] );
		_target_scene = _csvData[ ( int )VARIABLE_NAME.TARGET_SCENE ][ ( int )PROPERTY.VALUE ];
	}

	// Update is called once per frame
	void Update ( ) {

	}
}
