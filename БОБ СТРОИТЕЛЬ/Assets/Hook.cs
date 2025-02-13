using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Transform block;
    public float moveSpeed = 5f;
    public Transform svaz;
    end component;
    void Start()
    {
        component = FindObjectOfType<end>();
        block.parent = null;
    }
    void Update()
    {
        if (block.gameObject.activeSelf)
        {
            gameObject.GetComponent<AudioSource>().enabled = !component.Tab;
            float dist = Vector3.Distance(block.transform.position, transform.position);
            svaz.localPosition = new Vector3(0, 0, dist / 2);
            svaz.localScale = new Vector3(0.1f, dist / 2, 0.1f);
            if (dist > 2.5f)
            {
                block.position = Vector3.MoveTowards(block.position, gameObject.transform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else { Destroy(gameObject); }
    }
}
