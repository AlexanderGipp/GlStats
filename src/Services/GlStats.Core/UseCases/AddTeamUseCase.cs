﻿using GlStats.Core.Boundaries.Providers;
using GlStats.Core.Boundaries.UseCases.AddTeam;
using GlStats.Core.Entities;
using GlStats.Core.Entities.Exceptions;

namespace GlStats.Core.UseCases;

public class AddTeamUseCase : IAddTeamUseCase
{
    private readonly IAddTeamOutputPort _output;
    private readonly ITeamsProvider _teamsProvider;

    public AddTeamUseCase(IAddTeamOutputPort output, ITeamsProvider teamsProvider)
    {
        _output = output;
        _teamsProvider = teamsProvider;
    }

    public void Execute(Team team)
    {
        try
        {
            var teamId = _teamsProvider.AddTeam(team);
            _output.Default(teamId);
        }
        catch (NoDatabaseConnection)
        {
            _output.NoDatabaseConnection();
        }
    }
}