using UnityEngine;

public class EscapeArea : MonoBehaviour {
	bool _intrusion_area = false;
	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
	}

	void OnTriggerEnter ( Collider collider ) {
		if ( collider.gameObject.tag == "Player" ) {
			_intrusion_area = true;
		}
	}

	void OnTriggerExit ( Collider other ) {
		if ( other.gameObject.tag == "Player" ) {
			_intrusion_area = false;
		}
	}

	public bool getIntrusionArea ( ) {
		return _intrusion_area;
	}

}
