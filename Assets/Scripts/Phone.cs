using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Phone : MonoBehaviour
{
    public AudioSource click;
    public AudioClip wrong;
    public AudioClip clip;
    public GameAgeManager manager;
    public Button button;
    public GameObject target;
    [SerializeField]
    Animator anim;
    public Camera camera;
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private float bezeloffset;
    
    public Vector3 targetPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        camera.transform.position = Vector3.back * 40;
        float camHorizontal = rectTransform.rect.width / (float)Screen.width - bezeloffset;  
        float camVertical = rectTransform.rect.height / (float)Screen.height - bezeloffset;
        float camX = rectTransform.position.x / (float)Screen.width ;
        float camY = rectTransform.position.y / (float)Screen.height;
        camX -= camHorizontal * 1 / 2;
        camY -= camVertical * 1 / 2;
        camera.rect = new Rect(camX, camY, camHorizontal, camVertical);
    }

    private void LateUpdate()
    {
        if(target != null)
            camera.transform.position = target.transform.position + Vector3.back * 40;
        float camHorizontal = rectTransform.rect.width / (float)Screen.width - bezeloffset;  
        float camVertical = rectTransform.rect.height / (float)Screen.height - bezeloffset;
        float camX = rectTransform.position.x / (float)Screen.width ;
        float camY = rectTransform.position.y / (float)Screen.height;
        camX -= camHorizontal * 1 / 2;
        camY -= camVertical * 1 / 2;
        camera.rect = new Rect(camX,camY, camHorizontal, camVertical);
    }

    public void PopupPhone()
    {
        anim.SetBool("PopupPhone", true);
    }

    public void UnPopupPhone()
    {
        anim.SetBool("UnpopupPhone", true);
    }

    public void WrongAnswer()
    {
        anim.SetBool("WrongAnswer", true);
    }

    public void CheckTarget()
    {
        manager.CheckFather();
    }

    public void Click()
    {
        click.PlayOneShot(clip,3f);
    }

    public void Wrong()
    {
        click.PlayOneShot(wrong,3f);
    }
}
