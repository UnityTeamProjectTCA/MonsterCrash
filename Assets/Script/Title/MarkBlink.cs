using UnityEngine;
using UnityEngine.UI;

public class MarkBlink : MonoBehaviour {
	[SerializeField] Blink _start = null;
	Image _image = null;

	// Use this for initialization
	void Start ( ) {
		_image = GetComponent<Image>( );
	}

	// Update is called once per frame
	void Update ( ) {
		_image.color = _start.getColor( );
	}
}