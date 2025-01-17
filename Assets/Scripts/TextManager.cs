﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string speechSound;

    public float typingSpeed;
    public TextMeshProUGUI textDisplay;

    public void Digitar(string texto)
    {
        textDisplay.text = "";
        // Começa a corrotina de digitação
        if (transform.parent.gameObject.activeSelf)
        {
            StartCoroutine(TypeSentence(texto));
        }
    }

    #region Digitar
    // Corrotina
    IEnumerator TypeSentence(string texto)
    {
        // Pra cad letra da frase atual...
        foreach (char letra in texto)
        {
            // Adiciona uma letra no texto de display
            textDisplay.text += letra;

            if(speechSound != null && speechSound != "")
            FMODUnity.RuntimeManager.PlayOneShot(speechSound);

            // Espera o tempo determinado
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    #endregion
}
