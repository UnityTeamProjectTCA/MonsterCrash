using UnityEngine;

public class EscapePoint : MonoBehaviour {
	bool _intrusion_point = false;

	// Use this for initialization
	void Start( ) {
	}
	
	// Update is called once per frame
	void Update( ) {
	}

	void OnTriggerEnter( Collider collider ) {
		if ( collider.gameObject.tag == "EnemyA" || collider.gameObject.tag == "EnemyB" || collider.gameObject.tag == "EnemyC" ) {
			_intrusion_point = true;
		}
	}

	void OnTriggerExit( Collider other ) {
		if ( other.gameObject.tag == "EnemyA" || other.gameObject.tag == "EnemyB" || other.gameObject.tag == "EnemyC" ) {
			_intrusion_point = false;
		}
	}

	public bool getIntrusionPoint( ) {
		return _intrusion_point;
	}

}
