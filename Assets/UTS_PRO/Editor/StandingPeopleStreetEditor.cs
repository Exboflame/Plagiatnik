﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(StandingPeopleStreet))]
public class StandingPeopleStreetEditor : Editor
{

    public override void OnInspectorGUI()
    {
        StandingPeopleStreet _SPC = target as StandingPeopleStreet;
        SceneView.RepaintAll();

      if(_SPC.peopleCount < 1) _SPC.peopleCount = 1;

        if(_SPC.showSurface)
            _SPC.surface.GetComponent<MeshRenderer>().enabled = true;
        else
            _SPC.surface.GetComponent<MeshRenderer>().enabled = false;

        DrawDefaultInspector();

        if(_SPC.SurfaceType.ToString() == "Rectangle"){

            if(_SPC.isCircle)
                _SPC.SpawnRectangleSurface();

            _SPC.planeSize = EditorGUILayout.Vector2Field("Rectangle size:", _SPC.planeSize);

            _SPC.isCircle = false;
        	
    	}

    	else if(_SPC.SurfaceType.ToString() == "Circle"){

            if(!_SPC.isCircle)
                _SPC.SpawnCircleSurface();

            _SPC.circleDiametr = EditorGUILayout.FloatField("Circle diameter:", _SPC.circleDiametr);

            _SPC.isCircle = true;
    	}

        _SPC.showSurface = EditorGUILayout.Toggle("Show surface:", _SPC.showSurface);
        EditorGUILayout.Space();

        _SPC.peopleCount = EditorGUILayout.IntField("People count:", _SPC.peopleCount);
        EditorGUILayout.Space();


        if(GUILayout.Button("Populate!"))
        {
            _SPC.PopulateButton();
        }   

        if(GUILayout.Button("Remove people"))
        {
            _SPC.RemoveButton();
        }   

    }
}