using System;
using System.Collections.Generic;
using System.Data;
using HqFilling.DbContext;
using HqFilling.Model;

namespace HqFilling.Repository
{
    public class UserRepository
    {
        private DbUser _dbUser;
        private UserModel _userModel;
        
        // Default constructor
        public UserRepository()
        {
            _dbUser = new DbUser();
            _userModel = new UserModel();
        }

        public int SaveUserInfo(UserModel userModel)
        {
            _dbUser = new DbUser();
            int result = 0;
            try
            {
                result = _dbUser.SaveUserInfo(userModel);
            }
            catch (Exception exception) { }
            return result;
        }

        public UserModel GetUserInfo(UserModel userModel)
        {
            try
            {
                _dbUser = new DbUser();
                DataTable dtUser = _dbUser.GetUserInfo(userModel);
                foreach (DataRow dr in dtUser.Rows)
                {
                    _userModel = new UserModel();
                    _userModel.UserId = Convert.ToInt32(dr["UserId"].ToString());
                    _userModel.FirstName = dr["FirstName"].ToString();
                    _userModel.LastName = dr["LastName"].ToString();
                    _userModel.Username = dr["Username"].ToString();
                    _userModel.Password = dr["Password"].ToString();
                    _userModel.PresentAddress = dr["PresentAddress"].ToString();
                    _userModel.ParmanentAddress = dr["ParmanentAddress"].ToString();
                    _userModel.Phone = dr["Phone"].ToString();
                    _userModel.Phone2 = dr["Phone2"].ToString();
                    _userModel.Email = dr["Email"].ToString();
                    _userModel.IsActive = String.IsNullOrEmpty(dr["IsActive"].ToString()) ? false : true;

                    userModel = _userModel;
                }
            }
            catch (Exception exception) { }

            return userModel;
        }

        public UserModel GetUserInfoWithFeatures(UserModel userModel)
        {
            try
            {
                _dbUser = new DbUser();
                DataSet dsUser = _dbUser.GetUserInfoWithFeatures(userModel);
                _userModel = GetUserModelWithFeatures(dsUser);
            }
            catch (Exception exception) { }

            return _userModel;
        }
        public UserModel GetUserModelWithFeatures(DataSet dsUser)
        {
            _userModel = new UserModel();
            if (dsUser.Tables.Count > 0)
            {
                for (int i = 0; i < dsUser.Tables.Count; i++)
                {
                    // first table user basic information
                    if (i == 0)
                    {
                        // user info table
                        DataTable dtUser = dsUser.Tables[i];
                        try
                        {
                            foreach (DataRow dr in dtUser.Rows)
                            {
                                if (String.IsNullOrEmpty(dr["ErrorDescription"].ToString()))
                                {
                                    _userModel.UserId = Convert.ToInt32(dr["UserId"].ToString());
                                    _userModel.FirstName = dr["FirstName"].ToString();
                                    _userModel.LastName = dr["LastName"].ToString();
                                    _userModel.Username = dr["Username"].ToString();
                                    _userModel.Password = dr["Password"].ToString();
                                    _userModel.PresentAddress = dr["PresentAddress"].ToString();
                                    _userModel.ParmanentAddress = dr["ParmanentAddress"].ToString();
                                    _userModel.Phone = dr["Phone"].ToString();
                                    _userModel.Phone2 = dr["Phone2"].ToString();
                                    _userModel.Email = dr["Email"].ToString();
                                    _userModel.IsActive = String.IsNullOrEmpty(dr["IsActive"].ToString()) ? false : true;
                                    _userModel.ErrorDescription = dr["ErrorDescription"].ToString();
                                }
                                else
                                {
                                    _userModel.ErrorDescription = dr["ErrorDescription"].ToString();
                                }
                            }
                        }
                        catch (Exception exception) { }
                    }
                    // second table user features detail
                    if (i == 1)
                    {
                        // user feature table
                        DataTable dtUserFeatures = dsUser.Tables[i];
                        try
                        {
                            List<string> _roles = new List<string>();

                            foreach (DataRow dr in dtUserFeatures.Rows)
                            {
                                _roles.Add(dr["FeatureName"].ToString());
                            }
                            _userModel.Roles = _roles.ToArray();
                        }
                        catch (Exception exception) { }
                    }
                }

            }

            return _userModel;
        }
        public List<UserModel> GetUserInfoList(UserModel userModel)
        {
            List<UserModel> userModelList = new List<UserModel>();
            try
            {
                _dbUser = new DbUser();
                DataTable dtUser = _dbUser.GetUserInfo(userModel);
                foreach (DataRow dr in dtUser.Rows)
                {
                    _userModel = new UserModel();
                    _userModel.UserId = Convert.ToInt32(dr["UserId"].ToString());
                    _userModel.FirstName = dr["FirstName"].ToString();
                    _userModel.LastName = dr["LastName"].ToString();
                    _userModel.Username = dr["Username"].ToString();
                    _userModel.Password = dr["Password"].ToString();
                    _userModel.PresentAddress = dr["PresentAddress"].ToString();
                    _userModel.ParmanentAddress = dr["ParmanentAddress"].ToString();
                    _userModel.Phone = dr["Phone"].ToString();
                    _userModel.Phone2 = dr["Phone2"].ToString();
                    _userModel.Email = dr["Email"].ToString();
                    _userModel.IsActive = String.IsNullOrEmpty(dr["IsActive"].ToString()) ? false : true;

                    userModelList.Add(_userModel);
                }
            }
            catch (Exception exception) { }

            return userModelList;
        }
    }
}
