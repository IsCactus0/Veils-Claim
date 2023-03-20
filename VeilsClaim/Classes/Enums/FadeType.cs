namespace VeilsClaim.Classes.Enums
{
    /// <summary>
    /// Fade types for generating textures.
    /// </summary>
    public enum FadeType
    {
        ///<summary>No fade.</summary>
        None,
        ///<summary>Blurs the edges to remove pixelated look.</summary>
        Edge,
        ///<summary>Fades linearly from center.</summary>
        Linear,
        ///<summary>Fades from center following the inverse square law.</summary>
        InverseSquare,
    }
}