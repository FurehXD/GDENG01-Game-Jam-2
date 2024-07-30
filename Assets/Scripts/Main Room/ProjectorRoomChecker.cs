using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectorRoomChecker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text1;

    [SerializeField]
    private TextMeshProUGUI text2;

    [SerializeField]
    private TextMeshProUGUI text3;

    [SerializeField]
    private int code;

    private bool _isFinished = false;

    private void Update()
    {
        CheckCode();
    }

    private void CheckCode()
    {
        string codeString = code.ToString();

        if (codeString.Length != 3)
        {
            Debug.LogError("Code must be a 3-digit number.");
            return;
        }

        if (text1 == null || text2 == null || text3 == null)
        {
            Debug.LogError("All TextMeshProUGUI fields must be assigned.");
            return;
        }

        if (text1.text == codeString[0].ToString() &&
            text2.text == codeString[1].ToString() &&
            text3.text == codeString[2].ToString())
        {
            if(_isFinished == false)
            {
                PuzzleManager.Instance.DecrementPuzzlesRemaining();
                _isFinished = true;
            }
            
        }
        
    }
}
