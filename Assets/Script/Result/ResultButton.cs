using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour {
	[SerializeField] GameObject[ ] button = new GameObject[ 1 ];
	float TimeCount = 0;
	
	// Use this for initialization
	void Start ( ) {
		TimeCount = ResultCSV._time_count;
	}

	// Update is called once per frame
	void Update ( ) {
		TimeCount -= Time.deltaTime;
		if ( TimeCount <= 0 ) {
			for ( int i = 0; i < button.Length; i++ ) {
				button[ i ].SetActive( true );
			}
		}
	}

    void a(){ 
        if ( button[ 0 ].activeInHierarchy ) { 
            if ( Input.GetButtonDown( "Submit" ) ) {
			SceneManager.LoadScene( "Title" );
		}    
            
        }    
        
    }

}
