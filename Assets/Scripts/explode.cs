using UnityEngine;

public class explode : MonoBehaviour
{
    public GameObject confetti;

    public void explodeGuy()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        confetti.SetActive(true);
    }
}
