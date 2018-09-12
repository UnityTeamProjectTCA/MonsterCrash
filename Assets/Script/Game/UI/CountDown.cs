using UnityEngine;

public class CountDown : MonoBehaviour {
	const float START_SCALE = 3;
	const float END_SCALE = 1;
	float _wait_time = 0.75f;

	Vector3 _change_speed = Vector3.zero;

	// Use this for initialization
	void Start ( ) {
		transform.localScale = new Vector3( START_SCALE, START_SCALE, START_SCALE );
		_change_speed = new Vector3( 8, 8, 8 );
	}

	// Update is called once per frame
	void Update ( ) {
		transform.localScale -= _change_speed * Time.deltaTime;
		if ( transform.localScale.x <= END_SCALE ) {
			transform.localScale = new Vector3( END_SCALE, END_SCALE, END_SCALE );
			_wait_time -= Time.deltaTime;
			if ( _wait_time <= 0 && tag != "Finish" ) {
				Destroy( gameObject );
			}
		}
	}
}
