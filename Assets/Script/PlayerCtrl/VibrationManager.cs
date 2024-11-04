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

    public void TriggerCustomVibration(long milliseconds)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // Android 네이티브 Vibrator 클래스에 접근
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        
        // 진동 시작 (지정된 밀리초만큼)
        vibrator.Call("vibrate", milliseconds);
#elif UNITY_EDITOR
        Debug.Log($"[VibrationManager] TriggerCustomVibration called with {milliseconds} ms");
#endif
    }

    public void TriggerPatternVibration(long[] pattern, int repeat)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        
        // 진동 패턴 시작
        vibrator.Call("vibrate", pattern, repeat);
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
}
