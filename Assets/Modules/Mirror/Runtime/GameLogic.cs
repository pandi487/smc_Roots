using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Mirror.Runtime
{
    class GameSettings
    {
        private int taskNb;

        public int GetTaskNumber()
        {
            return taskNb; 
        }
        public GameSettings()
        {
            taskNb = 2;
        }
    }
    public class GameLogic : NetworkBehaviour
    {
        [SyncVar(hook = nameof(UpdateLocalTaskProgressBar))] private float taskProgress = 0f;
        private float maxProgress = 100f;
        public PlayerControllerNet localPlayer;
        public Slider progressBar;
        public GameObject taskLocations;
    
        private GameSettings _gameSettings = new GameSettings();
    
        public override void OnStartClient()
        {
            base.OnStartClient();
            int tasksGiven = _gameSettings.GetTaskNumber();
            int maxTasks = taskLocations.transform.childCount;
            if (tasksGiven >= maxTasks) //if too many tasks asked, enable everything
            {
                foreach (Transform child in taskLocations.transform)
                    child.gameObject.SetActive(true);
                return;
            }
            int curNbTask = 0;
            int security = maxTasks * 10;
            while (curNbTask < tasksGiven && security > 0)
                foreach (Transform child in taskLocations.transform) //randomly choose taskNb Tasks
                {
                    if (Random.Range(0, maxTasks) < tasksGiven && child.gameObject.activeSelf == false)
                    {
                        child.gameObject.SetActive(true);
                        curNbTask++;
                    }
                    if (curNbTask >= tasksGiven)
                        return;
                    security--;
                }
        }
        public void UpdateTaskProgress(float progress)
        {
            Debug.Log("taskProgress = " + taskProgress);

            Debug.Log("Updating taskProgress... ");
            CmdUpdateGlobalTaskProgress(progress);
        
            Debug.Log("taskProgress = " + taskProgress);
        
            localPlayer.doingTask = false;
        }

        // [Command(ignoreAuthority = true)]
        void CmdUpdateGlobalTaskProgress(float progress)
        {
            taskProgress += progress;
            //if (taskProgress >= maxProgress)
            //finish game
        }
    
        public void UpdateLocalTaskProgressBar(float old, float newvar)
        {
            taskProgress = newvar;
            Debug.Log("Updating taskBar to " + newvar);
            progressBar.value = taskProgress / maxProgress;
        }
    }
}