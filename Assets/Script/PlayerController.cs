using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Rigidbody
    Rigidbody2D rigidbody2D;

    Animator animation;

    //力
    float jumpForce = 680f;

    float walkForce = 30f;

    float maxWalkSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //フレーム買う
        Application.targetFrameRate = 60;

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        Jump();
        //移動
        InputArrow();


    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
        }

    }
    /// <summary>
    /// 移動
    /// </summary>
    void InputArrow()
    {
        int key = 0;
        //左右
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = -1;
        }

        //スピード
        float speed = Mathf.Abs(this.rigidbody2D.velocity.x);

        if (speed < this.maxWalkSpeed)
        {
            this.rigidbody2D.AddForce(transform.right * key * this.walkForce);
        }

        //反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animation.speed = speed / 0.75f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("Goal");
            SceneManager.LoadScene("GameClear");
        }
    }

}
