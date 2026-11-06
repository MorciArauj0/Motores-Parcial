using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }


}
