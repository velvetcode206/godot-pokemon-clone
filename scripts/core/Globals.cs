using Godot;
using System;

namespace GodotPokemonClone.scripts.core;

public partial class Globals : Node
{
    public static Globals Instance { get; private set; }

    [ExportCategory("Gameplay")] [Export] public int GridSize = 16;

    public override void _Ready()
    {
        Instance = this;
        Logger.Info("Initializing Globals instance...");
    }
}