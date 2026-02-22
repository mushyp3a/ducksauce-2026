using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text timerTextWin;
    public bool runOnStart = true;

    float elapsed;
    bool  running;

    void Start()
    {
        if (runOnStart) StartTimer();
    }

    void Update()
    {
        if (!running) return;
        elapsed += Time.deltaTime;
        int mins = (int)(elapsed / 60);
        int secs = (int)(elapsed % 60);
        int ms   = (int)((elapsed * 100) % 100);
        timerText.text = string.Format("{0}:{1:00}.{2:00}", mins, secs, ms);
        timerTextWin.text = string.Format("{0}:{1:00}.{2:00}", mins, secs, ms);
    }

    public void StartTimer() { running = true; }
    public void StopTimer()  { running = false; }
    public void ResetTimer() { elapsed = 0; timerText.text = "0:00"; }
    public float GetTime()   { return elapsed; }
}
