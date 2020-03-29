using Physics;
using UnityEngine;
using System.Collections.Generic;


[RequireComponent( typeof( LineRenderer ) ) ]
[RequireComponent( typeof( RopeSystem ) ) ]

public class RopeRenderer : MonoBehaviour
{
    private RopeSystem   m_rope;
    private LineRenderer m_line;
    

    void Awake()
    {
        m_rope = GetComponent< RopeSystem >();
        m_line = GetComponent< LineRenderer >();

        m_line.useWorldSpace = true;
    }


    void Update()
    {
        m_line.SetVertexCount( m_rope.particles.Count );

        for( int i = 0; i < m_rope.particles.Count; i++ )
        {
            m_line.SetPosition( i, m_rope.particles[ i ].position );
        }
    }
}
