using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    private int PumpCounter =0;

    [SerializeField] private Text pumpText;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Pump"))
        {
            Destroy(col.gameObject);
            PumpCounter++;
            Debug.Log("Pumps" + PumpCounter);
            pumpText.text = PumpCounter.ToString();
        }
        
        if (col.gameObject.CompareTag("Key"))
        {
            Hero hero = gameObject.GetComponent<Hero>();
            Destroy(col.gameObject); 
            hero.AddKey();
        }
    }
}