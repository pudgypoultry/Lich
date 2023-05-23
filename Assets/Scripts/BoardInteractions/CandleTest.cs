using UnityEngine;

public class CandleTest : MonoBehaviour
{
    public ParticleSystem fireParticles;
    private bool isMouseOver;

    private void Start()
    {
        // Deactivate fire particles on game start
        fireParticles.Stop();
    }

    private void OnMouseEnter()
    {
        // Triggered when the mouse hovers over the candle
        isMouseOver = true;
        fireParticles.Play();
    }

    private void OnMouseExit()
    {
        // Triggered when the mouse exits the candle
        isMouseOver = false;
        fireParticles.Stop();
    }

    private void Update()
    {
        // Check if the mouse is hovering over the candle in each frame
        if (isMouseOver && !fireParticles.isPlaying)
        {
            fireParticles.Play();
        }
    }
}
