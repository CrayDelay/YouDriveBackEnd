namespace CargoOrderingService.SharedTestHelpers.Fakes.RolePermission;

using AutoBogus;
using CargoOrderingService.Domain;
using CargoOrderingService.Domain.RolePermissions.Dtos;
using CargoOrderingService.Domain.Roles;
using CargoOrderingService.Domain.RolePermissions.Models;

public sealed class FakeRolePermissionForUpdateDto : AutoFaker<RolePermissionForUpdateDto>
{
    public FakeRolePermissionForUpdateDto()
    {
        RuleFor(rp => rp.Permission, f => f.PickRandom(Permissions.List()));
        RuleFor(rp => rp.Role, f => f.PickRandom(Role.ListNames()));
    }
}