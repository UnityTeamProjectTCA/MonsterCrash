using UnityEngine;

public class MoveLimit : MonoBehaviour {
	enum WALL {
		FORWARD,
		BACK,
		LEFT,
		RIGHT
	}

	const float WALL_POS_Y = 25f;
	const float WALL_RIGHT_ANGLE = 90f;

	[SerializeField] GameObject _player = null;
	[SerializeField] GameObject[ ] _wall = new GameObject[ 4 ];

	float _shift_pos = 0;

	// Use this for initialization
	void Start ( ) {
		_shift_pos = GameCSV._shift_pos;

		WallArrangement( );
	}

	// Update is called once per frame
	void Update ( ) {
		moveLimit( );
	}

	void moveLimit ( ) {
		//マップのスケールによって移動限界位置を調整
		float moveable_x = GetComponent<Renderer>( ).bounds.size.x / 4;
		float moveable_z = GetComponent<Renderer>( ).bounds.size.z / 4;

		//怪獣が見えない壁よりさきに行かないようにする
		if ( _player.transform.position.x >= transform.position.x + moveable_x ) {
			_player.transform.position = new Vector3( transform.position.x + moveable_x, _player.transform.position.y, _player.transform.position.z );
		}
		if ( _player.transform.position.x <= transform.position.x - moveable_x ) {
			_player.transform.position = new Vector3( transform.position.x - moveable_x, _player.transform.position.y, _player.transform.position.z );
		}
		if ( _player.transform.position.z >= transform.position.z + moveable_z ) {
			_player.transform.position = new Vector3( _player.transform.position.x, _player.transform.position.y, transform.position.z + moveable_z );
		}
		if ( _player.transform.position.z <= transform.position.z - moveable_z ) {
			_player.transform.position = new Vector3( _player.transform.position.x, _player.transform.position.y, transform.position.z - moveable_z );
		}
	}

	void WallArrangement( ) { 
		float moveable_x = GetComponent<Renderer>( ).bounds.size.x / 4;
		float moveable_z = GetComponent<Renderer>( ).bounds.size.z / 4;

		_wall[ ( int )WALL.LEFT ].transform.position = new Vector3( transform.position.x + moveable_x + _shift_pos, WALL_POS_Y, 0 );
		_wall[ ( int )WALL.LEFT ].transform.Rotate( new Vector3( 0, WALL_RIGHT_ANGLE, 0 ) );

		_wall[ ( int )WALL.RIGHT ].transform.position = new Vector3( transform.position.x - moveable_x - _shift_pos, WALL_POS_Y, 0 );
		_wall[ ( int )WALL.RIGHT ].transform.Rotate( new Vector3( 0, WALL_RIGHT_ANGLE, 0 ) );

		_wall[ ( int )WALL.FORWARD ].transform.position = new Vector3( 0, WALL_POS_Y, transform.position.z + moveable_z + _shift_pos );
		_wall[ ( int )WALL.FORWARD ].transform.Rotate( new Vector3( 0, 0, 0 ) );

		_wall[ ( int )WALL.BACK ].transform.position = new Vector3( 0, WALL_POS_Y, transform.position.z - moveable_z - _shift_pos );
		_wall[ ( int )WALL.BACK ].transform.Rotate( new Vector3( 0, 0, 0 ) );
	}
}
