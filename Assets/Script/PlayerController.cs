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

    //��
    [SerializeField,Header("�W�����v�̗�")]
    float jumpForce = 680f;
    [SerializeField, Header("�ړ����x")]
    float walkForce = 30f;
    [SerializeField, Header("�ړ��ő��")]
    float maxWalkSpeed = 2f;
    [SerializeField,Header("���݈ʒu�e�L�X�g")]
    Text nowPosText;
    [SerializeField, Header("�S�[���ʒu")]
    GameObject goalFlg;
    [SerializeField,Header("�ő�ʒuY")]
    float gameMaxPosY;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //�t���[������
        Application.targetFrameRate = 60;

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animation = GetComponent<Animator>();
        this.nowPosText = GameObject.Find("NowPos").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v
        Jump();
        //�ړ�
        InputArrow();
        //���݂̈ʒu�X�V
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
    /// �ړ�
    /// </summary>
    void InputArrow()
    {
        int key = 0;
        //���E
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = -1;
        }

        //�X�s�[�h
        float speed = Mathf.Abs(this.rigidbody2D.velocity.x);

        if (speed < this.maxWalkSpeed)
        {
            this.rigidbody2D.AddForce(transform.right * key * this.walkForce);
        }

        //���]
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
         nowPosText.text = "�S�[���܂�:" + length.ToString()+"m";
        //nowPosText.text = "���݂̈ʒu:" +0;
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
