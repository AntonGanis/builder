using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookElement : MonoBehaviour
{
    RandomMovement move;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public GameObject hook;
    void Start()
    {
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomMovement>();
    }
    void Update()
    {
        for (int i = 0; i < move.blocks.Count; i++)
        {
            if (move.blocks[i].GetComponent<Element>().i == 7 || move.blocks[i].GetComponent<Element>().i == 9)
            {
                if (move.blocks[i].transform.position.y <= 0.7f && move.blocks[i].GetComponent<Element>().pol == false && move.blocks[i].GetComponent<Element>().i > 0)
                {
                    deffet(i);
                }

            }
            else if (move.blocks[i].GetComponent<Element>().i == 10)
            {
                if (move.blocks[i].transform.position.y <= 1.2F && move.blocks[i].GetComponent<Element>().pol == false && move.blocks[i].GetComponent<Element>().i > 0)
                {
                    deffet(i);
                }

            }
            else
            {
                if (move.blocks[i].transform.position.y <= 1.3f && move.blocks[i].GetComponent<Element>().pol == false && move.blocks[i].GetComponent<Element>().i > 0 && move.blocks[i].GetComponent<Element>().enabled == true)
                {
                    if (move.blocks[i].GetComponent<Element>().i == 5) { move.blocks[i].GetComponent<Fence>().enabled = false; }
                    deffet(i);
                }

            }
        }

    }
    void deffet(int i)
    {
        move.blocks[i].GetComponent<Element>().i = -1;
        if (move.blocks[i].transform.localPosition.x > 0 && move.blocks[i].transform.localPosition.z >= 0)
        {
            GameObject bull = Instantiate(hook).gameObject as GameObject;
            bull.GetComponent<Hook>().block = move.blocks[i].transform;
            bull.GetComponent<LOOK>().target = move.blocks[i].transform;
            bull.transform.position = point1.position;
        }
        if (move.blocks[i].transform.localPosition.x <= 0 && move.blocks[i].transform.localPosition.z > 0)
        {
            GameObject bull = Instantiate(hook).gameObject as GameObject;
            bull.GetComponent<Hook>().block = move.blocks[i].transform;
            bull.GetComponent<LOOK>().target = move.blocks[i].transform;
            bull.transform.position = point2.position;
        }
        if (move.blocks[i].transform.localPosition.x >= 0 && move.blocks[i].transform.localPosition.z < 0)
        {
            GameObject bull = Instantiate(hook).gameObject as GameObject;
            bull.GetComponent<Hook>().block = move.blocks[i].transform;
            bull.GetComponent<LOOK>().target = move.blocks[i].transform;
            bull.transform.position = point3.position;
        }
        if (move.blocks[i].transform.localPosition.x < 0 && move.blocks[i].transform.localPosition.z <= 0)
        {
            GameObject bull = Instantiate(hook).gameObject as GameObject;
            bull.GetComponent<Hook>().block = move.blocks[i].transform;
            bull.GetComponent<LOOK>().target = move.blocks[i].transform;
            bull.transform.position = point4.position;
        }
    }
}
