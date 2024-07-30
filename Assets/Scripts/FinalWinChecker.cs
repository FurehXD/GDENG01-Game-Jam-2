using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWinChecker : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        _canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void ShowWinCanvas()
    {
        _canvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
