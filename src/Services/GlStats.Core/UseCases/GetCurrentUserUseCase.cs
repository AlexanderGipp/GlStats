﻿using GlStats.Core.Boundaries.Providers;
using GlStats.Core.Boundaries.UseCases.GetCurrentUser;
using GlStats.Core.Entities.Exceptions;

namespace GlStats.Core.UseCases;

public class GetCurrentUserUseCase : IGetCurrentUserUseCase
{
    private readonly IGetCurrentUserOutputPort _output;
    private readonly IGitLabProvider _gitLabProvider;

    public GetCurrentUserUseCase(IGetCurrentUserOutputPort output, IGitLabProvider gitLabProvider)
    {
        _output = output;
        _gitLabProvider = gitLabProvider;
    }

    public async Task Execute()
    {
        try
        {
            var currentUser = await _gitLabProvider.GetCurrentUserAsync();
            _output.Default(currentUser);
        }
        catch (NoConnectionException)
        {
            _output.NoConnection();
        }
        catch (InvalidConfigException)
        {
            _output.InvalidConfig();
        }
        catch
        {
            _output.InvalidConfig();
        }
    }
}