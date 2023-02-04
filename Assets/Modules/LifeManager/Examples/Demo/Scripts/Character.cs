using Modules.LifeManager.Runtime;
using UnityEngine;

public class Character : MonoBehaviour
{
    private LifeManager life = new LifeManager(10f);
    public GameObject lifeBar;
    void Start()
    {
        life.LooseOverTime(4f, 10f, this);
        life.LooseOverTime(4f, 5f, this);
        life.LooseOverTime(4f, 2f, this);
        life.DoOnDeath(ImDead);
    }

    void ImDead()
    {
        Debug.Log("ImDead");
    }
    
    // Update is called once per frame
    void Update()
    {
        lifeBar.transform.localScale = new Vector3(life.GetLife(), 1, 1);
    }
}
