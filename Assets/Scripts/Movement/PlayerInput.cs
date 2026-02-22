using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    HandMovementHandler handManager;
    public Transform[] positions;
    public float hangRadius;

    HoldDetector rHand;
    HoldDetector lHand;

    public Transform rDefault;
    public Transform lDefault;

    Rigidbody2D rb;
    bool holding;

    bool left;

    public float targetVelocity;
    public float forceStrength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        left = false;
        targetVelocity = 0;
        holding = false;
        handManager = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HandMovementHandler>();
        rb = GetComponent<Rigidbody2D>();
        rHand = GameObject.FindGameObjectWithTag("rHand").GetComponent<HoldDetector>();
        lHand = GameObject.FindGameObjectWithTag("lHand").GetComponent<HoldDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        float halfW = Camera.main.orthographicSize * Camera.main.aspect;
        if (transform.position.x > halfW)
            transform.position = new Vector3(-halfW, transform.position.y, transform.position.z);
        else if (transform.position.x < -halfW)
            transform.position = new Vector3(halfW, transform.position.y, transform.position.z);

        DistanceJoint2D joint = null;
        if (Input.GetKey(KeyCode.Space))
        {
            if (holding)
            {
                targetVelocity = Mathf.Min(targetVelocity + (3 * Time.deltaTime), 8);
                if (left)
                {
                    if (transform.position.y < lHand.pos.position.y && rb.linearVelocity.magnitude < targetVelocity)
                    {
                        rb.linearVelocity = rb.linearVelocity.normalized * targetVelocity;
                    }
                    else if (transform.position.y >= lHand.pos.position.y && rb.linearVelocityY > 0)
                    {
                        rb.linearVelocity *= 0.97f;
                    }
                    else
                    {
                        rb.gravityScale = 1;
                    }
                }
                else
                {
                    if (transform.position.y < rHand.pos.position.y && rb.linearVelocity.magnitude < targetVelocity)
                    {
                        rb.linearVelocity = rb.linearVelocity.normalized * targetVelocity;
                    }
                    else if (transform.position.y >= rHand.pos.position.y && rb.linearVelocityY > 0)
                    {
                        rb.linearVelocity *= 0.97f;
                    }
                    else
                    {
                        rb.gravityScale = 1;
                    }
                }
            }
            if (rHand.nearHold && !holding)
            {
                left = false;
                targetVelocity = rb.linearVelocity.magnitude;
                handManager.moveHand(false, rHand.pos, false);
                handManager.moveHand(true, lDefault, true);
                Destroy(gameObject.GetComponent<DistanceJoint2D>());

                joint = gameObject.AddComponent<DistanceJoint2D>();

                joint.autoConfigureDistance = false;
                joint.autoConfigureConnectedAnchor = false;

                Rigidbody2D holdRb = rHand.pos.GetComponent<Rigidbody2D>();

                joint.connectedBody = holdRb;
                joint.distance = hangRadius;

                joint.enableCollision = false;
                holding = true;
            }
            else if (lHand.nearHold && !holding)
            {
                left = true;
                targetVelocity = rb.linearVelocity.magnitude;
                handManager.moveHand(true, lHand.pos, false);
                handManager.moveHand(false, rDefault, true);
                Destroy(gameObject.GetComponent<DistanceJoint2D>());

                joint = gameObject.AddComponent<DistanceJoint2D>();

                joint.autoConfigureDistance = false;
                joint.autoConfigureConnectedAnchor = false;

                Rigidbody2D holdRb = lHand.pos.GetComponent<Rigidbody2D>();

                joint.connectedBody = holdRb;
                joint.distance = hangRadius;

                joint.enableCollision = false;
                holding = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && holding)
        {
            Destroy(gameObject.GetComponent<DistanceJoint2D>());
            holding = false;
            rb.linearVelocity = rb.linearVelocity.normalized * rb.linearVelocity.magnitude * 8f;
            handManager.moveHand(true, lDefault, true);
            handManager.moveHand(false, rDefault, true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && holding)
        {
            Destroy(gameObject.GetComponent<DistanceJoint2D>());
            rb.AddForceY(forceStrength, ForceMode2D.Impulse);
        }
    }
}
