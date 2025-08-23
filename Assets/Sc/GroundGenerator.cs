
using UnityEngine;
using static UnityEditor.Progress;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField]
    private GroundDeta[] _groundDeta; 

    [SerializeField]
    private float _generatTime;

    int _generatAllWeight;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GroundDeta gd in _groundDeta)
        {
            _generatAllWeight += gd.Weight;
        }
    }

    // Update is called once per frame
    void GroundGerate()
    {
        Debug.Log("seisei");

    }
}

[System.Serializable]
public class GroundDeta
{
    public GameObject GameObject;
    public int Weight;
}