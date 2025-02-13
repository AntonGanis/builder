using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Element : Sounds
{
    int sceneNumber;
    public bool end;
    public int i;// 1=����/��������_���  2=�����  3=����_����/��������/�����   4=������/�����  5=�����(������)  6=����/������    7=�����1   8=�����2  9=�����3   10=�����  11=��������
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
                gameObject.GetComponent<Animator>().SetTrigger("�����");
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
        if (col.tag == "����" && i != 5)
        {
            if (anim)
            {
                gameObject.GetComponent<Animator>().SetTrigger("�����");
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
        if (col.tag == "���")
        {
            if (anim)
            {
                gameObject.GetComponent<Animator>().SetTrigger("�����");
            }
            PlaySound(sounds[0], p1: 0.7f, p2: 1.7f);
            pol = true;
            if (glue)
            {
                glue = false;
            }
        }
        if (col.tag == "����")
        {
            if (anim)
            {
                gameObject.GetComponent<Animator>().SetTrigger("�����");
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
        if (col.tag == "����")
        {
            down = false;
        }
        if (col.tag == "���")
        {
            if (i != 5) { pol = false; }
        }
    }
}
