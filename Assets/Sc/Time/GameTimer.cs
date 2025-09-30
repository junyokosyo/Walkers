using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    private float _time;
    private bool _isRunning;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (_isRunning)
        {
            _time += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        _time = 0f;
        _isRunning = true;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public float GetTime()
    {
        return _time;
    }
}
