using UnityEngine;
using UnityEngine.UI;

public class CutIn : MonoBehaviour {
	const float SCREEN_WIDTH = 1920;
	const float SCREEN_HEIGHT = 1080;

	public static bool _cutin_flag = false;

	float _central_speed = 0;
	float _normal_speed = 0;
	float _central_X = 0;

	Image _image = null;

	float _speed = 0;
	float _timer = 0;
	float _width = 0;

	// Use this for initialization
	void Start ( ) {
		_central_speed = PrefabCSV._central_speed;
		_normal_speed = PrefabCSV._normal_speed;
		_central_X = PrefabCSV._central_X;

		_image = GetComponent<Image>( );
		_width = _image.rectTransform.sizeDelta.x;
		_image.rectTransform.localPosition = new Vector3( SCREEN_WIDTH + _width / 2, 0, 0 );
	}

	// Update is called once per frame
	void Update ( ) {
		_timer += Time.deltaTime;
		_speed = _normal_speed;
		if ( -_central_X <= _image.rectTransform.localPosition.x && _image.rectTransform.localPosition.x <= _central_X ) {
			_speed = _central_speed;
		}
		_image.rectTransform.localPosition += new Vector3( _speed, 0, 0 ) * Time.deltaTime;
		if ( ( int )_image.rectTransform.localPosition.x <= -SCREEN_WIDTH - _width / 2 ) {
			//_cutin_flag = false;
			Destroy( gameObject );
		}
	}
}
