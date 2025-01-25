using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQueueManager : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource to play sounds
    private Queue<AudioClip> audioQueue = new Queue<AudioClip>(); // Queue to store audio clips
    private bool isPlaying = false;

    // singleton
    public static AudioQueueManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // If the AudioSource is not playing and there are clips in the queue
        if (!audioSource.isPlaying && audioQueue.Count > 0 && !isPlaying)
        {
            StartCoroutine(PlayNextClip());
        }
    }

    /// Adds an audio clip to the queue.
    public void EnqueueSound(AudioClip clip)
    {
        if(audioQueue.Count > 10)
        {
            Debug.Log("Audio queue is full");
            return;
        }
        audioQueue.Enqueue(clip);
    }

    /// Plays the next clip in the queue.
    private IEnumerator PlayNextClip()
    {
        isPlaying = true;

        // Get the next clip from the queue
        AudioClip nextClip = audioQueue.Dequeue();
        audioSource.clip = nextClip;
        audioSource.Play();

        // Wait until the clip finishes playing
        yield return new WaitForSeconds(nextClip.length);

        isPlaying = false;
    }
}
