using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public Shader VhsShader;

    void Start()
    {
        // Créez un nouveau matériau et définissez son shader sur le shader VHS
        Material vhsMaterial = new Material(VhsShader);

        // Créez un nouvel objet Quad
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

        // Positionnez le Quad devant la caméra
        quad.transform.parent = transform;
        quad.transform.localPosition = new Vector3(0, 0, 1);
        quad.transform.localRotation = Quaternion.identity;
        quad.transform.localScale = new Vector3(Camera.main.aspect, 1, 1);

        // Appliquez le matériau au Quad
        quad.GetComponent<Renderer>().material = vhsMaterial;
    }
}
