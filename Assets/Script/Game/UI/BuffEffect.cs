using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEffect : MonoBehaviour {
	const float HEIGHT = 0.1f;

	[SerializeField] GameObject _speedbuff_effect = null;
	[SerializeField] GameObject _rangebuff_effect = null;
	[SerializeField] GameObject _player = null;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		transform.position = Vector3.Scale( _player.transform.position, new Vector3( 1, 0, 1 ) ) + transform.up * HEIGHT;
		_speedbuff_effect.SetActive( Player._speedup_flag );
		_rangebuff_effect.SetActive( Player._rangeup_flag );
	}
}
