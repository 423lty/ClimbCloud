using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField,Header("ゲームオーバーUI")]
    GameObject gameOverUI;
    [SerializeField, Header("ゴールまでの位置")]
    GameObject nowPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameOverUI.SetActive(true);
            nowPos.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
