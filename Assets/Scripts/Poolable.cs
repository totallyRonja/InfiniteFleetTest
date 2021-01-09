using System;
using UnityEngine;

public class Poolable : MonoBehaviour 
{
    public Action Spawn;
    
    private Pool _parentPool;
    private bool _active;

    public void Activate() 
    {
        _active = true;
        gameObject.SetActive(true);
    }

    public void SetParentPool(Pool parent) 
    {
        _parentPool = parent;
    }

    public void ReturnToPool() 
    {
        //there were cases where 2 collisions happened in 1 frame, trying to remove the object twice
        if(!_active) return;
        _active = false;
        gameObject.SetActive(false);
        _parentPool.Return(this);
    }
}
