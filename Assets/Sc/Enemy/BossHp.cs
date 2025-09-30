using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossHP : MonoBehaviour
{
    [SerializeField]
    private int _hp;
    [SerializeField]
    private GameObject _dieEffect;
    [SerializeField]
    private GameObject _damageEffectTarget;
    [SerializeField]
    private GameObject _levelmane;
    [SerializeField]
    private GameObject _efectpoj;

    Animator _anim;
    EnemyATK _bullet;
    LevelSystem _levelSystem;
    System.Random _random;
    void Start()
    {
        _bullet = GetComponent<EnemyATK>();
        _anim = GetComponent<Animator>();
        GameObject timer= GameObject.Find("Gamemaneger");
        if (timer != null)
        {
            var timesystem = timer.GetComponent<GameTimer>();
            timesystem.StartTimer();
        }


        GameObject obj = GameObject.Find("EXPManager");
        if (obj != null)
        {
            _levelSystem = obj.GetComponent<LevelSystem>();
        }

        _random = new System.Random();
       
    }
    public void TekaDamage(int damage)
    {
        SEManager.Instance.PlayAttackSE();
        Debug.Log(damage);
        Instantiate(_damageEffectTarget,_efectpoj.transform.position, Quaternion.identity);
        _hp -= damage;
        if (_hp <= 0)
        {
            SEManager.Instance.PlayBossDieSE();
            var fader = FindObjectOfType<ScreenFader>();
            if (fader != null)
            {
                fader.FadeOutAndCall(() =>
                {
                    Debug.Log("ホワイトアウト完了 → ゲームクリア処理へ");
                    OnGameClear();
                });
            }

            Instantiate(_dieEffect, _efectpoj.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);

            _levelSystem.AddExp(1);
        }

    }
    void OnGameClear()
    {
        GameTimer.Instance.StopTimer();
        float clearTime = GameTimer.Instance.GetTime();

        RankingManager.Instance.AddTime(clearTime);

        // 次のシーン（リザルト画面など）へ
        UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");
    }

}
