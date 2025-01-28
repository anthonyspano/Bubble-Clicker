using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQueueManager : MonoBehaviour
{
    public AudioSource audioSource1; // The AudioSource to play sounds
    public AudioSource audioSource2; // The AudioSource to play sounds
    public AudioSource audioSource3; // The AudioSource to play sounds
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
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    /// Adds an audio clip to the queue.
    public void EnqueueSound(AudioClip clip)
    {
        if(audioQueue.Count > 12)
        {
            //Debug.Log("Audio queue is full");
            return;
        }
        audioQueue.Enqueue(clip);
    }

    /// Plays the next clip in the queue.
    private IEnumerator PlayNextClip(AudioSource audioSource)
    {
        //isPlaying = true;

        // Get the next clip from the queue
        AudioClip nextClip = audioQueue.Dequeue();
        audioSource.clip = nextClip;
        audioSource.Play();
        Debug.Log("Playing clip: " + nextClip.name);
        // Wait until the clip finishes playing
        yield return new WaitForSeconds(0.25f);

        isPlaying = false;
    }
}
