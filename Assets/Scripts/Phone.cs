using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
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
    }

    private void LateUpdate()
    {
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
        anim.SetBool("UnPopupPhone", true);
    }

    public void WrongAnswer()
    {
        anim.SetBool("WrongAnswer", true);
    }
}
