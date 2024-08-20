using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Rigidbody
    Rigidbody2D rigidbody2D;

    Animator animation;

    //��
    float jumpForce = 680f;

    float walkForce = 30f;

    float maxWalkSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //�t���[������
        Application.targetFrameRate = 60;

        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v
        Jump();
        //�ړ�
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
