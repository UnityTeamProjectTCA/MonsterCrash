using UnityEngine;
using UnityEngine.UI;

public class ScorePlus : MonoBehaviour {
	Text _text = null;
	Text _score = null;

	[SerializeField] float _raise_speed = 0;
	[SerializeField] float _disappear_time = 0;

	// Use this for initialization
	void Start ( ) {
		_raise_speed = PrefabCSV._raise_speed;
		_disappear_time = PrefabCSV._font_disappear_time;

		_score = GameObject.Find( "Score" ).GetComponent<Text>( );
		_text = GetComponent<Text>( );
		_text.rectTransform.localPosition = _score.rectTransform.localPosition;
	}

	// Update is called once per frame
	void Update ( ) {
		_text.rectTransform.localPosition += new Vector3( 0, _raise_speed, 0 ) * Time.deltaTime;
		_text.color = GetAlphaColor( _text.color );
		if ( _text.color.a <= 0 ) {
			Destroy( gameObject );
		}
	}

	Color GetAlphaColor ( Color color ) {
		_disappear_time -= Time.deltaTime;
		color.a = _disappear_time;
		return color;
	}
}
