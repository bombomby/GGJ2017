using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_version2 : MonoBehaviour {

    public string Music = "Music";
    public string VFX = "VFX";

    public float DistortionLevel = 1;
    public AudioReverbPreset Reverb = AudioReverbPreset.Bathroom;

    // private parameters
    private AudioSource music;
    private AudioLowPassFilter audioLowPassFilter_music;
    private AudioHighPassFilter audioHighPassFilter_music;
    private AudioDistortionFilter musicDistortionFilter_music;
    private AudioReverbFilter audioReverbFilter_music;

    private AudioSource vfx;
    private AudioLowPassFilter audioLowPassFilter_vfx;
    private AudioHighPassFilter audioHighPassFilter_vfx;
    private AudioDistortionFilter musicDistortionFilter_vfx;
    private AudioReverbFilter audioReverbFilter_vfx;

   

    // Use this for initialization
    void Start()
    {
        // initialize nusic and vfx
        var audioSources = gameObject.transform.GetComponentsInChildren<AudioSource>();
        if(audioSources.Length >= 1)
        {
            music = audioSources[0];

            audioLowPassFilter_music = music.gameObject.GetComponent<AudioLowPassFilter>();
            audioHighPassFilter_music = music.gameObject.GetComponent<AudioHighPassFilter>();
            musicDistortionFilter_music = music.gameObject.GetComponent<AudioDistortionFilter>();
            musicDistortionFilter_music.distortionLevel = DistortionLevel;

            audioReverbFilter_music = music.gameObject.GetComponent<AudioReverbFilter>();
            audioReverbFilter_music.reverbPreset = Reverb;
        }

        if (audioSources.Length >= 2)
        {
            vfx = audioSources[1];
            audioLowPassFilter_vfx = vfx.gameObject.AddComponent<AudioLowPassFilter>();
            audioHighPassFilter_vfx = vfx.gameObject.AddComponent<AudioHighPassFilter>();
            musicDistortionFilter_vfx = vfx.gameObject.AddComponent<AudioDistortionFilter>();
            musicDistortionFilter_vfx.distortionLevel = DistortionLevel;

            audioReverbFilter_vfx = vfx.gameObject.AddComponent<AudioReverbFilter>();
            audioReverbFilter_vfx.reverbPreset = Reverb;
        }

        //disable all effects
        for (int i = 0; i < 4; i++)
        {
            EnableEffects(i, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // nothing 
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    private void EnableEffects(int i, bool value)
    {
        switch(i)
        {
            case 0:
                audioLowPassFilter_music.enabled = value;
                audioLowPassFilter_vfx.enabled = value;
                break;
            case 1:
                audioHighPassFilter_music.enabled = value;
                audioHighPassFilter_vfx.enabled = value;
                break;
            case 2:
                musicDistortionFilter_music.enabled = false;
                musicDistortionFilter_vfx.enabled = value;
                break;
            case 3:
                audioReverbFilter_music.enabled = value;
                audioReverbFilter_vfx.enabled = value;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="indices"></param>
    public void ActivateEffects(IList<int> indices)
    {
        for(int i=0; i<4; i++)
        {
            EnableEffects(i, false);
        }

        foreach(int i in indices)
        {
            EnableEffects(i, true);
        }
    }
}
