using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sndMan;

    [SerializeField] AudioSource audioSrcThrow;
    private AudioClip[] throwSounds;
    private int randomThrowSound;

    [SerializeField] AudioSource audioSrcEat;
    private AudioClip[] eatSounds;
    private int randomEatSound;


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

    public void PlayEatSound()
    {
        randomEatSound = Random.Range(0, 3);
        audioSrcEat.PlayOneShot(throwSounds[randomEatSound]);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
