using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderPlacement : MonoBehaviour
{
    Defender defender;

    private void OnMouseUp()
    {
        Vector2 clickWorldPos = GetPosClicked();
        Vector2 placementPos = SnapToGrid(clickWorldPos);
        PlaceDefender(placementPos);
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private Vector2 GetPosClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float snappedX = Mathf.Round(rawWorldPos.x);
        float snappedY = Mathf.Round(rawWorldPos.y);
        return new Vector2(snappedX, snappedY);
    }

    private void PlaceDefender(Vector2 atPosition)
    {
        Defender newDefender = Instantiate(defender, atPosition, Quaternion.identity);
    }
}
