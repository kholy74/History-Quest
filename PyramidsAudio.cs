using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidsAudio : MonoBehaviour
{
    private int currentClip;
    private AudioSource myAudioSource;
    //[SerializeField] AudioClip [] PyramidsClips;
    [SerializeField] AudioClip [] newPyramidsClips;
    [SerializeField] AudioClip QueenPyramids;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void StartClip(){
        if(newPyramidsClips[currentClip]!=null){
             myAudioSource.clip = newPyramidsClips[currentClip++];
             myAudioSource.Play();
        }
    }
    public void StartQueenClip(){
        if(QueenPyramids !=null){
             myAudioSource.clip = QueenPyramids;
             myAudioSource.Play();
        }
    }
    public void StopAnyClip(){
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
    }
}
