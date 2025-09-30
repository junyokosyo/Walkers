using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance;

    private List<float> _times = new List<float>();
    private float _lastTime;  // ← 今回のプレイタイムを保持する変数

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

    public void AddTime(float time)
    {
        _lastTime = time; 
        _times.Add(time);
        _times = _times.OrderBy(t => t).ToList();

        if (_times.Count > 3)
        {
            _times = _times.Take(3).ToList(); 
        }
    }

    public List<float> GetRanking()
    {
        return _times;
    }

    public float GetLastTime()
    {
        return _lastTime; 
    }
}
