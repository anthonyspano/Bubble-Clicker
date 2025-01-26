using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public int currency;

    // UI
    public Text currencyText;

    // singleton
    public static CurrencyManager instance;

    // items
    public GameObject goldfishPrefab;
    public GameObject swordfishPrefab;
    public GameObject anglerPrefab;


    private Dictionary<GameObject, int> itemPrices = new Dictionary<GameObject, int>();
    private Dictionary<string, int> specialItems = new Dictionary<string, int>();

    private AudioSource audioSource;
    public AudioClip popSound;

    public Text goldfishPrice;
    public Text swordfishPrice;
    public Text anglerPrice;
    public Text autoClickerPrice;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        itemPrices.Add(goldfishPrefab, 100);
        itemPrices.Add(swordfishPrefab, 100);
        itemPrices.Add(anglerPrefab, 100);
        specialItems.Add("AutoClicker", 100);

        goldfishPrice.text = itemPrices[goldfishPrefab].ToString();
        swordfishPrice.text = itemPrices[swordfishPrefab].ToString();
        anglerPrice.text = itemPrices[anglerPrefab].ToString();
        autoClickerPrice.text = specialItems["AutoClicker"].ToString();

    }

    void Update()
    {
        currencyText.text = currency.ToString();
    }

    public void AttemptPurchase(GameObject item)
    {
        if(CanAfford(item))
        {
            RemoveCurrency(itemPrices[item]);
            // Spawn gameobject
            var screenSide = Random.Range(0, 1);
            if(screenSide == 0)
            {
                // spawn on right side
                Instantiate(item, new Vector2(600, Random.Range(-100, 275)), Quaternion.identity);
            }
            else
            {
                Instantiate(item, new Vector2(-600, Random.Range(-100, 275)), Quaternion.identity);
            }
            audioSource.PlayOneShot(popSound);
        }
    }

    public void AttemptPurchaseAutoClicker()
    {
        if(CanAfford("AutoClicker"))
        {
            RemoveCurrency(specialItems["AutoClicker"]);
            // Upgrade AutoClicker
            BubbleSpawner.instance.spawnRate++;
        }
    }

    private bool CanAfford(GameObject item)
    {
        return currency >= itemPrices[item];
    }

    private bool CanAfford(string specialItem)
    {
        return currency >= specialItems[specialItem];
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        currencyText.text = currency.ToString();
    }   

    public void RemoveCurrency(int amount)
    {
        currency -= amount;
    }








}
