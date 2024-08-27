using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField,Header("�Q�[���I�[�o�[UI")]
    GameObject gameOverUI;
    [SerializeField, Header("�S�[���܂ł̈ʒu")]
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
