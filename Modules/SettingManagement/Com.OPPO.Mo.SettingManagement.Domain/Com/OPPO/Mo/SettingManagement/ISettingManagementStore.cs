﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.SettingManagement
{
    public interface ISettingManagementStore
    {
        Task<string> GetOrNullAsync(string name, string providerName, string providerKey);

        Task<List<SettingValue>> GetListAsync(string providerName, string providerKey);

        Task SetAsync(string name, string value, string providerName, string providerKey);
        
        Task DeleteAsync(string name, string providerName, string providerKey);
    }
}