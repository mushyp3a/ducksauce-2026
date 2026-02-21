using System;
using Unity.VisualScripting;
using UnityEngine;

public class ArmAnimation : MonoBehaviour
{
    public Vector2 target;

    public void move(Vector2 target)
    {
        this.target = target;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target, Time.deltaTime * 10);
    }
}
