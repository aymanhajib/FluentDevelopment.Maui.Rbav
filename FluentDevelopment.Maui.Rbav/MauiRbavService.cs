
using FluentDevelopment.Rba.Models;
using System.ComponentModel;
using FluentDevelopment.Rba;
using System.Linq;

namespace FluentDevelopment.Maui.Rbav
{
    public class MauiRbavService : RbaService, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private RbaRole? _currentRole = null;
        public RbaRole? CurrentRole
        {
            get => _currentRole;
            set
            {
                var oldValue = _currentRole;
                _currentRole = value;
                if (value != oldValue && value?.Name != oldValue?.Name)
                {
                    OnPropertyChanged(nameof(CurrentRole));
                }
            }
        }

        public bool HasRole(params string[] roleNames)
        {
            if (CurrentRole is null) return false;
            return roleNames.Any(rn => rn == CurrentRole.Name);
        }

        public bool HasResource(string resourceName)
        {
            if (CurrentRole is null) return false;
            return base.RoleHasResource(CurrentRole, resourceName);
        }

        public bool HasPermission(string permissionName)
        {
            if (CurrentRole is null) return false;
            return base.RoleHasPermission(CurrentRole, permissionName);
        }
        public bool HasPermission(string resourceName, string actionName)
        {
            if (CurrentRole is null) return false;
            return base.RoleHasPermission(CurrentRole, resourceName, actionName);
        }
        public bool HasPermission(string permissionName, string resourceName, string actionName)
        {
            if (CurrentRole is null) return false;
            return base.RoleHasPermission(CurrentRole, resourceName, actionName, permissionName);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
