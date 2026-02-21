using UnityEngine;

public class HandMovementHandler : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public int speed;
    Transform target;
    bool left = true;
    bool move = false;

    public void FixedUpdate()
    {
        if (left)
        {
            leftHand.transform.position = Vector3.MoveTowards(leftHand.transform.position, target.position, speed * Time.deltaTime);
            if (leftHand.transform.position == target.position)
            {
                move = false;
            }
        }
        else
        {
            rightHand.transform.position = Vector3.MoveTowards(rightHand.transform.position, target.position, speed * Time.deltaTime);
            if (rightHand.transform.position == target.position)
            {
                move = false;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void moveHand(bool left, Transform target)
    {
        this.left = left;
        this.target = target;
        move = true;
    }
}
