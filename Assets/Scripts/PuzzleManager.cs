using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    public TextMeshProUGUI puzzlesRemainingText;

    [SerializeField]
    private int puzzlesRemaining;

    [SerializeField]
    private Canvas _canvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdatePuzzlesRemainingText();
        _canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        //CheckWinCondition();
    }

    public void DecrementPuzzlesRemaining()
    {
        if (puzzlesRemaining > 0)
        {
            puzzlesRemaining--;
            UpdatePuzzlesRemainingText();
            CheckWinCondition();
            Debug.Log("Puzzle has decremented.");
        }
    }

    private void UpdatePuzzlesRemainingText()
    {
        if (puzzlesRemainingText != null)
        {
            puzzlesRemainingText.text = puzzlesRemaining.ToString();
        }
    }

    private void CheckWinCondition()
    {
        if (puzzlesRemaining == 0)
        {
            Debug.Log("YOU WIN!");
            // Win condition logic here

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _canvas.gameObject.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
