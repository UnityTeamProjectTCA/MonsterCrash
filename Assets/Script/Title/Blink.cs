using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {
	Image _image = null;

	float _blink_speed = 0;
	float _time = 0;

	// Use this for initialization
	void Start ( ) {
		_image = GetComponent<Image>( );
		if ( SceneManager.GetActiveScene( ).name == "Title" ) {
			_blink_speed = TitleCSV._blink_speed;
		}
		if ( SceneManager.GetActiveScene( ).name == "Result" ) {
			_blink_speed = ResultCSV._blink_speed;
		}
	}

	// Update is called once per frame
	void Update ( ) {
		_image.color = GetAlphaColor( _image.color );
	}

	Color GetAlphaColor ( Color color ) {
		_time += Time.deltaTime * _blink_speed;
		color.a = Mathf.Sin( _time ) * 0.5f + 0.5f;
		return color;
	}

	public Color getColor ( ) {
		return _image.color;
	}
}