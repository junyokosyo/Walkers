using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _attackSE;
    [SerializeField] private AudioClip _levelUpSE;
    [SerializeField] private AudioClip _damageSE;
    [SerializeField] private AudioClip _bossSE;
    private void Awake()
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

    public void PlayAttackSE() => _audioSource.PlayOneShot(_attackSE);
    public void PlayLevelUpSE() => _audioSource.PlayOneShot(_levelUpSE);
    public void PlayDamageSE() => _audioSource.PlayOneShot(_damageSE);
    public void PlayBossDieSE() => _audioSource.PlayOneShot(_bossSE);
}
