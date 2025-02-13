using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlokLevel : MonoBehaviour
{
    public GameObject saves;
    public int rer;
    public int i;
    public GameObject lok;

    void Update()
    {
        if(rer != 7){rer++;}
        if(rer == 7)
        {
            saves = GameObject.FindGameObjectWithTag("сохронять");
            if (saves.GetComponent<SaveTransform>().complit[i] == true)
            {
                gameObject.GetComponent<Button>().enabled = true;
                lok.SetActive(false);
                gameObject.GetComponent<BlokLevel>().enabled = false;
            }
        }
    }
}
