using System.Collections.Generic;

namespace LJD.App.Model.ViewModels
{
    public class AdminMenuComparer:IEqualityComparer<AdminMenu>
    {
        public bool Equals(AdminMenu x, AdminMenu y)
        {
            if (x == null || y == null)
                return false;
            return x.MObjectID.Equals(y.MObjectID) &&
                   x.MName.Equals(y.MName) &&
                   x.MArea.Equals(y.MArea) &&
                   x.MController.Equals(y.MController) &&
                   x.MIcon.Equals(y.MIcon) &&
                   x.IsLast.Equals(y.IsLast) &&
                   x.MHierarchy.Equals(y.MHierarchy) &&
                   x.MParentID.Equals(y.MParentID) &&
                   x.MStatus.Equals(y.MStatus) &&
                   x.MSort.Equals(y.MSort);

        }

        public int GetHashCode(AdminMenu obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}