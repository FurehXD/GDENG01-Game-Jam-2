using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isSteppedOn = false;
    public bool IsSteppedOn { get { return isSteppedOn; } set { isSteppedOn = value; } }

    private bool changeMat = false;
    public bool ChangeMat { get {  return changeMat; } set {  changeMat = value; } }

    //private bool[] tileCheck = {false, false, false};
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(changeMat);
        if(this.changeMat)
        {
            this.GetComponent<Renderer>().material = TileManager.Instance.LightMat;
        }
    }

    //private void CheckTile()
    //{
    //    switch(this.type)
    //    {
    //        case 0: //startpoint
    //            if (this.isSteppedOn && !this.tileChecks[0])
    //            {
    //                this.GetComponent<Renderer>().material = lightMat;
    //                this.tileChecks[0] = true;
    //            }
    //            break;

    //        //case 1:
    //        //    if(this.isSteppedOn && this.tileChecks[0])
    //        //    {
    //        //       this.GetComponent<Renderer>().material = lightMat;
    //        //       this.tileChecks[1] = true;
    //        //    }
    //        //    break;

    //        //case 2:
    //        //    if(this.isSteppedOn/* && type1 is stepped on already*/)
    //        //    {

    //        //    }
    //        //    break;

    //        //default:
    //        //    this.GetComponent<Renderer>().material = defaultMat;
    //        //    break;
    //    }
    //}

    //private void resetChecks()
    //{
    //    for (int i = 0; i < this.tileCheck.Length; i++) { 
            
        
    //    }
    //}

}
