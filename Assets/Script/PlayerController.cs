using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Rigidbody
    Rigidbody2D rigidbody2D;

    Animator animation;

    //力
    [SerializeField,Header("ジャンプの力")]
    float jumpForce = 680f;
    [SerializeField, Header("移動速度")]
    float walkForce = 30f;
    [SerializeField, Header("移動最大量")]
    float maxWalkSpeed = 2f;
    [SerializeField,Header("現在位置テキスト")]
    Text nowPosText;
    [SerializeField, Header("ゴール位置")]
    GameObject goalFlg;
    [SerializeField,Header("最大位置Y")]
    float gameMaxPosY;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //フレーム買う
        Application.targetFrameRate = 60;

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animation = GetComponent<Animator>();
        this.nowPosText = GameObject.Find("NowPos").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        Jump();
        //移動
        InputArrow();
        //現在の位置更新
        NowPosText();
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && this.rigidbody2D.velocity.y == 0)
        {
           
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
            animation.SetTrigger("Jump");
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
        if (this.transform.position.y == 0)
        {
            this.animation.speed = speed / 0.75f;
        }
        else
        {
            this.animation.speed = 1f;
        }

        if (this.transform.position.x < -10 || this.transform.position.x > 10)
        {
            SceneManager.LoadScene("GameScreen");
        }
        if(transform.position.y> gameMaxPosY)
        {
            transform.position = new Vector3(this.transform.position.x, gameMaxPosY, this.transform.position.z);
        }

    }


    void NowPosText()
    {
        Vector3 gameObject = this.gameObject.transform.position;
        var length = (int)(goalFlg.transform.position.y - gameObject.y);
         nowPosText.text = "ゴールまで:" + length.ToString()+"m";
        //nowPosText.text = "現在の位置:" +0;
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
