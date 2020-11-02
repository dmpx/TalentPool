﻿using System;

namespace Une.TalentPool.Configurations
{
    /// <summary>
    /// 用户定义的设置
    /// </summary>
    public interface IUserSettingDefinition : ISettingDefinition
    {
        Guid OwnerUserId { get; set; }
    }
}
