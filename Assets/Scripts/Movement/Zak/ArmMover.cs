using UnityEngine;
using UnityEngine.InputSystem;



public enum Arm
{
    LEFT,
    RIGHT
}

public class ArmMover : MonoBehaviour
{
    private ArmAnimation leftArm;
    private ArmAnimation rightArm;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftArm = transform.Find("LeftTarget").GetComponent<ArmAnimation>();
        rightArm = transform.Find("RightTarget").GetComponent<ArmAnimation>();
    }

    void moveArm(Arm arm, Vector2 position)
    {
        if (arm.Equals(Arm.RIGHT))
        {
            rightArm.move(position);
        }
        else
        {
            leftArm.move(position);
        }
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();

            mousePos.z = Camera.main.nearClipPlane;

            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            worldMousePos.z = 0f;

            moveArm(Arm.RIGHT, worldMousePos);
        }
        
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();

            mousePos.z = Camera.main.nearClipPlane;

            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            worldMousePos.z = 0f;

            moveArm(Arm.LEFT, worldMousePos);
        }

        
    }
}
