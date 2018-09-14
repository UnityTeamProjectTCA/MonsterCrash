using UnityEngine;
using UnityEngine.UI;

public class CutIn_Vertical : MonoBehaviour {
	const float SCREEN_WIDTH = 1920;
	const float SCREEN_HEIGHT = 1080;

	public static bool _cutin_flag = false;

	float _central_speed = 0;
	float _normal_speed = 0;
	float _central_pos = 0;

	Image _image = null;

	float _speed = 0;
	float _timer = 0;
	float _height = 0;

	// Use this for initialization
	void Start ( ) {
		_central_speed = PrefabCSV._central_speed;
		_normal_speed = PrefabCSV._normal_speed;
		_central_pos = PrefabCSV._central_pos;

		_image = GetComponent<Image>( );
		_height = _image.rectTransform.sizeDelta.y;
		_image.rectTransform.localPosition = new Vector3( 0, SCREEN_HEIGHT + _height / 2, 0 );
	}

	// Update is called once per frame
	void Update ( ) {
		_timer += Time.deltaTime;
		_speed = _normal_speed;
		if ( -_central_pos <= _image.rectTransform.localPosition.y && _image.rectTransform.localPosition.y <= _central_pos ) {
			_speed = _central_speed;
		}
		_image.rectTransform.localPosition += new Vector3( 0, _speed, 0 ) * Time.deltaTime;
		if ( ( int )_image.rectTransform.localPosition.y <= -SCREEN_HEIGHT - _height / 2 ) {
			Destroy( gameObject );
		}
	}
}
