using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance;

    public int killCount = 0;
    public TextMeshProUGUI killText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); // tránh trùng nếu reload scene
    }

    public void AddKill()
    {
        killCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        killText.text = "Kills: " + killCount;
    }
}
