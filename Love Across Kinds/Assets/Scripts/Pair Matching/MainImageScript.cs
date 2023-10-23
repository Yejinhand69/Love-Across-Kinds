using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameControllerScript gameController;

    public Transform target;
    public float speed = 0.2f;
    public float fadeSpeed = 20f;

    //public bool coroutineAllowed;
    //public bool firstPicOpen = false;
    

    private void Update()
    {
        
    }
    public void OnMouseDown()
    {
        if (image_unknown.activeSelf && gameController.canOpen)
        {
            
            image_unknown.SetActive(false);
              
            
            gameController.imageOpened(this);
            StartCoroutine(RotateCard());
        }
        
    }

    public IEnumerator RotateCard()
    {
        //coroutineAllowed = false;
        
        for (float i = 0f; i <= 180f; i += 10f)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
                
            yield return new WaitForSeconds(0.018f);
        }
        

        //coroutineAllowed = true; 
    }

    public IEnumerator RotateAgain()
    {
        //coroutineAllowed = false;

        for (float i = 180f; i >= 0f; i -= 10f)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            yield return new WaitForSeconds(0.022f);
        }


        //coroutineAllowed = true;
    }

    private int _spriteId;
    public int spriteId
    {
        get { return _spriteId; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image; //Gets the sprite renderer component to change the sprite.
    }

    public void Close()
    {

        StartCoroutine(RotateAgain());
        image_unknown.SetActive(true);// Hide image
    }

    public void Destroy()
    {

        Destroy(gameObject);
    }

    //public IEnumerator FadeOutObject()
    //{
    //    while (this.GetComponent<SpriteRenderer>().material.color.a > 0)
    //    {
    //        Color objectColor = this.GetComponent<SpriteRenderer>().material.color;
    //        float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

    //        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //        this.GetComponent<SpriteRenderer>().material.color = objectColor;
    //        yield return null;
    //    }
    //}

    //IEnumerator LoopRotation(float angle, bool FirstMat)
    //{
    //    var rot = 0f;
    //    const float dir = 1f;
    //    const float rotspeed = 180f;
    //    const float rotspeed1 = 90f;
    //    var startAngle = angle;
    //    var assigned = false;

    //    if (FirstMat) 
    //    {
    //        while (rot < angle)
    //        {
    //            var step = Time.deltaTime * rotspeed1;
    //            gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 2, 0)  * step, dir);

    //            if (rot >= (startAngle - 2) && assigned == false)
    //            {

    //                assigned = true;
    //            }
    //        }
    //    }

    //}



    //public void Open()
    //{

    //    image_unknown.SetActive(false);
    //}

    public void Move()
    {



        //transform.position = target.position;

        //Vector3 a = transform.position;
        //Vector3 b = target.position;
        //transform.position = Vector3.MoveTowards(a, b, speed);


        //transform.position += target.position + new Vector3(0, 0.5f, 0);


    }
    //public void Hide()
    //{
    //    image_unknown.SetActive(true);// Hide image
    //}
}
