using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instnace;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instnace == null)
            instnace = this;
        else
            Destroy(gameObject);
    }
}
