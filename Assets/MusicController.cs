using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

    [SerializeField] AudioSource audioSource;

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) MuteMusic();
        if (Input.GetKeyDown(KeyCode.N)) ChangeMusicVolume(.05f);
        if (Input.GetKeyDown(KeyCode.B)) ChangeMusicVolume(-.05f);
    }

	private void MuteMusic() {
        audioSource.mute = !audioSource.mute;
    }

    private void ChangeMusicVolume(float amount) {
        audioSource.volume += amount;
    }
}
