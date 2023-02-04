using System.Collections;
using UnityEngine;

namespace UI
{
    public class PopupInteraction : MonoBehaviour
    {
        public float closeTime = 5;

        private void Start()
        {
            if (closeTime > 0) 
                StartCoroutine(CloseAfter());
        }

        private IEnumerator CloseAfter()
        {
            yield return new WaitForSeconds(closeTime);
            CloseNotif();
        }

        public void CloseNotif()
        {
            Destroy(gameObject);
        }
    }
}