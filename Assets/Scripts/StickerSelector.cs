using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerSelector : MonoBehaviour
{
    public TexturePainter texturePainter;
    public GUIManager guiManger;

    public void ChooseSticker(GameObject sticker)
    {
        if (texturePainter.mode != Painter_BrushMode.DECAL) texturePainter.SaveTexture();
        guiManger.SetBrushMode(0);
        Image stickerImage = sticker.GetComponent<Image>();
        texturePainter.cursorDecal = stickerImage.sprite;
        texturePainter.SetBrushMode(Painter_BrushMode.DECAL);
       
    }
}
