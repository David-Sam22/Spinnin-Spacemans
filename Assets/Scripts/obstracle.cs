using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstracle : MonoBehaviour
{
    [SerializeField] public int HP;

    public Vector3 startPos, endPos;
    public float rotSpeed, moveSpeed, scale, score;

    void Start()
    {
        transform.rotation = Random.rotation;
        transform.position = startPos;
        transform.localScale = new Vector3(scale,scale,scale);
        score = 10 * scale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        if (transform.position == endPos)
        {
            Destroy(this.gameObject);
        }
    }

    public void reducedHP(int amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
