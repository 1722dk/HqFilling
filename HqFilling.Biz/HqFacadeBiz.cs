using System.Collections.Generic;
using HqFilling.Model;
using HqFilling.Security;
using HqFilling.Security.Models;

namespace HqFilling.Biz
{
    public class HqFacadeBiz : IMembershipService
    {
        
        #region Private property
        private UserBiz _userBiz;
        private UserModel _userModel;
        #endregion

        #region Default constructor

        // Default constructor..
        public HqFacadeBiz()
        {
            _userBiz = new UserBiz();
            _userModel = new UserModel();
        }
        #endregion

        #region

        // Public property

        #endregion

        #region UserBiz
        
        // add/edit user information
        public int SaveUserInfo(UserModel userModel)
        {
            return _userBiz.SaveUserInfo(userModel);
        }

        // Get user detail information
        public UserModel GetUserInfo(UserModel userModel)
        {
            return _userBiz.GetUserInfo(userModel);
        }

        // Get user detail information (including features)
        public UserModel GetUserInfoWithFeatures(UserModel userModel)
        {
            return _userBiz.GetUserInfoWithFeatures(userModel);
        }
        //Get User List 
        public List<UserModel> GetUserInfoList(UserModel userModel)
        {
            return _userBiz.GetUserInfoList(userModel); ;
        }
        
        #endregion

        
        #region IMembershipService methods

        public AuthStatus ValidateUser(string userName, string password)
        {
            _userModel = new UserModel();
            _userModel.Username = userName;
            _userModel.Password = password;
            _userModel.DbAction = "Login";

            _userModel = GetUserInfoWithFeatures(_userModel);

            AuthStatus authStatus = new AuthStatus();
            if (_userModel.ErrorDescription.Equals(string.Empty))
            {
                authStatus.Code = AuthStatusCode.SUCCESS;
                authStatus.Message = "Login successful!";
                authStatus.Data = _userModel;
            }
            else
            {
                authStatus.Code = AuthStatusCode.FAILED;
                authStatus.Message = _userModel.ErrorDescription;
            }

            return authStatus;
        }

        public string[] GetRoles(string userName)
        {
            return _userModel.Roles;
        }

        //public static bool IsUserInRole(string roleName)
        //{
        //    return HttpContext.Current.User.IsInRole(roleName);
        //}

        #endregion       
    }
}
