using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FenceManager : MonoBehaviour
{
    public List<Fence> _fence;
    public int kolvo;
    public int t;
    public bool end;

    void Update()
    {
        Fence[] allTTObjects = FindObjectsOfType<Fence>();
        _fence.Clear();
        foreach (Fence ttObject in allTTObjects)
        {
            if (ttObject.GetComponent<Fence>().enabled == true)
            {
                _fence.Add(ttObject);
            }
        }
        _fence = _fence.OrderBy(obj => obj.transform.GetSiblingIndex()).ToList();
       
        if (end == false)
        {
            if (_fence.Count != t && _fence.Count != 1)
            {
                for (int i = 0; i < _fence.Count; i++)
                {
                    if (_fence[i].end == false)
                    {
                        _fence[i].flag = true;
                        if (i + 1 < _fence.Count)
                        {
                            _fence[i].next = _fence[i + 1].transform;
                        }
                        break;
                    }
                }
                if (_fence.Count == kolvo)
                {
                    _fence[_fence.Count - 1].flag = true;
                    _fence[_fence.Count - 1].next = _fence[0].transform;
                    end = true;
                }
            }
            t = _fence.Count;
        }
        else
        {
            if(_fence.Count < kolvo)
            {
                end = false;
            }
        }
    }
}
