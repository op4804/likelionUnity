using System.Collections;
using UnityEngine;

public class DragonSummon : MonoBehaviour
{

    float movemnet = 1.5f;

    public GameObject babyDragon;
    void Start()
    {
        StartCoroutine(Pattern1());
        StartCoroutine(Pattern2());
        StartCoroutine(Pattern3());

    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -movemnet * Time.deltaTime, 0);
    }

    IEnumerator Pattern1()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            movemnet = 0;
        }
    }
    IEnumerator Pattern2()
    {
        float degree = -20;
        float arrangedX = -0.66f;
        float arrangedY;
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (movemnet < 0.1)
            {
                // È¸Àü
                transform.rotation = Quaternion.Euler(Vector3.forward * degree);

                Vector3 newPosition = new Vector3(transform.position.x + arrangedX, transform.position.y, transform.position.z);
                Instantiate(babyDragon, newPosition, transform.rotation);


                degree += 10;
                arrangedX += 0.33f;
            }            
        }
    }
    IEnumerator Pattern3()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            Destroy(gameObject);
        }
    }
}
