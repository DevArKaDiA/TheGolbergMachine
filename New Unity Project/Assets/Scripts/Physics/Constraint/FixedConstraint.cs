using System;
using UnityEngine;

namespace Physics
{
    public class FixedConstraint : Constraint
    {
        public Vector3  position { get; set; }
        public Particle particle { get; set; }


        public override void Solve()
        {
            particle.position = position;
        }


        public override void DrawGizmos()
        {
            Gizmos.color = Color.black;

            Gizmos.DrawLine( particle.position, position );
            Gizmos.DrawLine( position - Vector3.right * 0.2f, position + Vector3.right * 0.2f );
            Gizmos.DrawLine( position, position + Vector3.up * 0.2f );
        }
    }
}