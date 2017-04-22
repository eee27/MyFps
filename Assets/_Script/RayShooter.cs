using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPoint;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip hitSound;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GlobalData.isUi)
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(InitBulletPoint(hit));
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

    private IEnumerator InitBulletPoint(RaycastHit hit)
    {
        GameObject bullet = Instantiate(bulletPoint, hit.point, bulletPoint.transform.rotation);
        audioSource.clip = hitSound;
        audioSource.PlayOneShot(hitSound);
        yield return new WaitForSeconds(0.08f);
        Destroy(bullet);
    }
}