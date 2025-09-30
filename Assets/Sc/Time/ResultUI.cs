using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ResltUI : MonoBehaviour
{
    [SerializeField] private Text rankingText; // ランキングを表示するText
    [SerializeField] private Text lastTimeText; // 今回のプレイタイムを表示するText

    void Start()
    {
        ShowRanking();
    }

    void ShowRanking()
    {
        // 今回のタイム
        float lastTime = RankingManager.Instance.GetLastTime();
        lastTimeText.text = "今回のタイム: " + lastTime.ToString("F2") + "秒";

        // ランキング
        var ranking = RankingManager.Instance.GetRanking();
        var sb = new StringBuilder();
        sb.AppendLine("ランキング");

        for (int i = 0; i < ranking.Count; i++)
        {
            sb.AppendLine($"{i + 1}位: {ranking[i].ToString("F2")}秒");
        }

        rankingText.text = sb.ToString();
    }
}
