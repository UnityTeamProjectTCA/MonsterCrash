using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder( -2 )]

public class LoadCSV : MonoBehaviour {
	protected enum PROPERTY {
		NAME,
		VALUE
	};

	[SerializeField] WWW www = null;
	protected List<string[ ]> _csvData = new List<string[ ]>( );

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
	}

	protected void loadCSV ( ) {
		www = new WWW("file:///" + Application.streamingAssetsPath + "/CSV/" + SceneManager.GetActiveScene( ).name + ".csv" );
		while ( !www.isDone ){
		}
		StringReader reader = new StringReader( www.text );

		while ( reader.Peek( ) > -1 ) {
			string line = reader.ReadLine( );
			if ( line[ 0 ] == '/' ) {
				continue;
			}
			_csvData.Add( line.Split( ',' ) );

		}
	}
}

