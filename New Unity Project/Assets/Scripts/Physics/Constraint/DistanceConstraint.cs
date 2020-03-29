using System;
using UnityEngine;

namespace Physics
{
    public class DistanceConstraint : Constraint
    {
        public float    distance  { get; set; }
        public float    stiffness { get; set; }
        public Particle particleA { get; set; }
        public Particle particleB { get; set; }


        public override void Solve()
        {
            Vector3 dir        = ( particleA.position - particleB.position ).normalized;
            float   dist       = Vector3.Distance( particleA.position, particleB.position );
            float   distFactor = ( distance - dist ) / dist;

            float m1 = 1.0f / particleA.mass;
            float m2 = 1.0f / particleB.mass;

            float stiffnessFactor1 = ( m1 / ( m1 + m2 ) ) * stiffness;
            float stiffnessFactor2 = stiffness - stiffnessFactor1;

            particleA.position += dir * dist * stiffnessFactor1 * distFactor;
            particleB.position -= dir * dist * stiffnessFactor2 * distFactor;
        }


        public override void DrawGizmos()
        {
            float d = Vector3.Distance( particleA.position, particleB.position );

            if ( d < distance )
            {
                Gizmos.color = Color.yellow;
            }
            else if ( Mathf.Approximately( d, distance ) )
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawLine( particleA.position, particleB.position );
        }
    }
}