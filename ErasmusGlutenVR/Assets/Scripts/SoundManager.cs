using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sndMan;

    [SerializeField] AudioSource audioSrcThrow;
    private AudioClip[] throwSounds;
    private int randomThrowSound;

    // Start is called before the first frame update
    void Start()
    {
        sndMan = this;
        throwSounds = Resources.LoadAll<AudioClip>("throwSounds");
    }

    public void PlayThrowSound()
    {
        randomThrowSound = Random.Range(0, 2);
        audioSrcThrow.PlayOneShot(throwSounds[randomThrowSound]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
