﻿namespace GlStats.Core.Entities;

public class Project
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Uri? AvatarUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public Uri? WebUrl { get; set; }
}