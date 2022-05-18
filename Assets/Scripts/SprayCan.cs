using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprayCan : MonoBehaviour
{
    public GameObject shoe;
    private Animator anim;
    private TexturePainter texturePainter;
    public MeshRenderer[] canRanderers;
    public ParticleSystem sprayEffect;
    public Slider stickerLoadingBar;
    public float sprayDelayTime;
    private float sprayDelaTimer;
    private bool alreadyShaked;
    private bool alreadyGlued;
    

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        texturePainter = FindObjectOfType<TexturePainter>();
        sprayDelaTimer = sprayDelayTime;
    }
    void Update()
    {
        var cameraPos = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(cameraPos, out RaycastHit hit))
        {
            transform.position =new Vector3(hit.point.x,0.5f,hit.point.z);
        }

        transform.LookAt(shoe.transform.position ,Vector3.up);
        if(InputController.Instance.touchInput&&texturePainter.HitTestUVPosition())
        {
            if(!alreadyShaked&&texturePainter.mode==Painter_BrushMode.PAINT)SoundManager.instance.Play("Shake");
            if (texturePainter.mode == Painter_BrushMode.DECAL && !alreadyGlued) SoundManager.instance.Play("Glue");
            alreadyShaked = true;
            alreadyGlued = true;
            anim.SetBool("Shake", true);
            sprayDelaTimer -= Time.deltaTime;
            Spray();
            StartSprayFX();
        }
        else
        {
            SoundManager.instance.Stop("Spray");
            SoundManager.instance.Stop("Glue");
            alreadyShaked = false;
            alreadyGlued = false;
            anim.SetBool("Shake", false);
            //if (texturePainter.mode == Painter_BrushMode.PAINT) sprayDelaTimer = sprayDelayTime;
            //else sprayDelaTimer = 0;
            sprayDelaTimer = sprayDelayTime;
            StopSprayFX();
        }

        UpdateSpraycan();
        ShowHideCan();
        
        
    }

    public void Spray()
    {
        
        if (sprayDelaTimer<=0)
        {
            texturePainter.DoAction();
        }
    }

    private void StartSprayFX()
    {
        sprayEffect.startColor = texturePainter.brushColor;
        if (sprayDelaTimer - 0.2f <= 0 && sprayEffect.isStopped&&texturePainter.mode==Painter_BrushMode.PAINT)
        {
            sprayEffect.Play();
            SoundManager.instance.Play("Spray");
        }
        else if(texturePainter.mode == Painter_BrushMode.DECAL&&texturePainter.HitTestUVPosition())
        {
            //SoundManager.instance.Play("Glue");
            stickerLoadingBar.gameObject.SetActive(true);
            stickerLoadingBar.value = sprayDelaTimer/sprayDelayTime;
            if (stickerLoadingBar.value == 0) stickerLoadingBar.gameObject.SetActive(false);
        }
        
    }

    private void StopSprayFX()
    {
        if (sprayEffect.isPlaying) sprayEffect.Stop();
        stickerLoadingBar.gameObject.SetActive(false);
    }

    private void UpdateSpraycan()
    {
        MeshRenderer mesh =gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
        mesh.material.color = texturePainter.brushColor;
    }

   private void ShowHideCan()
    {
        
        if(texturePainter.mode==Painter_BrushMode.DECAL)
        {
            foreach (var spriteRenderer in canRanderers)
            {
                spriteRenderer.enabled = false;
            }
        }
        else
        {
            foreach (var spriteRenderer in canRanderers)
            {
                spriteRenderer.enabled = true;
            }
        }
    }
}



