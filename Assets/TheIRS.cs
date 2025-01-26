using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheIRS : MonoBehaviour
{
    public int taxRate;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bubble")
        {
            Debug.Log("IRS hit");
            CurrencyManager.instance.RemoveCurrency(taxRate);
            Destroy(other.gameObject);
        }
    }
}
