﻿using System.Resources;
using GlStats.Core.Boundaries.UseCases.AddTeam;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace GlStats.Wpf.Presenters;

public class AddTeamPresenter : IAddTeamOutputPort
{
    public bool HasDatabaseConnection = true;
    public int TeamId;
    private readonly MetroWindow? _window;

    private readonly ResourceManager _resourceManager;

    public AddTeamPresenter(ResourceManager resourceManager)
    {
        _resourceManager = resourceManager;

        _window = (Application.Current.MainWindow as MetroWindow);
    }

    public void Default(int teamId)
    {
        TeamId = teamId;
    }

    public void NoDatabaseConnection()
    {
        HasDatabaseConnection = false;
        _window.ShowMessageAsync(_resourceManager.GetString("NoDatabaseConnection"), _resourceManager.GetString("DatabaseConnectionError"));
    }
}