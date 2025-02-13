using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fence : Sounds
{
    int sceneNumber;

    public GameObject zabor;
    public Transform look;
    public Transform svaz;
    public Transform next;

    public Transform delit;

    public bool Delete;
    public bool flag;
    public bool end;
    public float dist;
    public List<GameObject> blocks;

    bool go;
    void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "пол")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Element>().pol = true;
            gameObject.GetComponent<Element>().enabled = false;
            go = true;
        }
    }

    void Update()
    {
        if (sceneNumber == SceneManager.GetActiveScene().buildIndex)
        {
            if (go)
            {
                if (flag)
                {
                    if (next != null)
                    {
                        if (next.gameObject.activeSelf == true)
                        {
                            if (next.GetComponent<Element>().pol == true)
                            {
                                dist = Vector3.Distance(transform.position, next.position);
                                look.GetComponent<LOOK>().enabled = true;
                                look.GetComponent<LOOK>().target = next;
                                for (float i = 0; i < dist; i += 0.325f)
                                {
                                    GameObject WALL0 = Instantiate(zabor) as GameObject;
                                    WALL0.transform.rotation = look.rotation;
                                    WALL0.transform.parent = look;
                                    WALL0.GetComponent<FenceOne>().I = (int)i * 2;
                                    WALL0.transform.localPosition = new Vector3(0.25f, 0, i);
                                    blocks.Add(WALL0);
                                }
                                svaz.localPosition = new Vector3(0.1626434f, 0.3131f, dist / 2);
                                svaz.localScale = new Vector3(0.1519037f, dist / 2, 0.1519037f);
                                flag = false;
                                end = true;
                                PlaySound(sounds[0], 1);
                            }
                        }
                        else
                        {
                            flag = false;
                            if (blocks.Count != 0)
                            {
                                for (int i = 0; i < blocks.Count; i++)
                                {
                                    GameObject WALL0 = blocks[i];
                                    blocks.RemoveAt(i);
                                    Instantiate(delit, WALL0.transform.position, WALL0.transform.rotation);
                                    Destroy(WALL0);
                                }
                            }
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    if (end == false || next.gameObject.activeSelf == false || next == null)
                    {
                        look.GetComponent<LOOK>().enabled = false;
                        svaz.localPosition = new Vector3(-0.1626434f, 0.3131f, 0.09074402f);
                        svaz.localScale = new Vector3(0.1519037f, 0.0918567f, 0.1519037f);
                        for (int i = 0; i < blocks.Count; i++)
                        {
                            GameObject WALL0 = blocks[i];
                            blocks.RemoveAt(i);
                            Instantiate(delit, WALL0.transform.position, WALL0.transform.rotation);
                            Destroy(WALL0);
                        }
                        end = false;
                        if (next != null)
                        {
                            if (next.gameObject.activeSelf == false)
                            {
                                for (int i = 0; i < next.GetComponent<Fence>().blocks.Count; i++)
                                {
                                    Instantiate(delit, next.GetComponent<Fence>().blocks[i].transform.position, next.GetComponent<Fence>().blocks[i].transform.rotation);
                                }
                                next = null;
                            }
                        }
                    }
                }
            }

        }
        else { gameObject.GetComponent<Fence>().enabled = false; }
    }
}
