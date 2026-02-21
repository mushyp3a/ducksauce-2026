using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    HandMovementHandler handManager;
    public Transform[] positions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handManager = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HandMovementHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            handManager.moveHand(true, positions[0]);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            handManager.moveHand(true, positions[1]);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            handManager.moveHand(false, positions[2]);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            handManager.moveHand(false, positions[3]);
        }
    }
}
