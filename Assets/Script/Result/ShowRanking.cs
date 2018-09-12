using UnityEngine;
using UnityEngine.UI;

public class ShowRanking : MonoBehaviour {
	const int MAX_RANKING = 5;                              //ランキングの最大数
	const int MAX_INDEX = MAX_RANKING - 1;                  //ranking配列の最大添字
	[SerializeField] Text[ ] _scoreText = new Text[ 5 ];    //scoreテキストの配列
	[SerializeField] Text _nowScoreText = null;
	int _show_score;                                        //プレイの時のスコアを入れる変数
	static int[ ] _ranking = new int[ MAX_RANKING ];        //１位～５位の格納配列
	string[ ] _key = new string[ MAX_RANKING ];             //セーブするコード 
	
	// Use this for initialization
	void Start ( ) {
		_show_score = ScoreManager._score;

		SetKeyString( );

		RankingLoad( );

		RankingSort( );

		NowScorePrint( );

		RankingPrint( );

		RankingSave( );

		//_score = 0; //スコアリセット
	}

	// Update is called once per frame
	void Update ( ) {
		RankingLeset( );
	}


	void SetKeyString ( ) {              //セーブするコードを設定する
		_key[ 0 ] = "SeveRanking1";
		_key[ 1 ] = "SaveRanking2";
		_key[ 2 ] = "SaveRanking3";
		_key[ 3 ] = "SaveRanking4";
		_key[ 4 ] = "SaveRanking5";
	}


	//ランキングをロードする
	void RankingLoad ( ) {
		for ( int i = 0; i < MAX_RANKING; i++ ) {
			_ranking[ i ] = PlayerPrefs.GetInt( _key[ i ], 0 );
		}
	}

	void RankingSort ( ) {
		//プレイ時のスコアがランキング最下位より上だったら最下位にそのスコアを入れる
		if ( _ranking[ MAX_INDEX ] < _show_score ) {
			_ranking[ MAX_INDEX ] = _show_score;
		}

		//配列を降順に並び替える
		int count = MAX_INDEX;
		int temp = 0;

		//最後から順番に見て入れ替えていく
		for ( int i = 0; i < MAX_INDEX; i++ ) {
			if ( _ranking[ count ] > _ranking[ count - 1 ] ) {
				temp = _ranking[ count - 1 ];
				_ranking[ count - 1 ] = _ranking[ count ];
				_ranking[ count ] = temp;
			}
			count--;
		}
	}

	void NowScorePrint ( ) {
		_nowScoreText.text = _show_score.ToString( );
	}

	void RankingPrint ( ) {
		//_scoreText配列に１位から順番に値を入れる
		for ( int i = 0; i < _scoreText.Length; i++ ) {
			_scoreText[ i ].text = _ranking[ i ].ToString( );
		}

		//プレイ時のスコアだったら文字を赤くする
		for ( int i = 0; i < _ranking.Length; i++ ) {
			if ( _ranking[ i ] == _show_score ) {
				_scoreText[ i ].color = new Color( 255, 0, 0, 255 );
				RankingEffect( i );
				break;
			}
		}
	}

	//ランキングをセーブする
	void RankingSave ( ) {
		for ( int i = 0; i < MAX_RANKING; i++ ) {
			PlayerPrefs.SetInt( _key[ i ], _ranking[ i ] );
		}
	}

	//Bを押しながらRを押したらランキングをリセットする
	void RankingLeset ( ) {
		if ( Input.GetKey( KeyCode.B ) ) {
			if ( Input.GetKey( KeyCode.R ) ) {
				PlayerPrefs.DeleteAll( );
			}
		}
	}

	//ランキングの演出上下に揺らす
	void RankingEffect ( int num ) {
		Animator animator = _scoreText[ num ].GetComponent<Animator>( );
		animator.SetBool( "RankingMoveFlag", true );
	}

}