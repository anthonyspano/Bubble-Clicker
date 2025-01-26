using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PartyLights : MonoBehaviour
{
   PostProcessVolume m_Volume;
   ColorGrading m_ColorGrading;
   
   Vector4 redColor = new Vector4(0.25f, -0.35f, 0.55f, -0.15f); // good color
   Vector4 blueColor = new Vector4(0.2f, -0.06f, 0.94f, 0.1f); // good color
   Vector4 greenColor = new Vector4(-0.32f, -0.17f, 0.47f, -0.25f); 
   //Vector4 purpleColor = new Vector4(0.12f, -0.66f, 0.34f, -0.3f); 

/*       Vector4 redColor = new Vector4(0.13f, -0.87f, -0.66f, -0.75f);
   Vector4 blueColor = new Vector4(-0.46f, -0.38f, 0.54f, 0.2f);
   Vector4 greenColor = new Vector4(-0.89f, 0.11f, -0.68f, -0.55f); // good
   Vector4 purpleColor = new Vector4(0.12f, -0.66f, 0.34f, -0.8f);  */

    List<Vector4> colorWheel = new List<Vector4>();

    void Start()
    {
        colorWheel.Add(redColor);
        colorWheel.Add(blueColor);
        colorWheel.Add(greenColor);
        //colorWheel.Add(purpleColor);
        //currentColor = ColorWheel.Blue;
        m_Volume = GetComponent<PostProcessVolume>();

        // Create or use an existing profile
        if (m_Volume.sharedProfile == null)
        {
            m_Volume.sharedProfile = ScriptableObject.CreateInstance<PostProcessProfile>();
        }

        // Add ColorGrading if it's not already in the profile
        if (!m_Volume.sharedProfile.TryGetSettings(out m_ColorGrading))
        {
            m_ColorGrading = m_Volume.sharedProfile.AddSettings<ColorGrading>();
        }

        m_ColorGrading.enabled.Override(true);
        m_ColorGrading.lift.Override(redColor);
        //m_Volume.weight = .4f;

        StartCoroutine(FlashingColors());
    }

    IEnumerator FlashingColors()
    {
        
        int currentColor = 0;
        while(true)
        {
            // cycle through colors

            m_ColorGrading.lift.Override(colorWheel[currentColor]);
            Debug.Log("Current Color: " + colorWheel[currentColor]);
            yield return new WaitForSeconds(0.8f);
            currentColor++;
            if(currentColor >= colorWheel.Count)
                currentColor = 0;
            //Debug.Log("Current Lift: " + m_ColorGrading.lift.value);

        }
    }
}

