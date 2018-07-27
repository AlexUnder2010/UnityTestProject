using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class CoreLogics : MonoBehaviour
{
    public Text Text;
    private bool flag = true;
    private float z = 0;
    private int cubeInt = 0;
    public GameObject cube;
    private int cubeQuantity = 0;
    public float MaxCubes = 10;

    public List<GameObject> cubes;

    // Use this for initialization
    private void Start()
    {
        cubes = new List<GameObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (flag)
        {
            if (IsEvenTime())
            {
                flag = false;
                StartCoroutine(SpawnCube());
            }
        }

        Text.text = ShowUtcTime();
    }

    private static string ShowUtcTime()
    {
        var tempTime = DateTime.UtcNow.ToString("HH:mm:ss");
        return tempTime;
    }

    private static bool IsEvenTime()
    {
        var tempTime = DateTime.UtcNow.ToString("ss");
        var result = Convert.ToInt32(tempTime);
        return (result % 2) == 0;
    }

    private IEnumerator SpawnCube()
    {
        var wait = new WaitForSeconds(2);
        while (true)
        {
            //cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z + z);
            var myVar = Instantiate(cube,
                new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z + z),
                cube.transform.rotation);
            cubes.Add(myVar);
            cubeQuantity = cubeQuantity + 1;
            if (cubes.Count > MaxCubes)
            {
                Destroy(cubes[cubeInt]);
                cubeInt = cubeInt + 1;
            }

            z = z + 1;
            yield return wait;
        }
    }
}