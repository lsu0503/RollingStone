using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();

                if(instance == null)
                    instance = new GameObject(typeof(T).Name).AddComponent<T>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = gameObject.AddComponent<T>();
        }

        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject.transform.root);
    }
}