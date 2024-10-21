using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button[] allButtons = FindObjectsOfType<Button>(true);

        foreach (var b in allButtons)
        {
            b.onClick.AddListener(() => AudioManager.instance.PlaySFX("Click"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
