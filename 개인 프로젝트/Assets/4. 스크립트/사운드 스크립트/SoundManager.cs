using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject prevSoundObj;
    public void SFXPlay(string sfxName, AudioClip clip,bool isBGM=false)
    {
        GameObject sound = new GameObject(sfxName + "Sound");
        AudioSource audioSource = sound.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        if(isBGM)
        {
            if(prevSoundObj != null)
            {
                Destroy(prevSoundObj);
            }              
            prevSoundObj = sound;
        }
        else
        {
            Destroy(sound, clip.length);
        }        
    }
}
