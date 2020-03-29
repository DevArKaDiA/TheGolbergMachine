using UnityEngine;
using UnityEngine.SceneManagement;


public class MouseControls : MonoBehaviour
{
    [SerializeField]
    private Vector3     m_focalPoint;

    [SerializeField]
    private Transform   m_rope;

    [SerializeField]
    private Camera      m_camera;

    [SerializeField]
    private float       m_translateScale;

    [SerializeField]
    private float       m_rotateScale;

    private int         m_button;
    private Vector3     m_mousePos;


    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButton( 0 ) && Input.GetMouseButton( 1 ) )
        {
            m_button = 2;
        }
        else if ( Input.GetMouseButton( 0 ) )
        {
            m_button = 0;
        }
        else if ( Input.GetMouseButton( 1 ) )
        {
            if ( m_button == 0 ) { m_mousePos = Input.mousePosition; }
            m_button = 1;
        }
        else
        {
            if ( m_button == 0 ) { m_mousePos = Input.mousePosition; }
            m_button = -1;
        }

        Vector3 delta = Input.mousePosition - m_mousePos;
        m_mousePos = Input.mousePosition;        

        switch( m_button )
        {
            case 0:
            {
                Vector3 dx = m_camera.transform.right * delta.x * m_translateScale;
                Vector3 dy = m_camera.transform.up * delta.y * m_translateScale;

                m_rope.transform.position += dx;
                m_rope.transform.position += dy;
            }
            break;

            case 1:
            {
                Vector3 dx = m_camera.transform.right * delta.x * m_translateScale;
                Vector3 dz = m_camera.transform.forward * delta.y * m_translateScale;

                m_rope.transform.position += dx;
                m_rope.transform.position += dz;
            }
            break;

            case 2:
            {
                float amount = delta.x * m_rotateScale;
                m_camera.transform.RotateAround( m_focalPoint, Vector3.up, amount );
            }
            break;
        }

        if ( Input.GetKeyDown( KeyCode.R ) )
        {
            m_rope.transform.position = Vector3.zero;         
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube( m_focalPoint, Vector3.one * 0.1f );
    }
}
