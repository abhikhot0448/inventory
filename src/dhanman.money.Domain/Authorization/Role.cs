﻿using B2aTech.CrossCuttingConcern.Core.Exceptions;

namespace dhanman.money.Domain.Authorization;

public sealed class Role
{
    private Permission[] _permissions;

    public Role(string name, string description, IEnumerable<Permission> permissions)
        : this()
    {
        Name = name;
        Description = description;
        _permissions = permissions.ToArray();
    }

    private Role()
    {
        Name = string.Empty;
        Description = string.Empty;
        _permissions = Array.Empty<Permission>();
    }

    public string Name { get; }

    public string Description { get; private set; }

    public IReadOnlyList<Permission> Permissions => _permissions.ToArray();

    public void Update(string description, IReadOnlyCollection<Permission> permissions)
    {
        if (!permissions.Any())
        {
            throw new DomainException(Errors.Role.AtLeastOnePermissionIsRequired);
        }

        Description = description;

        _permissions = permissions.ToArray();
    }
}
