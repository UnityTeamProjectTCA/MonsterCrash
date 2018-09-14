using UnityEngine;

[DefaultExecutionOrder( -1 )]

public class PrefabCSV : LoadCSV {
	enum VARIABLE_NAME {
		//AttentionCursor
		MIN_SIZE,
		CHANGE_SPEED,
		WAIT_TIME,
		//CutIn
		CENTRAL_SPEED,
		NORMAL_SPEED,
		CENTRAL_POS,
		//Deathblow
		DEATHBLOW_POS_Y,
		DEATHBLOW_POS_Z,
		DEATHBLOW_SPEED,
		GRAVITY,
		CHARGE_SPEED,
		SWAY_TIME,
		//Debris
		DEBRIS_DISAPPEAR_TIME,
		DEBRIS_ADDPOWER,
		//EnemyAI
		BULLET_POS,
		ATTACK_WAIT_TIME,
		ATTACK_TIME,
		ATTACK_DISTANCE,
		AVOID_DISTANCE,
		//EnemyDied
		DEATH_ROTATE_SPEED,
		DEATH_DISAPPEAR_TIME,
		//EnemyBullet
		SHOT_SPEED,
		//ScorePlus
		RAISE_SPEED,
		FONT_DISAPPEAR_TIME,
		//Building
		DEBRIS_NUM,
		STOP_TIME_SMALL1,
		STOP_TIME_SMALL2
	};

	public static float _min_size = 0;
	public static float _change_speed = 0;
	public static float _wait_time = 0;

	public static float _central_speed = 0;
	public static float _normal_speed = 0;
	public static float _central_pos = 0;

	public static float _deathblow_pos_Y = 0;
	public static float _deathblow_pos_Z = 0;
	public static float _deathblow_speed = 0;
	public static float _gravity = 0;
	public static float _charge_speed = 0;
	public static float _sway_time = 0;

	public static float _debris_disappear_time = 0;
	public static float _debris_addpower = 0;

	public static float _bullet_pos = 0;
	public static float _attack_wait_time = 0;
	public static float _attack_time = 0;
	public static float _attack_distance = 0;
	public static float _avoid_distance = 0;

	public static float _death_rotate_speed = 0;
	public static float _death_disappear_time = 0;

	public static float _shot_speed = 0;

	public static float _raise_speed = 0;
	public static float _font_disappear_time = 0;

	public static int _debris_num = 0;
	public static float _stop_time_small1 = 0;
	public static float _stop_time_small2 = 0;

	// Use this for initialization
	void Start ( ) {
		loadCSV( );

		_min_size              = float.Parse( _csvData[ ( int )VARIABLE_NAME.MIN_SIZE ][ ( int )PROPERTY.VALUE ] );
		_change_speed          = float.Parse( _csvData[ ( int )VARIABLE_NAME.CHANGE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_wait_time			   = float.Parse( _csvData[ ( int )VARIABLE_NAME.WAIT_TIME ][ ( int )PROPERTY.VALUE ] );

		_central_speed		   = float.Parse( _csvData[ ( int )VARIABLE_NAME.CENTRAL_SPEED ][ ( int )PROPERTY.VALUE ] );
		_normal_speed		   = float.Parse( _csvData[ ( int )VARIABLE_NAME.NORMAL_SPEED ][ ( int )PROPERTY.VALUE ] );
		_central_pos			   = float.Parse( _csvData[ ( int )VARIABLE_NAME.CENTRAL_POS ][ ( int )PROPERTY.VALUE ] );

		_deathblow_pos_Y	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATHBLOW_POS_Y ][ ( int )PROPERTY.VALUE ] );
		_deathblow_pos_Z	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATHBLOW_POS_Z ][ ( int )PROPERTY.VALUE ] );
		_deathblow_speed	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATHBLOW_SPEED ][ ( int )PROPERTY.VALUE ] );
		_gravity         	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.GRAVITY ][ ( int )PROPERTY.VALUE ] );
		_charge_speed		   = float.Parse( _csvData[ ( int )VARIABLE_NAME.CHARGE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_sway_time			   = float.Parse( _csvData[ ( int )VARIABLE_NAME.SWAY_TIME ][ ( int )PROPERTY.VALUE ] );

		_debris_disappear_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEBRIS_DISAPPEAR_TIME ][ ( int )PROPERTY.VALUE ] );
		_debris_addpower	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEBRIS_ADDPOWER ][ ( int )PROPERTY.VALUE ] );

		_bullet_pos			   = float.Parse( _csvData[ ( int )VARIABLE_NAME.BULLET_POS ][ ( int )PROPERTY.VALUE ] );
		_attack_wait_time	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.ATTACK_WAIT_TIME ][ ( int )PROPERTY.VALUE ] );
		_attack_time		   = float.Parse( _csvData[ ( int )VARIABLE_NAME.ATTACK_TIME ][ ( int )PROPERTY.VALUE ] );
		_attack_distance	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.ATTACK_DISTANCE ][ ( int )PROPERTY.VALUE ] );
		_avoid_distance		   = float.Parse( _csvData[ ( int )VARIABLE_NAME.AVOID_DISTANCE ][ ( int )PROPERTY.VALUE ] );
		
		_death_rotate_speed	   = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATH_ROTATE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_death_disappear_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATH_DISAPPEAR_TIME ][ ( int )PROPERTY.VALUE ] );
		
		_shot_speed			   = float.Parse( _csvData[ ( int )VARIABLE_NAME.SHOT_SPEED ][ ( int )PROPERTY.VALUE ] );

		_raise_speed           = float.Parse( _csvData[ ( int )VARIABLE_NAME.RAISE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_font_disappear_time   = float.Parse( _csvData[ ( int )VARIABLE_NAME.FONT_DISAPPEAR_TIME ][ ( int )PROPERTY.VALUE ] );

		_debris_num       =   int.Parse( _csvData[ ( int )VARIABLE_NAME.DEBRIS_NUM ][ ( int )PROPERTY.VALUE ] );
		_stop_time_small1 = float.Parse( _csvData[ ( int )VARIABLE_NAME.STOP_TIME_SMALL1 ][ ( int )PROPERTY.VALUE ] );
		_stop_time_small2 = float.Parse( _csvData[ ( int )VARIABLE_NAME.STOP_TIME_SMALL2 ][ ( int )PROPERTY.VALUE ] );
	}

	// Update is called once per frame
	void Update ( ) {

	}
}
