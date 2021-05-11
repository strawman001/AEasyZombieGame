using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutScene_DessertScene : MonoBehaviour
{

    public List<GameObject> gameObjectsNotNeededInCutscene;

    public GameObject TheBoss;
    public GameObject TheBoss_head;
    private BossMovementController bossMovementController;
    public Camera cutSceneCamera;

    int sequenceNumber;


    private void Awake()
    {
        bossMovementController = TheBoss.GetComponent<BossMovementController>();

        TurnOffGameObjects();

        StartCoroutine(Take1());

    }

    private void Update()
    {

        cutSceneCamera.transform.LookAt(TheBoss_head.transform);
        Take1Sequences(sequenceNumber);
    }
    void TurnOffGameObjects()
    {
        foreach(GameObject objects in gameObjectsNotNeededInCutscene)
        {
            objects.SetActive(false);
        }
    }

    void TurnOnGameObjects()
    {
        foreach (GameObject objects in gameObjectsNotNeededInCutscene)
        {
            objects.SetActive(true);
        }
    }

    IEnumerator Take1()
    {

        cutSceneCamera.transform.position = bossMovementController.gameObject.transform.position + new Vector3(10f, 20f, 120f);
        sequenceNumber = 2;
        yield return new WaitForSeconds(3.5f);

        sequenceNumber = 1;

        yield return new WaitForSeconds(4.0f);

        sequenceNumber = 0;

        yield return new WaitForSeconds(3.0f);

        TurnOnGameObjects();
        Destroy(this.gameObject);
    }

    void Take1Sequences(int sequenceNumber)
    {

        cutSceneCamera.transform.LookAt(bossMovementController.gameObject.transform);
        switch (sequenceNumber)
        {
            case 0:
                bossMovementController.Idle();
                return;

            case 1:

                bossMovementController.Walk();
                return;
            case 2:
                bossMovementController.Run();
                return;
        }
    }


}
