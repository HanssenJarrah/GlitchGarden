using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int startingStars = 100;
    int currentStars;
    Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        currentStars = startingStars;
        UpdateDisplayAmount();
    }

    private void UpdateDisplayAmount()
    {
        starText.text = currentStars.ToString();
    }

    public void AddStars(int amount)
    {
        currentStars += amount;
        UpdateDisplayAmount();
    }

    public bool SpendStars(int amount)
    {
        if(currentStars - amount < 0) { return false; }
        currentStars -= amount;
        UpdateDisplayAmount();
        return true;
    }
}
