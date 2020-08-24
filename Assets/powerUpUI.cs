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

    }
}
