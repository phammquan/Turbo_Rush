using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object_Pooling : Singleton<Object_Pooling>
{
    Dictionary<GameObject, List<GameObject>> _listGameObject = new Dictionary<GameObject, List<GameObject>>();

    public GameObject GetPrefabs(GameObject defaultGameobject)
    {
        if (_listGameObject.ContainsKey(defaultGameobject))
        {
            foreach (GameObject o in _listGameObject[defaultGameobject])
            {
                if (o.activeSelf)
                    continue;
                return o;
            }
            GameObject g = Instantiate(defaultGameobject, this.transform.position, Quaternion.identity);
            _listGameObject[defaultGameobject].Add(g);
            g.SetActive(false);
            return g;
        }
        List<GameObject> newList = new List<GameObject>();
        GameObject newObject = Instantiate(defaultGameobject, this.transform.position, Quaternion.identity);
        newList.Add(newObject);
        newObject.SetActive(false);
        _listGameObject.Add(defaultGameobject, newList);
        return newObject;
    }
    
    
}
