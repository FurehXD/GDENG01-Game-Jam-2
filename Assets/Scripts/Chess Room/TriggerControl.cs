using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    [SerializeField]
    private Tile tile;

  //  [SerializeField]
    private float timeThreshold = 3.0f;

    private float time;

    [SerializeField]
    private GameObject piece;
    

    private void OnTriggerEnter(Collider other)
    {
     //   Debug.Log("Entered");
        //this.tile.IsSteppedOn = true;
    }

    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject == this.piece)
        {
            this.time += Time.deltaTime;
            Debug.Log("Staying");
        }

        if(this.time >= this.timeThreshold)
        {
            this.tile.IsSteppedOn = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        this.tile.IsSteppedOn = false;
        this.time = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
