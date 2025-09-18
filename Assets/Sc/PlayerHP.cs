using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100; // �ő�HP
    private int _health;

    [SerializeField]
    private GameObject _efect;

    [SerializeField]
    private GameObject _point;

    [SerializeField]
    private Slider _hpSlider; // �� Text����Slider�ɕύX

    private void Awake()
    {
        _health = _maxHealth;
        _hpSlider.maxValue = _maxHealth;  // �ő�l�ݒ�
        _hpSlider.value = _health;        // ���݂�HP�𔽉f
    }

    public void TekaDamage(int damage)
    {
        SEManager.Instance.PlayDamageSE();
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, _maxHealth); // 0�����ɂȂ�Ȃ��悤�ɂ���

        Instantiate(_efect, _point.transform.position, Quaternion.identity);

        _hpSlider.value = _health; // �� �X���C�_�[�X�V

        if (_health <= 0)
        {
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

        if (_health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");
        }
    }
}
