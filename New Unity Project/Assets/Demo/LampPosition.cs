using Physics;
using UnityEngine;
using System.Collections;

public class LampPosition : MonoBehaviour
{
    [SerializeField]
    private RopeSystem m_rope;

	
	void Update ()
    {
	    if ( m_rope != null && m_rope.particles != null && m_rope.particles.Count >= 2 )
        {
            int n = m_rope.particles.Count;

            Vector3     pos = m_rope.particles[ n -1 ].position;
            Quaternion  rot = Quaternion.LookRotation( transform.forward, m_rope.particles[ n - 2 ].position - m_rope.particles[ n - 1 ].position );

            transform.position = pos;
            transform.rotation = rot;
        }
	}
}
