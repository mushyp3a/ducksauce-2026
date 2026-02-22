using System;
using UnityEngine;

public enum HoldType
{
    Super,
    Normal
}

public class HoldScript : MonoBehaviour
{

    public HoldType type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getMult()
    {
        return type switch
        {
            HoldType.Super => 5,
            _ => 1,
        };
    }
}
