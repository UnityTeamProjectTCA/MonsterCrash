using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {
	public bool _visable = false;
	public Renderer _rend;
	// Use this for initialization
	void Start () {
		_rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update( ) {
	}

	void OnWillRenderObject(){
		if (Camera.current.name == "Main Camera") {
			_visable = true;
		} else {
			_visable = false;
		}
	}
}
