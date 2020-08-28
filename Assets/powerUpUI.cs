using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUpUI : MonoBehaviour

{

    public gameController _gameController;
    public RawImage yButton;
    public RawImage bButton;
    public RawImage aButton;
    public RawImage xButton;

    public Texture2D empty;
    public Texture2D flashlightImage;
    public Texture2D environmentalLighting;
    public Texture2D lurkerImage;
    public Texture2D soundImage;
    public Texture2D crunchImage;

    // Start is called before the first frame update
    void Start()
    {

        _gameController = GetComponentInParent<gameStart>()._gamecontroller.GetComponent<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameController._hasFlashlightControl && yButton.texture != flashlightImage)
        {
            yButton.texture = flashlightImage;
        }
        else if (!_gameController._hasFlashlightControl && yButton.texture != empty)
        {
            yButton.texture = empty;
        }

        if (_gameController._hasLightingControl && bButton.texture != environmentalLighting)
        {
            bButton.texture = environmentalLighting;
        }
        else if (!_gameController._hasLightingControl && bButton.texture != empty)
        {
            bButton.texture = empty;
        }

        if (_gameController._hasLuker && xButton.texture != lurkerImage)
        {
            xButton.texture = lurkerImage;
        }
        else if (!_gameController._hasLuker && xButton.texture != empty)
        {
            xButton.texture = empty;
        }

        if (_gameController._hasScreamControl && aButton.texture != soundImage)
        {
            aButton.texture = soundImage;
        }
        else if (_gameController._hasCrunchControl && aButton.texture != crunchImage)
        {
            aButton.texture = crunchImage;
        }
        else if (!_gameController._hasScreamControl && !_gameController._hasCrunchControl && aButton.texture != empty)
        {
            aButton.texture = empty;
        }

    }
}
