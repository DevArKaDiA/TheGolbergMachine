using System;
using UnityEngine;

namespace Physics
{
    public class FloorConstraint : Constraint
    {
        public float    displacement { get; set; }
        public Particle particle { get; set; }

        public override void Solve()
        {
            Ray        r    = new Ray( particle.position + Vector3.up * 100.0f, Vector3.down );
            RaycastHit hit;

            if ( UnityEngine.Physics.Raycast( r, out hit, 100.0f + displacement ) )
            {
                particle.position = hit.point + Vector3.up * displacement;
            }
        }


        public override void DrawGizmos()
        {

        }
    }
}