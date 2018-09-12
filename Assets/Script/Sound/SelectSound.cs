using UnityEngine;
using UnityEngine.EventSystems;


public class SelectSound : MonoBehaviour, ISelectHandler {
	[SerializeField] AudioSource Select_SE = null;

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
	}

	public void OnSelect ( BaseEventData eventData ) {
		Select_SE.Play( );
	}
}
