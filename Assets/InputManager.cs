using System.Collections.Generic;
using UnityEngine;

public struct PossibleInput
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public PossibleInput(KeyCode l, KeyCode r, KeyCode j)
    {
        leftKey = l;
        rightKey = r;
        jumpKey = j;
    }
}

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] PlayerInputs[] players;
    KeyCode A, W, D;
    bool[] used;

    private void Start()
    {
        if (instance == null) instance = this;

        A = KeyCode.A;
        W = KeyCode.W;
        D = KeyCode.D;

        List<PossibleInput> inputs = new List<PossibleInput>();
        inputs.Add(new PossibleInput(W, A, D));
        inputs.Add(new PossibleInput(W, D, A));
        inputs.Add(new PossibleInput(D, W, A));
        inputs.Add(new PossibleInput(D, A, W));
        inputs.Add(new PossibleInput(A, D, W));
        inputs.Add(new PossibleInput(A, W, D));

        int combPos = 0;
        used = new bool[inputs.Count];
        for (int i = 0; i < players.Length; i++)
        {
            combPos = Random.Range(0, inputs.Count);
            if (!used[combPos])
            {
                players[i].SetInput(inputs[combPos]);
                used[combPos] = true;
            }
            else i--;
        }
    }

    public void ResetInputs()
    {
        for (int i = 0; i < used.Length; i++)
        {
            used[i] = false;
        }
    }
}
