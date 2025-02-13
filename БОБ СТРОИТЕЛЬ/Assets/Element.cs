using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Element : Sounds
{
    int sceneNumber;
    public bool end;
    public int i;// 1=блок/мусорный_бак  2=крыша  3=блок_дома/хрущевки/школа   4=грядка/горка  5=забор(разный)  6=баня/качель    7=гараж1   8=гараж2  9=гараж3   10=столб  11=паутинка
    public bool down;
    public bool destroy;
    public bool glue;
    public bool pol;
    public bool anim;
    public bool koord;
    public GameObject glueglue;
    void Start()
    {
        if (glue)
        {
            glueglue.SetActive(true);
        }
    }
    void Update()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        if (sceneNumber == 0)
        {
            if (anim)
            {
                gameObject.GetComponent<Animator>().SetTrigger("строй");
            }
            if (gameObject.GetComponent<BoxCollider>())
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
            }
            gameObject.GetComponent<AudioSource>().enabled = false;
            gameObject.GetComponent<SoundVolume>().enabled = false;
            gameObject.GetComponent<SoundVolume>().enabled = false;
            if (gameObject.GetComponent<Fence>()) { gameObject.GetComponent<Fence>().enabled = false; }
            if (gameObject.GetComponent<HouseBlock>()) { gameObject.GetComponent<HouseBlock>().enabled = false; }
            if (gameObject.GetComponent<HrushovkaBlock>()) { gameObject.GetComponent<HrushovkaBlock>().enabled = false; }
            gameObject.GetComponent<Element>().enabled = false;

        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "блок" && i != 5)
        {
            if (anim)
            {
                gameObject.GetComponent<Animator>().SetTrigger("строй");
            }
            if (i == 2)
            {
                if (col.GetComponent<Element>().i!=2)
                {
                    down = true;
                }
            } 
            else
            {
                down = true;
            }
            if (glue)
            {
                PlaySound(sounds[1], 1);
                gameObject.transform.parent = col.transform;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                glue = false;
            }
            else 
            {
                if (col.GetComponent<Element>().down != true && col.GetComponent<Element>().i > 0)
                {
                    PlaySound(sounds[0], p1: 0.7f, p2: 1.7f);
                }
            }
        }
        if (col.tag == "пол")
        {
            if (anim)
            {
                gameObject.GetComponent<Animator>().SetTrigger("строй");
            }
            PlaySound(sounds[0], p1: 0.7f, p2: 1.7f);
            pol = true;
            if (glue)
            {
                glue = false;
            }
        }
        if (col.tag == "звук")
        {
            if (anim)
            {
                gameObject.GetComponent<Animator>().SetTrigger("строй");
            }
            PlaySound(sounds[0], p1: 0.7f, p2: 1.7f);
            if (glue)
            {
                glue = false;
            }
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "блок")
        {
            down = false;
        }
        if (col.tag == "пол")
        {
            if (i != 5) { pol = false; }
        }
    }
}
