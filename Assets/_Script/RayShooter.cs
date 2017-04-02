using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPoint;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(InitBulletPoint(hit.point));
            }
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    /*----------------------------------------------*/

    private IEnumerator InitBulletPoint(Vector3 pos)
    {
        GameObject bullet = Instantiate(bulletPoint, pos, bulletPoint.transform.rotation);
        yield return new WaitForSeconds(1);
        Destroy(bullet);
    }
}