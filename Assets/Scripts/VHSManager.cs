using UnityEngine;

public class VHSManager : MonoBehaviour
{
    public static VHSManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el efecto VHS en todas las escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
