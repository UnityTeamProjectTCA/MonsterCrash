using UnityEngine;

public class SubmitButton : MonoBehaviour {
	[SerializeField] AudioSource _submit_BGM = null;
	[SerializeField] Animation _anim = null;

	Animator _animator = null;
	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
	}


	public void OnClickButton ( ) {
		_submit_BGM.Play( );
		_anim.Play( );
	}

	public void YesClick ( ) {
		_animator.SetBool( "YesExplosion", true );
	}

	public void NoClick ( ) {
		_animator.SetBool( "NoExplosion", true );
	}
}
