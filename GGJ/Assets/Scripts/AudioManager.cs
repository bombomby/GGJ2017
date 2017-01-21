using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip Audio_001;
    public AudioClip Audio_002;
    public AudioClip Audio_003;
    public AudioClip Audio_004;

    IDictionary<int, AudioSource> AudioSources;
    IDictionary<int, bool> ActiveAudio;
    //IDictionary<int, int> AudioWeight;

    // Use this for initialization
    void Start () {
        ActiveAudio = new Dictionary<int, bool>();
        //AudioWeight = new Dictionary<int, int>();
        AudioSources = new Dictionary<int, AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        foreach(var clip in ActiveAudio)
        {
            if(clip.Value)
            {
                if(!AudioSources[clip.Key].isPlaying)
                {
                    AudioSources[clip.Key].Play();
                }
            }
            else
            {
                AudioSources[clip.Key].Stop();
            }
        }
	}


    /// <summary>
    /// Get AudioClip
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private AudioClip GetCLip(int index)
    {
        switch(index)
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
        foreach(var source in AudioSources)
        {
            source.Value.loop = value;
        }
    }

    public void DesacActivateAllBut(IList<int> indexes)
    {
        foreach (var source in AudioSources)
        {
            if(!indexes.Contains(source.Key))
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

        if(!AudioSources.ContainsKey(index))
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
}
