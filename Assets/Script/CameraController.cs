using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("cat").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
    }
}
