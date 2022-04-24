using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(user => user.Id == id);
            if (result == null) return new SuccessDataResult<User>(Messages.NoData);
            return new SuccessDataResult<User>(result);
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

        public IResult DeleteById(int id)
        {
            var result = _userDal.Get(user => user.Id == id);
            if (result == null) return new SuccessDataResult<User>(Messages.NoData);
            _userDal.Delete(result);
            return new SuccessDataResult<User>(Messages.Deleted + " : " + result.Id);
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result == null) return new SuccessDataResult<User>(Messages.NoData);
            if (!FieldsChecker.checker(user)) return new ErrorResult(Messages.NotInProperFormat);
            _userDal.Update(user);
            return new SuccessDataResult<User>(Messages.Updated);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.NoData);
            }

            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(user => user.Email == email);

            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.NotFound);
            }

            return new SuccessDataResult<User>(result);
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
                   //&& user.Password.Length >= 6
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