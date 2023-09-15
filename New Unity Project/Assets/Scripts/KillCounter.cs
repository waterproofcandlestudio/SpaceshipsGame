using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text counterText;
    int kills;

    // Update is called once per frame
    void Update()
    {
        ShowKills();
        if (kills >= 15)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void ShowKills()
    {
        counterText.text = kills.ToString();
    }

    public void AddKill()
    {
        kills++;
    }
}
