using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChessRoomPuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject Key;

    [SerializeField]
    private GameObject PlayerPiece;

    [SerializeField]
    private GameObject KingPiece;

    private bool solved;

    private Vector3 initialPosition;

    private void Start()
    {
        PlayerPiece.GetComponent<Rigidbody>().useGravity = false;
        Key.SetActive(false);
        initialPosition = PlayerPiece.transform.position;
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
            KingPiece.SetActive(false);
       }

       if(PlayerPiece.transform.position != initialPosition) {
            PlayerPiece.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
