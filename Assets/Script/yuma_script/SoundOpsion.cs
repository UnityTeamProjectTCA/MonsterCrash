using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOpsion : MonoBehaviour {

	[SerializeField] GameObject soundOptionCanvas = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("4")) {
			soundOptionCanvas.SetActive (!soundOptionCanvas.activeSelf);
		}
	}
}
