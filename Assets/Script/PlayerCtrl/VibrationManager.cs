using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerCustomVibration(long milliseconds, int amplitude)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // Android 네이티브 Vibrator 클래스에 접근
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        if (vibrator != null)
        {
            if (AndroidVersion() >= 26)
            {
                // Android API 26 이상에서 VibrationEffect 사용하여 진동 강도 조절
                AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
                AndroidJavaObject vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>(
                    "createOneShot", milliseconds, amplitude);
                vibrator.Call("vibrate", vibrationEffect);
            }
            else
            {
                // API 26 미만에서는 진동 강도 조절 불가, 기본 진동
                vibrator.Call("vibrate", milliseconds);
            }
        }
#elif UNITY_EDITOR
        Debug.Log($"[VibrationManager] TriggerCustomVibration called with {milliseconds} ms");
#endif
    }

    public void TriggerPatternVibration(long[] pattern, int[] amplitudes, int repeat)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        if (vibrator != null)
        {
            if (AndroidVersion() >= 26)
            {
                // 진동 패턴과 강도 조절을 위한 VibrationEffect 생성
                AndroidJavaClass vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
                AndroidJavaObject vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>(
                    "createWaveform", pattern, amplitudes, repeat); // 진동 세기 배열 추가
                vibrator.Call("vibrate", vibrationEffect);
            }
            else
            {
                // API 26 미만에서는 강도 조절 불가
                vibrator.Call("vibrate", pattern, repeat);
            }
        }
#elif UNITY_EDITOR
        Debug.Log($"[VibrationManager] TriggerPatternVibration called with pattern: [{string.Join(", ", pattern)}], repeat: {repeat}");
#endif
    }

    public void StopVibration()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        
        // 진동 멈춤
        vibrator.Call("cancel");
#elif UNITY_EDITOR
        Debug.Log("[VibrationManager] StopVibration called");
#endif
    }

    // Android 버전 확인 메서드
    private int AndroidVersion()
    {
        AndroidJavaClass version = new AndroidJavaClass("android.os.Build$VERSION");
        return version.GetStatic<int>("SDK_INT");
    }
}
