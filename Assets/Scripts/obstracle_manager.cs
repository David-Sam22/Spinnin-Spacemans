using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstracle_manager : MonoBehaviour
{
    //  [SerializeField] int numberSpawn;
    [SerializeField] float repeatrate;
    [SerializeField] GameObject obstracleObj;

    private Vector3 start, end;
    private int index, hp;
    private float speed, scale;
    // Start is called before the first frame update

    private void Awake()
    {
        start = Vector3.zero;
        end = Vector3.zero;
        index = 0;
    }
    void Start()
    {
        InvokeRepeating("instantiateObstractle", 2f, repeatrate);
    }

    private void instantiateObstractle()
    {
        GameObject obs = Instantiate(obstracleObj);
        setComponents(obs);
    }

    private void setComponents(GameObject obj)
    {
        index = Random.Range(0, 4);
        switch (index)
        {
            case 0: // right - bot cam
                start = new Vector3(24f, Random.Range(-13f, 13f), 0f);
                end = new Vector3(-24f, Random.Range(13f, -13f), 0f);
                scale = Random.Range(0.9f, 1.6f);
                hp = Mathf.RoundToInt(scale) * 2;
                speed = 6 - (scale * 3);
                break;
            case 1: // top - right cam
                start = new Vector3(Random.Range(-16f, 16f), 13f, 0f);
                end = new Vector3(Random.Range(16f, -16f), -13f, 0f);
                scale = Random.Range(0.9f, 1.6f);
                hp = Mathf.RoundToInt(scale) * 2;
                speed = 6 - (scale * 3);
                break;
            case 2: // left - top cam
                start = new Vector3(-24f, Random.Range(13f, -13f), 0f);
                end = new Vector3(24f, Random.Range(-13f, 13f), 0f);
                scale = Random.Range(0.9f, 1.6f);
                hp = Mathf.RoundToInt(scale) * 2;
                speed = 6 - (scale * 3);
                break;
            case 3: // left
                start = new Vector3(Random.Range(16f, -16f), -13f, 0f);
                end = new Vector3(Random.Range(-16f, 16f), 13f, 0f);
                scale = Random.Range(0.9f, 1.6f);
                hp = Mathf.RoundToInt(scale) * 2;
                speed = 6 - (scale * 3);
                break;
        }

        obj.GetComponent<obstracle>().startPos = start;
        obj.GetComponent<obstracle>().endPos = end;
        obj.GetComponent<obstracle>().scale = scale;
        obj.GetComponent<obstracle>().moveSpeed = speed;
        obj.GetComponent<obstracle>().HP = hp;
    }
}
