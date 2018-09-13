using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniCtrl : MonoBehaviour {
    Animator _anim = null;

	bool _attack_anim = false;          //攻撃モーションをするかどうか
    bool _walk_anim = false;          //移動モーションをするかどうか
	// Use this for initialization
	void Start( ) {
		_anim = GetComponent<Animator>( );
	}
	
	// Update is called once per frame
	void Update( ) {
		
        if ( _attack_anim && !_walk_anim ) { 
            _anim.SetBool( "Walk", false );
            _anim.SetBool( "Attack", true );
            _anim.SetBool( "Standbye", false );
        }

		if ( !_attack_anim && _walk_anim ) {
            _anim.SetBool( "Walk", true );
            _anim.SetBool( "Attack", false );
            _anim.SetBool( "Standbye", false );
        }

		if ( !_attack_anim && !_walk_anim ) { 
            _anim.SetBool( "Walk", false );
            _anim.SetBool( "Attack", false );
            _anim.SetBool( "Standbye", true );
        }

	}

	public void setAttackAnimFlag( bool flag ) {
		_attack_anim = flag;
	}

	public void setWalkAnimFlag( bool flag ) {
		_walk_anim = flag;
	}
}
