
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class GroundGenerator : MonoBehaviour
{

    [SerializeField]
        private GameObject _groundprefab;

    int _generatAllWeight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void GroundGerate()
    {

        Instantiate(_groundprefab,new Vector3(0.9134874f, -0.01606563f, 48.0954f),Quaternion.identity);
       

    }
}