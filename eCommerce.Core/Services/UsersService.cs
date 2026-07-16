
using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;
internal class UsersService : IUsersService
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _userRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if(user == null)
        {
            return null;
        }

        //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token dummy", Success:true);
        return _mapper.Map<AuthenticationResponse>(user) with 
        { Success = true, Token = "Token dum dum" };   
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {

        //ApplicationUser user = new ApplicationUser()
        //{
        //    PersonName = registerRequest.PersonName,
        //    Email = registerRequest.Email,
        //    Passwords = registerRequest.Password,
        //    Gender = registerRequest.Gender.ToString()
        //};

        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
        
        ApplicationUser? registeredUser = await _userRepository.AddUser(user);

        if(registeredUser==null)
        {
            return null;
        }

        //return new AuthenticationResponse(registeredUser.UserID, 
        // registeredUser.Email, registeredUser.PersonName,
        //registeredUser.Gender, "token dummy", Success: true);

        return _mapper.Map<AuthenticationResponse>(registeredUser) with
        { Success = true, Token = "Token dum dum" };

    }
}


