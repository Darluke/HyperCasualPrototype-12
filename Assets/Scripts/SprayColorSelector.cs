using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayColorSelector : MonoBehaviour
{
    public float selectedSprayYPos;
    public GameObject currentSprayColorGO;
    public TexturePainter texturePainter;
    public GUIManager guiManger;


    public void ChooseColor(GameObject parent)
    {
        if (texturePainter.mode != Painter_BrushMode.PAINT) texturePainter.SaveTexture();
        guiManger.SetBrushMode(1);
        if (currentSprayColorGO!=null) currentSprayColorGO.transform.position = new Vector3(currentSprayColorGO.transform.position.x, currentSprayColorGO.transform.position.y - selectedSprayYPos, currentSprayColorGO.transform.position.z);
        currentSprayColorGO = parent;
        currentSprayColorGO.transform.position = new Vector3(currentSprayColorGO.transform.position.x, currentSprayColorGO.transform.position.y + selectedSprayYPos, currentSprayColorGO.transform.position.z);
        texturePainter.brushColor = currentSprayColorGO.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
    }
}
