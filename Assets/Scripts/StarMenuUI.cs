using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarMenuUI : MonoBehaviour
{
    public TextMeshProUGUI name;

    public void StartGame()
    {
        GameManager.Instance.playerName = name.text;
        SceneManager.LoadScene(1);
    }
}
