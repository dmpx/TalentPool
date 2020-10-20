﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Une.TalentPool.Roles;

namespace Une.TalentPool.EntityFrameworkCore.Stores
{
    public class VanRoleStore : RoleStore<Role, TalentDbContext, Guid>, IRoleStore
    {
        public VanRoleStore(TalentDbContext context) : base(context)
        {

        }

        public async Task<List<string>> GetPermissionClaimsAsync(Role role, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            return await Context.RoleClaims
                .Where(w => w.ClaimType == AppConstansts.ClaimTypes.Permission && w.RoleId == role.Id)
                .Select(s => s.ClaimValue)
                .ToListAsync(cancellationToken);
        }
    }
}
