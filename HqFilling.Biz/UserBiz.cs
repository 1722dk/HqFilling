using System.Collections.Generic;
using HqFilling.Model;
using HqFilling.Repository;

namespace HqFilling.Biz
{
    public class UserBiz
    {
        private UserRepository _userRepository;
        private UserModel _userModel;
        
        // Default constructor
        public UserBiz()
        {
            _userRepository = new UserRepository();
            _userModel = new UserModel();
        }

        // Save user info 
        public int SaveUserInfo(UserModel userModel)
        {
            _userRepository = new UserRepository();
            int newUser = _userRepository.SaveUserInfo(userModel);

            return newUser;
        }

        // Get user detail information
        public UserModel GetUserInfo(UserModel userModel)
        {
            _userRepository = new UserRepository();
            return _userRepository.GetUserInfo(userModel);
        }

        // Get user info with features
        public UserModel GetUserInfoWithFeatures(UserModel userModel)
        {
            _userRepository = new UserRepository();
            return _userRepository.GetUserInfoWithFeatures(userModel);
        }
        // Get user detail list
        public List<UserModel> GetUserInfoList(UserModel userModel)
        {
            _userRepository = new UserRepository();
            return _userRepository.GetUserInfoList(userModel);
        }
    }
}
