using UnityEngine;
using UnityEngine.SceneManagement;
public class MergeScenes : MonoBehaviour {
	void Start( ) {
        SceneManager.LoadScene( "Stage1", LoadSceneMode.Additive );
		//Application.LoadLevelAdditive("BuildingStage1");
	}
}
