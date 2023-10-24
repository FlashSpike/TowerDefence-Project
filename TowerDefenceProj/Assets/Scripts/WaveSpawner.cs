using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [Header("Attributes")]
    private float countdown = 2f;  //countdown for the 1st wave
    private int waveIndex = 0; //Starting number of waves (0 = 1st wave)
    public float timeBetweenWaves = 5f; //accessible to edit from the editor (Timers per Waves)

    [Header("Unity Setup Fields")]
    public Transform enemyPrefab;   //Enemy Prefab
    public Transform spawnPoint;    //Starting point
    public TextMeshProUGUI waveCountdownText; //Countdown Timer Text


    // Start is called before the first frame update
    private void Update()
    {
        //Timer Per Waves
        if (countdown <= 0f) //if countdown = 0 spawn a new wave
        {
            StartCoroutine(SpawnWave()); //This will allow the wave to spawn infinately(basically repeating a process)
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; //Timer per Wave, Frame indepentdent, Run it over mutiple frames to continue with other task

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);  //To Ensure Countdown will never be less than 0

        waveCountdownText.text = string.Format("{0:00:00}", countdown) ; //Text for countdown, Formatted in decimal points.
    }

    //Enemies Per Waves
    IEnumerator SpawnWave() //Enable to run in the background and avoid disruption and freezing your codes 
    {
        waveIndex++; //+1 wave

        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++) //+1 enemy per wave
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //Timer for +1 enemy
        }
    }

    //Enemies Spawnpoint
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); //Enemy's Spawnpoint
    }

}
