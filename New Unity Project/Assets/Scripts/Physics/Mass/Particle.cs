using UnityEngine;
using System.Collections.Generic;

namespace Physics
{
    public class Particle
    {  
        public Vector3             position       { get; set; }
        public Vector3             prevPosition   { get; set; }
        public float               mass           { get; set; }
        public List< Constraint >  constraints    { get; set; }
        public Vector3             force          { get; set; }
                


        public Particle()
        {
            mass        = 1.0f;
            constraints = new List< Constraint >();
        }


        public void SetInitialPosition( Vector3 pos )
        {
            position       = pos;
            prevPosition   = pos;
        }


        // Instead of storing forces, we will 
        public void ApplyForce( Vector3 f )
        {
            force += f;   
        }


        public void SolveConstraints()
        {
            for( int i = 0; i < constraints.Count; i++ )
            {
                constraints[ i ].Solve();
            }
        }


        public void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere( position, mass * 0.1f );

            for( int i = 0; i < constraints.Count; i++ )
            {
                constraints[ i ].DrawGizmos();
            }            
        }
    }
}