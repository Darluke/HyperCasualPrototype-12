using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GUIManager : MonoBehaviour {
	//public Text guiTextMode;
	//public Slider sizeSlider;
	public TexturePainter painter;
	public GameObject toStickerButton;
	public GameObject stickerContainer;
	public GameObject guiCanvas;
	[SerializeField] private Light sceneLight;
	[SerializeField] private Animator debugMenuAnim;
	[SerializeField] private Animator colorPalleteAnim;
	private bool isStickersRevealed=false;
	private float canvasAcivationDelayTime;


    public void SetBrushMode(int newMode){
		Painter_BrushMode brushMode =newMode==0? Painter_BrushMode.DECAL:Painter_BrushMode.PAINT; //Cant set enums for buttons :(
		//string colorText=brushMode==Painter_BrushMode.PAINT?"orange":"purple";	
		//guiTextMode.text="<b>Mode:</b><color="+colorText+">"+brushMode.ToString()+"</color>";
		painter.SetBrushMode (brushMode);
	}
	//public void UpdateSizeSlider(){
	//	painter.SetBrushSize (sizeSlider.value);
	//}

	public void ShowHideStickers()
    {
		isStickersRevealed = !isStickersRevealed;
		stickerContainer.GetComponent<Animator>().SetBool("ShowSticker", isStickersRevealed);
	}

	public void ShowCanvas(float delayTime)
    {
		canvasAcivationDelayTime = delayTime;
		StartCoroutine("ShowCanvasDelay");
    }

	IEnumerator ShowCanvasDelay()
    {
		yield return new WaitForSeconds(canvasAcivationDelayTime);
		guiCanvas.SetActive(!guiCanvas.activeInHierarchy);
    }

	public void ChangeLights()
    {
		Color lightColor= ColorSelector.GetColor();
		sceneLight.color = new Color(Mathf.Abs(lightColor.r), Mathf.Abs(lightColor.g), Mathf.Abs(lightColor.b));
    }

	public void ShowHideDebugMenu()
    {
		debugMenuAnim.SetBool("Show", !debugMenuAnim.GetBool("Show"));
		colorPalleteAnim.SetBool("Show", !colorPalleteAnim.GetBool("Show"));

	}


}
