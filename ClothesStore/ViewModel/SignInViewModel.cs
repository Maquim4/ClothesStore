using ClothesStore.Model;
using System;
using ClothesStore.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Security.Principal;

namespace ClothesStore.ViewModel
{
    public class SignInViewModel : ViewModelBase
    {
        private string _login;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible=true;

        private IUserRepository userRepository;

        public string Login
        {
            get { return _login; }
            set 
            { 
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get { return _password; }   
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));    
            }
        }

        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        
        

        public ICommand LoginCommand { get; }       
        public ICommand ShowPasswordCommand { get; }     
        public ICommand ViewRegisterCommand { get; }


        public SignInViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            ViewRegisterCommand = new ViewModelCommand(ExecuteRegisterCommand);

        }

        private void ExecuteRegisterCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Login) ||  Login.Length < 3 || Password.Length < 3 || Password == null)
                validData = false;
            else
                validData = true;
            return validData;
        }
        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Login, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Login), null);
                IsViewVisible = false;
            
            }
            else
            {
                ErrorMessage=" Invalid login or password";
            }
        }   

        

    

        

        
    }
}
