using UnityEngine;
using System.Collections;

namespace Physics
{
    public class RopeSystem : PhysicsSystem
    {
        [SerializeField]
        private float m_gravity;

        [SerializeField]
        private float m_pointMass;

        [SerializeField]
        private int   m_segmentCount;

        [SerializeField]
        private float m_segmentLength;

        [SerializeField]
        private float m_stiffness;


        private FixedConstraint m_rootConstraint;


        protected override void Awake()
        {
            base.Awake();

            // Add particles and constraints
            for( int i = 0; i < m_segmentCount; i++ )
            {
                Particle p = new Particle { mass = m_pointMass };
                p.SetInitialPosition( transform.position + Vector3.down * m_segmentLength * i );

                particles.Add( p );

                // First particle is pinned to the system
                if ( i == 0 )
                {
                    m_rootConstraint = new FixedConstraint { position = transform.position, particle = p };
                    p.constraints.Add( m_rootConstraint );
                }
                // Other particles are connected to each other in sequence
                else
                {
                    DistanceConstraint c = new DistanceConstraint
                    {
                        distance  = m_segmentLength,
                        stiffness = m_stiffness,
                        particleA = p,
                        particleB = particles[ i - 1 ]
                    };

                    p.constraints.Add( c );

                    // Add floor constraint for niceness
                    p.constraints.Add(
                        new FloorConstraint { particle = p, displacement = 0.4f }
                    );
                }
            }
            
        }


        protected override void FixedUpdate()
        {
            if ( particles == null ) { return; }

            if ( m_rootConstraint != null )
            {
                m_rootConstraint.position = transform.position;
            }

            for( int i = 0; i < particles.Count; i++ )
            {
                particles[ i ].ApplyForce( Vector3.down * m_gravity * particles[ i ].mass );
            }

            base.FixedUpdate();
        }

    }
}