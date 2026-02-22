using UnityEngine;

public class HandMovementHandler : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public int speed;
    Transform rTarget;
    Transform lTarget;
    bool left = true;

    int rSpeed;
    int lSpeed;

    public bool lLock = false;
    public bool rLock = false;

    public bool rDefault = true;
    public bool lDefault = true;

    public void Update()
    {
        if (lLock) {
            leftHand.transform.position = lTarget.position;
        } else if (Vector2.Distance(lTarget.position, leftHand.transform.position) < 0.1) {
            lLock = true;
            leftHand.transform.position = lTarget.position;
        } else if (!lLock)
        {
            leftHand.transform.position = Vector2.MoveTowards(leftHand.transform.position, lTarget.position, Time.deltaTime * lSpeed);
        }


        if (rLock) {
            rightHand.transform.position = rTarget.position;
        }
        else if (Vector2.Distance(rTarget.position, rightHand.transform.position) < 0.1) {
            rLock = true;
            rightHand.transform.position = rTarget.position;
        } else if (!rLock)
        {
            rightHand.transform.position = Vector2.MoveTowards(rightHand.transform.position, rTarget.position, Time.deltaTime * rSpeed);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void moveHand(bool left, Transform target, bool defaultPos, int speed = 10)
    {
        if (left)
        {
            lLock = false;
            lDefault = defaultPos;
            lTarget = target;
            lSpeed = speed;
        }
        else
        {
            rLock = false;
            rDefault = defaultPos;
            rTarget = target;
            rSpeed = speed;
        }
    }
}
