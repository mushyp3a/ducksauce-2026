using UnityEngine;

public class HandMovementHandler : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public int speed;
    public Transform rTarget;
    public Transform rTargetDefault;
    
    public Transform lTarget;
    public Transform lTargetDefault;

    bool left = true;

    int rSpeed = 10;
    int lSpeed = 10;

    public bool lLock = false;
    public bool rLock = false;

    public bool rDefault = true;
    public bool lDefault = true;

    public void Update()
    {
        Transform lTargetNow = lTarget ?? lTargetDefault;

        if (lTargetNow)
        {
            if (lLock) {
            leftHand.transform.position = lTargetNow.position;
        } else if (Vector2.Distance(lTargetNow.position, leftHand.transform.position) < 0.1) {
            lLock = true;
            leftHand.transform.position = lTargetNow.position;
        } else if (!lLock)
        {
            leftHand.transform.position = Vector2.MoveTowards(leftHand.transform.position, lTargetNow.position, Time.deltaTime * lSpeed);
        }
        }
        

        Transform rTargetNow = rTarget ?? rTargetDefault;

        if (rTargetNow)
        {
            if (rLock) {
            rightHand.transform.position = rTargetNow.position;
        }
        else if (Vector2.Distance(rTargetNow.position, rightHand.transform.position) < 0.1) {
            rLock = true;
            rightHand.transform.position = rTargetNow.position;
        } else if (!rLock)
        {
            rightHand.transform.position = Vector2.MoveTowards(rightHand.transform.position, rTargetNow.position, Time.deltaTime * rSpeed);
        }
        }
    }

    public void moveLeft(Transform target)
    {
        lLock = false;
        
        lTarget = target;
    }

    public void detachLeft()
    {
        lLock = false;
        lTarget = null;
    }

    public void moveRight(Transform target)
    {
        rLock = false;
        
        rTarget = target;
    }

    public void detactRight()
    {
        rLock = false;
        rTarget = null;
    }

    public void leftDefault(Transform target)
    {
        if (rTarget == null)
        {
            rLock = false;
        }
        lTargetDefault = target;
    }

    public void rightDefault(Transform target)
    {
        if (lTarget == null)
        {
            rLock = false;
        }
        rTargetDefault = target;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // public void moveHand(bool left, Transform target, bool defaultPos, int speed = 10)
    // {
    //     if (left)
    //     {
    //         lLock = false;
    //         lDefault = defaultPos;
    //         lTarget = target;
    //         lSpeed = speed;
    //     }
    //     else
    //     {
    //         rLock = false;
    //         rDefault = defaultPos;
    //         rTarget = target;
    //         rSpeed = speed;
    //     }
    // }
}
