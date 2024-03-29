﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour {

    /* 
     * Diese Klasse hat alle Laser als eine Collection gespeichert und updatet sie - jetzt jeden frame - 
     * kann aber auch nur einige male pro Sekunde passieren um die performance zu verbessern
     */
    HashSet<Laser> lasers;

    public static LaserManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        lasers = new HashSet<Laser>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateLasers();
	}

    void UpdateLasers()
    {
        foreach(Laser laser in lasers)
        {
            laser.UpdateLaser();
        }
    }

    public void AddLaser(Laser laser)
    {
        lasers.Add(laser);
    }

    //this gets called by a block object which wants to know which lasers are hitting it
    public List<Laser> GetInputLasers(BlockObject blockObject)
    {
        List<Laser> lasersToReturn = new List<Laser>();

        foreach (Laser laser in lasers)
        {
            if(laser.destinationBlock == blockObject)
            {
                lasersToReturn.Add(laser);
            }
        }

        return lasersToReturn;
    }
}
