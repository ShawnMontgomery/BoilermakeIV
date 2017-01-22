﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PicPane : MonoBehaviour {

    // Add this script to a GameObject. The Start() function fetches an
    // image from the documentation site.  It is then applied as the
    // texture on the GameObject.
    List<Vector3> possLocations = new List<Vector3>();
    List<int> possAng = new List<int>();
    public string url = "https://docs.unity3d.com/uploads/Main/ShadowIntro.png"; //Will be depreciated as soon as ImageMode is implemented
    public ImageModel myModel;


    public Transform target;
    public float speed = 5;


    IEnumerator Start() {
        possLocations.Add(new Vector3(-1,((float) -2.5),-1));
        possAng.Add(-90);
        possLocations.Add(new Vector3(-1, ((float)-2), ((float).5)));
        possAng.Add(-65);
        possLocations.Add(new Vector3(-1, ((float)-1), ((float)1.5)));
        possAng.Add(-40);
        possLocations.Add(new Vector3(-1, ((float)-.25), 2));
        possAng.Add(-20);

        possLocations.Add(new Vector3(-1, ((float)1.5), 2));
        possAng.Add(0);

        possLocations.Add(new Vector3(-1, ((float)2.75), 2));
        possAng.Add(20);
        possLocations.Add(new Vector3(-1, ((float)4), ((float) 1.5)));
        possAng.Add(40);
        possLocations.Add(new Vector3(-1, ((float)5), ((float) .5)));
        possAng.Add(65);
        possLocations.Add(new Vector3(-1, ((float)5.5), -1));
        possAng.Add(90);

        target = this.transform;
        return this.loadImage();
    }

    public IEnumerator loadImage()
    {


        Debug.Log("here first you bastard");
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;

    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    void setImageModel(ImageModel i)
    {
        myModel = i;
        url = i.ImageUrl;
        loadImage();
          
    }

    public void setActive()
    {
        GameObject infoPane = GameObject.FindWithTag("InfoPane");
        //Set all stuff here
    }
}
