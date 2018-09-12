using System.IO;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder( -2 )]

public class LoadCSV : MonoBehaviour {
	protected enum PROPERTY {
		NAME,
		VALUE
	};

	[SerializeField] TextAsset csvFile = null;
	protected List<string[ ]> _csvData = new List<string[ ]>( );

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
	}

	protected void loadCSV ( ) {
		StringReader reader = new StringReader( csvFile.text );

		while ( reader.Peek( ) > -1 ) {
			string line = reader.ReadLine( );
			if ( line[ 0 ] == '/' ) {
				continue;
			}
			_csvData.Add( line.Split( ',' ) );

		}
	}
}

