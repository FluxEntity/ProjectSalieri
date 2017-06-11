using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoAttack : MonoBehaviour
{
    public Transform N1;
    public Transform N2;
    public Transform N3;
    public Transform N4;
    public Transform N5;
    public Transform N6;

    public Transform C1;
    public Transform C2;
    public Transform C3;
    public Transform C4;
    public Transform C5;
    public Transform C6;

    float currentTime;

    float[,] noteMap;

    float startTime;

    float firstTime;

    float typenotelast;

    float typenotenext;

    float offset;

    public int noteCounter;

    Transform boardTransform;

    public AudioBehavior audioRef;

    // Use this for initialization
    void Start()
    {
        boardTransform = GetComponent<Transform>();
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        offset = 0;
        noteCounter = 0;
        startTime = audioRef.trackTime;
        print("START: " + startTime);
        firstTime = startTime + audioRef.SPB * audioRef.BPB - (7.37f / audioRef.noteVelocity);

        noteMap = new float[,]
        {
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 1, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
            { 0, 0, 1, 0, 0, 0, 4 },
        };

        if (noteMap != null) {
            typenotelast = noteMap[0, 6];
            noteMap[0, 6] = firstTime;
        }
        for (int i = 1; i < noteMap.GetLength(0); i++)
        {
            typenotenext = noteMap[i, 6];
            noteMap[i, 6] = noteMap[i - 1, 6] + 60 * (4f / typenotelast) / (audioRef.BPM);
            typenotelast = typenotenext;
        }
        Instantiate(C1, new Vector3(C1.position.x, boardTransform.position.y - 2.6f, C1.position.z), C1.rotation).parent = boardTransform;
        Instantiate(C2, new Vector3(C2.position.x, boardTransform.position.y - 2.6f, C2.position.z), C2.rotation).parent = boardTransform;
        Instantiate(C3, new Vector3(C3.position.x, boardTransform.position.y - 2.6f, C3.position.z), C3.rotation).parent = boardTransform;
        Instantiate(C4, new Vector3(C4.position.x, boardTransform.position.y - 2.6f, C4.position.z), C4.rotation).parent = boardTransform;
        Instantiate(C5, new Vector3(C5.position.x, boardTransform.position.y - 2.6f, C5.position.z), C5.rotation).parent = boardTransform;
        Instantiate(C6, new Vector3(C6.position.x, boardTransform.position.y - 2.6f, C6.position.z), C6.rotation).parent = boardTransform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = audioRef.trackTime;
        while (currentTime >= noteMap[noteCounter, 6]){
            print("CALCULATED TIME: " + noteMap[noteCounter, 6]);
            if (noteMap[noteCounter, 6] - startTime < 0)
            {
                offset = (noteMap[noteCounter, 6] - startTime) * audioRef.noteVelocity;
                print("CALCULATED OFFSET: " + offset);
            }
            else
            {
                offset = 0;
            }

            if (noteMap[noteCounter, 0] == 1)
            {
                print("SPAWNTIME: " + currentTime);
                Instantiate(N1, new Vector3(N1.position.x, boardTransform.position.y + 5.2f + offset, N1.position.z), N1.rotation).parent = boardTransform;
            }
            if (noteMap[noteCounter, 1] == 1)
            {
                Instantiate(N2, new Vector3(N2.position.x, boardTransform.position.y + 5.2f + offset, N2.position.z), N2.rotation).parent = boardTransform;
            }
            if (noteMap[noteCounter, 2] == 1)
            {
                print("1: Calculated -- " + noteMap[noteCounter, 6]);
                print("2: Actual -- " + currentTime);
                Instantiate(N3, new Vector3(N3.position.x, boardTransform.position.y + 5.2f + offset, N3.position.z), N3.rotation).parent = boardTransform;
            }
            if (noteMap[noteCounter, 3] == 1)
            {
                Instantiate(N4, new Vector3(N4.position.x, boardTransform.position.y + 5.2f + offset, N4.position.z), N4.rotation).parent = boardTransform;
            }
            if (noteMap[noteCounter, 4] == 1)
            {
                Instantiate(N5, new Vector3(N5.position.x, boardTransform.position.y + 5.2f + offset, N5.position.z), N5.rotation).parent = boardTransform;
            }
            if (noteMap[noteCounter, 5] == 1)
            {
                Instantiate(N6, new Vector3(N6.position.x, boardTransform.position.y + 5.2f + offset, N6.position.z), N6.rotation).parent = boardTransform;
            }
            noteCounter++;
        }
    }
}