using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour {

	Slider _slider = null;
	Player _player = null;
	// Use this for initialization
	void Start ( ) {
		_slider = GetComponent<Slider>( );
		_player = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<Player>( );
	}

	// Update is called once per frame
	void Update ( ) {
		_slider.value = _player.getFireStamina( );
	}
}
