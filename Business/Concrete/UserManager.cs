using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count == 0) return new SuccessDataResult<List<User>>(Messages.NoData);
            return new SuccessDataResult<List<User>>(result);
        }

        public IResult Add(User user)
        {
            if (FieldsChecker.checker(user))
            {
                _userDal.Add(user);
            }
            else
            {
                return new ErrorResult(Messages.NotInProperFormat);
            }

            return new SuccessResult(Messages.Added);
        }

        private User IsUserExist(int id)
        {
            var result = _userDal.Get(car => car.Id == id);
            return result;
        }
    }

    class FieldsChecker
    {
        public static bool checker(User user)
        {
            return !user.Email.Equals("")
                   && !user.FirstName.Equals("")
                   && !user.LastName.Equals(null)
                   && !user.LastName.Equals("")
                   && user.Password.Length >= 6
                   && emailVerify(user.Email);
        }

        private static bool emailVerify(String email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}