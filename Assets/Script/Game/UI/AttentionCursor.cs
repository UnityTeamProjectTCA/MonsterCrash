using UnityEngine;

public class AttentionCursor : MonoBehaviour {
	float _min_size = 1f;
	float _speed = 1f;
	float _wait_time = 2f;

	bool _shrinking_end = false;
	float _max_size = 1f;

	RectTransform _rect_transform = null;
	// Use this for initialization
	void Start( ) {
		_min_size = PrefabCSV._min_size;
		_speed = PrefabCSV._change_speed;
		_wait_time = PrefabCSV._wait_time;

		_rect_transform = GetComponent<RectTransform>( );

        _max_size = _rect_transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update( ) {
		Shrinking( );
		Delete( );
	}


	void Shrinking( ) {
		if ( _shrinking_end ) return;

        _max_size -= Time.deltaTime * _speed;
		_rect_transform.localScale = new Vector2( _max_size, _max_size );

		if ( _rect_transform.localScale.x < _min_size && 
			_rect_transform.localScale.y < _min_size ) {
			_rect_transform.localScale = new Vector2( _min_size, _min_size );
			_shrinking_end = true;
		}
	}


	void Delete( ) {
		if ( !_shrinking_end ) return;

		_wait_time -= Time.deltaTime;

		if ( _wait_time < 0 ) Destroy( this.gameObject );

	}

}
