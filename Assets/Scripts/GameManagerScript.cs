using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    //Attributes: using serialize field to expose enemy object and field size in editor
    [SerializeField] GameObject enemy;
    [SerializeField] int fieldSize = 25;

    //Statics: Using public static variable to maintain score based on enemy kills, updated from bullet script
    public static int Score = 0;

    
    void Start()
    {
        InvokeRepeating("spawn", UnityEngine.Random.Range(2, 5), 1);
    }

    private void spawn()
    {
        Vector3 enemyPos = new Vector3(UnityEngine.Random.Range(-fieldSize, fieldSize), 1, UnityEngine.Random.Range(-fieldSize, fieldSize));
        Instantiate(enemy, enemyPos, new Quaternion());
    }
}
