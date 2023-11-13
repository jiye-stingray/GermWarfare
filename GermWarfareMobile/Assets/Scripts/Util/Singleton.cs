using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour  where T : Singleton<T>
{
    public bool _isDontDestroy;

    private static T _instance;
    public static T Instance
    {
        get 
        { 
            if(_instance == null )
            {
                _instance = FindObjectOfType(typeof(T)) as T; 

                if(_instance == null )
                {
                    var go = new GameObject(typeof(T).ToString());
                    _instance = go.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    public virtual void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;

            if (_isDontDestroy)
                DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
