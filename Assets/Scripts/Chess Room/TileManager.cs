using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;

    [SerializeField]
    private Material lightMat;
    public Material LightMat { get { return lightMat; } }

    [SerializeField]
    private List<Tile> tiles;


    private int countMoves = 0;
    public int CountMoves { get { return countMoves; } }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(tiles[0].IsSteppedOn);
        CheckTile();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    void CheckTile()
    {
        if (tiles.Count >= 5)
        {
            if (countMoves == 0 && tiles[0].IsSteppedOn)
            {
                countMoves++;
                tiles[0].ChangeMat = true;
            }

            else if (countMoves == 1 && (tiles[1].IsSteppedOn || tiles[2].IsSteppedOn))
            {
                countMoves++;

                if (tiles[1].IsSteppedOn)
                {
                    tiles[1].ChangeMat = true;
                }
                else if (tiles[2].IsSteppedOn)
                {
                    tiles[2].ChangeMat = true;
                }                
            }

            else if (countMoves == 2 && (tiles[3].IsSteppedOn || tiles[4].IsSteppedOn))
            {
                countMoves++;

                if (tiles[3].IsSteppedOn)
                {
                    tiles[3].ChangeMat = true;
                }
                else if (tiles[4].IsSteppedOn)
                {
                    tiles[4].ChangeMat = true;
                }
            }
        }
    }
}
