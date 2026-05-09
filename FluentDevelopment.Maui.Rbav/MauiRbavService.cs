
using FluentDevelopment.Rba.Models;
using System.ComponentModel;
using FluentDevelopment.Rba;
using System.Linq;

namespace FluentDevelopment.Maui.Rbav
{
    /// <summary>
    /// Provides role-based access validation services for MAUI applications.
    /// </summary>
    public class MauiRbavService : RbaService, INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets the current role for access validation.
        /// </summary>
        public RbaRole? CurrentRole
        {
            get => field;
            set
            {
                var oldValue = field;
                field = value;
                if (value != oldValue && value?.Name != oldValue?.Name)
                {
                    OnPropertyChanged(nameof(CurrentRole));
                }
            }
        }

        /// <summary>
        /// Determines whether the current role matches any of the specified role names.
        /// </summary>
        /// <param name="roleNames">An array of role names to check.</param>
        /// <returns><c>true</c> if the current role matches any of the specified names; otherwise, <c>false</c>.</returns>
        public bool HasRole(params string[] roleNames)
        {
            if (CurrentRole is null) return false;
            return roleNames.Any(rn => rn == CurrentRole.Name);
        }

        /// <summary>
        /// Determines whether the current role has access to the specified resource.
        /// </summary>
        /// <param name="resourceName">The name of the resource.</param>
        /// <returns><c>true</c> if the current role has access; otherwise, <c>false</c>.</returns>
        public bool HasResource(string resourceName)
        {
            if (CurrentRole is null) return false;
            return base.RoleHasResource(CurrentRole, resourceName);
        }

        /// <summary>
        /// Determines whether the current role has the specified permission.
        /// </summary>
        /// <param name="permissionName">The name of the permission.</param>
        /// <returns><c>true</c> if the current role has the permission; otherwise, <c>false</c>.</returns>
        public bool HasPermission(string permissionName)
        {
            if (CurrentRole is null) return false;
            return base.RoleHasPermission(CurrentRole, permissionName);
        }

        /// <summary>
        /// Determines whether the current role has permission for the specified resource and action.
        /// </summary>
        /// <param name="resourceName">The name of the resource.</param>
        /// <param name="actionName">The name of the action.</param>
        /// <returns><c>true</c> if the current role has the permission; otherwise, <c>false</c>.</returns>
        public bool HasPermission(string resourceName, string actionName)
        {
            if (CurrentRole is null) return false;
            return base.RoleHasPermission(CurrentRole, resourceName, actionName);
        }

        /// <summary>
        /// Determines whether the current role has the specified permission for the given resource and action.
        /// </summary>
        /// <param name="permissionName">The name of the permission.</param>
        /// <param name="resourceName">The name of the resource.</param>
        /// <param name="actionName">The name of the action.</param>
        /// <returns><c>true</c> if the current role has the permission; otherwise, <c>false</c>.</returns>
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
