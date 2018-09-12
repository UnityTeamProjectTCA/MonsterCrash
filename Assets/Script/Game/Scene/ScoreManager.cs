using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	[SerializeField] GameObject _scoreplus = null;
	[SerializeField] GameObject _canvas = null;

	public enum SCORE_TYPE {
		BUILDING_SMALL_TYPE_1,
		BUILDING_SMALL_TYPE_2,
		BUILDING_SMALL_TYPE_3,
		BUILDING_BIG_TYPE_1,
		BUILDING_BIG_TYPE_2,
		BUILDING_BIG_TYPE_3,
		ENEMY_A,
		ENEMY_B,
		ENEMY_C,
		BONUS
	}

	int _building_small_type1_score = 0;
	int _building_small_type2_score = 0;
	int _building_small_type3_score = 0;
	int _building_big_type1_score = 0;
	int _building_big_type2_score = 0;
	int _building_big_type3_score = 0;
	int _enemy_a_score = 0;
	int _enemy_b_score = 0;
	int _enemy_c_score = 0;
	int _bonus = 0;

	public static int _score = 0;

	// Use this for initialization
	void Start ( ) {
		_building_small_type1_score = GameCSV._building_small_type1_score;
		_building_small_type2_score = GameCSV._building_small_type2_score;
		_building_small_type3_score = GameCSV._building_small_type3_score;
		_building_big_type1_score = GameCSV._building_big_type1_score;
		_building_big_type2_score = GameCSV._building_big_type2_score;
		_building_big_type3_score = GameCSV._building_big_type3_score;
		_enemy_a_score = GameCSV._enemy_a_score;
		_enemy_b_score = GameCSV._enemy_b_score;
		_enemy_c_score = GameCSV._enemy_c_score;
		_bonus = GameCSV._bonus;

		_score = 0;
	}

	// Update is called once per frame
	void Update ( ) {
	}

	void writeScorePlus ( int score ) {
		GameObject scoreplus = Instantiate( _scoreplus );
		scoreplus.transform.SetParent( _canvas.transform, false );
		scoreplus.GetComponent<Text>( ).text = "+" + score.ToString( );

	}

	public void AddScore ( SCORE_TYPE type ) {
		switch ( type ) {
			case SCORE_TYPE.BUILDING_SMALL_TYPE_1:
				_score += _building_small_type1_score;
				writeScorePlus( _building_small_type1_score );
				break;

			case SCORE_TYPE.BUILDING_SMALL_TYPE_2:
				_score += _building_small_type2_score;
				writeScorePlus( _building_small_type2_score );
				break;

			case SCORE_TYPE.BUILDING_SMALL_TYPE_3:
				_score += _building_small_type3_score;
				writeScorePlus( _building_small_type3_score );
				break;

			case SCORE_TYPE.BUILDING_BIG_TYPE_1:
				_score += _building_big_type1_score;
				writeScorePlus( _building_big_type1_score );
				break;

			case SCORE_TYPE.BUILDING_BIG_TYPE_2:
				_score += _building_big_type2_score;
				writeScorePlus( _building_big_type2_score );
				break;

			case SCORE_TYPE.BUILDING_BIG_TYPE_3:
				_score += _building_big_type3_score;
				writeScorePlus( _building_big_type3_score );
				break;

			case SCORE_TYPE.ENEMY_A:
				_score += _enemy_a_score;
				writeScorePlus( _enemy_a_score );
				break;

			case SCORE_TYPE.ENEMY_B:
				_score += _enemy_b_score;
				writeScorePlus( _enemy_b_score );
				break;

			case SCORE_TYPE.ENEMY_C:
				_score += _enemy_c_score;
				writeScorePlus( _enemy_c_score );
				break;

			case SCORE_TYPE.BONUS:
				_score += _bonus;
				writeScorePlus( _bonus );
				break;

			default:
				break;
		}
	}
}
