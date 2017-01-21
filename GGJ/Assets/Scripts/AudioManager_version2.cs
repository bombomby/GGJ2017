using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_version2 : MonoBehaviour {

    public string Music = "Music";
    public string VFX = "VFX";

    // private parameters
    private AudioSource music;
    private AudioLowPassFilter audioLowPassFilter_music;
    private AudioHighPassFilter audioHighPassFilter_music;
    private AudioDistortionFilter musicDistortionFilter_music;
    private AudioReverbFilter audioReverbFilter_music;

    private AudioLowPassFilter audioLowPassFilter_vfx;
    private AudioHighPassFilter audioHighPassFilter_vfx;
    private AudioDistortionFilter musicDistortionFilter_vfx;
    private AudioReverbFilter audioReverbFilter_vfx;

    private AudioSource vfx;

    private List<Component> musicEffects;
    private List<Component> vfxEffects;

    private AudioDistortionFilter distortion;

    // Use this for initialization
    void Start()
    {
        // get Composents

        var allComponents = gameObject.transform.GetComponentsInChildren(typeof(Component));

        musicEffects = new List<Component>();
        vfxEffects = new List<Component>();
        /*
        // gather all music components
        foreach (var component in allComponents)
        {
            if(component.name.Equals(Music))
            {
                if(!(component is AudioSource) && !(component is Transform))
                {


                    musicEffects.Add(component);
                }
            }

            if (component.name.Equals(VFX))
            {
                if (!(component is AudioSource) && !(component is Transform))
                {
                    vfxEffects.Add(component);
                }
            }
        }
        */

        // initialize nusic and vfx
        var audioSources = gameObject.transform.GetComponentsInChildren<AudioSource>();
        if(audioSources.Length >= 1)
        {
            music = audioSources[0];

            audioLowPassFilter_music = music.gameObject.AddComponent<AudioLowPassFilter>();
            audioHighPassFilter_music = music.gameObject.AddComponent<AudioHighPassFilter>();
            musicDistortionFilter_music = music.gameObject.AddComponent<AudioDistortionFilter>();
            musicDistortionFilter_music.distortionLevel = 2;

            audioReverbFilter_music = music.gameObject.AddComponent<AudioReverbFilter>();
            audioReverbFilter_music.reverbPreset = AudioReverbPreset.Bathroom;
        }

        if (audioSources.Length >= 2)
        {
            vfx = audioSources[1];
            audioLowPassFilter_vfx = vfx.gameObject.AddComponent<AudioLowPassFilter>();
            audioHighPassFilter_vfx = vfx.gameObject.AddComponent<AudioHighPassFilter>();
            musicDistortionFilter_vfx = vfx.gameObject.AddComponent<AudioDistortionFilter>();
            musicDistortionFilter_vfx.distortionLevel = 2;

            audioReverbFilter_vfx = vfx.gameObject.AddComponent<AudioReverbFilter>();
            audioReverbFilter_vfx.reverbPreset = AudioReverbPreset.Bathroom;
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
                musicDistortionFilter_music.enabled = value;
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
    /*
    /// <summary>
    /// Get AudioClip
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private AudioClip GetCLip(int index)
    {
        switch (index)
        {
            case 0: return Audio_001;
            case 1: return Audio_002;
            case 2: return Audio_003;
            case 3: return Audio_004;
            default: return null;
        }
    }

    /// <summary>
    /// Loop
    /// </summary>
    public void Loops(bool value)
    {
        foreach (var source in AudioSources)
        {
            source.Value.loop = value;
        }
    }

    public void DesacActivateAllBut(IList<int> indexes)
    {
        foreach (var source in AudioSources)
        {
            if (!indexes.Contains(source.Key))
            {
                source.Value.Stop();
                source.Value.loop = false;
            }
        }
    }

    public void ActivateAudio(int index, bool value)
    {
        ActiveAudio[index] = value;
        //AudioWeight[index] += value ? 1 : -1;

        if (!AudioSources.ContainsKey(index))
        {
            //AudioSource source = new AudioSource();

            //AudioSource source = Instantiate(new AudioSource(), transform.position, Quaternion.identity);

            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = GetCLip(index);
            audioSource.loop = true;

            audioSource.transform.SetParent(transform);

            AudioSources.Add(index, audioSource);
        }
    }
    */
}
