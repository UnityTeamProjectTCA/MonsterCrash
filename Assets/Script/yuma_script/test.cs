using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.02f;
    public float bullet_speed = 3f;
    public GameObject bullet;
    public Transform muzzle;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //移動
            rb.position += new Vector3(speed, 0, 0);
            //向き
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.position += new Vector3(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.position += new Vector3(0, 0, speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.position += new Vector3(0, 0, -speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
            Vector3 force;
            force = this.gameObject.transform.forward * bullet_speed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            bullets.transform.position = new Vector3(muzzle.position.x, muzzle.position.y + 1f, muzzle.position.z+2f);

        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            Destroy(other.gameObject);
        }
    }
}
