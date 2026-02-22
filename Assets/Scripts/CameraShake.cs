using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    [Header("Defaults")]
    public float defaultDuration  = 0.2f;
    public float defaultMagnitude = 0.15f;
    public float dampingSpeed     = 3f;

    Vector3 originPos;
    float   shakeDuration;
    float   shakeMagnitude;
    float   timer;

    void Awake()
    {
        Instance  = this;
        originPos = transform.localPosition;
    }

    void Update()
    {
        if (timer <= 0) return;

        timer -= Time.deltaTime;
        float strength = Mathf.Lerp(0, shakeMagnitude, timer / shakeDuration);
        transform.localPosition = originPos + (Vector3)Random.insideUnitCircle * strength;

        if (timer <= 0)
            transform.localPosition = originPos;
    }

    public void Shake() => Shake(defaultDuration, defaultMagnitude);

    public void Shake(float duration, float magnitude)
    {
        originPos      = transform.localPosition;
        shakeDuration  = duration;
        shakeMagnitude = magnitude;
        timer          = duration;
    }
}
