using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
	public class MixerController : MonoBehaviour {

		public AudioMixer audioMixer;
		public void SetMusicVolume(float volume)
		{
			if (volume <= -40)
				volume = -80;
			audioMixer.SetFloat("musicVolume", volume);
		}
	
		public void SetSfxVolume(float volume) {
			if (volume <= -40)
				volume = -80;
			audioMixer.SetFloat("sfxVolume", volume);
		}

		public void ToggleMusic(bool toggle) {
			if (toggle) {
				SetMusicVolume(0f);
			}
			else {
				SetMusicVolume(-80f);
			}
		}
	
		public void ToggleSfx(bool toggle) {
			if (toggle) {
				SetSfxVolume(0f);
			}
			else {
				SetSfxVolume(-80f);
			}
		}
	}
}
