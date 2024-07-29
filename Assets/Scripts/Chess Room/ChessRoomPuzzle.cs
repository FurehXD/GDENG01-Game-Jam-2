using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessRoomPuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject Key;

    private bool solved;

    private void Start()
    {
        Key.SetActive(false);
    }

    private void Update()
    {
       if(TileManager.Instance.CountMoves == 3)
       {
            solved = true;
       }

       if (solved == true)
       {
            Key.SetActive(true);
       }
    }
}
