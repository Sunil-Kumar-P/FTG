using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -3.5f;   //since we set movespeed which makes them static
    public static float rightSide = 3.5f;
    public float internalLeft;
    public float internalRight;


    // Update is called once per frame
    void Update()
    {
        internalLeft=leftSide;
        internalRight=rightSide;
        
    }
}
