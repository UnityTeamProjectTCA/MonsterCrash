using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniCtrl : MonoBehaviour {
    EnemyAi _enemy_ai = null;
    Animator _anim = null;
	// Use this for initialization
	void Start( ) {
        _enemy_ai = GetComponent<EnemyAi>( );
		_anim = GetComponent<Animator>( );
	}
	
	// Update is called once per frame
	void Update( ) {
		
        if ( _enemy_ai.getAttack( ) ) { 
            _anim.SetBool( "Walk", false );
            _anim.SetBool( "Attack", true );
            _anim.SetBool( "Standbye", false );
        } else if ( _enemy_ai.getMoving( ) ) {
            _anim.SetBool( "Walk", true );
            _anim.SetBool( "Attack", false );
            _anim.SetBool( "Standbye", false );
        } else { 
            _anim.SetBool( "Walk", false );
            _anim.SetBool( "Attack", false );
            _anim.SetBool( "Standbye", true );
        }

	}
}
