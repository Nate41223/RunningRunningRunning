using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemsManager : MonoBehaviour {

    public GameObject draft;

    public static int previouslevel;

    public static List<GameObject> particleSystems = new List<GameObject>();

    // Use this for initialization
    void Start () {
        previouslevel = GamePlayManager.level;
		SpawnDraft();
    }
	
	void Update () {
        CheckParticleLife();

        if (GamePlayManager.level != previouslevel)
        {
            UpdateDraft();
            previouslevel = GamePlayManager.level;
        }
    }

    public void SpawnDraft()
    {
        GameObject obj = Instantiate(draft, transform);
		ParticleSystem ps = obj.GetComponent<ParticleSystem>();
		var main = ps.main;
		main.startSpeed = GamePlayManager.speed;
		particleSystems.Add (obj);
    }

	public static void UpdateDraft() {
		ParticleSystem ps = particleSystems[0].GetComponent<ParticleSystem>();
		var main = ps.main;
		main.startSpeed = GamePlayManager.speed;
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
