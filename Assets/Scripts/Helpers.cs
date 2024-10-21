using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Helpers : MonoBehaviour
{
    public static Dictionary<Button, Sprite> originalSprites = new Dictionary<Button, Sprite>();
    public static void ChangeBtnBackground(Button button, Sprite newBackground)
    {
        if (!originalSprites.ContainsKey(button))
        {
            originalSprites[button] = button.image.sprite;
        }

        button.image.sprite = (button.image.sprite == newBackground) ? originalSprites[button] : newBackground;

    }
}
