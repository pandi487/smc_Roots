using System.Collections;
using GamevrestUtils;
using UnityEngine;

namespace UI
{
    public class TransitionManager : MonoBehaviour
    {
        [Header("Config")] public GameObject selectedTransitionPrefab;
        public float transitionTime = 1f;
        [Header("References")] [ReadOnly] public GameObject transitionObject;
        [ReadOnly] public Animator transition;
        private static readonly int StartId = Animator.StringToHash("Start");

        public void TransitionToScene(SceneReference reference)
        {
            StartCoroutine(LoadScene(reference));
        }

        private IEnumerator LoadScene(SceneReference reference)
        {
            transition.SetTrigger(StartId);
            yield return new WaitForSeconds(transitionTime);
            reference.Load();
        }

        private void Start()
        {
            transitionObject = Instantiate(selectedTransitionPrefab, transform);
            transition = transitionObject.GetComponent<Animator>();
        }
    }
}