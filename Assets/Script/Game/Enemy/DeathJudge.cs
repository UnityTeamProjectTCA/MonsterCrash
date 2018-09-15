using UnityEngine;

public class DeathJudge : MonoBehaviour {
	AudioSource _enemy_death_sound;
	EnemyDied _enemy_died = null;
	BoxCollider _collider = null;

	bool _death_flag = false;

	void Awake ( ) {
		_enemy_died = GetComponent<EnemyDied>( );
		_collider = GetComponent<BoxCollider>( );
		_enemy_died.enabled = false;
	}

	// Use this for initialization
	void Start ( ) {
		_enemy_death_sound = GameObject.Find( "SE_Enemy_Death" ).GetComponent<AudioSource>( );
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _death_flag ) {
			_enemy_died.enabled = true;
			_collider.enabled = false;
			return;
		}
	}

	public void Death ( ) {
		_death_flag = true;
		_enemy_death_sound.Play( );
	}

    
    public bool getDeathFlag( ) { 
        return _death_flag;    
    }    
}
