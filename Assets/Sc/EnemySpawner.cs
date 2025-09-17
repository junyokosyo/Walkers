using System;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private EnemyDeta[] _enemy;

    [SerializeField]
    private Transform[] _spawnPoint;

    [SerializeField]
    private float _spawnTime=3f;

    float _spawnCount = 0f;
    int _allWeight;

    System.Random  _random;
    void Start()
    {
         _random = new System.Random(); 
        foreach (EnemyDeta enemdata in _enemy)
        {
            _allWeight += enemdata.Weight;
        }
    }

    void Update()
    {
        _spawnCount += Time.deltaTime;
        if (_spawnCount > _spawnTime)
        {
            int spawnPoint = _random.Next(0, _spawnPoint.Length);

            int randamenemy = _random.Next(1, _allWeight);
            foreach (var enemdate in _enemy)
            {
                randamenemy -= enemdate.Weight;
                if (randamenemy < 0)
                {
                    Instantiate(enemdate.EnemyPrefab).transform.position=
                        _spawnPoint[spawnPoint].transform.position;
                    _spawnCount = 0;
                }
            }
        }
    }
}
[Serializable]
public class EnemyDeta
{
    public GameObject EnemyPrefab;
    public int Weight;
}