using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;

    public bool tocarBGM;
    public int bgmIndex;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance); 
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (!tocarBGM)
        {
            PararTodosBGM();
        } 
        else
        {
            if (!bgm[bgmIndex].isPlaying)
            {
                PlayBGM(bgmIndex);
            }
        }
    }
    public void PlaySFX(int _sfxIndex)
    {
        if (_sfxIndex < sfx.Length)
        {
            sfx[_sfxIndex].Play();
        }
    }

    public void PararSFX(int _sfxIndex) => sfx[_sfxIndex].Stop();

    public void PlayBGM(int _sfxIndex)
    {
        bgmIndex = _sfxIndex;
        PararTodosBGM();

        bgm[bgmIndex].Play();
    }

    public void PararTodosBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
}
