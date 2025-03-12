using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instacne;
    AudioSource myAudio;

    public AudioClip bulletSound;
    public AudioClip enemyDie;


    private void Awake()
    {
        if(SoundManager.instacne == null)
        {
            SoundManager.instacne = this;
        }    
    }

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(bulletSound);
    }

    public void PlayEnemyDie()
    {
        myAudio.PlayOneShot(enemyDie);
    }

}
