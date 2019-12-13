using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Vector2 widthThresold;
    private Vector2 heightThresold;
    [SerializeField] private Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        widthThresold = new Vector2();

    }

    // Update is called once per frame
    void Update()
    {
        hitBoundaries();
    }

    private void hitBoundaries()
    {
        if (!myRenderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string hitobject = collision.gameObject.tag;
        if (hitobject == "Obstacle")
        {
            obstracle obs = collision.gameObject.GetComponent<obstracle>();
            Debug.Log("Hit " + obs.HP--);
            if(obs.HP == 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

}
