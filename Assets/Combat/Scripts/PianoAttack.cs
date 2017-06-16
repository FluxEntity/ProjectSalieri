using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoAttack : MonoBehaviour
{
    public AudioBehavior audioRef;

    public Transform Note;
    public Transform LongNote;
    public Transform C1;
    public Transform C2;
    public Transform C3;
    public Transform C4;
    public Transform C5;
    public Transform C6;
    Transform boardTransform;

    public float tailLength;
    float currentTime;
    float[,] noteMap;
    float startTime;
    float firstTime;
    float typenotelast;
    float typenotenext;
    float offset;
    float destroyTime;
    bool done;
    public int noteCounter;
    public bool NOMOREOFFSETS;

    // Use this for initialization
    void Start()
    {
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        startTime = audioRef.trackTime;
        boardTransform = GetComponent<Transform>();
        offset = 0;
        noteCounter = 0;
        firstTime = (startTime + audioRef.SPB * audioRef.BPB - (7.33f / audioRef.noteVelocity))%audioRef.GetComponent<AudioSource>().clip.length;
        //if (firstTime >= audioRef.GetComponent<AudioSource>().clip.length)
       // {
        //    startTime -= audioRef.GetComponent<AudioSource>().clip.length;
        //    firstTime -= audioRef.GetComponent<AudioSource>().clip.length;
       // }
        NOMOREOFFSETS = false;
        done = false;

        noteMap = new float[,]
        {
            { 0.1f, 0, 0, 0, 0, 0, 1/4f },
            { 0, 0.1f, 0, 0, 0, 0, 1/4f },
            { 0, 0, 0.1f, 0, 0, 0, 1/4f },
            { 0, 0, 0, 0.1f, 0, 0, 1/4f },
            { 0.1f, 0, 0, 0, 0, 0.1f, 1/2f },
            { 0, 0, 0.1f, 0, 0.1f, 0, 1/2f },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 1 },
            { 0, 1, 0, 0, 1, 0, 1 },
            { 1f, 0, 0, 0.1f, 0, 0, 1/4f },
            { 0, 0, 0, 0, 0.1f, 0, 1/8f },
            { 0, 0, 0, 0, 0, 0.1f, 1/8f },
            { 0, 0, 0, 0, 0.1f, 0, 1/4f},
            { 0, 0, 0, 0.1f, 0, 0, 1/4f},
            { 0, 0, 0, 0, 0.1f, 0, 1/4f},
            { 0, 0, 0, 0.1f, 0, 0.1f, 1/4f},
            { 0, 0, 0, 0.1f, 0, 0.1f, 1/4f},
            { 0, 0, 0, 0.1f, 0, 0.1f, 1/4f},


        };

        if (noteMap != null) {
            typenotelast = noteMap[0, 6];
            noteMap[0, 6] = firstTime;
        }
        for (int i = 1; i < noteMap.GetLength(0); i++)
        {
            typenotenext = noteMap[i, 6];
            noteMap[i, 6] = (noteMap[i - 1, 6] + 60 * (4*typenotelast) / (audioRef.BPM))%audioRef.GetComponent<AudioSource>().clip.length;
            typenotelast = typenotenext;
        }
        destroyTime = ((noteMap[noteMap.GetLength(0) - 1, 6] + 60 * (audioRef.BPB) / (audioRef.BPM)) + (7.33f / audioRef.noteVelocity))%audioRef.GetComponent<AudioSource>().clip.length;
        Instantiate(C1, new Vector3(C1.position.x, boardTransform.position.y - 2.6f, C1.position.z), C1.rotation).parent = boardTransform;
        Instantiate(C2, new Vector3(C2.position.x, boardTransform.position.y - 2.6f, C2.position.z), C2.rotation).parent = boardTransform;
        Instantiate(C3, new Vector3(C3.position.x, boardTransform.position.y - 2.6f, C3.position.z), C3.rotation).parent = boardTransform;
        Instantiate(C4, new Vector3(C4.position.x, boardTransform.position.y - 2.6f, C4.position.z), C4.rotation).parent = boardTransform;
        Instantiate(C5, new Vector3(C5.position.x, boardTransform.position.y - 2.6f, C5.position.z), C5.rotation).parent = boardTransform;
        Instantiate(C6, new Vector3(C6.position.x, boardTransform.position.y - 2.6f, C6.position.z), C6.rotation).parent = boardTransform;

        //Instatiate all notes with negative spawntimes
        while (noteMap[noteCounter, 6] < startTime && noteMap[noteCounter, 6] + (audioRef.BPB + 1) * audioRef.SPB > startTime)
        {
            offset = (noteMap[noteCounter, 6] - startTime)*audioRef.noteVelocity;
            for (int i = 0; i < 6; i++)
            {
                if (noteMap[noteCounter, i] != 0)
                {
                    tailLength = noteMap[noteCounter, i];
                    if (tailLength == 0.1f)
                    {
                        Instantiate(Note, new Vector3(Note.position.x - 1.5f + 0.6f * i, boardTransform.position.y + 5.2f + offset), Note.rotation).parent = boardTransform;
                    }
                    else
                    {
                        Transform blarg = Instantiate(LongNote, new Vector3(LongNote.position.x - 1.5f + 0.6f * i, boardTransform.position.y + 5.2f + offset), LongNote.rotation);
                        blarg.SetParent(boardTransform);
                        blarg.gameObject.GetComponent<NoteLongBehavior>().tailLength = 60 * audioRef.SPB * tailLength / audioRef.noteVelocity;
                    }
                }
            }
            noteCounter++;
            if (noteCounter >= noteMap.GetLength(0)) { done = true; break; }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            currentTime = audioRef.trackTime;
            while ((currentTime >= noteMap[noteCounter, 6] && currentTime <= noteMap[noteCounter, 6] + 6))
            {
                for (int i = 0; i < 6; i++) {
                    if (noteMap[noteCounter, i] != 0)
                    {
                        tailLength = noteMap[noteCounter, i];
                        if (tailLength == 0.1f)
                        {
                            Instantiate(Note, new Vector3(Note.position.x - 1.5f + 0.6f*i, boardTransform.position.y + 5.2f), Note.rotation).parent = boardTransform;
                        }
                        else
                        {
                            Transform blarg = Instantiate(LongNote, new Vector3(LongNote.position.x - 1.5f + 0.6f * i, boardTransform.position.y + 5.2f), LongNote.rotation);
                            blarg.SetParent(boardTransform);
                            blarg.gameObject.GetComponent<NoteLongBehavior>().tailLength = 60 * audioRef.SPB * tailLength / audioRef.noteVelocity;
                        }
                    }
                }
                noteCounter++;
                if (noteCounter >= noteMap.GetLength(0)) { done = true; break; }
            }
        }
        else
        {
            if(audioRef.trackTime >= destroyTime && audioRef.trackTime <= destroyTime + 6)
            {
                Destroy(gameObject);
            }
        }
    }
}