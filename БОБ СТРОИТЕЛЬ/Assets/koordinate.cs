using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koordinate : MonoBehaviour
{
    RandomMovement move;
    int t;
    public Transform[] koord;
    public float gotovo;
    int y;
    void Start()
    {
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<RandomMovement>();
    }
    void Update()
    {
        if (move.blocks.Count < koord.Length)
        {
            if (t != move.blocks.Count)
            {
                for (int i = 0; i < move.blocks.Count; i++)
                {
                    if (move.blocks[i].GetComponent<Element>().koord == false && (move.blocks[i].GetComponent<Element>().pol || move.blocks[i].GetComponent<Element>().down))
                    {
                        for (int j = 0; j < koord.Length; j++)
                        {
                            float dist = Vector3.Distance(move.blocks[i].transform.position, koord[j].position);
                            if (dist <= 0.8f)
                            {
                                move.blocks[i].GetComponent<Element>().koord = true; break;
                            }
                        }
                    }
                }
            }
            t = move.blocks.Count - 1;
        }
        else
        {
            GameObject[] moveSports = GameObject.FindGameObjectsWithTag("блок");
            if (t != -999)
            {
                for (int i = 0; i < move.blocks.Count; i++)
                {
                    if (move.blocks[i].GetComponent<Element>().koord) { y++; }
                }
                gotovo = y / (float)moveSports.Length;
                t = -999;
            }
        }
    }
}
