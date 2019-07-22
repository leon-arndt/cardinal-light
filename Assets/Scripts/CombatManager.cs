using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    [SerializeField]
    GameObject combatAttackPrefab, danceMovePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //create an attack object
    public void CreateAttack(Transform parent, Vector3 position)
    {
        GameObject attack = Instantiate(combatAttackPrefab, parent);
        attack.transform.position = position;
    }

    //create a dance object
    public void CreateDance(Transform parent, Vector3 position)
    {
        GameObject danceMove = Instantiate(danceMovePrefab, parent);
        danceMove.transform.position = position;
    }
}
