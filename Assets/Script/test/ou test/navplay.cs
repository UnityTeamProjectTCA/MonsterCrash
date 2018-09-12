using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navplay : MonoBehaviour {
	public GameObject _target;
	NavMeshAgent _navMeshAgent;
	// Use this for initialization
	void Start () {
		_navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		_navMeshAgent.destination = _target.transform.position;
	}
}
