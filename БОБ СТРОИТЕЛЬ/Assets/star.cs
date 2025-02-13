using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star : MonoBehaviour
{
    public float speed = 3.0f;
    public float time;
    public float predel;
    public bool stt;
    public GameObject doter1;//прилет + полет
    public GameObject doter2;//улет + нету

    public Text tTt;
    public Text tTtMenu;
    public int r;
    public int re;
    int ro;

    public Reiting menu;
    public end END;

    void Start()
    {
        ro = r;
        Vector3 mov = transform.localPosition;
        mov.x = Random.Range(-7f, 7f);
        mov.z = Random.Range(-7f, 7f);
        transform.localPosition = mov;
        tTt.text = r.ToString("D1");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<RandomMovement>() && stt == false)
        {
            stt = true;
            r -= 1;
            tTt.text = r.ToString("D1");
            doter1.SetActive(false);
            doter2.SetActive(true);
        }
    }
    void Update()
    {
        if (r != 0)
        {
            if (stt)
            {
                time += Time.deltaTime;
                if (time > 1)
                {
                    gameObject.GetComponent<AudioSource>().enabled = false;
                }
                if (time > predel)
                {
                    stt = false;
                    time = 0;
                    doter1.SetActive(true);
                    doter2.SetActive(false);
                }
            }
            else
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
                if (END.Tab != true)
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
                if (transform.localPosition.x < -8.1f)
                {
                    Vector3 mov = transform.localPosition;
                    transform.localPosition = new Vector3(-8, transform.localPosition.y, transform.localPosition.z);
                    
                    float angle = Random.Range(-150, 150);
                    transform.Rotate(0, angle, 0);
                }
                if (transform.localPosition.x > 8.1f)
                {
                    Vector3 mov = transform.localPosition;
                    transform.localPosition = new Vector3(8, transform.localPosition.y, transform.localPosition.z);

                    float angle = Random.Range(-150, 150);
                    transform.Rotate(0, angle, 0);
                }
                if (transform.localPosition.z < -8.1f)
                {
                    Vector3 mov = transform.localPosition;
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -8);

                    float angle = Random.Range(-150, 150);
                    transform.Rotate(0, angle, 0);
                }
                if (transform.localPosition.z > 8.1f)
                {
                    Vector3 mov = transform.localPosition;
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 8);

                    float angle = Random.Range(-150, 150);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
        else
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
        tTtMenu.text = (ro - r).ToString("D1");
        menu.pigeons = ro - r;
        menu.pigeons_pred = ro;
    }
}
