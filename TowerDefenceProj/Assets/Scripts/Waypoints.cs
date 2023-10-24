using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points; //Making the list of game objects in the scene(Transform) of waypoints accessible to any script without the need for reference(static)
    
    private void Awake() //Making the waypoints a priority to load before all the other codes(Awake)
    {                                         
                                                        
                                                      //"new Transform" = changing the values of Transform
        //Waypoints = child of Parent Waypoint        //Points = Waypoints.
       points = new Transform[transform.childCount];  //Counting the number of "Child" in the "Parent" called "Waypoints"
                                                      //Giving the "points" an array which is the "child" of the "parent" grouped as "Waypoints" which is filled with many "child" waypoints

        //Waypoints Pathway
        for (int i = 0; i < points.Length; i++)       //Array for the waypoints, starting from point 0(First Point) and +1 every point reached, gradually till the End Point(points.Length) which is the total number of "child" waypoints.
        {
            points[i] = transform.GetChild(i);        //Points[i] =  The "Child" in the "Parent" called "Waypoints"
        }
    }
}
