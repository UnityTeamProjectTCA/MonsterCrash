using UnityEngine;

public class CameraScript : MonoBehaviour {
	const float INIT_ANGLE_X = -Mathf.PI / 2;

	public static float _sway_time_count = 0;
	public static bool _sway_flag = false;

	float _radius = 0;
	float _start_y = 0;
	float _view_up_max = 0;
	float _view_down_max = 0;
	float _sway_speed = 0;
	float _sway_speed_horizontal = 0;
	float _sway_horizontal_max = 0;
	float _sway_angle_max = 0;
	float _camera_move_speed_x = 0;
	float _camera_move_speed_y = 0;

	GameObject _player = null;
	float _camera_width = 0;
	float _camera_width_sway = 0;
	float _camera_depth = 0;
	float _camera_height = 0;
	float _angle_x = 0;
	float _angle_y = 0;
	float _sway_angle = 0;

	// Use this for initialization
	void Start ( ) {
		_radius = GameCSV._radius;
		_start_y = GameCSV._start_y;
		_view_up_max = GameCSV._view_up_max;
		_view_down_max = GameCSV._view_down_max;
		_sway_speed = GameCSV._sway_speed;
		_sway_speed_horizontal = GameCSV._sway_speed_horizontal;
		_sway_horizontal_max = GameCSV._sway_horizontal_max;
		_sway_angle_max = GameCSV._sway_angle_max;
		_camera_move_speed_x = GameCSV._camera_move_speed_x;
		_camera_move_speed_y = GameCSV._camera_move_speed_y;

		_player = GameObject.Find( "Player" );
		_camera_depth = -_radius;
	}

	// Update is called once per frame
	void Update ( ) {
		transform.position = _player.transform.position + new Vector3( _camera_width+ _camera_width_sway, _camera_height + _start_y, _camera_depth );
		calSway( );
		transform.LookAt( _player.transform.position );
		if ( _sway_flag ) {
			transform.eulerAngles = new Vector3( transform.eulerAngles.x, transform.eulerAngles.y, _sway_angle );
		}
		if ( !Player._playable ) {
			return;
		}
		if ( CutIn_Vertical._cutin_flag ) {
			return;
		}

		cameraMove( );
	}

	void cameraMove ( ) {
		float _horizontal_move = Input.GetAxisRaw( "Horizontal2" );
		float _vertical_move = Input.GetAxisRaw( "Vertical2" );

		if ( Mathf.Abs( Input.GetAxisRaw( "Horizontal2" ) ) >= 0.05f || Mathf.Abs( Input.GetAxisRaw( "Vertical2" ) ) >= 0.05f ) {
			_angle_x -= _horizontal_move * _camera_move_speed_x * Time.deltaTime;
			_angle_y -= _vertical_move * _camera_move_speed_y * Time.deltaTime;
			_angle_y = Mathf.Clamp( _angle_y, -_view_down_max, _view_up_max );
			_camera_width = _radius * Mathf.Cos( _angle_y ) * Mathf.Cos( _angle_x + INIT_ANGLE_X );
			_camera_depth = _radius * Mathf.Cos( _angle_y ) * Mathf.Sin( _angle_x + INIT_ANGLE_X );
			_camera_height = _radius * Mathf.Sin( _angle_y );
		}
	}

	void calSway ( ) {
		if ( _sway_flag ) {
			_sway_angle = _sway_angle_max * Mathf.Sin( Time.time * _sway_speed );
			_camera_width_sway = _sway_horizontal_max * Mathf.Cos( Time.time * _sway_speed_horizontal );
			_sway_time_count -= Time.deltaTime;
			if ( _sway_time_count <= 0 && ( int )_sway_angle == 0 ) {
				_sway_flag = false;
			}
		} else {
			_sway_angle = 0;
		}
	}
}
