using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonAnimation : MonoBehaviour {
	[SerializeField] AudioSource _submit_SE = null;
	bool _click;
	float _sizeX;
	float _sizeY;
	public string _to_scene;
	// Use this for initialization
	void Start ( ) {
		_click = false;
		_sizeX = GetComponent<RectTransform>( ).sizeDelta.x;
		_sizeY = GetComponent<RectTransform>( ).sizeDelta.y;
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _click ) {
			RectTransform rectTrans = GetComponent<RectTransform>( );
			rectTrans.sizeDelta = new Vector2( _sizeX, _sizeY );
			if ( _sizeX > 150 ) {
				_sizeX -= 200 * Time.deltaTime;
				_sizeY -= 200 * Time.deltaTime;
			}
			if ( _sizeX < 150 ) {
				SceneManager.LoadScene( _to_scene );
				_submit_SE.Play( );
			}
		}
	}
	public void OnClickButton ( ) {
		_click = true;
	}
}
