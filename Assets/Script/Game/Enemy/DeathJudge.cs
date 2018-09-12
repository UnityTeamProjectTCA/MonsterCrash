using UnityEngine;

public class DeathJudge : MonoBehaviour {
	AudioSource _enemy_death_sound;

	bool _death_flag = false;

	void Awake ( ) {
		GetComponent<EnemyDied>( ).enabled = false;
	}

	// Use this for initialization
	void Start ( ) {
		_enemy_death_sound = GameObject.Find( "SE_Enemy_Death" ).GetComponent<AudioSource>( );
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _death_flag ) {
			GetComponent<EnemyDied>( ).enabled = true;
			GetComponent<BoxCollider>( ).enabled = false;
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
