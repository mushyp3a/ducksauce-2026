using UnityEngine;

public class HoldDetector : MonoBehaviour
{
    public bool nearHold;
    public Transform pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nearHold = false;
        pos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.7f).gameObject.tag.Equals("HandHold"))
        {
            nearHold = true;
            pos = Physics2D.OverlapCircle(transform.position, 0.7f).gameObject.transform;
        }
        else
        {
            nearHold = false;
            pos = transform;
        }
    }
}
