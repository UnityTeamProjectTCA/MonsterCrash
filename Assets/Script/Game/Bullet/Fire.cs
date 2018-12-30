using UnityEngine;

public class Fire : MonoBehaviour {
	[SerializeField] ParticleSystem _fire = null;
	[SerializeField] GameObject _player = null;
	[SerializeField] ScoreManager _score_manager = null;

	float _original_range = 0;
	float _raised_range = 0;
	
	// Use this for initialization
	void Start ( ) {
		_original_range = GameCSV._original_range;
		_raised_range = GameCSV._raised_range;

		_fire = GetComponent<ParticleSystem>( );
	}

	// Update is called once per frame
	void Update ( ) {
		Vector3 dir = ( transform.position - _player.transform.position ).normalized;
		transform.forward = Vector3.Scale( dir, new Vector3( 1, 0, 1 ) );
		rangeUpBuff( );
	}

	void rangeUpBuff ( ) {
		ParticleSystem.MainModule main = _fire.main;
		if ( Player._rangeup_flag ) {
			main.startSpeed = _raised_range;
		} else {
			main.startSpeed = _original_range;
		}
	}

	private void OnParticleCollision ( GameObject other ) {

		if ( other.gameObject.tag == "EnemyA" ) {
			other.GetComponent<DeathJudge>( ).Death( );
			_score_manager.AddScore( ScoreManager.SCORE_TYPE.ENEMY_A );
			Player._rangeup_flag = true;
			BuffSE._buff_flag = true;
		}

		if ( other.gameObject.tag == "EnemyB" ) {
			other.GetComponent<DeathJudge>( ).Death( );
			_score_manager.AddScore( ScoreManager.SCORE_TYPE.ENEMY_B );
			Player._speedup_flag = true;
			BuffSE._buff_flag = true;
		}

		if ( other.gameObject.tag == "EnemyC" ) {
			other.GetComponent<DeathJudge>( ).Death( );
			_score_manager.AddScore( ScoreManager.SCORE_TYPE.ENEMY_C );
			_player.GetComponent<Player>( ).deathblowIncrease( 1 );
			BuffSE._buff_flag = true;
		}
	}
}