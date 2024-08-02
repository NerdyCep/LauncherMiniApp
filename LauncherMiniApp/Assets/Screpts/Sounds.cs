using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource audioSourceClick; // Источник звука для кликов
    public AudioSource audioSourceMaine; // Источник фоновой музыки
    
    void Start()
    {
        // Если audioSourceMaine не назначен через инспектор, попробуем найти его на этом объекте
        if (audioSourceMaine == null)
        {
            audioSourceMaine = GetComponent<AudioSource>();
        }

        // Начнем воспроизведение фоновой музыки
        if (audioSourceMaine != null)
        {
            audioSourceMaine.loop = true; // Настроим на бесконечное воспроизведение
            audioSourceMaine.Play(); // Запускаем воспроизведение
        }
        else
        {
            Debug.LogWarning("AudioSourceMaine не назначен и не найден на этом объекте.");
        }
    }

    public void PlaySound()
    {
        if (audioSourceClick != null)
        {
            audioSourceClick.Play(); // Воспроизводим звук клика
        }
        else
        {
            Debug.LogWarning("AudioSourceClick не назначен.");
        }
    }
}

