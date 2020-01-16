using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    public class SoundManager : Singleton<SoundManager>
        , IEating, IThrowing
    {
        [SerializeField] AudioSource audioSrcThrow;
        private AudioClip[] throwSounds;
        private int randomThrowSound;

        [SerializeField] AudioSource audioSrcEat;
        private AudioClip[] eatSounds;
        private int randomEatSound;

        [SerializeField] AudioSource audioSrcHit;
        private AudioClip[] hitSounds;
        private int randomhitSound;

        [SerializeField] AudioSource audioSrcClean;
        private AudioClip[] cleanSounds;
        private int randomcleanSound;

        [SerializeField] AudioSource audioSrcClock;
        [SerializeField] AudioClip tickingSound;
        [SerializeField] AudioClip timeUpSound;

        void Awake()
        {
            throwSounds = Resources.LoadAll<AudioClip>("throwSounds");
            eatSounds = Resources.LoadAll<AudioClip>("eatSounds");
            hitSounds = Resources.LoadAll<AudioClip>("hitSounds");
            cleanSounds = Resources.LoadAll<AudioClip>("cleanSounds");

            Clock.Instance.OnTimesUpEvent += PlayTimeUpSound;
            Clock.Instance.OnClockThresholdEvent += PlayTickingSound;
            GameManager.Instance.OnStartThrowEvent += PlayThrowSound;
        }

        public void PlayThrowSound()
        {
            randomThrowSound = Random.Range(0, 2);
            audioSrcThrow.PlayOneShot(throwSounds[randomThrowSound]);
        }

        public void PlayEatSound()
        {
            randomEatSound = Random.Range(0, 3);
            audioSrcEat.PlayOneShot(eatSounds[randomEatSound]);
        }

        public void PlayHitSound()
        {
            randomhitSound = Random.Range(0, 1);
            audioSrcHit.PlayOneShot(hitSounds[randomhitSound]);
        }

        public void PlayCleanSound()
        {
            randomcleanSound = Random.Range(0, 2);
            audioSrcClean.PlayOneShot(cleanSounds[randomcleanSound]);
        }

        public void PlayTickingSound()
        {
            Debug.Log("yes");
            audioSrcClock.PlayOneShot(tickingSound);
        }

        public void PlayTimeUpSound()
        {
            audioSrcClock.PlayOneShot(timeUpSound);
        }

        public void OnEat(EdibleObject o)
        {
            PlayEatSound();
        }

        public void OnHitChef(EdibleObject o)
        {
            PlayHitSound();
        }
    }

}
