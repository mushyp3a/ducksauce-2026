using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HoldDetector : MonoBehaviour
{
    public bool nearHold;
    public Transform pos;

    public HoldScript holdScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nearHold = false;
        pos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1f);

        if (hit != null && hit.CompareTag("HandHold"))
        {
            nearHold = true;

            GameObject obj = Physics2D.OverlapCircle(transform.position, 1f).gameObject;

            pos = obj.transform;
            holdScript = obj.GetComponent<HoldScript>();
        }
        else
        {
            nearHold = false;
            pos = transform;
        }
    }
}
