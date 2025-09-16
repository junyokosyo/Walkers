using System;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private EnemyDeta[] _enemy;

    int _allWeight;
    void Start()
    {
        foreach (EnemyDeta enemdata in _enemy)
        {
            _allWeight += enemdata.Weight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public class EnemyDeta
{
    public GameObject EnemyPrefab;
    public int Weight;
}