﻿using GlStats.Core.Boundaries.Providers;
using GlStats.Core.Boundaries.UseCases.GetTeams;
using GlStats.Core.Entities.Exceptions;

namespace GlStats.Core.UseCases;

public class GetTeamsUseCase : IGetTeamsUseCase
{
    private readonly IGetTeamsOutputPort _output;
    private readonly ITeamsProvider _teamsProvider;

    public GetTeamsUseCase(IGetTeamsOutputPort output, ITeamsProvider teamsProvider)
    {
        _output = output;
        _teamsProvider = teamsProvider;
    }
    

    public void Execute()
    {
        try
        {
            var teams = _teamsProvider.GetTeams();
            _output.Default(teams);
        }
        catch (NoDatabaseConnection)
        {
            _output.NoDatabaseConnection();
        }
    }
}