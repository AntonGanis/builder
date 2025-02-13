using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveTransform : MonoBehaviour
{
    public Transform[] bild = new Transform[9];
    public bool[] destroy = new bool[9];
    public bool[] complit = new bool[9];

    void Start()
    {
        GameObject[] saves = GameObject.FindGameObjectsWithTag("сохронять");
        if (saves.Length > 1)
        {
            Destroy(saves[1]);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (i == (SceneManager.GetActiveScene().buildIndex - 1))
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            if (destroy[i])
            {
                Destroy(transform.GetChild(i).GetChild(0).gameObject);
                destroy[i] = false;
            }
        }
        for (int i = 0; i < 8; i++)
        {
            if (transform.GetChild(i).childCount != 0)
            {
                complit[i + 1] = true;
            }
        }
    }
    public void SaveTransforms()
    {
        PlayerPrefs.SetInt("TransformCount", bild.Length); // Сохраняем количество элементов в массиве

        for (int i = 0; i < bild.Length; i++)
        {
            PlayerPrefs.SetFloat("Transform" + i + "_PosX", bild[i].position.x);
            PlayerPrefs.SetFloat("Transform" + i + "_PosY", bild[i].position.y);
            PlayerPrefs.SetFloat("Transform" + i + "_PosZ", bild[i].position.z);

            PlayerPrefs.SetFloat("Transform" + i + "_RotX", bild[i].rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("Transform" + i + "_RotY", bild[i].rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("Transform" + i + "_RotZ", bild[i].rotation.eulerAngles.z);
        }
    }

    public void LoadTransforms()
    {
        int transformCount = PlayerPrefs.GetInt("TransformCount");

        for (int i = 0; i < transformCount; i++)
        {
            float posX = PlayerPrefs.GetFloat("Transform" + i + "_PosX");
            float posY = PlayerPrefs.GetFloat("Transform" + i + "_PosY");
            float posZ = PlayerPrefs.GetFloat("Transform" + i + "_PosZ");
            Vector3 position = new Vector3(posX, posY, posZ);

            float rotX = PlayerPrefs.GetFloat("Transform" + i + "_RotX");
            float rotY = PlayerPrefs.GetFloat("Transform" + i + "_RotY");
            float rotZ = PlayerPrefs.GetFloat("Transform" + i + "_RotZ");
            Quaternion rotation = Quaternion.Euler(rotX, rotY, rotZ);

            bild[i].position = position;
            bild[i].rotation = rotation;
        }
    }
}