using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
