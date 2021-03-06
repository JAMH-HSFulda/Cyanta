﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Daten für das Herstellen des Labyrinths

public class VoxelData {
    public int forward = 10;
    public int sideways = 10;

    //Bei einer 1 im Array wird an der Stelle ein Würfel hinzugefügt
    int[,] data = new int[,] {{0,0,0,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0,0,1,1,1,0}, 
                              {0,1,0,0,0,0,0,0,1,0,1,0,1,0,1,1,1,0,1,0,0,0,0,1,0,1,1,0,1,0}, 
                              {0,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,0,0,0,0,1,1,1,0}, 
                              {0,1,0,0,0,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,1,1,1,1,0,1,0}, 
                              {0,1,0,1,1,1,1,1,1,1,1,0,0,0,1,1,1,0,1,0,1,0,1,0,0,1,0,0,1,0}, 
                              {0,1,0,1,0,0,0,0,1,0,1,0,1,1,1,0,1,1,1,0,1,0,0,0,0,1,0,0,1,0}, 
                              {0,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0}, 
                              {0,1,0,1,0,0,0,0,0,0,1,1,1,0,1,0,1,0,1,0,0,0,0,0,0,1,0,0,0,0}, 
                              {0,1,0,1,0,0,1,1,1,1,1,0,0,0,1,0,1,0,1,0,1,1,1,1,0,1,1,0,0,0}, 
                              {0,1,0,1,0,0,1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,0,0,0,0,0,1,0,1,0},
                              {0,1,0,1,0,0,1,0,1,0,0,1,0,0,1,0,1,0,0,0,0,0,1,1,1,1,1,0,1,0}, 
                              {0,1,0,1,0,0,1,0,1,1,0,0,0,0,1,1,1,1,1,1,1,0,1,0,0,0,0,0,1,0}, 
                              {0,1,0,1,1,1,1,0,1,0,0,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,1}, 
                              {0,1,0,1,0,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0}, 
                              {0,1,0,1,0,1,1,1,1,0,1,0,1,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0}, 
                              {0,1,0,1,0,0,1,0,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,1,0,0,1,0,0,0}, 
                              {0,1,0,1,0,0,1,0,1,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0}, 
                              {1,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0}, 
                              {0,1,0,1,0,1,0,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,1,0,0,1,0}, 
                              {0,1,0,1,0,1,0,1,1,1,1,0,0,1,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1,0},
                              {0,1,0,1,1,1,0,1,0,0,1,1,0,0,0,1,1,0,1,0,0,0,0,0,0,1,0,0,0,0}, 
                              {0,1,0,0,0,1,1,1,0,0,0,0,0,1,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0}, 
                              {0,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,0,0}, 
                              {0,1,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,0,1,1,1,1,0}, 
                              {0,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,1,0,0,1,0,0,1,0}, 
                              {0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0}, 
                              {0,1,1,1,1,1,1,1,0,1,0,1,1,1,0,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0}, 
                              {0,1,0,0,0,0,0,1,0,1,0,1,0,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,0}, 
                              {0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0}, 
                              {0,1,1,1,0,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0}};
        
        
    /* Array random mit Einsen und Nullen füllen
    int[,] data = new int[50, 50];
    public void fillData() {
        //data = dataLevel1; 
        //Random.seed = 42;
        for(int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                data[i, j] = Random.Range(0, 2);  // random int from 0 - 1 -> (0 to max + 1)
                Debug.Log("i: " + i + " j: " + j + " " + data[i, j]);
            }
        }
    }*/

    public int Width {
        get {return data.GetLength (0); }
    }

    public int Depth {
        get {return data.GetLength (1); }
    }

    public int GetCell  (int x, int z) {
        return data[x, z];
    }

    //Nachbar vorhanden? Ja --> kein Face auf dieser Seite
    public int GetNeighbor (int x, int z, Direction dir) {
        DataCoordinate offsetToCheck = offsets[(int) dir];
        DataCoordinate neighborCoord = new DataCoordinate(x + offsetToCheck.x, 0 + offsetToCheck.y, z + offsetToCheck.z);

        if(neighborCoord.x < 0 || neighborCoord.x >= Width || neighborCoord.y != 0 || neighborCoord.z < 0 || neighborCoord.z >= Depth) {
            return 0;
        } else {
            return GetCell(neighborCoord.x, neighborCoord.z);
        }
    }

    struct DataCoordinate {
        public int x;
        public int y;
        public int z;

        public DataCoordinate(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    DataCoordinate[] offsets = {
        new DataCoordinate (0, 0, 1),
        new DataCoordinate (1, 0, 0),
        new DataCoordinate (0, 0, -1),
        new DataCoordinate (-1, 0, 0),
        new DataCoordinate (0, 1, 0),
        new DataCoordinate (0, -1, 0)
    };
}

public enum Direction {
    North, 
    East,
    South,
    West,
    Up,
    Down
}