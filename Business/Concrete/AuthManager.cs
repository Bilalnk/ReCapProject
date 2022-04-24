#region info

// Bilal Karataş20220424

#endregion

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(Messages.UserRegistered, user);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            var isVerifiedPasswordHash = HashingHelper.VerifyPasswordHash(userForLoginDto.Password,
                userToCheck.PasswordHash, userToCheck.PasswordSalt);

            if (isVerifiedPasswordHash)
            {
                return new SuccessDataResult<User>(Messages.SuccessfulLogin, userToCheck);
            }

            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email).Success)
            {
                return new SuccessResult(Messages.UserAlreadyExist);
            }

            return new ErrorResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(Messages.AccessTokenCreated, accessToken);
        }
    }
}