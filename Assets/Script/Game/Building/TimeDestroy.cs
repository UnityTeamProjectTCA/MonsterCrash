using UnityEngine;

public class TimeDestroy : MonoBehaviour {
	float _loading_time = 0;
	// Use this for initialization
	void Start( ) {
		_loading_time = GameCSV._loading_time;
	}
	
	// Update is called once per frame
	void Update( ) {
		_loading_time -= Time.deltaTime;
		if ( _loading_time < 0 ) Destroy( this.gameObject );
	}
}
