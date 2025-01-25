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

    void Update()
    {
        currencyText.text = currency.ToString();
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

    public bool CanAfford(int amount)
    {
        return currency >= amount;
    }

    



}
