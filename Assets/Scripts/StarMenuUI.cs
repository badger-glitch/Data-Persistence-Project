using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.PlayerName();
    }
}
