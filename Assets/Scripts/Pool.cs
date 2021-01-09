using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour 
{
    [SerializeField] private Poolable _prefab;

    private readonly Stack<Poolable> _pooledObjects = new Stack<Poolable>();

    public Poolable Spawn() 
    {
        Poolable instance;
        //get or spawn instance
        if (_pooledObjects.Count > 0)
            instance = _pooledObjects.Pop();
        else
            instance = Instantiate(_prefab);

        instance.Activate();
        instance.SetParentPool(this);
        instance.Spawn();
        return instance;
    }

    public void Return(Poolable lostChild) 
    {
        //hide the child as well as possible
        lostChild.transform.parent = null;
        lostChild.SetParentPool(null);
        //and remember it
        _pooledObjects.Push(lostChild);
    }
}
