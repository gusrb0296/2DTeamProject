using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private Sound[] bgm = null;
    [SerializeField]
    private Sound[] sfx = null;
    [SerializeField]
    private AudioSource bgmPlay = null;
    public List<AudioSource> sfxPlays = new List<AudioSource>();



    private void Start()
    {
        AudioSource sfxPlayer = gameObject.AddComponent<AudioSource>();
        sfxPlays.Add(sfxPlayer);
        SetBGMByGameLevel();
    }

    // 배경음악 재생
    public void PlayBGM(string bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (bgmName == bgm[i].name)
            {
                bgmPlay.clip = bgm[i].clip;
                bgmPlay.Play();
                return;
            }
        }
    }

    // GameLevel에 따라 배경음악을 설정
    public void SetBGMByGameLevel()
    {
        int gameLevel = PlayerPrefs.GetInt("GameLevel");
        //Debug.Log(PlayerPrefs.GetInt("GameLevel"));

        if (gameLevel >= 1 && gameLevel <= bgm.Length)
        {
            PlayBGM(bgm[gameLevel - 1].name);
        }
        else
        {
            Debug.Log("잘못된 GameLevel입니다.");
        }
    }

    public void StopBGM()
    {
        bgmPlay.Stop();
    }

    // 효과음 재생
    public void PlaySFX(string sfxName, float volume = 0.5f)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfxName == sfx[i].name)
            {
                AudioSource sfxPlay = AddSFXPlayer();
                sfxPlay.clip = sfx[i].clip;
                sfxPlay.volume = volume;
                sfxPlay.Play();
                return;
            }
        }
    }

    private AudioSource AddSFXPlayer()
    {
        for (int i = 0; i < sfxPlays.Count; i++)
        {
            if (!sfxPlays[i].isPlaying)
            {
                return sfxPlays[i];
            }
        }

        // 모든 SFX 플레이어가 사용 중일 경우 새 플레이어 생성
        AudioSource newSFXPlay = gameObject.AddComponent<AudioSource>();
        sfxPlays.Add(newSFXPlay);
        return newSFXPlay;
    }
}
