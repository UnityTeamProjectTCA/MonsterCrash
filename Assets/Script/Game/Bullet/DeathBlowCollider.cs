using UnityEngine;

public class DeathBlowCollider : MonoBehaviour {
	[SerializeField] Player _player = null;
	[SerializeField] ScoreManager _score_manager = null;

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
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
			_player.deathblowIncrease( 1 );
			BuffSE._buff_flag = true;
		}
	}
}