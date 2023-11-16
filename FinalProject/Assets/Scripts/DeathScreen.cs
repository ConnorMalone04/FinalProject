using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    public bool gameOver = false;
    private bool screenOn = false;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<UnityEngine.UI.Image>();
        image.canvasRenderer.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameOver) {
            if (!screenOn) {
                screenOn = true;
                image.CrossFadeAlpha(1, 1, false);
                
            }
        }
    }
}
