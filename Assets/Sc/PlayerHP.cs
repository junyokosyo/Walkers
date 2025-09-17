using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int _health;

    [SerializeField]
    private GameObject _efect;

    [SerializeField]
    private GameObject _point;

    [SerializeField]
    private Text _life;

    private void Awake()
    {
        _life.text=_health.ToString();
    }
    public void TekaDamage(int damage)
    {

        _health -= damage;
        Instantiate(_efect, _point.transform.position, Quaternion.identity);
        _life.text = _health.ToString();
        if (_health <= 0)
        {
            Debug.Log(_health);
            StartCoroutine(HitstopCoroutine(2f, 0.3f));
        }
        else
        {
            StartCoroutine(HitstopCoroutine(0.3f, 0.3f));
        }
    }

    private IEnumerator HitstopCoroutine(float duration, float slowScale)
    {
        Time.timeScale = slowScale;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}
