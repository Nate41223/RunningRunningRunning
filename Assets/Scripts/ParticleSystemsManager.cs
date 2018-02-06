using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemsManager : MonoBehaviour {

    public GameObject draft;

    public static int previouslevel;


    public List<GameObject> particleSystems = new List<GameObject>();

    // Use this for initialization
    void Start () {
        previouslevel = GamePlayManager.level;
    }
	
	void Update () {
        CheckParticleLife();

        
        if (GamePlayManager.level != previouslevel)
        {
            SpawnDraft();
            previouslevel = GamePlayManager.level;
        }
    }

    public void SpawnDraft()
    {
        GameObject obj = Instantiate(draft, transform);
        particleSystems.Add(obj);
    }

    private void CheckParticleLife()
    {
        for (int i = particleSystems.Count - 1; i >= 0; i--)
        {
            ParticleSystem ps = particleSystems[i].GetComponent<ParticleSystem>();
            
            if(!ps.IsAlive())
            {
                Destroy(particleSystems[i]);
                particleSystems.RemoveAt(i);
            }
        }
    }
}
