using UnityEngine;
using UnityEngine.UI;

public class CutIn_Vertical : MonoBehaviour {
	const float SCREEN_WIDTH = 1920;
	const float SCREEN_HEIGHT = 1080;
	float SCREEN_LENTH = Mathf.Sqrt( SCREEN_WIDTH * SCREEN_WIDTH + SCREEN_HEIGHT * SCREEN_HEIGHT );

	public static bool _cutin_flag = false;

	float _central_speed = 0;
	float _normal_speed = 0;
	float _central_pos = 0;

	Image _image = null;

	float _speed = 0;
	float _speed_x = 0;
	float _speed_y = 0;
	float _timer = 0;
	float _width = 0;
	float _height = 0;

	// Use this for initialization
	void Start ( ) {
		_central_speed = GameCSV._central_speed;
		_normal_speed = GameCSV._normal_speed;
		_central_pos = GameCSV._central_pos;

		_image = GetComponent<Image>( );
		_width = _image.rectTransform.sizeDelta.x;
		_height = _image.rectTransform.sizeDelta.y;
		_image.rectTransform.localPosition = new Vector3( -SCREEN_WIDTH - _width / 2, -SCREEN_HEIGHT - _height / 2, 0 );
	}

	// Update is called once per frame
	void Update ( ) {
		_timer += Time.deltaTime;
		_speed_x = _speed * SCREEN_WIDTH / SCREEN_LENTH;
		_speed_y = _speed * SCREEN_HEIGHT / SCREEN_LENTH;
		if ( -_central_pos <= _image.rectTransform.localPosition.x && _image.rectTransform.localPosition.x <= _central_pos ) {
			_speed = _central_speed;
		} else {
			_speed = _normal_speed;
		}
		if ( -_central_pos <= _image.rectTransform.localPosition.y && _image.rectTransform.localPosition.y <= _central_pos ) {
			_speed = _central_speed;
		} else {
			_speed = _normal_speed;
		}

		_image.rectTransform.localPosition += new Vector3( _speed_x, _speed_y, 0 ) * Time.deltaTime;
		if ( _image.rectTransform.localPosition.x >= SCREEN_WIDTH + _width / 2 &&
			 _image.rectTransform.localPosition.y >= SCREEN_HEIGHT + _height / 2 ) {
			Destroy( gameObject );
		}
	}
}
