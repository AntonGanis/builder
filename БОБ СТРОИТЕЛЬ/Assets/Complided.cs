using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complided : MonoBehaviour
{
    public bool of;// для материнского объекта

    public int TIP_Complided; // 0=крыши 1=блока 2=N_крыш
    int shit;

    public int TIP;// тригер тип
    public int I;//число у игрока
    public bool end;// флажок конца цикла
    public float kon;// конечная высота
    public int kolvo;// количество крыш
    public int kolvo_dop;// всромогательная
    RandomMovement move;
    float time;
    end component;

    int opt;
    void Start()
    {
        component = FindObjectOfType<end>();
        move = FindObjectOfType<RandomMovement>();
    }
    void Update()
    {
        if (opt > 4)
        {
            if (move.N[I] != 0)
            {
                if (TIP_Complided == 0)
                {
                    for (int i = 0; i < move.blocks.Count; i++)
                    {
                        if (move.blocks[i].transform.position.y >= kon && move.blocks[i].GetComponent<Element>().down && move.blocks[i].GetComponent<Element>().i == TIP && move.blocks[i].GetComponent<Element>().end == false)
                        {
                            end = true;
                            move.blocks[i].GetComponent<Element>().end = true;
                        }
                    }
                }
                else if (TIP_Complided == 2)
                {
                    for (int i = 0; i < move.blocks.Count; i++)
                    {
                        if (move.blocks[i].transform.position.y >= kon && move.blocks[i].GetComponent<Element>().down && move.blocks[i].GetComponent<Element>().i == TIP && move.blocks[i].GetComponent<Element>().end == false)
                        {
                            move.blocks[i].GetComponent<Element>().end = true;
                            kolvo_dop++;
                        }
                    }
                    if (kolvo == kolvo_dop)
                    {
                        end = true;
                    }
                }
                else
                {
                    for (int i = 0; i < move.blocks.Count; i++)
                    {
                        if ((move.blocks[i].GetComponent<Element>().down || move.blocks[i].GetComponent<Element>().pol) && move.blocks[i].GetComponent<Element>().i == TIP && move.blocks[i].GetComponent<Element>().end == false)
                        {
                            move.blocks[i].GetComponent<Element>().end = true;
                            shit++;
                        }
                    }
                    if (shit == kon)
                    {
                        end = true;
                    }
                }
            }
            else
            {
                time += Time.deltaTime;
                if (time > 1)
                {
                    if (TIP_Complided == 0)
                    {
                        for (int i = 0; i < move.blocks.Count; i++)
                        {
                            if (move.blocks[i].transform.position.y >= kon && move.blocks[i].GetComponent<Element>().down && move.blocks[i].GetComponent<Element>().i == TIP && move.blocks[i].GetComponent<Element>().end == false)
                            {
                                end = true;
                                move.blocks[i].GetComponent<Element>().end = true;
                            }
                        }
                        if (end == false)
                        {
                            for (int i = 0; i < component.Comp.Length; i++)
                            {
                                if (component.Comp[i].gameObject == gameObject)
                                {
                                    component.Comp[i] = null;
                                    if (component.Comp.Length > 1)
                                    {
                                        for (int j = i; j < component.Comp.Length - 1; j++)
                                        {
                                            component.Comp[j] = component.Comp[j + 1];
                                        }
                                        component.Comp[component.Comp.Length - 1] = null;
                                    }
                                    System.Array.Resize(ref component.Comp, component.Comp.Length - 1);
                                    gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < move.blocks.Count; i++)
                        {
                            if ((move.blocks[i].GetComponent<Element>().down || move.blocks[i].GetComponent<Element>().pol) && move.blocks[i].GetComponent<Element>().i == TIP && move.blocks[i].GetComponent<Element>().end == false)
                            {
                                move.blocks[i].GetComponent<Element>().end = true;
                                shit++;
                            }
                        }
                        if (shit != kon)
                        {
                            for (int i = 0; i < component.Comp.Length; i++)
                            {
                                if (component.Comp[i].gameObject == gameObject)
                                {
                                    component.Comp[i] = null;
                                    if (component.Comp.Length > 1)
                                    {
                                        for (int j = i; j < component.Comp.Length - 1; j++)
                                        {
                                            component.Comp[j] = component.Comp[j + 1];
                                        }
                                        component.Comp[component.Comp.Length - 1] = null;
                                    }
                                    System.Array.Resize(ref component.Comp, component.Comp.Length - 1);
                                    gameObject.SetActive(false);
                                }
                            }
                        }
                        else
                        {
                            end = true;
                        }
                    }
                }
            }
            opt = 0;
        }
        else { opt++; }
    }
}
