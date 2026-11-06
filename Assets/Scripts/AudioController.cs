using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [SerializeField] private AudioSource enemyMusic;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySnapshot(AudioClip audioClip, Transform spawn, float volume)
    {
        AudioSource audioSource = Instantiate(enemyMusic, spawn.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioClip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
