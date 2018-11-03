using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class movietest : MonoBehaviour {
	[SerializeField] RawImage image = null;
	[SerializeField] VideoPlayer video = null;
	[SerializeField] AudioSource source = null;
	void Awake ( ) {
		video.EnableAudioTrack( 0, true );
		video.SetTargetAudioSource( 0, source );
	}
	void Update ( ) {
		image.texture = video.texture;
	}
}