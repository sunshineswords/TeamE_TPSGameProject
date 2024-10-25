using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BGM_Volume : MonoBehaviour
{
    [SerializeField]
    AudioMixer BGMMixer;//いじるミキサーを入れる
    [SerializeField]
    Slider BGMSlider;//操作するスライダーを入れる

    // Start is called before the first frame update
    void Start()
    {
        BGMSlider.onValueChanged.AddListener(SetAudioMixerBGM);
    }

    // Update is called once per frame
    //void Update(){}

    public void SetAudioMixerBGM(float value)
    {
        float volume = Mathf.Clamp(20f * Mathf.Log10(Mathf.Clamp(value, 0f, 1f)), -80f, 0f);
        BGMMixer.SetFloat("BGM", volume);
    }
}
