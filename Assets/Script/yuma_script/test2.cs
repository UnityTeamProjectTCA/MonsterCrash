using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.right * 10.0f);
	}
}
