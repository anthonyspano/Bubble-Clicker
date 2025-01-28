using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popuptext : MonoBehaviour
{
    public GameObject popupTextPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnPopupText();
        }
    }

    void SpawnPopupText()
    {
        Instantiate(popupTextPrefab, new Vector2(0,Screen.height), Quaternion.identity);
    }
}
