using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText; // Текстовый UI элемент для отображения FPS

    private float deltaTime = 0.0f;

    void Update()
    {
        // Вычисляем время между кадрами
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        // Вычисляем и отображаем FPS
        float fps = 1.0f / deltaTime;
        fpsText.text = string.Format("{0:0.} fps", fps);
    }
}
