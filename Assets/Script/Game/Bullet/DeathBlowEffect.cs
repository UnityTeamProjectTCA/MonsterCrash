using UnityEngine;

public class DeathBlowEffect : MonoBehaviour {
	float _timer = 0;
	GameObject _camera = null;

	// Use this for initialization
	void Start ( ) {
		_camera = GameObject.FindGameObjectWithTag( "MainCamera" );
	}

	// Update is called once per frame
	void Update ( ) {
		transform.forward = ( _camera.transform.position - transform.position ).normalized;
		_timer += Time.deltaTime;
		if ( _timer >= 3f ) {
			Destroy( gameObject );
		}
	}
}