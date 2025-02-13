using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMovement : Sounds
{
    public int Last;

    public Transform spawn;
    public Transform[] spic;
    public int[] N;
    public int NNN;
    public Transform bulletMat;
    float time;

    public SkipElement Skip;

    public int dirX = 1;
    public int dirZ = 0;
    bool go;
    bool go1;
    float timeSinceLastMove = 0f;
    public float moveSpeed = 5f;

    public GameObject cam;
    public GameObject balk1;
    public GameObject on1;
    public GameObject balk2;
    public GameObject on2;

    public GameObject II;

    public List<GameObject> blocks;

    public bool glue;
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.SetQualityLevel(5);
        for (int i = 0; i < spic.Length; i++)
        {
            Skip.text[i].text = N[i].ToString("D1");
        }
    }
    void Update()
    {
        QualitySettings.shadowDistance = 30;

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            Element elementComponent = hit.collider.GetComponent<Element>();
            if (elementComponent != null && elementComponent.down)
            {
                transform.parent.Translate(Vector3.up * 4f * Time.deltaTime);
            }
        }
        if(transform.parent.transform.position.y > 3)
        {
            cam.GetComponent<MouseLook>().minVert = -20f;
        }
        if (go1)
        {
            if (Input.GetMouseButton(0) && N[NNN] != 0)
            {
                N[NNN]--;
                GameObject bull = Instantiate(spic[NNN]).gameObject as GameObject;
                bull.transform.position = spawn.position;
                bull.transform.parent = bulletMat;
                Last = NNN;
                gameObject.GetComponent<Animator>().SetTrigger("кидай");
                blocks.Add(bull);
                if (glue)
                {
                    bull.GetComponent<Element>().glue=true;
                    glue = false;
                    if (bull.GetComponent<HouseBlock>())
                    {
                        bull.GetComponent<HouseBlock>().enabled = false;
                        bull.GetComponent<HouseBlock>().door.SetActive(false);
                        bull.GetComponent<HouseBlock>().window.SetActive(true);
                    }
                }
                II.SetActive(false);
                go1 = false;
                for(int i = 0; i < spic.Length; i++)
                {
                    Skip.text[i].text = N[i].ToString("D1");
                }
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time >= 2)
            {
                if (N[NNN] != 0) { II.SetActive(true); }
                go1 = true;
                time = 0f;
            }
        }

        if (go)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                balk1.transform.parent = transform.parent;
                balk2.transform.parent = gameObject.transform;
                on1.SetActive(false);
                dirX = -1;
                dirZ = 0;
                go = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                balk1.transform.parent = transform.parent;
                balk2.transform.parent = gameObject.transform;
                on1.SetActive(false);
                dirX = 1;
                dirZ = 0;
                go = false;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                balk2.transform.parent = transform.parent;
                balk1.transform.parent = gameObject.transform;
                on2.SetActive(false);
                dirX = 0;
                dirZ = 1;
                go = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                balk2.transform.parent = transform.parent;
                balk1.transform.parent = gameObject.transform;
                on2.SetActive(false);
                dirX = 0;
                dirZ = -1;
                go = false;
            }
        }
        else
        {
            timeSinceLastMove += Time.deltaTime;
            if (timeSinceLastMove >= 1)
            {
                PlaySound(sounds[0], 0.5f, p1: 0.5f, p2: 0.5f);
                go = true;
                timeSinceLastMove = 0f;
                on1.SetActive(true);
                on2.SetActive(true);
            }
        }
        Move();
    }
    void Move()
    {
        transform.Translate(new Vector3(dirX * moveSpeed * Time.deltaTime, 0f, dirZ * moveSpeed * Time.deltaTime));

        if (transform.localPosition.x < -8.1f)
        {
            balk1.transform.parent = transform.parent;
            balk2.transform.parent = gameObject.transform;
            dirX = 1;
            dirZ = 0;
        }
        if(transform.localPosition.x > 8.1f)
        {
            balk1.transform.parent = transform.parent;
            balk2.transform.parent = gameObject.transform;
            dirX = -1;
            dirZ = 0;
        }
        if (transform.localPosition.z < -8.1f)
        {
            balk2.transform.parent = transform.parent;
            balk1.transform.parent = gameObject.transform;
            dirX = 0;
            dirZ = 1;
        }
        if(transform.localPosition.z > 8.1f)
        {
            balk2.transform.parent = transform.parent;
            balk1.transform.parent = gameObject.transform;
            dirX = 0;
            dirZ = -1;
        }
    }
}