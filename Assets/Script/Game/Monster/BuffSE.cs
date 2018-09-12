using UnityEngine;

public class BuffSE : MonoBehaviour {
	[SerializeField] AudioSource _buff_SE = null;
	public static bool _buff_flag = false;

	// Use this for initialization
	void Start( ) {
	}
	
	// Update is called once per frame
	void Update( ) {
		if (_buff_flag && !_buff_SE.isPlaying) {
			_buff_SE.Play ();
			_buff_flag = false;
		}
	}

}
