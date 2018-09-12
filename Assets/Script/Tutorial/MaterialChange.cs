using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour {
	[SerializeField] float _set_change_time = 1f;
	[SerializeField] float _transparency = 0.5f;

	Material _material = null;
	float _change_time;
	Color _initial_color;
	Color _change_color;
	bool _is_flashing;
	// Use this for initialization
	void Start( ) {
		_material = GetComponent< Renderer >( ).materials [ 1 ];
		_change_time = _set_change_time;
		_transparency = 0;
		_initial_color = _material.color;
		_change_color = new Color (_material.color.r, _material.color.g, _material.color.b, _transparency);
		_is_flashing = true;
	}
	
	// Update is called once per frame
	void Update( ) {
		if ( _is_flashing )Flashing( );

		if (!_is_flashing && _material.color == _initial_color) _material.color = _change_color;
	}

	void Flashing( ) {
		_change_time -= Time.deltaTime;

		if ( _change_time < 0 ) {
			if ( _material.color == _initial_color ) {
				_material.color = _change_color;
			} else {
				_material.color = _initial_color;
			}

			_change_time = _set_change_time;
		}
	}

	public void setIsFlashing( bool value ) {
		_is_flashing = value;
	}

}
