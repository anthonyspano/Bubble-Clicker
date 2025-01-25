using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // two buttons, one for buying goldfish, one for autoclick
    public Button buyGoldfishButton;
    public Button buyAutoclickButton;

    // two text fields, one for the cost of goldfish, one for the cost of autoclick
    public Text goldfishCostText;
    public Text autoclickCostText;

    public GameObject shopUI;
    public GameObject goldfishPrefab;

    public bool shopOpen = true;

    private AudioSource audioSource;
    public AudioClip popSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // show shop
            shopOpen = !shopOpen;
            shopUI.SetActive(shopOpen);
        }
    }

    public void spawnGoldfish()
    {
        // spawn a goldfish
        Instantiate(goldfishPrefab, new Vector2(600, Random.Range(-100, 275)), Quaternion.identity);
        PlayPopSound();
    }

    public void buyAutoclick()
    {
        // buy autoclick
        BubbleSpawner.instance.spawnRate++;
        PlayPopSound();
    }

    public void PlayPopSound()
    {
        Debug.Log("Playing pop sound");
        audioSource.PlayOneShot(popSound);
    }
}
