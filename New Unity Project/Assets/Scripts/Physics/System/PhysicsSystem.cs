using UnityEngine;
using System.Collections.Generic;

namespace Physics
{
    public abstract class PhysicsSystem : MonoBehaviour
    {
        public List< Particle > particles { get; set; }
        
        [SerializeField]
        private int             m_relaxationIterations;

        [SerializeField]
        private float           m_dampeningFactor;
        
        #if UNITY_EDITOR
        [SerializeField]
        private float           m_simulationTime;       // For debugging
        #endif


        protected virtual void Awake()
        {
            particles = new List< Particle >();
        }


        protected virtual void FixedUpdate()
        {
            if ( particles == null ) { return; }            

            for( int k = 0; k < m_relaxationIterations; k++ )
            {
                for( int n = 0; n < particles.Count; n++ )
                {
                    particles[ n ].SolveConstraints();
                }   
            }            
            
            VerletPhysicsStep();            

#if UNITY_EDITR
            m_simulationTime += Time.fixedDeltaTime;                
#endif
        }


        private void VerletPhysicsStep()
        {
            for ( int i = 0; i < particles.Count; i++ )
            {
                Particle p = particles[ i ];

                // Can't simulate non-existent mass
                if ( Mathf.Approximately( p.mass, 0.0f ) ) { return; }

                // Get acceleration from froce and reset force
                float   invMass = 1.0f / p.mass;
                Vector3 accel   = p.force * invMass;
                Vector3 vel     = ( p.position - p.prevPosition ) * m_dampeningFactor;
                p.force = Vector3.zero;

                // Do verlet integration
                Vector3 next = p.position + vel + accel * Time.fixedDeltaTime * Time.fixedDeltaTime;

                // Update positions
                p.prevPosition = p.position;
                p.position = next;

                #if UNITY_EDITOR
                    Debug.DrawRay( p.position, accel * 0.1f, Color.blue );
                    Debug.DrawRay( p.position, vel, Color.cyan );
                    Debug.DrawLine( p.prevPosition, p.position, Color.yellow );
                #endif
            }
        
        }


        void OnDrawGizmos()
        {
            if ( particles != null )
            {
                for ( int i = 0; i < particles.Count; i++ )
                {
                    particles[ i ].DrawGizmos();
                }
            }
        }
    }

}