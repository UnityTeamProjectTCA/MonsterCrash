using UnityEngine;

public class DeathBlowEffect : MonoBehaviour {
	float _timer = 0;
	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		_timer += Time.deltaTime;
		if ( _timer >= 3 ) {
			Destroy( gameObject );
		}
	}
}