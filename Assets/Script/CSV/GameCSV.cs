using UnityEngine;

[DefaultExecutionOrder( -1 )]

public class GameCSV : LoadCSV {
	enum VARIABLE_NAME {
		//Player
		FIRE_POS_Y,
		FIRE_POS_Z,
		STAMINA_MAX,
		STAMINA_SPEED,
		ORIGIN_VELOCITY,
		RAISED_VELOCITY,
		SPEEDUP_TIME,
		RANGEUP_TIME,
		DEMIRIT_TIME,
		//Camera
		RADIUS,
		START_Y,
		VIEW_UP_MAX,
		VIEW_DOWN_MAX,
		SWAY_SPEED,
		SWAY_SPEED_HORIZONTAL,
		SWAY_HORIZONTAL_MAX,
		SWAY_ANGLE_MAX,
		CAMERA_MOVE_SPEED_X,
		CAMERA_MOVE_SPEED_Y,
		//EmemyMake
		NEAR_DISTANCE,
		FAR_DISTANCE,
		ENEMY_MAX,
		APPEAR_WAIT_TIME,
		APPEAR_RATE,
		A_RATE,
		B_RATE,
		//Fire
		ORIGINAL_RANGE,
		RAISED_RANGE,
		//MoveLimit
		SHIFT_POS,
		//UIManager
		WAIT_TIME,
		TIME_LIMIT,
		//MinMap
		MAX_SEARCH_RANGE,
		//TimeDestroy
		LOADING_TIME,
		//ScoreMnager
		BUILDING_SMALL_TYPE1_SCORE,
		BUILDING_SMALL_TYPE2_SCORE,
		BUILDING_SMALL_TYPE3_SCORE,
		BUILDING_BIG_TYPE1_SCORE,
		BUILDING_BIG_TYPE2_SCORE,
		BUILDING_BIG_TYPE3_SCORE,
		ENEMY_A_SCORE,
		ENEMY_B_SCORE,
		ENEMY_C_SCORE,
		BONUS,
		//AttentionCursor
		MIN_SIZE,
		CHANGE_SPEED,
		ATTENTION_WAIT_TIME,
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
		BULLET_HEIGHT,
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

	//Player
	public static float _fire_pos_y = 0;
	public static float _fire_pos_z = 0;
	public static float _stamina_max = 0;
	public static float _stamina_speed = 0;
	public static float _origin_velocity = 0;
	public static float _raised_velocity = 0;
	public static float _speedup_time = 0;
	public static float _rangeup_time = 0;
	public static float _demirit_time = 0;

	//Camera
	public static float _radius = 0;
	public static float _start_y = 0;
	public static float _view_up_max = 0;
	public static float _view_down_max = 0;
	public static float _sway_speed = 0;
	public static float _sway_speed_horizontal = 0;
	public static float _sway_horizontal_max = 0;
	public static float _sway_angle_max = 0;
	public static float _camera_move_speed_x = 0;
	public static float _camera_move_speed_y = 0;

	//EnemyMake
	public static float _near_distance = 0;
	public static float _far_distance = 0;
	public static int _enemy_max = 0;
	public static float _appear_wait_time = 0;
	public static float _appear_rate = 0;
	public static float _A_rate = 0;
	public static float _B_rate = 0;

	//Fire
	public static float _original_range = 0;
	public static float _raised_range = 0;

	//MoveLimit
	public static float _shift_pos = 0;

	//UIManager
	public static float _wait_time = 0;
	public static float _time_limit = 0;

	//MinMap
	public static float _max_search_range = 0;

	//TimeDestroy
	public static float _loading_time = 0;

	//ScoreManager
	public static int _building_small_type1_score = 0;
	public static int _building_small_type2_score = 0;
	public static int _building_small_type3_score = 0;
	public static int _building_big_type1_score = 0;
	public static int _building_big_type2_score = 0;
	public static int _building_big_type3_score = 0;
	public static int _enemy_a_score = 0;
	public static int _enemy_b_score = 0;
	public static int _enemy_c_score = 0;
	public static int _bonus = 0;

	//////////////////////////////////
	public static float _min_size = 0;
	public static float _change_speed = 0;
	public static float _attention_wait_time = 0;

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
	public static float _bullet_height = 0;
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

		_fire_pos_y      = float.Parse( _csvData[ ( int )VARIABLE_NAME.FIRE_POS_Y      ][ ( int )PROPERTY.VALUE ] );
		_fire_pos_z      = float.Parse( _csvData[ ( int )VARIABLE_NAME.FIRE_POS_Z      ][ ( int )PROPERTY.VALUE ] );
		_stamina_max     = float.Parse( _csvData[ ( int )VARIABLE_NAME.STAMINA_MAX     ][ ( int )PROPERTY.VALUE ] );
		_stamina_speed   = float.Parse( _csvData[ ( int )VARIABLE_NAME.STAMINA_SPEED   ][ ( int )PROPERTY.VALUE ] );
		_origin_velocity = float.Parse( _csvData[ ( int )VARIABLE_NAME.ORIGIN_VELOCITY ][ ( int )PROPERTY.VALUE ] );
		_raised_velocity = float.Parse( _csvData[ ( int )VARIABLE_NAME.RAISED_VELOCITY ][ ( int )PROPERTY.VALUE ] );
		_speedup_time	 = float.Parse( _csvData[ ( int )VARIABLE_NAME.SPEEDUP_TIME    ][ ( int )PROPERTY.VALUE ] );
		_rangeup_time    = float.Parse( _csvData[ ( int )VARIABLE_NAME.RANGEUP_TIME    ][ ( int )PROPERTY.VALUE ] );
		_demirit_time    = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEMIRIT_TIME    ][ ( int )PROPERTY.VALUE ] );

		_radius                = float.Parse( _csvData[ ( int )VARIABLE_NAME.RADIUS                ][ ( int )PROPERTY.VALUE ] );
		_start_y               = float.Parse( _csvData[ ( int )VARIABLE_NAME.START_Y               ][ ( int )PROPERTY.VALUE ] );
		_view_up_max           = float.Parse( _csvData[ ( int )VARIABLE_NAME.VIEW_UP_MAX           ][ ( int )PROPERTY.VALUE ] );
		_view_down_max         = float.Parse( _csvData[ ( int )VARIABLE_NAME.VIEW_DOWN_MAX         ][ ( int )PROPERTY.VALUE ] );
		_sway_speed            = float.Parse( _csvData[ ( int )VARIABLE_NAME.SWAY_SPEED            ][ ( int )PROPERTY.VALUE ] );
		_sway_speed_horizontal = float.Parse( _csvData[ ( int )VARIABLE_NAME.SWAY_SPEED_HORIZONTAL ][ ( int )PROPERTY.VALUE ] );
		_sway_horizontal_max   = float.Parse( _csvData[ ( int )VARIABLE_NAME.SWAY_HORIZONTAL_MAX   ][ ( int )PROPERTY.VALUE ] );
		_sway_angle_max        = float.Parse( _csvData[ ( int )VARIABLE_NAME.SWAY_ANGLE_MAX        ][ ( int )PROPERTY.VALUE ] );
		_camera_move_speed_x   = float.Parse( _csvData[ ( int )VARIABLE_NAME.CAMERA_MOVE_SPEED_X   ][ ( int )PROPERTY.VALUE ] );
		_camera_move_speed_y   = float.Parse( _csvData[ ( int )VARIABLE_NAME.CAMERA_MOVE_SPEED_Y   ][ ( int )PROPERTY.VALUE ] );

		_near_distance    = float.Parse( _csvData[ ( int )VARIABLE_NAME.NEAR_DISTANCE    ][ ( int )PROPERTY.VALUE ] );
		_far_distance     = float.Parse( _csvData[ ( int )VARIABLE_NAME.FAR_DISTANCE     ][ ( int )PROPERTY.VALUE ] );
		_enemy_max        =   int.Parse( _csvData[ ( int )VARIABLE_NAME.ENEMY_MAX        ][ ( int )PROPERTY.VALUE ] );
		_appear_wait_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.APPEAR_WAIT_TIME ][ ( int )PROPERTY.VALUE ] );
		_appear_rate      = float.Parse( _csvData[ ( int )VARIABLE_NAME.APPEAR_RATE      ][ ( int )PROPERTY.VALUE ] );
		_A_rate           = float.Parse( _csvData[ ( int )VARIABLE_NAME.A_RATE           ][ ( int )PROPERTY.VALUE ] );
		_B_rate           = float.Parse( _csvData[ ( int )VARIABLE_NAME.B_RATE           ][ ( int )PROPERTY.VALUE ] );

		_original_range = float.Parse( _csvData[ ( int )VARIABLE_NAME.ORIGINAL_RANGE ][ ( int )PROPERTY.VALUE ] );
		_raised_range   = float.Parse( _csvData[ ( int )VARIABLE_NAME.RAISED_RANGE   ][ ( int )PROPERTY.VALUE ] );

		_shift_pos = float.Parse( _csvData[ ( int )VARIABLE_NAME.SHIFT_POS ][ ( int )PROPERTY.VALUE ] );

		_wait_time  = float.Parse( _csvData[ ( int )VARIABLE_NAME.WAIT_TIME  ][ ( int )PROPERTY.VALUE ] );
		_time_limit = float.Parse( _csvData[ ( int )VARIABLE_NAME.TIME_LIMIT ][ ( int )PROPERTY.VALUE ] );

		_max_search_range = float.Parse( _csvData[ ( int )VARIABLE_NAME.MAX_SEARCH_RANGE ][ ( int )PROPERTY.VALUE ] );

		_loading_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.LOADING_TIME ][ ( int )PROPERTY.VALUE ] );

		_building_small_type1_score = int.Parse( _csvData[ ( int )VARIABLE_NAME.BUILDING_SMALL_TYPE1_SCORE ][ ( int )PROPERTY.VALUE ] );
		_building_small_type2_score	= int.Parse( _csvData[ ( int )VARIABLE_NAME.BUILDING_SMALL_TYPE2_SCORE ][ ( int )PROPERTY.VALUE ] );
		_building_small_type3_score	= int.Parse( _csvData[ ( int )VARIABLE_NAME.BUILDING_SMALL_TYPE3_SCORE ][ ( int )PROPERTY.VALUE ] );
		_building_big_type1_score	= int.Parse( _csvData[ ( int )VARIABLE_NAME.BUILDING_BIG_TYPE1_SCORE   ][ ( int )PROPERTY.VALUE ] );
		_building_big_type2_score	= int.Parse( _csvData[ ( int )VARIABLE_NAME.BUILDING_BIG_TYPE2_SCORE   ][ ( int )PROPERTY.VALUE ] );
		_building_big_type3_score	= int.Parse( _csvData[ ( int )VARIABLE_NAME.BUILDING_BIG_TYPE3_SCORE   ][ ( int )PROPERTY.VALUE ] );
		_enemy_a_score				= int.Parse( _csvData[ ( int )VARIABLE_NAME.ENEMY_A_SCORE              ][ ( int )PROPERTY.VALUE ] );
		_enemy_b_score				= int.Parse( _csvData[ ( int )VARIABLE_NAME.ENEMY_B_SCORE              ][ ( int )PROPERTY.VALUE ] );
		_enemy_c_score				= int.Parse( _csvData[ ( int )VARIABLE_NAME.ENEMY_C_SCORE              ][ ( int )PROPERTY.VALUE ] );
		_bonus						= int.Parse( _csvData[ ( int )VARIABLE_NAME.BONUS                      ][ ( int )PROPERTY.VALUE ] );

		_min_size = float.Parse( _csvData[ ( int )VARIABLE_NAME.MIN_SIZE ][ ( int )PROPERTY.VALUE ] );
		_change_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.CHANGE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_attention_wait_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.ATTENTION_WAIT_TIME ][ ( int )PROPERTY.VALUE ] );

		_central_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.CENTRAL_SPEED ][ ( int )PROPERTY.VALUE ] );
		_normal_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.NORMAL_SPEED ][ ( int )PROPERTY.VALUE ] );
		_central_pos = float.Parse( _csvData[ ( int )VARIABLE_NAME.CENTRAL_POS ][ ( int )PROPERTY.VALUE ] );

		_deathblow_pos_Y = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATHBLOW_POS_Y ][ ( int )PROPERTY.VALUE ] );
		_deathblow_pos_Z = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATHBLOW_POS_Z ][ ( int )PROPERTY.VALUE ] );
		_deathblow_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATHBLOW_SPEED ][ ( int )PROPERTY.VALUE ] );
		_gravity = float.Parse( _csvData[ ( int )VARIABLE_NAME.GRAVITY ][ ( int )PROPERTY.VALUE ] );
		_charge_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.CHARGE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_sway_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.SWAY_TIME ][ ( int )PROPERTY.VALUE ] );

		_debris_disappear_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEBRIS_DISAPPEAR_TIME ][ ( int )PROPERTY.VALUE ] );
		_debris_addpower = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEBRIS_ADDPOWER ][ ( int )PROPERTY.VALUE ] );

		_bullet_pos = float.Parse( _csvData[ ( int )VARIABLE_NAME.BULLET_POS ][ ( int )PROPERTY.VALUE ] );
		_bullet_height = float.Parse( _csvData[ ( int )VARIABLE_NAME.BULLET_HEIGHT ][ ( int )PROPERTY.VALUE ] );
		_attack_wait_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.ATTACK_WAIT_TIME ][ ( int )PROPERTY.VALUE ] );
		_attack_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.ATTACK_TIME ][ ( int )PROPERTY.VALUE ] );
		_attack_distance = float.Parse( _csvData[ ( int )VARIABLE_NAME.ATTACK_DISTANCE ][ ( int )PROPERTY.VALUE ] );
		_avoid_distance = float.Parse( _csvData[ ( int )VARIABLE_NAME.AVOID_DISTANCE ][ ( int )PROPERTY.VALUE ] );

		_death_rotate_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATH_ROTATE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_death_disappear_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.DEATH_DISAPPEAR_TIME ][ ( int )PROPERTY.VALUE ] );

		_shot_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.SHOT_SPEED ][ ( int )PROPERTY.VALUE ] );

		_raise_speed = float.Parse( _csvData[ ( int )VARIABLE_NAME.RAISE_SPEED ][ ( int )PROPERTY.VALUE ] );
		_font_disappear_time = float.Parse( _csvData[ ( int )VARIABLE_NAME.FONT_DISAPPEAR_TIME ][ ( int )PROPERTY.VALUE ] );

		_debris_num = int.Parse( _csvData[ ( int )VARIABLE_NAME.DEBRIS_NUM ][ ( int )PROPERTY.VALUE ] );
		_stop_time_small1 = float.Parse( _csvData[ ( int )VARIABLE_NAME.STOP_TIME_SMALL1 ][ ( int )PROPERTY.VALUE ] );
		_stop_time_small2 = float.Parse( _csvData[ ( int )VARIABLE_NAME.STOP_TIME_SMALL2 ][ ( int )PROPERTY.VALUE ] );
	}

	// Update is called once per frame
	void Update ( ) {

	}
}
