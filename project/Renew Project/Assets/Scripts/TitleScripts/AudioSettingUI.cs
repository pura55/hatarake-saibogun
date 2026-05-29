using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

//Unityの中から引用する
public class AudioSettingUI : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField masterInputField;
    [SerializeField] private TMP_InputField bgmInputField;
    [SerializeField] private TMP_InputField seInputField;

    private void Start()
    {
        // 保存値読み込み
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float bgm = PlayerPrefs.GetFloat("BGMVolume", 1f);
        float se = PlayerPrefs.GetFloat("SEVolume", 1f);

        // Slider初期化
        masterSlider.value = master;
        bgmSlider.value = bgm;
        seSlider.value = se;

        // 表示更新
        UpdateUI(masterSlider, masterInputField);
        UpdateUI(bgmSlider, bgmInputField);
        UpdateUI(seSlider, seInputField);

        // 音量適用
        SetVolume("MasterVolume", master);
        SetVolume("BGMVolume", bgm);
        SetVolume("SEVolume", se);

        // Slider変更イベント
        masterSlider.onValueChanged.AddListener(OnMasterSliderChanged);
        bgmSlider.onValueChanged.AddListener(OnBGMSliderChanged);
        seSlider.onValueChanged.AddListener(OnSESliderChanged);

        // InputField変更イベント
        masterInputField.onEndEdit.AddListener(OnMasterInputChanged);
        bgmInputField.onEndEdit.AddListener(OnBGMInputChanged);
        seInputField.onEndEdit.AddListener(OnSEInputChanged);
    }

    //Sliderを変更したら、InputFieldも変更

    private void OnMasterSliderChanged(float value)
    {
        ApplyVolume("MasterVolume", value, masterInputField);
    }

    private void OnBGMSliderChanged(float value)
    {
        ApplyVolume("BGMVolume", value, bgmInputField);
    }

    private void OnSESliderChanged(float value)
    {
        ApplyVolume("SEVolume", value, seInputField);
    }

    //InputFieldを変更したら、Sliderも変更

    private void OnMasterInputChanged(string text)
    {
        InputToSlider(text, masterSlider, "MasterVolume", masterInputField);
    }

    private void OnBGMInputChanged(string text)
    {
        InputToSlider(text, bgmSlider, "BGMVolume", bgmInputField);
    }

    private void OnSEInputChanged(string text)
    {
        InputToSlider(text, seSlider, "SEVolume", seInputField);
    }

    //Sliderの小数点切り捨て処理
    private void ApplyVolume(string parameterName, float value, TMP_InputField inputField)
    {
        // 音量変更
        SetVolume(parameterName, value);

        //0～100の制限
        int displayValue = Mathf.FloorToInt(value * 100);

        //InputFieldへ変更
        inputField.text = displayValue.ToString();

        //保存
        PlayerPrefs.SetFloat(parameterName, value);
    }


    //InputFieldの小数点切り捨て処理
    private void InputToSlider(string text, Slider slider, string parameterName, TMP_InputField inputField)
    {
        if (int.TryParse(text, out int value))
        {
            // 0～100の制限
            value = Mathf.Clamp(value, 0, 100);

            // Slider値へ変換
            float sliderValue = value / 100f;

            // Slider更新
            slider.value = sliderValue;

            // 音量変更
            SetVolume(parameterName, sliderValue);

            // 保存
            PlayerPrefs.SetFloat(parameterName, sliderValue);

            // 表示更新
            inputField.SetTextWithoutNotify(value.ToString());
        }
        else
        {
            // 数字以外入力時は元に戻す
            int currentValue = Mathf.FloorToInt(slider.value * 100);

            inputField.SetTextWithoutNotify(currentValue.ToString());
        }
    }

    //SliderとInputFieldの紐づけ
     private void UpdateUI(Slider slider,TMP_InputField inputField)
    {
        int displayValue = Mathf.FloorToInt(slider.value * 100);
        inputField.SetTextWithoutNotify(displayValue.ToString());
    }

    //AudioMixerの調整
    private void SetVolume(string parameterName, float value)
    {
        // 0対策
        if (value <= 0.0001f)
        {
            value = 0.0001f;
        }

        // Linear → dB変換
        float db = Mathf.Log10(value) * 20f;
        audioMixer.SetFloat(parameterName, db);
    }
}