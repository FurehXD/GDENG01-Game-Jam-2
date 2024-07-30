using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberChanger : MonoBehaviour, IInteractEffect
{
    [SerializeField]
    private TextMeshProUGUI numberText;

    void Start()
    {
        if (numberText != null && !int.TryParse(numberText.text, out _))
        {
            numberText.text = "0";
        }
    }

   

    public void ExecuteEffect()
    {
        if (numberText != null)
        {
            int currentNumber = int.Parse(numberText.text);

            currentNumber = (currentNumber + 1) % 10;

            numberText.text = currentNumber.ToString();
        }
    }
}
