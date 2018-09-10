

using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject[] attackerPrefabs;
    int spawnerCount = 5;

	
	// Update is called once per frame
	void Update () {
        foreach(GameObject attackerGO in attackerPrefabs){
            if(isTimeToSpawn(attackerGO)){
                spawn(attackerGO);
            }
        }
	}

    private void spawn(GameObject attackerGO)
    {
        GameObject newAttacker =  Instantiate(attackerGO, gameObject.transform);
        Debug.Log(newAttacker.name + " spawned");
        newAttacker.transform.parent = gameObject.transform;
    }

    private bool isTimeToSpawn(GameObject attackerGO)
    {
        Attacker attacker = attackerGO.GetComponent<Attacker>();
        float spawnFrequency = 1 / attacker.seenEverySeconds;

        //the more frequent, the less this value is
        float spawnProbability = spawnFrequency * Time.deltaTime / spawnerCount;

        return Random.value < spawnProbability;
    }
}
