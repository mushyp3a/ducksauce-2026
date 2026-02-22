using System;
using UnityEngine;

public enum HoldType
{
    Super,
    Normal
}

public class HoldScript : MonoBehaviour
{
    public GameObject particle;
    public HoldType type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particle = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == HoldType.Super)
        {
            particle.SetActive(true);
        }
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
