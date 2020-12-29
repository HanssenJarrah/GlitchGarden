using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    Color unselectedItemColour = new Color32(200, 200, 200, 255);

    private void OnMouseUp()
    {
        var shopItems = FindObjectsOfType<ShopItem>();
        foreach (ShopItem item in shopItems)
        {
            item.GetComponent<SpriteRenderer>().color = unselectedItemColour;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
