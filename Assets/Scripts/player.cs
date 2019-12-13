using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speedForce;
    [SerializeField] int Health;
    private shooting bullet;
    private float minX, maxX, minY, maxY;
    private Rigidbody playerRig;

    // Start is called before the first frame update
    private void Awake()
    {
        playerRig = GetComponent<Rigidbody>();
        bullet = GetComponent<shooting>();
        speedForce = 40f;
        minX = 0.05f;
        minY = 0.1f;
        maxX = 0.95f;
        maxY = 0.9f;
    }

    void Start()
    {
        Health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        lookatDirection();
        boundaries();

        if (bullet.isShot)
        {
            knockBack();
            bullet.isShot = false;
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Game over");
            //show gameover scene
        }
    }

    private void knockBack()
    {
        playerRig.AddForce(transform.up * -(speedForce + 50f));
    }

    private void boundaries()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        if (pos.x < minX)
        {
            pos.x = minX;
            playerRig.velocity = Vector3.zero;
        }

        if (pos.x > maxX)
        {
            pos.x = maxX;
            playerRig.velocity = Vector3.zero;
        }

        if (pos.y < minY)
        {
            pos.y = minY;
            playerRig.velocity = Vector3.zero;
        }
        if (pos.y > maxY)
        {
            pos.y = maxY;
            playerRig.velocity = Vector3.zero;
        }

            transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    private void lookatDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
        Rigidbody playerRig = GetComponent<Rigidbody>();
        playerRig.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string hitobject = collision.gameObject.tag;
        if (hitobject == "Obstacle")
        {
            Health--;
            Debug.Log("HP: " + Health + " left");
            Destroy(collision.gameObject);
        }
    }
}
