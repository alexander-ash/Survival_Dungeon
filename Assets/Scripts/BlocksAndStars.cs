using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksAndStars : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite OpenWay;
    [SerializeField] GameObject Reminder;

    void Start()
    {
        Reminder.SetActive(false);
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(SeeTheReminder());
    }
    public void OpenTheDoor()
    {
        Destroy(boxCollider2D);
        spriteRenderer.sprite = OpenWay;
        spriteRenderer.color = new Color32(255, 255, 255, 255);
        this.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Background");
        
    }

    IEnumerator SeeTheReminder()
    {
        Reminder.SetActive(true);
        yield return new WaitForSecondsRealtime(8f);
        Reminder.SetActive(false);
    }

    
}
