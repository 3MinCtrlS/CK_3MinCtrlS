using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 작성자 : 전시은
// 작성일 : 2022.11.25
// 사용 방법 : GameManager에 오브젝트들을 전달 해 주어 동작.
// 제작 사유 : Setting UI 객체 컨트롤 및 관리 용이성 향상
public class SettingUI : MonoBehaviour
{
    [SerializeField] private AudioListener audioListener;
    [SerializeField] private GameObject soundButton; //ButtonSound
    [SerializeField] private Slider soundSlider; //Slider

    [SerializeField] private GameObject fullscreenButton; //ButtonF
    [SerializeField] private GameObject windowdedButton; //ButtonW
    private const string prefsVolume = "musicVolume";

    // Start is called before the first frame update
    private void Start()
    {
        Initalize();
    }

    // 초기 환경 셋팅
    private void Initalize()
    {
        if (!PlayerPrefs.HasKey(prefsVolume))
        {
            PlayerPrefs.SetFloat(prefsVolume, 1);
            LoadSetting();
        }
        else
        {
            LoadSetting();
        }

        //popupTitle = GameObject.Find("PopupTopbarTitleText"); //PopupTopbarTitleText
        //soundSlider = GameObject.Find("Slider").GetComponent<Slider>(); //Slider
        //soundButton = GameObject.Find("ButtonSound"); //ButtonSound
        //fullscreenButton = GameObject.Find("ButtonF"); //ButtonF
        //windowdedButton = GameObject.Find("ButtonW"); //ButtonW

        Debug.Log("SettingUI :: Initalize - Done");
    }

    public void SoundOnOff()
    {
    }
    public void SoundSlider()
    {
        AudioListener.volume = soundSlider.value;
        SaveSetting();
    }

    private void LoadSetting()
    {
        soundSlider.value = PlayerPrefs.GetFloat(prefsVolume);
        AudioListener.volume = soundSlider.value;
    }
    private void SaveSetting()
    {
        PlayerPrefs.SetFloat(prefsVolume, soundSlider.value);
    }
}