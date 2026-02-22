using UnityEngine;
using Unity.Cinemachine;

public class ClimbCameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Vertical Follow")]
    public float upSmoothSlow  = 2f;
    public float upSmoothFast  = 8f;
    public float speedThreshold = 6f;

    public bool win = false;

    public Transform winPos;

    GameObject confetti;

    float    highestY;
    float    targetY;
    Camera   cam;

    void Start()
    {
        cam      = Camera.main;
        highestY = transform.position.y;
        targetY  = highestY;
        confetti = transform.GetChild(0).gameObject;
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (!win)
        {
            float playerY    = player.position.y;
            float playerSpeed = player.GetComponent<Rigidbody2D>().linearVelocity.magnitude;

            // only ever move the target up
            if (playerY > targetY)
                targetY = playerY;

            // smoothing speed scales with player speed
            float t = Mathf.InverseLerp(0, speedThreshold, playerSpeed);
            float smooth = Mathf.Lerp(upSmoothSlow, upSmoothFast, t);

            Vector3 pos = transform.position;
            pos.y = Mathf.Lerp(pos.y, targetY, smooth * Time.deltaTime);
            transform.position = pos;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, winPos.position.y, upSmoothFast * Time.deltaTime), transform.position.z);
        }

        if (transform.position == winPos.position)
        {
            confetti.SetActive(true);
        }
    }
}
