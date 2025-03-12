using System.Collections;
using UnityEngine;

public class DragonSummon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float movemnet = 2;
    void Start()
    {
        StartCoroutine(Pattern());
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, movemnet * Time.deltaTime, 0);
    }

    IEnumerator Pattern()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            movemnet = 0;
        }
    }

}
