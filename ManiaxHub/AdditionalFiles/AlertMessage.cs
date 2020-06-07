using ManiaxHub.Models;
using System;
using System.Linq;

namespace ManiaxHub.AdditionalFiles
{
    public static class AlertMessage
    {
        #region AllMessages
        /// <summary>
        /// All messages to show notification
        /// </summary>
        /// 
        public static string AuthorizationMessage = "You are not authorized to perform this Operation. Please Contact your Administrator.";
        public static string WarehouseNotAssigned = "You have not assigned any Warehouse. Please Contact your Administrator";
        public static string BranchNotAssigned = "You have not assigned any Branch. Please Contact your Administrator";
        public static string ProductionUnitNotAssigned = "You have not assigned any Production Unit. Please Contact your Administrator";
        public static string SuccessMessage = "Transaction has been completed Successfully";
        public static string PrimaryKeyError = "This Record is already added in Database.";
        public static string NotFound = "Record Not Found.";
        public static string RecordAdded = "Your Record Added Successfully !";
        public static string RecordNotAdded = "Record not Added Successfully!";
        public static string ApprovedTransaction = "Transaction has been Successfully Approved";
        public static string OrderApproved = "Order has been Successfully Approved";
        public static string RejectOrder = "Order has been Rejected Successfully";
        public static string PODelete = "Purchase Order Can,t be deleted because purchase Order have been received";
        public static string NowarehouseAssign = "User have no Warehouse assign! please first assign Warehouse to that user";
        public static string ReferenceUsed = "Transaction has been completed Successfully Because its Reference is used in other Items";
        public static string DepartmentNotAssigned = "User have no Department assign! please first assign Department to that user";
        public static string AssignNosupplier = "User have no Supplier assign! please first assign Supplier to that user";
        public static string AssignNobranch = "User have no Branch assign! please first assign Branch to that user";
        public static string AssignNodepartment = "User have no Department assign! please first assign Department to that user";
        public static string permissionnotinrole = "Permission Can not be deleted because its reference used in Role Permissions";
        public static string IntegrationFail = "Fail Integration";
        public static string IntegrationDuplication = "Integration already executed !";
        public static string IntegrationOverFlow = "Integration Could not be executed beacause Integration date is equal or Greater than today !";
        public static string AttendanceFail = "You cannot mark Attendance of an empolyee two times in a day !";
        public static string AuditDuplication = "Audit already executed !";
        public static string ErrorMessage = "Transaction can not completed Successfully. Because its reference used in Permissions.";
        #endregion
        
        //public static DateTime GetBranchClosingDate(long userID)
        //{
        //    ManiaXEntities db = new ERPEntManiaXEntitiesities();
        //    var Branches = db.vwUserBranches.Where(a => a.UserID == userID);
        //    DateTime BranchTransitionDate = DateTime.Now;
        //    //if (Branches.Count() == 1)
        //    //{
        //    //    long BranchID = 0; ;
        //    //    foreach (var item in Branches)
        //    //    {
        //    //        BranchID = item.BranchID;
        //    //    }
        //    //    BranchTransitionDate = db.Database.SqlQuery<DateTime>("select dbo.fxBranchTransactionDate(" + BranchID + ")").First();
        //    //}
        //    //else
        //    //{
        //        long BranchID = 0;
        //        foreach (var item in Branches)
        //        {
        //            BranchID = item.BranchID;
        //            break;
        //        }
        //        BranchTransitionDate = db.Database.SqlQuery<DateTime>("select dbo.fxBranchTransactionDate(" + BranchID + ")").First();
        //    //}
        //    return BranchTransitionDate;
        //}
        
    }
}